using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Canvas")]
    [SerializeField] private Canvas startCanvas;
    [SerializeField] private Canvas gameCanvas;
    [SerializeField] private GameObject startMenu;
    [SerializeField] private GameObject tutorialMenu;
    [SerializeField] private TextMeshProUGUI narrationText;
    [SerializeField] private float narrationShowTime = 3f;
    [SerializeField] private TextMeshProUGUI questText;
    [SerializeField] private GameObject pauseMenu;
    [Header("Cameras")]
    [SerializeField]private GameObject mainCamera;
    [SerializeField]private GameObject startCamera;
    [Header("Quests")]
    [SerializeField] private Quest[] quests;
    Quest activeQuest;
    private bool gameStarted = false;
    private bool gameCompleted = false;
    private bool gamePaused = false;

    private FPLook myPlayerFPLook;

    void Update()
    {
        if(gameStarted)
        {
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                pauseMenu.SetActive(!pauseMenu.activeInHierarchy);
                gamePaused = pauseMenu.activeInHierarchy;

                if(gamePaused)
                {
                    Cursor.lockState = CursorLockMode.Confined;
                    Cursor.visible = true; 
                }
                else
                {
                    Cursor.lockState = CursorLockMode.Locked;
                    Cursor.visible = false; 
                }
            }

            if(gamePaused)
                return;

            if(!gameCompleted)
            {
                updateQuestText(activeQuest.description);
                if(activeQuest.isCompleted())
                    getNextQuest();
            }
        }
    }

    IEnumerator StartGame()
    {
        startCanvas.gameObject.SetActive(false);
        startCamera.SetActive(false);
        mainCamera.SetActive(true);
        myPlayerFPLook = FindObjectOfType<FPLook>();
        myPlayerFPLook.LookEnabled = false;
        yield return new WaitForSeconds(2.5f);
        gameCanvas.gameObject.SetActive(true);
        myPlayerFPLook.LookEnabled = true;
        getNextQuest();
        gameStarted = true;
    }

    public void updateNarration(string text)
    {
        StartCoroutine(updateNarrationText(text));
    }

    IEnumerator updateNarrationText(string text)
    {
        narrationText.text = text;
        yield return new WaitForSeconds(narrationShowTime);
        narrationText.text = null;
    }
    public void updateQuestText(string text)
    {
        questText.text = text;
    }

    private void getNextQuest()
    {
        foreach(Quest quest in quests)
        {
            if(!quest.isCompleted()){
                activeQuest = quest;
                activeQuest.startQuest();
                updateNarration(activeQuest.narration);
                break;
            }
        }

        if(activeQuest.isCompleted())
        {
            gameCompleted = true;
            updateQuestText("Merry Christmas");
        }
    }

    public void startGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false; 
        StartCoroutine(StartGame());
    }

    public void quitGame()
    {
        Application.Quit();
    }
    public bool IsPaused
    {
        get
        {
            return gamePaused;
        }
        set
        {
            Time.timeScale = value ? 0 : 1;
            gamePaused = value;
        }
    }

    public void toMainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void openTutorial()
    {
        startMenu.SetActive(false);
        tutorialMenu.SetActive(true);
    }

    public void openStartMenu()
    {
        startMenu.SetActive(true);
        tutorialMenu.SetActive(false);
    }
}
