using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    [SerializeField] private float speed = 8f;
    [SerializeField] private float jumpPower = 16f;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private static readonly Vector3 InitialPosition = new(250.11f, 16f, 1f);
    //[SerializeField] private static Vector3 InitialPosition = new(-13, 0f, 1f);
    //[SerializeField] private static readonly Vector3 InitialPosition = new(196.19f, 4f, 1f);
    [SerializeField] private GameManager gameManager;
    [SerializeField] private AudioClip playerJump;

    // private    
    private float horizontal;
    private int score;
    private int currentScore = 0;
    private bool _isMovable;
    private int maxTurn = 3;


    // public   
    public Rigidbody2D rb2d;
    public Animator animator;
    public Vector2 Position;
    public int currentTurn;

    // Start is called before the first frame update
    void Start()
    {
        _isMovable = true;
        currentTurn = maxTurn;
        gameManager.turnText.text = " " + maxTurn;
        rb2d = GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();       
    }

    // Update is called once per frame
    void Update()
    {
        // If player is not movable, do not run the rest
        if (!_isMovable) return;

        horizontal = Input.GetAxis("Horizontal");

        // If player is on the ground and press jump
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            AudioManager.instantiate.PlaySound(playerJump);
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpPower);
        }

        // If player releases jump button while jumping, lower the jump height
        if (Input.GetButtonUp("Jump") && rb2d.velocity.y > 0)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, rb2d.velocity.y * 0.5f);
        }

        Flip();
        SetAnimation(rb2d.velocity.x, rb2d.velocity.y);
        
    }

    public void FixedUpdate()
    {
        if (!_isMovable) return;      
        rb2d.velocity = new Vector2(speed * horizontal, rb2d.velocity.y);
        
        
    }

   public void SetAnimation(float x, float y)
    {
        if (x < 0) x *= -1;
        animator.SetFloat("velocityX", x);
        animator.SetFloat("velocityY", y);
        animator.SetBool("grounded", IsGrounded());
    }

    public void Flip()
    {
        if(Input.GetAxis("Horizontal") > 0)
        {
            transform.localScale = Vector3.one;
        }
        if(Input.GetAxis("Horizontal") < 0)
        {
            transform.localScale = new Vector2(-1f, 1f);
        }
    }
    public bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }


    public void Init()
    {
        _isMovable = true;
        transform.position = InitialPosition;       
    }

    public void SetMovable(bool isMovable)
    {
        _isMovable = isMovable;
        rb2d.velocity = Vector2.zero;
    }

    public void GetScore(int amount)
    {
        score += currentScore + amount;
        Debug.Log(score);
        gameManager.scoreText.text = " " + score;
        gameManager.pauseScoreText.text = " " + score;
        gameManager.endgameScoreText.text = " " + score;
    }

    public void GetTurn()
    {
        if (currentTurn < maxTurn)
        {
            currentTurn++;
            gameManager.turnText.text = " " + currentTurn;
        }
    }    

    public void OnPlayerDead()
    {      
        gameManager.dieGamePanel.SetActive(true);
        Time.timeScale = 0;
        StartCoroutine(WaitAndResumeGame(1));
        currentTurn --;
        gameManager.turnText.text = " " + currentTurn;      
        if(currentTurn == 0)
        {
            gameManager.dieGamePanel.SetActive(false);
            Destroy(gameObject);
            gameManager.EndGame();
        }
    }

    public IEnumerator WaitAndResumeGame(float time)
    {
        yield return new WaitForSecondsRealtime(time);      
        gameManager.dieGamePanel.SetActive(false);
        Time.timeScale = 1;
        Init();
        
    }

}
