using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using DG.Tweening.Core.Easing;

public class GameManager : MonoBehaviour
{
    [Header("In-game UI")]
    [SerializeField] private TMP_Text playerNameText;   

    [Header("Pause Game panel")]
    [SerializeField] private GameObject pauseGamePanel;   
    [SerializeField] private TMP_Text pausePlayerNameText;
    [SerializeField] private Button UndoButton;

    [Header("End Game panel")]
    [SerializeField] private GameObject endGamePanel;
    [SerializeField] private TMP_Text endgamePlayerNameText;  
    [SerializeField] private Button exitButton;
    [SerializeField] private Button backToMenuButton;

    [Header("DieGamePanel")]
    public GameObject dieGamePanel;

    [Header("Player scripts")]
    [SerializeField] private PlayerController playerController;
    [SerializeField] private EnemyController enemyController;

    // public
    public TMP_Text scoreText;
    public TMP_Text turnText;
    public TMP_Text pauseScoreText;
    public TMP_Text endgameScoreText;

    // private
    private bool _isPause;
    private bool _isGameOver;

    private void Awake()
    {
        playerNameText.text = "Obu";
        pausePlayerNameText.text = "Obu";
        endgamePlayerNameText.text = "Obu";
        Init();
    }

    private void Update()
    {
        // If game is already over, disable the pause function
        if (Input.GetKeyDown(KeyCode.Escape) && !_isGameOver)
            PauseGame();
        
    }

    public void OnClickBackToMenu()
    {
        SceneManager.LoadScene(0);
        // Resume the movement of all objects
        SetTheMovement(1);
    }

    public void OnClickRestartButton()
    {     
        SceneManager.LoadScene(1);
        // Resume the movement of all objects
        SetTheMovement(1);

    }
    public void OnClickUndoButton()
    {
        // Hide pause-game panel
        pauseGamePanel.SetActive(false);
        // Resume the movement of all objects
        SetTheMovement(1);
    }

    public void OnClickExit()
    {
#if UNITY_EDITOR 
        UnityEditor.EditorApplication.isPlaying = false;
#else 
       Application.Quit();
#endif
    }

    public void OnEndLevel()
    {
        Debug.Log("End level!");
        EndGame();
    }

    //public void DiePanel()
    //{
    //    dieGamePanel.SetActive(true);
    //}
    //public IEnumerator ShowDiePanelForSeconds(float seconds)
    //{
    //    dieGamePanel.SetActive(true);
    //    yield return new WaitForSeconds(seconds);
    //    dieGamePanel.SetActive(false);
    //}
    public void Init()
    {
        // Init player's scripts
        playerController.Init();

        // Reset the boolean variables
        _isPause = false;
        _isGameOver = false;

        // Hide the panels
        pauseGamePanel.SetActive(false);
        endGamePanel.SetActive(false);
    }

    /// Pause the game
    private void PauseGame()
    {
        _isPause = !_isPause;
        
        // Pause the game
        if (_isPause)
        {           
            // Display the pause-game panel
            pauseGamePanel.SetActive(true);
            // Stop the movement of all objects
            SetTheMovement(0);
        }
        // Unpause the game
        else
        {
            // Hide pause-game panel
            pauseGamePanel.SetActive(false);     
            // Resume the movement of all objects
            SetTheMovement(1);
        }
    }
    public void EndGame()
    {
        Debug.Log("End Level");
        // Display the end-game panel
        endGamePanel.SetActive(true);
        // Stop the movement of all objects
        SetTheMovement(0);
    }

    private void SetTheMovement(float x)
    {
        Time.timeScale = x;
    }

}