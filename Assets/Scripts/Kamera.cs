using System.Collections;
using UnityEngine;
using DG.Tweening;

public class Kamera : MonoBehaviour
{
    public GameObject Player;
    Camera kamera;
    public Vector3 target_Offset;
    public float delay;

    private void Awake() {
        kamera = GetComponent<Camera>();
    }

    // Update is called once per frame
    public void Tetikle()
    {
        DOTween.Kill("kamera");
        kamera.transform.DOMove(new Vector3(Player.transform.position.x,Player.transform.position.y,-10),delay).SetId("kamera");
    }


    public void ZamanEfekt(bool efekt)
    {
        DOTween.Kill("zaman");

        if (efekt)
        {
            Time.timeScale = 0.35f;
            kamera.DOOrthoSize(5,0.5f).SetId("zaman");
        }
        else
        {
            Time.timeScale = 1f;
            kamera.DOOrthoSize(5.5f,0.5f).SetId("zaman");
        }
    }

    
}
