using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mermi : MonoBehaviour
{
    private int hasarGucu;
    private float hiz;
    private Rigidbody2D body;
    private SpriteRenderer spriteRenderer;
    public MermiTuru tur;

        public enum MermiTuru
    {
        normal,
        kuvvetli
    }

    public void MermiAta(float phiz, int phasarGucu, Sprite sprite, Vector2 baslamaVectoru, float zEkseni, LayerMask katman)
    {
        hiz = phiz;
        hasarGucu = phasarGucu;
        GetComponent<SpriteRenderer>().sprite = sprite;
        transform.position = baslamaVectoru;
        transform.rotation = Quaternion.Euler(0, 0, zEkseni);
        gameObject.layer = katman;
        gameObject.SetActive(true);
    }
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        body = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        body.velocity = transform.up * hiz;
    }

    private void Reset()
    {
        GetComponent<BoxCollider2D>();
    }

    private void OnBecameInvisible()
    {
        ObjectPool.MermiDepola(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.transform.tag == "Mermi")
        {
            return;
        }

        switch (gameObject.layer)
        {
            case 8:
                if (other.gameObject.tag == "Player")
                {
                    other.gameObject.GetComponent<Player>().CanSistemi(hasarGucu);
                    ObjectPool.MermiDepola(gameObject);
                }
                break;

            case 9:
                if (other.gameObject.tag == "Enemy")
                {
                    other.gameObject.GetComponent<Enemy>().CanSistemi(hasarGucu);
                    ObjectPool.MermiDepola(gameObject);
                }
                break;
        }



    }
}
