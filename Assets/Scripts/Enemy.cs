using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Enemy : MonoBehaviour
{
    private Vector2 hedef, fark;
    private float aradakiMesafa, hiz, sayac, atesAraligi;
    public int mesafeMiktari, can, mermiHizi, mermiGucu;
    private bool dur, ates, docla, surekliTakip;
    public CreateEnemy kaynak;
    private Rigidbody2D body;
    private CircleCollider2D box;
    private SpriteRenderer spriteRenderer;
    private Mermi.MermiTuru mermiTuru;
    private CreateEnemy.Mesafe mesafeTuru;
    private CreateEnemy.Zeka zekaTuru;



    private float RotateSpeed = 5f;
    private float Radius = 18f;

    private Vector2 _centre;
    private float _angle;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        box = GetComponent<CircleCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = kaynak.dusmanSprite;

        mesafeMiktari = kaynak.mesafeMiktari;
        hiz = kaynak.hiz;
        can = kaynak.can;
        mermiHizi = kaynak.mermiHizi;
        mermiGucu = kaynak.mermiGucu;

        mermiTuru = kaynak.mermiTuru;
        zekaTuru = kaynak.zeka;
        mesafeTuru = kaynak.mesafe;
        docla = kaynak.docla;
        surekliTakip = kaynak.surekliTakip;
        atesAraligi = kaynak.atesAraligi;


    }
    // Start is called before the first frame update
    private void Start()
    {
        StartCoroutine(OyuncuyaGit());
        StartCoroutine(AtesEt());
    }

    private void OyuncuyaBak()
    {
        hedef = Objects.Player.transform.position;
        fark = hedef - new Vector2(transform.position.x, transform.position.y);

        float Angle = Mathf.Atan2(fark.y, fark.x);
        float AngleInDegrees = Angle * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, AngleInDegrees - 90);
    }


    IEnumerator OyuncuyaGit()
    {

        switch (kaynak.zeka)
        {

            case CreateEnemy.Zeka.takipEden:

                while (true)
                {
                    OyuncuyaBak();
                    TakipZeka();
                    yield return new WaitForEndOfFrame();
                }

            default:
                break;

        }

    }

    private void OnEnable()
    {
        sayac = 0;
    }

    private IEnumerator AtesEt()
    {
        while (gameObject.activeSelf)
        {
            yield return new WaitForSeconds(atesAraligi);
            ObjectPool.MermiKullan(mermiHizi,mermiGucu,mermiTuru,transform.position,transform.rotation.eulerAngles.z,gameObject.layer);
        }
    }

    private void DocZeka()
    {
        _angle += Time.deltaTime;

        var offset = new Vector3(Mathf.Sin(_angle) * -0.3f, Mathf.Cos(_angle * -0.3f), 0);
        body.velocity = offset;

    }

    private void TakipEtmeyen()
    {
        float oyuncuFark = Vector2.Distance(new Vector2(transform.position.x, transform.position.y), hedef);

        if (surekliTakip)
        {
            while (oyuncuFark > 1)
            {
                oyuncuFark = Vector2.Distance(new Vector2(transform.position.x, transform.position.y), hedef);
                OyuncuyaBak();
                body.velocity = transform.up * hiz;
            }

        }
        else
        {
            while (oyuncuFark > 1)
            {
                body.velocity = transform.up * hiz;
            }
        }

        StartCoroutine("Boom");
    }


    IEnumerator Boom()
    {
        box.radius = 0;
        spriteRenderer.DOFade(0, 0.15F);
        yield return new WaitForSeconds(0.15f);

        while (box.radius < 0.45f)
        {
            box.radius += 0.1f;
            yield return new WaitForSeconds(0.1f);
        }

       // ObjectPool.DusmanDepola(gameObject);
    }


    private void TakipZeka()
    {
        float oyuncuFark = Vector2.Distance(new Vector2(transform.position.x, transform.position.y), hedef);
        OyuncuyaBak();

        if (oyuncuFark > 3f) //MESAFE MİKTARİ
        {
            body.velocity = transform.up * hiz; //HİZ

        }

        else if (oyuncuFark <= 1f) //MESAFE MİKTARİ
        {
            body.velocity = transform.up * -hiz;
        }
        else if (oyuncuFark <= 3f & oyuncuFark > 1.5f)
        {
            if (body.velocity.magnitude > 0 & !docla)
            {
                body.velocity = Vector2.zero;

            }

            else if (docla)
            {
                DocZeka();
            }

        }

    }

    public void CanSistemi(int gelenHasar)
    {
        can -= gelenHasar;

        if (can <= 0)
        {
            //ObjectPool.DusmanDepola(gameObject);
        }
    }

}
