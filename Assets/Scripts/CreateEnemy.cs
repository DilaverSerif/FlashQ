using UnityEngine;

[CreateAssetMenu(fileName = "CreateEnemy", menuName = "FlashQ/CreateEnemy", order = 0)]
public class CreateEnemy : ScriptableObject
{
    [Header("Zeka Ayarları")]
    public bool oluncePatla, atesEt, docla, odaklan;
    public Zeka zeka;
    public Mermi.MermiTuru mermiTuru;
    public Mesafe mesafe;
    public int mesafeMiktari;
    [Header("Kisilestirme Ayarları")]
    public Sprite dusmanSprite;
    public int can, mermiHizi, mermiGucu;
    public float hiz, atesAraligi;
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