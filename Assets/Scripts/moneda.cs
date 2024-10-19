using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moneda : MonoBehaviour
{
    [SerializeField] private ParticleSystem particles;
    public int pointsToAdd;
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            // Destruye la moneda para simular que fue recogida
            particles.Play();
            Destroy(gameObject);
            PointSytem.Instance.AddingPoints(pointsToAdd);
        }
    }

    
}
