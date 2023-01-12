using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerZone : MonoBehaviour
{ 
    [SerializeField] private SpikeA spikeA;

    private void OnTriggerEnter2D(Collider2D collision)
    {      
        PlayerController controller = collision.GetComponent<PlayerController>();   
        if(controller != null)
        {
            spikeA.gameObject.SetActive(true);
            spikeA.rb2d.gravityScale = 4;
            controller.SetMovable(false);
            Destroy(gameObject);
        }
    }

    void OnDrawGizmosSelected()
    {
        // Draw a sphere at the transform's position      
        Gizmos.DrawSphere(transform.position, 1);
    }
}
