using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    public Collider2D col;

    public Enemy enemy;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerStats player = other.GetComponent<PlayerStats>();
            PlayerController playerController = other.GetComponent<PlayerController>();

            if (player != null)
            {
                playerController.TakeDamage(enemy.damage.GetValue());
                Debug.Log("Player health: " + player.currentHealth);
                enemy.ApplyKnockback(playerController);
            }
        }
    }
}
