using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetCoin : MonoBehaviour
{
    [SerializeField] private ParticleSystem collisionParticleSystem;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private int value;
    public bool once = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController playerController = collision.GetComponent<PlayerController>();
        if (collision.gameObject.CompareTag("Player") && once)
        {
            var em = collisionParticleSystem.emission;
            var dur = collisionParticleSystem.duration;

            em.enabled = true;
            collisionParticleSystem.Play();
            playerController.GetScore(value);

            once = false;
            Destroy(spriteRenderer);
            Invoke(nameof(DestroyObject), dur);
        }
    }

    private void DestroyObject()
    {
        Destroy(gameObject);
    }
}
