using Cinemachine;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Playables;

public class ShowTheBridge : MonoBehaviour
{
    [SerializeField] private ParticleSystem collisionParticleSystem;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private GameObject theBridge;
    [SerializeField] private int value;
    [SerializeField] private GameObject _camera;
    [SerializeField] private AudioClip magicStick;
    [SerializeField] private AudioClip showTheBridge;
    //[SerializeField] private CinemachineVirtualCamera vCam;
    [SerializeField] private CutScene_Controller CutScene_Controller;
    private bool once = true;

    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.R))
    //    {
    //        MoveTheCamera();
    //    }

    //    if (Input.GetKeyDown(KeyCode.T))
    //    {
    //       ResetCamera();
    //    }
    //}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController playerController = collision.GetComponent<PlayerController>();
        if (collision.gameObject.CompareTag("Player") && once)
        {
            AudioManager.instantiate.PlaySound(magicStick);
            var em = collisionParticleSystem.emission;
            var dur = collisionParticleSystem.duration;

            em.enabled = true;
            collisionParticleSystem.Play();
            playerController.GetScore(value);
            playerController.SetMovable(false);
            CutScene_Controller.PlayCamera();
            Invoke("TheSoundShowsTheBridge", 1f);
            theBridge.SetActive(true);             
            theBridge.GetComponent<SpriteRenderer>().DOFade(1f, 3.5f).SetEase(Ease.Linear);
            //AudioManager.instantiate.PlaySound(showTheBridge);
            playerController.SetMovable(true);
            //MoveTheCamera();
            //Invoke("ResetCamera", 1.5f);
            
            once = false;
            Destroy(spriteRenderer);
            Invoke(nameof(DestroyObject), dur);
            
            
        }
    }

    private void DestroyObject()
    {
        Destroy(gameObject);
    }

    private void TheSoundShowsTheBridge()
    {      
        AudioManager.instantiate.PlaySound(showTheBridge);
    }

    //private void MoveTheCamera()
    //{
    //    Debug.Log("ABC");
    //    vCam.enabled = false;
    //    _camera.transform.SetPositionAndRotation(theBridge.transform.position, theBridge.transform.rotation);
    //}

    //private void ResetCamera()
    //{
    //    vCam.enabled = true;
    //}
}
