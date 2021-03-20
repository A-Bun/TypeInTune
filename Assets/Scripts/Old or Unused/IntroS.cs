using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroS : MonoBehaviour
{
    public Image boss;
    public DialogueManager manager;
    public Dialogue introDialogue1, introDialogue2;
    public GameObject introFader, intro;
    private float introAlpha;
    private bool second;

    // Start is called before the first frame update
    void Start()
    {
        boss.gameObject.SetActive(true);
        introAlpha = intro.GetComponent<Image>().color.a;
        StartCoroutine(WaitForDialogue(introDialogue1));
    }

    // Update is called once per frame
    void Update()
    {
        if (introAlpha == 1)
        {
            IntroPartOne();
            introAlpha = intro.GetComponent<Image>().color.a;
        }
        else if (introAlpha == 0 && second == false)
        {
            Debug.Log("true");
            second = true;
            IntroPartTwo();
        }
    }

    public void IntroPartOne()
    {
        if (introDialogue1.isComplete)
        {
            introFader.SetActive(true);
        }
    }

    public void IntroPartTwo()
    {
        intro.SetActive(true);
        introFader.SetActive(false);
        StartCoroutine(WaitForDialogue(introDialogue2));
    }

    IEnumerator WaitForDialogue(Dialogue dialogue)
    {
        yield return new WaitForSeconds(3f);
        StartCoroutine(BeginDialogue(dialogue));
    }

    IEnumerator BeginDialogue(Dialogue dial)
    {
        yield return null;
        manager.StartDialogue(dial);
    }
}
