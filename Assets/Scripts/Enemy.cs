using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Enemy : MonoBehaviour
{
    private Vector2 hedef, fark;
    private float saldiriMenzili, hiz, atesAraligi;
    public int can, mermiHizi, mermiGucu;
    private bool docla;
    public CreateEnemy kaynak;
    private Sprite[] patlamaSprite;
    private Rigidbody2D body;
    private CircleCollider2D box;
    private SpriteRenderer spriteRenderer;
    private Mermi.MermiTuru mermiTuru;
    private CreateEnemy.Zeka zekaTuru;
    private Durum durum = Durum.ilerliyor;

    public enum Durum
    {
        patladi,
        atesEdiyor,
        ilerliyor,
        docliyor
    }

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        box = GetComponent<CircleCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        patlamaSprite = Resources.LoadAll<Sprite>("Sprites/patlama");
        spriteRenderer.sprite = kaynak.dusmanSprite;
        hiz = kaynak.hiz;
        can = kaynak.can;
        mermiHizi = kaynak.mermiHizi;
        mermiGucu = kaynak.mermiGucu;
        mermiTuru = kaynak.mermiTuru;
        docla = kaynak.docla;



        atesAraligi = kaynak.atesAraligi;


        if (hiz > mermiHizi)
        {
            Debug.LogError("HATA MERMI HIZI HAREKET HIZINDAN DÜŞÜK");
            Debug.Break();
        }


        switch (zekaTuru)
        {
            case CreateEnemy.Zeka.YakinSaldiran:
                saldiriMenzili = 5f;
            break;
            case CreateEnemy.Zeka.UzakSaldiran:
                saldiriMenzili = 8f;
            break;
            case CreateEnemy.Zeka.Kamizake:
                saldiriMenzili = 0.5f;
            break;
        }


    }

    private void OyuncuyaBak()
    {
        hedef = Objects.Player.transform.position;
        fark = hedef - new Vector2(transform.position.x, transform.position.y);

        float Angle = Mathf.Atan2(fark.y, fark.x);
        float AngleInDegrees = Angle * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, AngleInDegrees - 90);
    }

    private IEnumerator AtesEt()
    {
        while (gameObject.activeSelf)
        {
            yield return new WaitForSeconds(atesAraligi);
            ObjectPool.MermiKullan(3.5f, mermiGucu, mermiTuru, transform.position, transform.rotation.eulerAngles.z, gameObject.layer);
        }

    }

    private void ZekaPiriltisi()
    {
        float oyuncuFark = Vector2.Distance(new Vector2(transform.position.x, transform.position.y), hedef);

            OyuncuyaBak();
            body.velocity = transform.up * hiz;

            if (oyuncuFark < 1.5f)
            {
                durum = Durum.patladi;
            }

    }

    IEnumerator Boom()
    {
        body.velocity = Vector2.zero;
        box.radius = 0;

        for (int i = 0; i < 4; i++)
        {
            yield return new WaitForSeconds(0.15f);
            box.radius += 0.09f;
            spriteRenderer.sprite = patlamaSprite[i];
        }
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.sprite = null;
        box.enabled = false;
    }

    private void TakipZeka()
    {
        float oyuncuFark = Vector2.Distance(new Vector2(transform.position.x, transform.position.y), hedef);

        OyuncuyaBak();

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
