using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarIntroScript : MonoBehaviour
{
    public Image boss;
    public DialogueManager manager;
    public Dialogue introDialogue1, introDialogue2;
    public GameObject intro, textBox;
    public Animator animator;
    public bool second;
    private bool triggered, started, done;

    // Start is called before the first frame update
    void Start()
    {
        boss.gameObject.SetActive(true);
        StartCoroutine(WaitForDialogue(introDialogue1));
    }

    // Update is called once per frame
    void Update()
    {
        done = textBox.GetComponent<TextBox>().done;

        if (triggered == false)
        {
            IntroPartOne();
        }
        else if (second == true)
        {
            second = false;
            IntroPartTwo();
        }
        else if (introDialogue2.isComplete)
        {
            animator.SetTrigger("FadeEnd");
        }
    }

    public void IntroPartOne()
    {
        if (introDialogue1.isComplete && done)
        {
            triggered = true;
            animator.SetTrigger("FadeOut");
        }
    }

    public void IntroPartTwo()
    {
        intro.SetActive(true);
        if (!introDialogue2.isComplete)
        {
            animator.SetTrigger("FadeIn");
            StartCoroutine(WaitForDialogue(introDialogue2));
        }
    }

    IEnumerator WaitForDialogue(Dialogue dialogue)
    {
        yield return new WaitForSeconds(3f);
        manager.StartDialogue(dialogue);
    }

    IEnumerator BeginDialogue(Dialogue dial)
    {
        yield return null;
        manager.StartDialogue(dial);
    }
}
