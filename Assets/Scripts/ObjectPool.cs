using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{

    private static GameObject mermi;
    private static Sprite[] mermiSprites;

    private static List<GameObject> mermiDeposu = new List<GameObject>();
    private static List<GameObject> dusmaniDeposu = new List<GameObject>();
    // Start is called before the first frame update


    public enum MermiTuru
    {
        normal,
        kuvvetli
    }

    private void Awake()
    {
        mermi = Resources.Load<GameObject>("Mermi/Mermi");
        Debug.Log(mermi.name);
        mermiSprites = Resources.LoadAll<Sprite>("Mermi/Sprites/Mermiler");
    }

    public static void MermiDepola(GameObject gelenMermi)
    {
        mermiDeposu.Add(gelenMermi);
        gelenMermi.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        gelenMermi.SetActive(false);
    }

    public static GameObject MermiKullan(MermiTuru turu, int hasarGucu, int hiz, Vector3 baslaVector, float dongu)
    {
        Sprite sanalSprite = null;
        GameObject sanalMermi;

        if (mermiDeposu.Count == 0)
        {
            sanalMermi = Instantiate(mermi);
        }
        else
        {
            sanalMermi = mermiDeposu[0];
            mermiDeposu.RemoveAt(0);
        }

        switch (turu)
        {
            case MermiTuru.normal:
                sanalSprite = mermiSprites[0];
                break;

        }

        sanalMermi.GetComponent<Mermi>().OzellikAta(hiz, hasarGucu, sanalSprite,baslaVector,dongu);
        if(sanalMermi.activeSelf == false) sanalMermi.SetActive(true);
        return sanalMermi;
    }
}
