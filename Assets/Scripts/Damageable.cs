using UnityEngine;
using UnityEngine.Events;

public class Damageable : MonoBehaviour
{
    public UnityEvent OnDead;
    public UnityEvent<float> OnHealthChange; // event with argument and it call a method anywhere with updated Health.
    public UnityEvent OnHit, OnHeal;
    public int MaxHealth = 100;
    [SerializeField]
    private int health; // current private health

    public int Health
    {
        get { return health; }
        set 
        { 
            health = value;
            OnHealthChange?.Invoke((float)Health / MaxHealth);
        }
    }

    private void Start()
    {
        Health = MaxHealth;
    }

    internal void Hit(int DamagePoint)
    {
        Health -= DamagePoint;
        if(Health <= 0)
        {
            OnDead?.Invoke();
        }
        else
        {
            OnHit?.Invoke();
        }
    }

    public void Heal(int Healthboost)
    {
        Health += Healthboost;
        Health = Mathf.Clamp(Health, 0, MaxHealth);
        OnHeal?.Invoke();
    }

    
}
