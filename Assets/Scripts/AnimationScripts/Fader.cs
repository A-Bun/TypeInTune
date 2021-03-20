using UnityEngine;
using UnityEngine.SceneManagement;

public class Fader : MonoBehaviour
{
    public Animator animator;
    private int levelToLoad;

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
