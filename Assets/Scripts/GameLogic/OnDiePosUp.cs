using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class OnDiePosUp : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private HotAirBalloon HotAirBalloon;
    private void OnTriggerEnter2D(Collider2D collision)
    {

        PlayerController controller = collision.GetComponent<PlayerController>();
        if (controller != null)
        {
            //gameManager.DiePanel();          
            controller.OnPlayerDead();
            //Destroy(HotAirBalloon.gameObject);
            //HotAirBalloon.gameObject.SetActive(false);
        }
    }

}
