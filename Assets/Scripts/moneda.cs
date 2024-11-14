using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moneda : MonoBehaviour
{
    [SerializeField] private ParticleSystem particles;
    [SerializeField] public AudioClip audioCoin;
    public float volumen = 10f;
    public int pointsToAdd;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {

            AudioSource.PlayClipAtPoint(audioCoin, transform.position, volumen);

            particles.Play();
            PointSytem.Instance.AddingPoints(pointsToAdd);
            Destroy(gameObject);
        }
    }
}