using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;



// Classe Tank que implementa a interface IDamageable
public interface IDamageable
{
    void TakeDamage(int damage);
    void Heal(int amount);
}

// Classe Dano que implementa a interface IDamageable
public class Dano : MonoBehaviour, IDamageable
{
    public int MaxHealth = 100; // Vida inicial do tanque
    [SerializeField]
    private int health;

    public int Health
    {
        get { return health; }
        set
        {
            health = value;
            OnHealthChange?.Invoke((float)Health / MaxHealth);
        }
    }

    public UnityEvent OnDead;
    public UnityEvent<float> OnHealthChange;
    public UnityEvent OnHit, OnHeal;

    private void Start()
    {
        Health = MaxHealth;
    }

    // Método da interface IDamageable para receber dano
    public void TakeDamage(int damage)
    {
        Health -= damage;
        if (health <= 0)
        {
            OnDead?.Invoke();
        }
        else
        {
            OnHit?.Invoke();
        }
    }

    // Método da interface IDamageable para curar
    public void Heal(int healthBoost)
    {
        Health += healthBoost;
        Health = Mathf.Clamp(Health, 0, MaxHealth);
        OnHeal?.Invoke();
    }

    // Método Hit pode continuar existindo, pois usa TakeDamage internamente
    internal void Hit(int damagePoints)
    {
        TakeDamage(damagePoints); // Utilizando o método da interface
    }
}
