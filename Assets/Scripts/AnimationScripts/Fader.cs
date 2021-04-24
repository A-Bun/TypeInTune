using UnityEngine;
using UnityEngine.SceneManagement;

public class Fader : MonoBehaviour
{
    public Animator animator;
    public PauseMenu pauseMenu;
    private int levelToLoad;

    void OnEnable()
    {
        //Tell our 'OnLevelFinishedLoading' function to start listening for a scene change as soon as this script is enabled.
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

    void OnDisable()
    {
        //Tell our 'OnLevelFinishedLoading' function to stop listening for a scene change as soon as this script is disabled. Remember to always have an unsubscription for every delegate you subscribe to!
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }

    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        if (GetCurrentLevelIndex() != 0)
        {
            pauseMenu.LoadGame();
        }
    }

    //void Start()
    //{
    //    SceneManager.sceneLoaded += OnSceneLoaded;
    //}

    //private void OnLevelWasLoaded(int level)
    //{
    //    pauseMenu.LoadGame();
    //}

    //public void OnSceneLoaded(Scene aScene, LoadSceneMode aMode)
    //{
    //    pauseMenu.LoadGame();
    //}

    /* Fade To Next Level 
     *   Fades to the next level in the scene manager.
     */
    public void FadeToNextLevel()
    {
        FadeToLevel(SceneManager.GetActiveScene().buildIndex + 1);
    }

    /* Fade To Level
     *   Parameter: int levelIndex
     *   Saves the passed in level index for later use and triggers the "FadeOut"
     *   animation.
     */
    public void FadeToLevel(int levelIndex)
    {
        levelToLoad = levelIndex;
        if (GetCurrentLevelIndex() != 0)
        {
            pauseMenu.SaveGame();
        }
        animator.SetTrigger("FadeOut");
    }

    /* On Fade Complete
     *   Loads the previously saved level index in the scene manager once the 
     *   "FadeOut" animation is completed.
     */
    public void OnFadeComplete()
    {
        SceneManager.LoadScene(levelToLoad);
    }

    public int GetCurrentLevelIndex()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }
}
