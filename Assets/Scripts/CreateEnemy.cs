using UnityEngine;

[CreateAssetMenu(fileName = "CreateEnemy", menuName = "FlashQ/CreateEnemy", order = 0)]
public class CreateEnemy : ScriptableObject {
    public bool oluncePatla,atesEt;
    public Zeka zeka;
    public Mesafe mesafe;
    public enum Zeka
    {
        takipEden,
        tank,
        patlayan
    }

    public enum Mesafe
    {
        yapis,
        uzakta,
        yakin
    }



}