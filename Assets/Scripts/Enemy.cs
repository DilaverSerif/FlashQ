using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Enemy : MonoBehaviour
{
    private GameObject hedef;
    private Vector2 fark;
    private float saldiriMenzili, hiz, atesAraligi,oyuncuFark;
    private int mermiHizi, can, mermiGucu;
    private bool docla, atesWait, kamizakeAtes;
    public CreateEnemy kaynak;
    private Sprite[] patlamaSprite;
    private Rigidbody2D body;
    private CircleCollider2D box;
    private SpriteRenderer spriteRenderer;
    private CreateEnemy.Zeka zekaTuru;
    private CreateMermi.MermiTuru mermiTuru;
    private Durum durum = Durum.ilerliyor;

    public enum Durum
    {
        patladi,
        atesEdiyor,
        ilerliyor,
        kaciyor
    }

private void OnEnable() {
        spriteRenderer.sprite = kaynak.dusmanSprite;
        hiz = kaynak.hiz;
        can = kaynak.can;
        mermiHizi = kaynak.mermiHizi;
        mermiGucu = kaynak.mermiGucu;
        mermiTuru = kaynak.mermiTuru;
        docla = kaynak.docla;
        zekaTuru = kaynak.zeka;
        atesAraligi = kaynak.atesAraligi;
        kamizakeAtes = kaynak.kamizakeAtes;
        atesWait = kaynak.atesETME;

        switch (zekaTuru)
        {
            case CreateEnemy.Zeka.YakinSaldiran:
                saldiriMenzili = 2f;
                break;
            case CreateEnemy.Zeka.UzakSaldiran:
                saldiriMenzili = 5f;
                break;
            case CreateEnemy.Zeka.Kamizake:
                saldiriMenzili = 0.5f;
                break;
        }

        if (hiz > mermiHizi)
        {
            Debug.LogError("HATA MERMI HIZI HAREKET HIZINDAN DÜŞÜK");
            Debug.Break();
        }


        if (kamizakeAtes & zekaTuru != CreateEnemy.Zeka.Kamizake)
        {
            Debug.Log("HATA KAMIZAKE ATES VE ZEKA UYUMSUZ");
            Debug.Break();
        }

                
                
        StartCoroutine(OyuncuyaBak());
        StartCoroutine(OyuncuyaGo());
}

    private void Awake()
    {
        hedef = GameObject.FindGameObjectWithTag("Player");

        body = GetComponent<Rigidbody2D>();
        box = GetComponent<CircleCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        patlamaSprite = Resources.LoadAll<Sprite>("Sprites/patlama");
    }


    private IEnumerator OyuncuyaBak()
    {
        while (durum != Durum.patladi)
        {
            oyuncuFark = Vector2.Distance(new Vector2(transform.position.x, transform.position.y), hedef.transform.position);
            fark = new Vector2(hedef.transform.position.x, hedef.transform.position.y) - new Vector2(transform.position.x, transform.position.y);

            float Angle = Mathf.Atan2(fark.y, fark.x);
            float AngleInDegrees = Angle * Mathf.Rad2Deg;

            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, AngleInDegrees - 90), hiz * Time.deltaTime);

            yield return new WaitForEndOfFrame();
        }


    }



    private IEnumerator Boom()
    {
        if (durum == Durum.patladi) yield break;

        durum = Durum.patladi;
        body.velocity = Vector2.zero;
        box.radius = 0;

        for (int i = 0; i < 4; i++)
        {
            yield return new WaitForSeconds(0.075f);
            box.radius += 0.09f;
            spriteRenderer.sprite = patlamaSprite[i];
        }
        yield return new WaitForSeconds(0.075f);
        spriteRenderer.sprite = null;
        box.enabled = false;
        ObjectPool.NesneDepola(gameObject);
    }
    

    private void YapayZeka()
    {
        if (durum == Durum.patladi) return;

        if (oyuncuFark > saldiriMenzili)
        {
            durum = Durum.ilerliyor;
            StartCoroutine("OyuncuyaGo");
        }
        else if (oyuncuFark < 1.5f)
        {
            durum = Durum.kaciyor;
            StartCoroutine("Kac");
        }
        else if (oyuncuFark > 1.5f & oyuncuFark < saldiriMenzili)
        {
            durum = Durum.atesEdiyor;
            StartCoroutine("Saldir");
        }

    }

    private bool doc;
    private int yon = 10;

    private IEnumerator Docle()
    {
        doc = true;
        StartCoroutine(DocSayac(1,10));
        while (durum == Durum.atesEdiyor & doc)
        {
            transform.RotateAround(hedef.transform.position, new Vector3(0,0,1), Time.deltaTime * (hiz * yon));
            yield return new WaitForEndOfFrame();
        }
        doc = false;

    }

    private IEnumerator DocSayac(float minCD, float maxCD)
    {
        while (doc)
        {
            if(Random.Range(-5,6) > 0) yon = 10;
            else yon = -10;
            yield return new WaitForSeconds(Random.Range(minCD, maxCD));
        }

    }


    private IEnumerator Saldir()
    {
        while (oyuncuFark < saldiriMenzili & oyuncuFark > 1.5f)
        {
            body.velocity = Vector2.zero;
            if (!atesWait) StartCoroutine("AtesEt");
            if (!doc & docla) StartCoroutine("Docle");
            yield return new WaitForEndOfFrame();
        }

        YapayZeka();
    }

        private IEnumerator AtesEt()
    {
        if (atesWait | durum == Durum.patladi) yield break;
        atesWait = true;
        yield return new WaitForSeconds(atesAraligi);
        atesWait = false;
        ObjectPool.MermiKullan(mermiTuru,gameObject,1);
    }

    private IEnumerator OyuncuyaGo()
    {
        while (oyuncuFark > saldiriMenzili &
         durum == Durum.ilerliyor)
        {
            body.velocity = transform.up * hiz;
            yield return new WaitForEndOfFrame();
        }
        YapayZeka();
    }

    private IEnumerator Kac()
    {
        while (durum == Durum.kaciyor &
        oyuncuFark < 1.5f)
        {
            body.velocity = transform.up * -hiz;
            yield return new WaitForEndOfFrame();
        }

        YapayZeka();
    }


    private void OyuncuGerile()
    {
        body.velocity = transform.up * -hiz;
    }


    public void CanSistemi(int gelenHasar)
    {
        can -= gelenHasar;

        if (can <= 0)
        {
            StartCoroutine("Boom");
        }
    }

}
