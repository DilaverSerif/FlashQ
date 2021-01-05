using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Vector2 hedef, fark;
    private float aradakiMesafa;
    private int can,hiz;
    private bool dur,ates;
    [SerializeField]
    private mesafe pMesafe;

    public enum mesafe
    {
        yapis,
        uzakta,
        yakin
    }

    public enum atesEt
    {
        evet,
        hayir
    }

    public enum patla
    {
        evet,
        hayir
    }

    // Start is called before the first frame update
    private void Start()
    {
        OyuncuyaBak();
    }


    private void OyuncuyaGit()
    {
        switch (pMesafe)
        {
            case mesafe.yapis:
            break;

            case mesafe.uzakta:
            break;
            
            case mesafe.yakin:
            break;
            
            default:
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

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, hedef) < 1f)
        {
            //Debug.Log("BOM");
        }

        GetComponent<Rigidbody2D>().velocity = fark;
    }
}
