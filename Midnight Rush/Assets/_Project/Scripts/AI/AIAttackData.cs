using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/AIAttackData", order = 1)]
public class AIAttackData : ScriptableObject
{
    public float damage;
    public float cooldown;
}
