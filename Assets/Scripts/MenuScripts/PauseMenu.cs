using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public static bool paused = false;
    public GameObject pauseMenu, menuButtons, quitButtons;
    public PlayerInfo player;
    public Fader fader;
    private Animator anim;
    private bool menu;

    void Start()
    {
        if (player.fader.GetCurrentLevelIndex() == 0 || player.fader.GetCurrentLevelIndex() == 3)
        {
            menu = true;
        }
        else
        {
            anim = pauseMenu.GetComponent<Animator>();
        }
    }

    /* Update
     *   Checks if the excape key was pressed, and calls a function based on the status of
     *   the "paused" boolean.
     */
    void Update()
    {
        // checks if the excape key was pressed
        if (Input.GetKeyDown("escape") && !menu)
        {
            if(paused)
            {
                Resume();
            }
            else
            {
                pauseMenu.SetActive(true);
                Pause();
            }
        }
    }

    private void ToggleButtons(GameObject gameObj, bool status)
    {
        Button[] buttons ;
        buttons = gameObj.GetComponentsInChildren<Button>();

        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = status;
        }
    }

    /* Resume
     *   Hides the pause menu, resumes the game by unfreezing time, and sets the paused
     *   to false.
     */
    public void Resume()
    {
        ToggleButtons(menuButtons, false);
        ToggleButtons(quitButtons, false);
        anim.SetBool("IsPaused", false);
        Time.timeScale = 1f;
        paused = false;
    }

    /* Pause
     *   Displays the pause menu, pauses the game by freezing time, and sets the paused
     *   boolean to true. 
     */
    void Pause()
    {
        ToggleButtons(menuButtons, true);
        ToggleButtons(quitButtons, true);
        menuButtons.SetActive(true);
        quitButtons.SetActive(false);
        anim.SetBool("IsPaused", true);
        Time.timeScale = 0f;
        paused = true;
    }

    /* Save game
     *   to be determined
     */
    public void SaveGame()
    {
        player.SaveOwnedSongs();
        player.SaveOwnedPianos();
        player.SaveCompletedDialogues();
        player.SaveCompletedLetters();

        SaveSystem.SavePlayer(player);
        Debug.Log("Saving Game...");
    }

    /* Load Game
     *   to be determined
     */
    public void LoadGame()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        if (data != null)
        {
            player.day = data.day;
            player.currMoney = data.currMoney;
            player.currScene = data.currScene;
            player.prevDayMoney = data.prevDayMoney;
            player.ownedMusic = data.ownedMusic;
            player.ownedPianos = data.ownedPianos;
            player.comDialogues = data.comDialogues;
            player.comLetters = data.comLetters;
            player.introCompleted = data.introCompleted;
            player.tutorialCompleted = data.tutorialCompleted;

            player.LoadOwnedSongs();
            player.LoadOwnedPianos();
            player.LoadCompletedDialogues();
            player.LoadCompletedLetters();
        }

        Debug.Log("Loading Game...");
    }

    /* Load Overall Game
     *   to be determined
     */
    public void LoadOverallGame()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        if (data != null)
        {
            player.day = data.day;
            player.currMoney = data.currMoney;
            player.currScene = data.currScene;
            player.ownedMusic = data.ownedMusic;
            player.ownedPianos = data.ownedPianos;
            player.comDialogues = data.comDialogues;
            player.comLetters = data.comLetters;
            player.introCompleted = data.introCompleted;
            player.tutorialCompleted = data.tutorialCompleted;

            player.LoadOwnedSongs();
            player.LoadOwnedPianos();
            player.LoadCompletedDialogues();
            player.LoadCompletedLetters();

            if (player.fader.GetCurrentLevelIndex() != player.currScene)
            {
                player.fader.FadeToLevel(player.currScene);
            }
        }
        else
        {
            Debug.LogError("There is no save file to load. Please start a new game instead.");
        }

        Debug.Log("Loading Game from Menu...");
    }

    /* Settings
     *   to be determined
     */
    public void Settings()
    {
        Debug.Log("Settings appear...");
    }

    /* Quit To Main Menu
     *   Resumes the game and then quits to the main menu through the hierarchy.
     */
    public void QuitToMainMenu()
    {
        Resume();
    }

    /* Quit To Main Menu
     *   Resumes the game and then quits to the desktop.
     */
    public void QuitToDesktop()
    {
        Resume();
        SaveGame();
        Debug.Log("Quitting Game...");
        Application.Quit();
    }
}
