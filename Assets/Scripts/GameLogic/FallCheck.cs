using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallCheck : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        PlayerController controller = collision.GetComponent<PlayerController>();
        explosivebombs explosivebombs = collision.GetComponent<explosivebombs>();
        if (controller != null)
        {
            controller.OnPlayerDead();
        }
        if(explosivebombs != null)
        {
            Destroy(explosivebombs);
        }
    }
}
