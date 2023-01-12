using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheBirdIsCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerController playerController = collision.collider.GetComponent<PlayerController>();
        if(playerController != null)
        {
            playerController.OnPlayerDead();
            Destroy(gameObject);
        }
    }
}
