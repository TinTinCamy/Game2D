using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    private void Start()
    {
        Destroy(gameObject,0.5f);
    }

    public void PlayerDead()
    {
        Debug.Log("Explosion");
        playerController.OnPlayerDead();
    }

}
