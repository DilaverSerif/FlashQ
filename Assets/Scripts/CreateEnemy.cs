using UnityEngine;

[CreateAssetMenu(fileName = "CreateEnemy", menuName = "FlashQ/CreateEnemy", order = 0)]
public class CreateEnemy : ScriptableObject {
    public enum Turler
    {
        takipEden,
        tank,
        normal
    }

    public Turler dusmanTuru;

}