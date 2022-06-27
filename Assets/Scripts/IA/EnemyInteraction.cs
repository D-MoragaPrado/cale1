using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TypeDetection
{
    Range,
    Melee
}

public class EnemyInteraction : MonoBehaviour
{
    [SerializeField] private GameObject selectionRangeFX;
    [SerializeField] private GameObject selectionMeleeFX;


    public void ShowEnemySelected(bool state, TypeDetection type)
    {
        if (type == TypeDetection.Range)
        {
            selectionRangeFX.SetActive(state);
        }
        else
        {
            selectionMeleeFX.SetActive(state);
        }
        
    }

    public void DisableSpriteSelect()
    {
        selectionMeleeFX.SetActive(false);
        selectionRangeFX.SetActive(false);
    }


}
