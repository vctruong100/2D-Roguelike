using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 1;
    public float Health {
        set {
            health = value;
            if(health <= 0) {
                Die();
            }
        }
        get {
            return health;
        }
    }

    public void Die() {
        Destroy(gameObject);
    }

}
