using UnityEngine;

public class Mermi : MonoBehaviour
{
    private Rigidbody2D body;
    private SpriteRenderer spriteRenderer;
    private float mermiHizi, mermiHasari;
    public float ekstraGuc;
    private bool guvenlik;
    public CreateMermi mermiKaynak;
    public CreateMermi.MermiTuru mermiTuru;
    public GameObject parent;

    public void MermiAta()
    {
        //MERMİ
        spriteRenderer.sprite = mermiKaynak.mermiSprite;
        mermiHizi = mermiKaynak.mermiHiz * ekstraGuc;
        mermiHasari = mermiKaynak.mermiGuc * ekstraGuc;


        //GENEL
        transform.position = parent.transform.localPosition;
        transform.rotation = Quaternion.Euler(0,0,parent.transform.localRotation.eulerAngles.z);
        gameObject.layer = parent.layer;

        //OPEN
        guvenlik = false;
        gameObject.SetActive(true);
        body.velocity = transform.up * mermiHizi;
    }
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        body = GetComponent<Rigidbody2D>();
    }

    private void OnBecameInvisible()
    {
        ObjectPool.NesneDepola(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.transform.tag == "Mermi" | guvenlik)
        {
            return;
        }

        guvenlik = true;

        switch (gameObject.layer)
        {
            case 8:
                if (other.gameObject.tag == "Player")
                {
                    other.gameObject.GetComponent<Player>().CanSistemi((int)mermiHasari);
                }
                break;

            case 9:
                if (other.gameObject.tag == "Enemy")
                {
                    other.gameObject.GetComponent<Enemy>().CanSistemi((int)mermiHasari);
                }
                break;
        }

        ObjectPool.NesneDepola(gameObject);

    }
}
