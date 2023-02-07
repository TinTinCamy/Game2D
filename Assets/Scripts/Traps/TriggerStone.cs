using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerStone : MonoBehaviour
{
    [SerializeField] private Stone rollingStone;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController controller = collision.GetComponent<PlayerController>();
        if (controller != null)
        {
            rollingStone.rb2d.gravityScale = 4;
        }
    }
}
