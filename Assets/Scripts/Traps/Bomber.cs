using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomber : MonoBehaviour
{
    [SerializeField] private GameObject bombPrefab; // drag the bomb prefab into this field in the inspector
    [SerializeField] private float bombDropInterval = 5f; // set the bomb drop interval in seconds
    //[SerializeField] private Collider2D colliderToIgnore;
    private float lastBombDropTime;

    void Update()
    {
        if (Time.time - lastBombDropTime > bombDropInterval)
        {
            lastBombDropTime = Time.time;
            DropBomb();
        }
    }

    void DropBomb()
    {
        // instantiate a new bomb at the position of the bomber
        GameObject bomb = Instantiate(bombPrefab, transform.position, Quaternion.identity);
        //physics2d.ignorecollision(getcomponent<collider2d>(), collidertoignore);
        // add downward velocity to the bomb
        Rigidbody2D rb = bomb.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, -5);
    }
}
