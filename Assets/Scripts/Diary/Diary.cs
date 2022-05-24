using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diary : Singleton<Diary>
{
    [SerializeField] private int cantSlot;
    public int CantSlot => cantSlot;

    [Header("Items")]
    [SerializeField] private DiaryPersonaje[] itemsDiary;

    public DiaryPersonaje[] ItemsDiary => itemsDiary;


    private void Start()
    {
        itemsDiary = new DiaryPersonaje[cantSlot];
    }

    public void AddItem(DiaryPersonaje itemForAdd)
    {
        if (itemForAdd == null) { return; }

        //verificar si ya existe uno
        /*List<int> indexes = VerifyExistence(itemForAdd.Id); //ta fallando aqui */
        AddItemInSlot(itemForAdd);
        
    }

    private List<int> VerifyExistence(string itemId)
    {
        List<int> indexsItems = new List<int>();
        for (int i = 0; i < itemsDiary.Length; i++)
        {
            Debug.Log(itemsDiary[i].Id);
            if (itemsDiary[i].Id != null)
            {
                if (itemsDiary[i].Id == itemId)
                {
                    indexsItems.Add(i);
                }
            }

        }
        return indexsItems;
    }

    private void AddItemInSlot(DiaryPersonaje item)
    {
        for (int i = 0; i < itemsDiary.Length; i++)
        {
            if (itemsDiary[i] == null)
            {
                itemsDiary[i] = item;
                
                DiaryUI.Instance.DrawItemDiary(item, i);
                return;
            }
        }
    }
}
