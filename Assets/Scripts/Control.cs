using UnityEngine;
using UnityEngine.EventSystems;

public class Control : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    enum Durum
    {
        normal,
        ates,
        flash
    }
    private Vector2 ilkVector, sonVector;
    private Durum suankiDurum = Durum.normal;

    public GameObject hedefleyici, Player, kamera;

    public void OnDrag(PointerEventData eventData)
    {
        kamera.GetComponent<Kamera>().ZamanEfekt(true);

        suankiDurum = Durum.flash;
        sonVector = Camera.main.ScreenToWorldPoint(eventData.position);

        float mesafe = Vector2.Distance(sonVector, ilkVector);
        Vector2 fark = ilkVector - sonVector;

        float Angle = Mathf.Atan2(fark.y, fark.x);
        float AngleInDegrees = Angle * Mathf.Rad2Deg;


        hedefleyici.transform.rotation = Quaternion.Euler(0, 0, AngleInDegrees - 90);
        hedefleyici.transform.localScale = new Vector3(1, mesafe, 1);
        Player.GetComponent<Player>().Bak(AngleInDegrees);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        ilkVector = Camera.main.ScreenToWorldPoint(eventData.position);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (suankiDurum != Durum.flash)
        {
            suankiDurum = Durum.ates;
            Fire();
        }
        else
        {
            Vector2 hedefNokta = hedefleyici.transform.GetChild(0).position;
            hedefleyici.transform.localScale = Vector3.zero;
            ilkVector = Player.transform.position;
            sonVector = Player.transform.position;
            suankiDurum = Durum.normal;
            kamera.GetComponent<Kamera>().ZamanEfekt(false);

            if (Vector2.Distance(hedefNokta, Player.transform.position) < 0.35f)
            {
                return;
            }

            Player.transform.position = hedefNokta;
            kamera.GetComponent<Kamera>().Tetikle();

        }

    }


    private void Fire()
    {
        Vector2 fark = new Vector2(Player.transform.position.x, Player.transform.position.y) - ilkVector;

        float Angle = Mathf.Atan2(fark.y, fark.x);
        float AngleInDegrees = Angle * Mathf.Rad2Deg;
        Player.GetComponent<Player>().Bak(AngleInDegrees);



        hedefleyici.transform.rotation = Quaternion.Euler(0, 0, AngleInDegrees - 90);


        ObjectPool.MermiKullan(5, 5, Mermi.MermiTuru.normal, Player.transform.position, AngleInDegrees+90,9);

        suankiDurum = Durum.normal;
    }
}
