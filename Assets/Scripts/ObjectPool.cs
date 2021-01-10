using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    private static ObjectPool1 mermiHavuzu;
    private static Sprite[] mermiSprites;
    private GameObject mermi;

    private void Awake()
    {
        mermi = Resources.Load<GameObject>("Mermi/Mermi");
        mermiHavuzu = new ObjectPool1(mermi);
        
        mermiSprites = Resources.LoadAll<Sprite>("Mermi/Sprites/Mermiler");
    }

    private void Start() {
        mermiHavuzu.obje = mermi;
        mermiHavuzu.Depola(100);

    }

    
    public static void MermiKullan(float phiz, int phasarGucu,Mermi.MermiTuru tur,Vector2 baslamaVectoru, float zEkseni, LayerMask katman)
    {
        Sprite bos = null;
        var mermi = mermiHavuzu.ObjeKullan();

        switch (tur)
        {
            case Mermi.MermiTuru.normal:
            bos = mermiSprites[0];
            break;
            
        }

        mermi.GetComponent<Mermi>().MermiAta(phiz,phasarGucu,bos,baslamaVectoru,zEkseni,katman);
    }

    public static void MermiDepola(GameObject gelenObje)
    {
        mermiHavuzu.ObjeDepola(gelenObje);
    }

}
