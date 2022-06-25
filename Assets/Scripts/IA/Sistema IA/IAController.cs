using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AttackTypes
{
    Melee,
    Embestida
}

public class IAController : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] private PlayerStats stats;

    [Header("Estados")]
    [SerializeField] private IAEstado estadoInicial;
    [SerializeField] private IAEstado estadoDefault;

    [Header("Config")]
    [SerializeField] private float rangeDetection;
    [SerializeField] private float rangeAttack;
    [SerializeField] private float rangeRamming;
    [SerializeField] private float speedMovement;
    [SerializeField] private float speedRamming;
    [SerializeField] private LayerMask playerLayerMask;

    [Header("Atack")]
    [SerializeField] private float damage;
    [SerializeField] private AttackTypes typeAttack;
    [SerializeField] private float timeBetweenAttack;

    [Header("Debug")]
    [SerializeField] private bool showDetection;
    [SerializeField] private bool showRangeAttack;

    private float timeForNextAttack;
    private BoxCollider2D _boxCollider2D;


    public Transform  PlayerReference { get; set; }
    public IAEstado EstadoActual { get; set; }
    public EnemyMovement EnemyMovement { get; set; }
    public float RangeDetection => rangeDetection;
    public float RangeAttack => rangeAttack;
    public float Damage => damage;
    public AttackTypes TypeAttack => typeAttack;
    public float SpeedMovement => speedMovement;
    public LayerMask PlayerLayerMask => playerLayerMask;
    //public float RangeAttackDetermined

    private void Start()
    {
        _boxCollider2D = GetComponent<BoxCollider2D>();
        EstadoActual = estadoInicial;
        EnemyMovement = GetComponent<EnemyMovement>();
    }

    private void Update()
    {
        EstadoActual.ExecuteEstado(this);
    }


    public void ChangeEstado(IAEstado newEstado)
    {
        if(newEstado != estadoDefault)
        {
            EstadoActual = newEstado;
        }
    }

    public void AttackMelee(float cant)
    {
        if(PlayerReference!= null)
        {
            ApplyDamagetoPlayer(cant);
        }
    }

    public void AttackRamming(float cant)
    {
        StartCoroutine(IERamming(cant));
    }

    private IEnumerator IERamming(float cant)
    {
        Vector3 playerPosition = PlayerReference.position;
        Vector3 positionInitial = transform.position;
        Vector3 directionToPlayer = (playerPosition - positionInitial).normalized;
        Vector3 positionAttack = playerPosition - directionToPlayer * 0.5f;
        _boxCollider2D.enabled = false;


        float transitionAttack = 0f;
        while (transitionAttack <= 1f)
        {
            transitionAttack += Time.deltaTime * speedMovement;
            float interpolacion = (-Mathf.Pow(transitionAttack, 2) + transitionAttack) * 4f;
            transform.position = Vector3.Lerp(positionInitial, positionAttack, interpolacion);
            yield return null;
        }

        if(PlayerReference != null)
        {
            ApplyDamagetoPlayer(cant);
        }
        _boxCollider2D.enabled = true;
    }




    public void ApplyDamagetoPlayer(float cant)
    {
        float damageToDo = 0;
        if (Random.value < stats.percentageBlocking / 100)
        {
            return;
        }
        damageToDo = Mathf.Max(cant - stats.defense, 1f);
        PlayerReference.GetComponent<PlayerLife>().TakeDamage(damageToDo);
    }



    public bool PlayerInRangeAttack(float range)
    {
        float distanceToPlayer = (PlayerReference.position - transform.position).sqrMagnitude;
        if (distanceToPlayer < Mathf.Pow(range,2))
        {
            return true;
        }
        return false;
    }


    public bool IsTimeAttack()
    {
        if (Time.time>timeForNextAttack)
        {
            return true;
        }
        return false;
    }

    public void UpdateTimeBetweenAtack()
    {
        timeForNextAttack = Time.time + timeBetweenAttack;
    }


    private void OnDrawGizmos()
    {
        if (showDetection)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position, rangeDetection);
        }

        if (showRangeAttack)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, rangeAttack);
        }
    }
}
