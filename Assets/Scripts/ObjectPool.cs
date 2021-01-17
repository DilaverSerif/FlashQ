using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    private static ObjectPool1 mermiHavuzu;
    private static ObjectPool1 dusmanHavuzu;
    private static CreateMermi[] mermiCesitleri;
    private GameObject mermi, dusman;

    private void Awake()
    {
        mermi = Resources.Load<GameObject>("Mermi");
        dusman = Resources.Load<GameObject>("Enemy");
        mermiHavuzu = new ObjectPool1(mermi);

        mermiCesitleri = Resources.LoadAll<CreateMermi>("Objects/Mermiler");

        dusmanHavuzu = new ObjectPool1(dusman);
    }

    private void Start()
    {
        //mermiHavuzu.obje = mermi;
        mermiHavuzu.Depola(100);
        dusmanHavuzu.Depola(100);


    }


    public static void DusmanSpawn(CreateEnemy pDusman, Vector2 pozisyon)
    {
        var dusman = dusmanHavuzu.ObjeKullan();

        dusman.GetComponent<Enemy>().kaynak = pDusman;
        dusman.transform.position = pozisyon;
        dusman.SetActive(true);

    }


    public static void MermiKullan(CreateMermi.MermiTuru pMermi, GameObject parent,float ekstraGuc)
    {
        CreateMermi sanalMermi;
        var mermi = mermiHavuzu.ObjeKullan();

        switch (pMermi)
        {
            case CreateMermi.MermiTuru.akilli:
                sanalMermi = mermiCesitleri[0];
                break;
            case CreateMermi.MermiTuru.icindenGecen:
                sanalMermi = mermiCesitleri[0];
                break;
            case CreateMermi.MermiTuru.normal:
                sanalMermi = mermiCesitleri[0];
                break;
            case CreateMermi.MermiTuru.kuvvetli:
                sanalMermi = mermiCesitleri[0];
                break;
            default:
                sanalMermi = mermiCesitleri[0];
                break;
        }

        mermi.GetComponent<Mermi>().ekstraGuc = ekstraGuc;
        mermi.GetComponent<Mermi>().parent = parent;
        mermi.GetComponent<Mermi>().mermiKaynak = sanalMermi;
        mermi.GetComponent<Mermi>().MermiAta();
        mermi.SetActive(true);
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
