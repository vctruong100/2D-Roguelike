using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    public Collider2D col;

    public Enemy enemy;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Hitbox triggered");
        if (other.CompareTag("Player"))
        {
            PlayerStats player = other.GetComponent<PlayerStats>();
            PlayerController playerController = other.GetComponent<PlayerController>();

            if (player != null)
            {
                player.Health -= enemy.damage;
                Debug.Log("Player health: " + player.health);
                enemy.ApplyKnockback(playerController);
            }
        }
    }
}
