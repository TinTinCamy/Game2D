using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

 public class MenuManager : MonoBehaviour
 {
    [SerializeField] private Button playButton;
    [SerializeField] private Button settingButton;
    [SerializeField] private Button exitButton;
    [SerializeField] private Button backButton;
    [SerializeField] private GameObject settingPanel;
    [SerializeField] private GameObject mainPanel;

    private bool onSettingPanel;

    private void OnEnable()
    {
        playButton.onClick.AddListener(OnClickPlay);
        settingButton.onClick.AddListener(OnClickSetting);
        exitButton.onClick.AddListener(OnClickExit);        
    }

    private void OnDisable()
    {
        playButton.onClick.RemoveListener(OnClickPlay);
        settingButton.onClick.RemoveListener(OnClickSetting);
        exitButton.onClick.RemoveListener(OnClickExit);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && onSettingPanel)
            SceneManager.LoadScene("MenuScene");
    }
    private void OnClickPlay()
    {
        //SceneManager.LoadScene("PlayGameScene");
        SceneManager.LoadScene(1);
    }

    public void OnBackButton()
    {     
        settingPanel.SetActive(false);
        mainPanel.SetActive(true);
        
    }

    public void OnClickSetting()
    {
        onSettingPanel = !onSettingPanel;
        if(onSettingPanel)
        {
            settingPanel.SetActive(true);
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
