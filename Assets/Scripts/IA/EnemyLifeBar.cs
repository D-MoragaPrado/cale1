using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyLifeBar : MonoBehaviour
{
    [SerializeField] private Image barLife;
    private float healthActual;
    private float healthMax;

    public void ModifyHealth(float pHealthActual, float pHealthMax)
    {
        healthActual = pHealthActual;
        healthMax = pHealthMax;
    }

    // Update is called once per frame
    void Update()
    {
        barLife.fillAmount = Mathf.Lerp(barLife.fillAmount, healthActual / healthMax, 10f * Time.deltaTime);
    }
}
