using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    private static ObjectPool1 mermiHavuzu;
    private static ObjectPool1 dusmanHavuzu;
    private static Sprite[] mermiSprites;
    private GameObject mermi,dusman;

    private void Awake()
    {
        mermi = Resources.Load<GameObject>("Mermi/Mermi");
        dusman = Resources.Load<GameObject>("Enemy");
        mermiHavuzu = new ObjectPool1(mermi);
        
        mermiSprites = Resources.LoadAll<Sprite>("Mermi/Sprites/Mermiler");

        dusmanHavuzu = new ObjectPool1(dusman);
    }

    private void Start() {
        //mermiHavuzu.obje = mermi;
        mermiHavuzu.Depola(100);
        dusmanHavuzu.Depola(100);


    }


    public static void DusmanSpawn(CreateEnemy pDusman,Vector2 pozisyon)
    {
        var dusman = dusmanHavuzu.ObjeKullan();

        dusman.GetComponent<Enemy>().kaynak = pDusman;
        dusman.transform.position = pozisyon;
        dusman.SetActive(true);

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

    public static void NesneDepola(GameObject gelenObje)
    {
        if (gelenObje.tag == "Enemy")
        {
            dusmanHavuzu.ObjeDepola(gelenObje);
        }
        else mermiHavuzu.ObjeDepola(gelenObje);
        
    }

}
