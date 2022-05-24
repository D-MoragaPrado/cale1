using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptX : MonoBehaviour
{
    [SerializeField] private PlayerExperience playerex;
    private bool interactuado;


    private void Start()
    {
        interactuado = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !interactuado)
        {
            playerex.AddExperience(4);
            interactuado = true;
        }
    }
}
