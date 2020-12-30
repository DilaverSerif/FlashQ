using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector2 ilk, son;
    public GameObject sd;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ilk = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        if (Input.GetMouseButtonUp(0))
        {

        }

        if (Input.GetMouseButton(0))
        {
            son = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            float mesafe = son.y - ilk.y;
            Vector2 fark = ilk - son;
            float Angle = Mathf.Atan2(fark.y, fark.x);
            float AngleInDegrees = Angle * Mathf.Rad2Deg;
            float sonuc = Vector3.Angle(ilk, son);
            Debug.Log(AngleInDegrees + " " + ilk);
            sd.transform.rotation = Quaternion.Euler(0, 0, AngleInDegrees - 90);
            sd.transform.localScale = new Vector3(1,mesafe,1);
        }
    }

}
