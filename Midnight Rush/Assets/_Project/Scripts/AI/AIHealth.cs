using UnityEngine;
using UnityEngine.Events;

public class AIHealth : MonoBehaviour
{
    [SerializeField] int defaultHP = 100;
    public int CurrentHP { get; private set; }

    public UnityEvent<int> onDamage;

    [SerializeField] GameObject onDamageFX;

    public void InitHealth()
    {
        CurrentHP = defaultHP;
    }

    public void TakeDamage(int _damage)
    {
        CurrentHP -= _damage;
        onDamage.Invoke(CurrentHP);
        onDamageFX.SetActive(false);
        onDamageFX.SetActive(true);
    }
}
