using UnityEngine;

[CreateAssetMenu(fileName = "CreateMermi", menuName = "FlashQ/CreateMermi", order = 1)]
public class CreateMermi : ScriptableObject {
    public enum MermiTuru
    {
        normal,
        icindenGecen,
        kuvvetli,
        akilli,
        parcalanan
    }

    public float mermiHiz,mermiGuc;
    public Sprite mermiSprite;
    
}