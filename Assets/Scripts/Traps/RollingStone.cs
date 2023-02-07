using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollingStone : MonoBehaviour
{
    public Rigidbody2D rb2d;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerController playerController = collision.collider.GetComponent<PlayerController>();
        if (playerController != null)
        {
            playerController.OnPlayerDead();
            Destroy(gameObject);
        }
    }

}
