using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    [SerializeField] private float changeTime = 3.0f;
    
    private bool isMovable;

    private Rigidbody2D rb2d;
    float timer;
    int direction = 1;

    public void Start()
    {
        isMovable = true;
        timer = changeTime;
        rb2d = GetComponent<Rigidbody2D>();
    }
    public void Update()
    {
        if (!isMovable) return;
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            direction = -direction;
            timer = changeTime;
        }
        Flip();
    }

    public void FixedUpdate()
    {
        if (!isMovable) return;
        Vector2 position = rb2d.position;
        position.x = position.x - Time.deltaTime * speed * direction;
        rb2d.MovePosition(position);
    }
    private void Flip()
    {
        if(direction > 0)
        {
            transform.localScale = Vector2.one;
        }
        else
        {
            transform.localScale = new Vector2(-1, 1);
        }
    }

    public void SetMovable(bool _ismovable)
    {
        isMovable = _ismovable; 
    }
}
