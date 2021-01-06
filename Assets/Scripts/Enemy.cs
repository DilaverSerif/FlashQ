using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Vector2 hedef, fark;
    private float aradakiMesafa;
    public int mesafeMiktari,hiz,can,mermiHizi,mermiGucu;
    private bool dur,ates;
    public CreateEnemy kaynak;
    private Rigidbody2D body;
    private SpriteRenderer spriteRenderer;
    private ObjectPool.MermiTuru mermiTuru;
    private CreateEnemy.Mesafe mesafeTuru;
    private CreateEnemy.Zeka zekaTuru;

    private void Awake() {
        body = GetComponent<Rigidbody2D>();
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
    }
    // Start is called before the first frame update
    private void Start()
    {
        StartCoroutine(OyuncuyaGit());
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

        yield return new WaitForEndOfFrame();
    }


    private void TakipZeka()
    {
        if (Vector2.Distance(new Vector2(transform.position.x,transform.position.y),hedef) > mesafeMiktari) //MESAFE MİKTARİ
        {
            OyuncuyaBak();
            body.velocity = fark * hiz; //HİZ

        }
        else if(body.angularVelocity <= 3 & body.angularVelocity > 2) //MESAFE MİKTARİ
        {
            body.velocity = fark * -hiz;
        }
        else
        {
            body.velocity = Vector2.zero;
        }
    }

}
