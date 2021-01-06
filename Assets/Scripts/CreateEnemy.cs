using UnityEngine;

[CreateAssetMenu(fileName = "CreateEnemy", menuName = "FlashQ/CreateEnemy", order = 0)]
public class CreateEnemy : ScriptableObject {
    public bool oluncePatla,atesEt;
    public Sprite dusmanSprite;
    public Zeka zeka;
    public ObjectPool.MermiTuru mermiTuru;
    public Mesafe mesafe;
    public int mesafeMiktari,hiz,can,mermiHizi,mermiGucu;
    public float saldiriCapi;
    public enum Zeka
    {
        takipEden,
        takipEtmeyen
    }

    public enum Mesafe
    {
        yapis,
        uzakta,
        yakin
    }



}