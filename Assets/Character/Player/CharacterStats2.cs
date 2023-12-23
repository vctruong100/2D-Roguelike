using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats12 : MonoBehaviour
{
    public Stats2 damage;
    public Stats2 armor;
    public int maxHealth = 100;
    public int currentHealth { get; private set; }

    void Awake () {
        currentHealth = maxHealth;
    }

    void Update () {
        if (Input.GetKeyDown(KeyCode.T)) {
            TakeDamage(10);
        }
    }

    public void TakeDamage (int damage) {
        damage -= armor.GetValue();
        damage = Mathf.Clamp(damage, 0, int.MaxValue);

        currentHealth -= damage;
        Debug.Log(transform.name + " takes " + damage + " damage.");

        if (currentHealth <= 0) {
            Die();
        }
    }

    public virtual void Die () {
        // Die in some way
        // This method is meant to be overwritten
        Debug.Log(transform.name + " died.");
    }
}
