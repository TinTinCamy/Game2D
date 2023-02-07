using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public static Vector3 respawnPoint = new(86,1.5f, 1f);
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController playerController = collision.GetComponent<PlayerController>();
        if (playerController != null)
        {
            //playerController.InitialPosition = respawnPoint;
        }
    }
}
