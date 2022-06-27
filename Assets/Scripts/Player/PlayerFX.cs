using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TipoPersonaje
{
    Player,
    IA
}



public class PlayerFX : MonoBehaviour
{
    [Header("Pooler")]
    [SerializeField] private ObjectPooler pooler;

    [Header("Config")]
    [SerializeField] private GameObject canvasTextAnimationPrefab;
    [SerializeField] private Transform canvasTextPosition;

    [Header("Tipo")]
    [SerializeField] private TipoPersonaje tipoPersonaje;

    private void Start()
    {
        pooler.CreatePooler(canvasTextAnimationPrefab);
    }


    private IEnumerator IEShowText(float cant, Color color )
    {
        GameObject newTextGO = pooler.GetInstance();
        TextAnimation text = newTextGO.GetComponent<TextAnimation>();
        text.SetText(cant,color);
        newTextGO.transform.SetParent(canvasTextPosition);
        newTextGO.transform.position = canvasTextPosition.position;
        newTextGO.SetActive(true);


        yield return new WaitForSeconds(1f);
        newTextGO.SetActive(false);
        newTextGO.transform.SetParent(pooler.ListContenedor.transform);
    }


    private void ResponceDamageReceivedToPlayer(float damage)
    {
        if (tipoPersonaje == TipoPersonaje.Player)
        {
            StartCoroutine(IEShowText(damage,Color.black));
        }
        
    }

    private void ResponceDamageToEnemy(float damage)
    {
        if(tipoPersonaje == TipoPersonaje.IA)
        {
            StartCoroutine(IEShowText(damage,Color.red));
        }
    }


    private void OnEnable()
    {
        IAController.EventDamageDone += ResponceDamageReceivedToPlayer;
        PlayerAttack.EventDamagedEnemy += ResponceDamageToEnemy;
    }

    private void OnDisable()
    {
        IAController.EventDamageDone -= ResponceDamageReceivedToPlayer;
        PlayerAttack.EventDamagedEnemy -= ResponceDamageToEnemy;
    }
}
