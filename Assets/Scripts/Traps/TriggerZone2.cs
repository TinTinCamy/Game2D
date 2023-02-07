using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZone2 : MonoBehaviour
{
    [SerializeField] private SpikeB spikeB;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController controller = collision.GetComponent<PlayerController>();
        if (controller != null)
        {
            spikeB.gameObject.SetActive(true);
            spikeB.rb2d.gravityScale = 3;
            //controller.SetMovable(isMovable);
            Destroy(gameObject);
        }
    }

    void OnDrawGizmosSelected()
    {
        // Draw a sphere at the transform's position      
        Gizmos.DrawSphere(transform.position, 1);
    }
}
