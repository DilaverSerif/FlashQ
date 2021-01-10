using UnityEngine;

[CreateAssetMenu(fileName = "CreateEnemy", menuName = "FlashQ/CreateEnemy", order = 0)]
public class CreateEnemy : ScriptableObject
{
    [Header("Zeka Ayarları")]
    public bool oluncePatla, atesEt, docla;
    public Mermi.MermiTuru mermiTuru;
    public Zeka zeka;

    [Header("Kisilestirme Ayarları")]
    public Sprite dusmanSprite;
    public int can, mermiHizi, mermiGucu;
    public float hiz, atesAraligi;
    public enum Zeka
    {
        UzakSaldiran,
        YakinSaldiran,
        Kamizake
    }



}