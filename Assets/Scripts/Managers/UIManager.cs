using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [SerializeField] private Image PlayerLife;           //la barrita de color
    [SerializeField] private TMPro.TextMeshProUGUI lifeTMP;    // el texto 100/100


    private float actualHealth;
    private float maxHealth;


    private void Awake()
    {
        Instance = this;
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateUIPlayer();
    }

    private void UpdateUIPlayer()
    {
        PlayerLife.fillAmount = Mathf.Lerp(PlayerLife.fillAmount, actualHealth / maxHealth, 10f * Time.deltaTime); //barra modificada

        lifeTMP.text = $"{actualHealth}/{maxHealth}"; //texto actualizado
    }


    public void UpdateLifePlayer(float pActualHealth , float pMaxHealth)
    {
        actualHealth = pActualHealth;
        maxHealth = pMaxHealth;
    }
}
