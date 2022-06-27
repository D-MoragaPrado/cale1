using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextAnimation : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI damageText;

    public void SetText(float cant, Color color)
    {
        damageText.text = cant.ToString();
        damageText.color = color;
    }
}
