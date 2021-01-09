using UnityEngine;

[CreateAssetMenu(fileName = "CreateEnemy", menuName = "FlashQ/CreateEnemy", order = 0)]
public class CreateEnemy : ScriptableObject {
    public bool oluncePatla,atesEt,docla,surekliTakip;
    public Sprite dusmanSprite;
    public Zeka zeka;
    public Mermi.MermiTuru mermiTuru;
    public Mesafe mesafe;
    public int mesafeMiktari,can,mermiHizi,mermiGucu;
    public float hiz,atesAraligi;
    public enum Zeka
    {
        takipEden,
        takipEtmeyen,
    }

    public enum Mesafe
    {
        yapis,
        uzakta,
        yakin
    }



}