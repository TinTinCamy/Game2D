using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    [SerializeField] private int value;
    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController controller = other.GetComponent<PlayerController>();     
        if( controller != null )
        {
            controller.GetScore(value);
            Destroy(gameObject);
        }
    }
}
