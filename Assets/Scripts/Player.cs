using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int can,maxCan;


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
