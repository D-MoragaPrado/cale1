using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    [SerializeField] private int cantForCreate;

    private List<GameObject> list;
    public GameObject ListContenedor { get;private set; }

    public void CreatePooler(GameObject objectForCreate)
    {
        list = new List<GameObject>();
        ListContenedor = new GameObject($"Pool - {objectForCreate.name}");

        for (int i = 0; i < cantForCreate; i++)
        {
            list.Add(AddInstance(objectForCreate));
        }
    }


    private GameObject AddInstance(GameObject objectForCreate)
    {
        GameObject newObject = Instantiate(objectForCreate, ListContenedor.transform);
        newObject.SetActive(false);
        return newObject;
    }

    public GameObject GetInstance()
    {
        for (int i = 0; i < list.Count; i++)
        {
            if (list[i].activeSelf == false)
            {
                return list[i];
            }
        }
        return null;
    }

    public void DestroyPooler()
    {
        Destroy(ListContenedor);
        list.Clear();
    }
}
