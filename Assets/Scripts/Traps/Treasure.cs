using DG.Tweening.Core.Easing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treasure : MonoBehaviour
{
    [SerializeField] private GameObject explosion;
    [SerializeField] private PlayerController playerController;
    [SerializeField] private GameManager gameManager;
    private void OnTriggerEnter2D(Collider2D collision)
    {            
        PlayerController controller = collision.GetComponent<PlayerController>();
        if (controller != null)
        {          
            //// Initialization The Explosion
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
