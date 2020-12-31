using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boom : MonoBehaviour
{

    private void OnEnable()
    {
        StartCoroutine(VarOlus());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            collision.GetComponent<Player>().CanSistemi(1);
        }
    }

    IEnumerator VarOlus()
    {
        yield return new WaitForSecondsRealtime(0.3f);
        Destroy(gameObject);
    }
}
