using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Ending : MonoBehaviour
{
    public PlayerInteract player;
    public Letter letter10, herLetter;
    public AudioSource audioSource;
    public DialogueManager manager;
    public Button yesButton, nextButton, closeButton, clockButton;
    public GameObject personUI, envelope, blocker;
    public TextMeshProUGUI letterText;
    public Fader fader;
    public Sprite evelyn;
    public List<Dialogue> dialogues = new List<Dialogue>();

    private bool yesDisabled, day5, hers, gameEnd;
    private GameObject bossImage;
    private int num;

    // Start is called before the first frame update
    void Start()
    {
        personUI.SetActive(true);
        bossImage = personUI.transform.GetChild(0).gameObject;
        envelope.SetActive(false);
        num = -1;
        letterText.text = "";
        closeButton.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (letter10.isComplete && !audioSource.isPlaying && !yesDisabled && player.GetDay() == 4)
        {
            yesDisabled = true;
            yesButton.enabled = false;
            blocker.SetActive(true);
            StartCoroutine(WaitForDialogue(dialogues[0]));
        }

        if (player.GetDay() == 5 && !day5)
        {
            day5 = true;
            bossImage.SetActive(true);
            yesButton.enabled = false;
            clockButton.enabled = false;
            StartCoroutine(WaitForDialogue(dialogues[1]));
        }
        
        if(dialogues[1].isComplete && !herLetter.isComplete)
        {
            bossImage.SetActive(false);
        }
        
        if (manager.currSentence == dialogues[1].sentences[2])
        {
            envelope.SetActive(true);
        }

        if(herLetter.isComplete && closeButton.gameObject.activeInHierarchy == false && !hers)
        {
            hers = true;
            bossImage.GetComponent<Image>().sprite = evelyn;
            bossImage.SetActive(true);
            StartCoroutine(WaitForDialogue(dialogues[2]));
        }

        if(dialogues[2].isComplete && !gameEnd)
        {
            gameEnd = true;
            fader.FadeToLevel(4);
        }
    }

    public void StartEnding()
    {
        DisplayNextLine();
    }

    public void DisplayNextLine()
    {
        num++;
        if(num == herLetter.sentences.Count-1)
        {
            string line = herLetter.sentences[num];

            nextButton.gameObject.SetActive(false);
            StartCoroutine(Wait(line));
        }
        else if (num < herLetter.sentences.Count)
        {
            string line = herLetter.sentences[num];

            StopAllCoroutines();
            StartCoroutine(TypeSentence(line));
        }
        else
        {
            nextButton.gameObject.SetActive(false);
        }
    }

    IEnumerator WaitForDialogue(Dialogue dialogue)
    {
        yield return new WaitForSeconds(3f);
        manager.StartDialogue(dialogue);
    }

    IEnumerator TypeSentence(string sentence)
    {
        nextButton.enabled = false;
        for (int i = 0; i < sentence.Length; i++)
        {
            letterText.text += sentence[i];
            yield return new WaitForSeconds(0.05f);
        }
        nextButton.enabled = true;
        herLetter.completedSentences[num] = true;
    }

    IEnumerator Wait(string sentence)
    {
        nextButton.enabled = false;
        yield return new WaitForSeconds(2f);
        StartCoroutine(TypeSentence(sentence));
        nextButton.enabled = true;
        closeButton.gameObject.SetActive(true);
        herLetter.isComplete = true;
    }
}
