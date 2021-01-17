using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool1 : MonoBehaviour
{
    private Stack<GameObject> objeHavuzu = new Stack<GameObject>();
    public GameObject obje;
    public ObjectPool1(GameObject prefab)
    {
        this.obje = prefab;
    }

    public void ObjeDepola(GameObject gelenObje)
    {
        gelenObje.SetActive(false);
        objeHavuzu.Push(gelenObje);
    }

    public GameObject ObjeKullan()
    {
        if (objeHavuzu.Count > 0)
        {

           return objeHavuzu.Pop();

        }
        else
        {
            ObjeDepola(Object.Instantiate(obje));
            return (objeHavuzu.Pop());
        }

    }

    public void Depola(int miktar)
    {
        for (int i = 0; i < miktar; i++)
        {
            var yeniObje = Object.Instantiate(obje);
            ObjeDepola(yeniObje);
        }
    }

}
