using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
    private int can,maxCan;

    public void Bak(float gelen)
    {
        DOTween.Kill("donus");
        transform.DORotate(new Vector3(0,0,gelen+90),0.15f).SetId("donus");
    }


    public void CanSistemi(int hasar)
    {
        
        if (can > 100)
        {
            can -= hasar;
            transform.localScale = new Vector3((can - 100) / 100,(can - 100) / 100,(can - 100) / 100);
        }
        else
        {
            Debug.Log("ÖLÜM");
        }

    }

}
