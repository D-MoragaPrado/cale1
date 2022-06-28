using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptX : MonoBehaviour
{
    [SerializeField] private string nameMision;
    private bool interactuado;


    private void Start()
    {
        interactuado = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") )
        {
            QuestManager.Instance.AddProgress(nameMision, 1);
        }
    }
}
