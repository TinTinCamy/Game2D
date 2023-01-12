using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotAirBalloon : MonoBehaviour
{
    [SerializeField] private float riseSpeed = 6f;
    private bool moving;

    private void FixedUpdate()
    {
        if (moving)
        {
            transform.position += new Vector3(0, riseSpeed * Time.deltaTime, 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerController playerController = collision.collider.GetComponent<PlayerController>();
        if (playerController)
        {
            moving = true;
            collision.collider.transform.SetParent(transform);
            playerController.SetMovable(false);
            playerController.rb2d.velocity = Vector2.zero;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        PlayerController playerController = collision.collider.GetComponent<PlayerController>();
        if (playerController)
        {
            moving = false;
            collision.collider.transform.SetParent(null);

        }
    }
}
