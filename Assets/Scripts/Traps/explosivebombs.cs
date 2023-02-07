using DG.Tweening.Core.Easing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosivebombs : MonoBehaviour
{
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private CapsuleCollider2D caps2d;
    [SerializeField] private Animator animator;
    [SerializeField] private AudioClip explosion;
    [SerializeField] private AudioSource explosionBoom;
    
    private void Start()
    {
        animator = GetComponent<Animator>();          
        caps2d = GetComponent<CapsuleCollider2D>();
        Physics2D.IgnoreCollision(this.GetComponent<Collider2D>(), 
            GameObject.FindWithTag("TheMushroom").GetComponent<Collider2D>());
    }
    

    void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerController playerController = collision.collider.GetComponent<PlayerController>();
        if (collision.gameObject.CompareTag ("Player"))
        {                       
            // Play the animation
            animator.SetTrigger("Collision");
            //PlayTheSound();
            playerController.OnPlayerDead();
            Destroy(gameObject);
           
        }
        if(IsGrounded())
        {
            //PlayTheSound();
            //AudioManager.instantiate.PlaySound(explosion);           
            animator.SetTrigger("Collision");           
            Destroy(gameObject,0.4f);         
        }
    }
  
    public bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void PlayTheSound()
    {
        explosionBoom.Play();
        explosionBoom.volume = 0.3f;
    }
}
