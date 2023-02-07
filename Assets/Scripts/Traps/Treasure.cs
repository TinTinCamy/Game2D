using DG.Tweening.Core.Easing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treasure : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private PlayerController playerController;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {                 
        
        if (playerController != null)
        {
            SetAnimation();                
            Destroy(gameObject,0.5f);
            //playerController.OnPlayerDead();
            
        }      
    }

    private void SetAnimation()
    {
        anim.SetBool("Explosion", true);
    }

    private void PlayerDead()
    {
        Debug.Log("Treasure");
        playerController.OnPlayerDead();
    }
}
