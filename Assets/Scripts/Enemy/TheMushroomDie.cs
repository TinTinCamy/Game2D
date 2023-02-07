using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheMushroomDie : MonoBehaviour
{
    [SerializeField] private int value;
    [SerializeField] private EnemyController enemy;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController playerController = collision.GetComponent<PlayerController>();
        if (playerController != null)
        {
            enemy.isMovable = false;
            enemy.animator.SetTrigger("Hit");          
            Destroy(this.transform.parent.gameObject,0.7f);
            playerController.GetScore(value);

        }
    }
}
