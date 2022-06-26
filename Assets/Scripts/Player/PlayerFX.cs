using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFX : MonoBehaviour
{
    [SerializeField] private GameObject canvasTextAnimationPrefab;
    [SerializeField] private Transform canvasTextPosition;

    private ObjectPooler pooler;

    private void Awake()
    {
        pooler = GetComponent<ObjectPooler>();
    }

    private void Start()
    {
        pooler.CreatePooler(canvasTextAnimationPrefab);
    }


    private IEnumerator IEShowText(float cant)
    {
        GameObject newTextGO = pooler.GetInstance();
        TextAnimation text = newTextGO.GetComponent<TextAnimation>();
        text.SetText(cant);
        newTextGO.transform.SetParent(canvasTextPosition);
        newTextGO.transform.position = canvasTextPosition.position;
        newTextGO.SetActive(true);


        yield return new WaitForSeconds(1f);
        newTextGO.SetActive(false);
        newTextGO.transform.SetParent(pooler.ListContenedor.transform);
    }


    private void ResponceDamageReceived(float damage)
    {
        StartCoroutine(IEShowText(damage));
    }

    private void OnEnable()
    {
        IAController.EventDamageDone += ResponceDamageReceived;
    }

    private void OnDisable()
    {
        IAController.EventDamageDone -= ResponceDamageReceived;
    }
}
