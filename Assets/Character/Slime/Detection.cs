using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detection : MonoBehaviour
{
    public string tagTarget = "Player";
    public Collider2D col;
    public List<Collider2D> detectedObjects = new List<Collider2D>();

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            detectedObjects.Add(other);
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        detectedObjects.Remove(other);
    }
}
