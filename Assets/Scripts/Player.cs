using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
    private int can, maxCan;
    private CreateMermi.MermiTuru mermiTuru;

    public void Bak(float gelen,bool ates)
    {
        DOTween.Kill("donus");
        transform.DORotate(new Vector3(0, 0, gelen + 90), 0.1f).SetId("donus").OnComplete(() => AtesEt(ates));
    }


    public void CanSistemi(int hasar)
    {

        if (can > 100)
        {
            can -= hasar;
        }
        else
        {
            Debug.Log("ÖLÜM");
        }

    }

    private void AtesEt(bool ates)
    {
        if(!ates) return;
        ObjectPool.MermiKullan(mermiTuru, gameObject, 1);
    }

}
