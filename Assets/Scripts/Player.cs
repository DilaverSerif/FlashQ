using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int can;

    private void Update()
    {

    }

    public void CanSistemi(int hasar)
    {
        can -= hasar;

        if (can <= 0)
        {
            Debug.Log("ÖLDÜN");
        }

    }

}
