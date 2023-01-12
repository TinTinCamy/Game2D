using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CollisionCheck : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {       
        PlayerController playerController = collision.GetComponent<PlayerController>();
        if(playerController !=null)
        {           
            Destroy(this.transform.parent.gameObject);
            playerController.OnPlayerDead();          
        }
    }
}
