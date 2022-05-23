using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDiaryAdd : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private DiaryPersonaje diaryItemReference;
    [SerializeField] private bool interactuado;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !interactuado)
        {
            Debug.Log("deberia agregarme :D");
            Diary.Instance.AddItem(diaryItemReference);
            interactuado = true;
        }
    }

}
