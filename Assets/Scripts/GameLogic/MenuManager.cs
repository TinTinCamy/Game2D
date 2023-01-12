using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

 public class MenuManager : MonoBehaviour
 {
    [SerializeField] private Button playButton;
    [SerializeField] private Button OptionButton;
    [SerializeField] private Button exitButton;
    [SerializeField] private GameObject optionPanel;
    [SerializeField] private GameObject mainPanel;

    private bool onOptionPanel;

    private void OnEnable()
    {
        playButton.onClick.AddListener(OnClickPlay);
        OptionButton.onClick.AddListener(OnClickOption);
        exitButton.onClick.AddListener(OnClickExit);        
    }

    private void OnDisable()
    {
        playButton.onClick.RemoveListener(OnClickPlay);
        OptionButton.onClick.RemoveListener(OnClickOption);
        exitButton.onClick.RemoveListener(OnClickExit);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && onOptionPanel)
            SceneManager.LoadScene("MenuScene");
    }
    private void OnClickPlay()
    {
        SceneManager.LoadScene("PlayGameScene");
    }

    private void OnClickOption()
    {
        onOptionPanel = !onOptionPanel;
        if(onOptionPanel)
        {
            optionPanel.SetActive(true);
        }
        else 
        {
           mainPanel.SetActive(true);
        }
    }

    public void OnClickExit()
    {
#if UNITY_EDITOR 
        UnityEditor.EditorApplication.isPlaying = false;
#else 
       Application.Quit();
#endif
    }
 }
