using UnityEngine;

[CreateAssetMenu(fileName = "CreateEnemy", menuName = "FlashQ/CreateEnemy", order = 0)]
public class CreateEnemy : ScriptableObject {
    public bool oluncePatla,atesEt,docla;
    public Sprite dusmanSprite;
    public Zeka zeka;
    public ObjectPool.MermiTuru mermiTuru;
    public Mesafe mesafe;
    public int mesafeMiktari,can,mermiHizi,mermiGucu;
    public float hiz;
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