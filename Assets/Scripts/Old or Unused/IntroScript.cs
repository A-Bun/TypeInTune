using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroScript : MonoBehaviour
{
    public Image boss;
    public DialogueManager manager;
    public Dialogue introDialogue;
    public Fader fader;

    // Start is called before the first frame update
    void Start()
    {
        boss.gameObject.SetActive(true);
        StartCoroutine(WaitForDialogue());
    }

    // Update is called once per frame
    void Update()
    {
        EndIntro();
    }

    IEnumerator WaitForDialogue()
    {
        yield return new WaitForSeconds(3f);
        manager.StartDialogue(introDialogue);
    }

    public void EndIntro()
    {
        if(introDialogue.isComplete)
        {
            fader.FadeToNextLevel();
        }
    }
}
