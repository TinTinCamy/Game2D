using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crushing : MonoBehaviour
{
    [SerializeField] private Transform up;
    [SerializeField] private Transform down;
    [SerializeField] private float upSpeed;
    [SerializeField] private float downSpeed;

    private bool chop;

    void Update()
    {
        if(transform.position.y >= up.position.y)
        {
            chop = true;
        } 
        if(transform.position.y <= down.position.y)
        {
            chop = false;
        }

        if(chop)
        {
            transform.position = Vector2.MoveTowards(transform.position, down.position, downSpeed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, up.position, upSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController playerController = collision.GetComponent<PlayerController>();
        if (playerController != null)
        {
            playerController.OnPlayerDead();
        }
    }
}
