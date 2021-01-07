using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mermi : MonoBehaviour
{
    private  int hiz,hasarGucu;
    private SpriteRenderer spriteRenderer;
    public ObjectPool.MermiTuru tur;
    private void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Reset() {
         GetComponent<BoxCollider2D>();
    }


    public void OzellikAta(int phiz,int phasarGucu,Sprite sprite,Vector2 basla,float don)
    {
        spriteRenderer.sprite = sprite;
        hiz = phiz;
        hasarGucu = phasarGucu;
        transform.position = basla;
        transform.rotation = Quaternion.Euler(0,0,don);
    }
    private void OnBecameInvisible()
    {
        ObjectPool.MermiDepola(gameObject);
    }
}
