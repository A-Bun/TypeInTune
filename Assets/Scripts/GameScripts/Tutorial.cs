using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Tutorial : MonoBehaviour
{
    public PlayerInteract pi;
    public GameObject personUI, blocker, songbookPanel, shopPanel, boxSB, boxShop, boxLap;
    public GameObject letter, boxLetter, textBox, fader;
    public Button songbookButton, shopButton, laptopButton, buyButton, yesButton, clockButton;
    public DialogueManager manager;
    public bool wrongTime;
    public Letter tutLetter;
    public Fader fade;
    public List<Dialogue> dialogues = new List<Dialogue>();

    private bool sbStart, sbEnd, shopStart, shopEnd, lapStart, lapEnd, dial2, dial5;
    private bool dayStart, dial6, doneSen, bought, dayEnd;
    private Image image;
    private Vector3 orgPos, botMid;
    private TypeTrackerV2 typeTrack;
    private GameObject bossImage;

    void Start()
    {
        if(pi.GetTutorialStatus())
        {
            personUI.SetActive(false);
            clockButton.onClick.AddListener(SaveToNextScene);
            gameObject.GetComponent<Tutorial>().enabled = false;
        }
        else
        {
            typeTrack = letter.GetComponent<TypeTrackerV2>();
            letter.GetComponent<LetterInteract>().letter = tutLetter;
            textBox = personUI.transform.GetChild(1).gameObject;
            bossImage = personUI.transform.GetChild(0).gameObject;
            orgPos = textBox.transform.position;
            blocker.SetActive(true);
            songbookButton.enabled = false;
            shopButton.enabled = false;
            laptopButton.enabled = false;
            buyButton.enabled = false;
            clockButton.enabled = false;
            songbookPanel.transform.GetChild(2).gameObject.SetActive(false);
            shopPanel.transform.GetChild(1).gameObject.SetActive(false);
            botMid = new Vector3(0f, -290f, 0f);
            StartCoroutine(WaitForDialogue(dialogues[0]));
        }
    }

    void Update()
    {
        if(manager.currSentence == dialogues[0].sentences[2])
        {
            boxSB.SetActive(true);
        }
        else if(manager.currSentence == dialogues[2].sentences[0])
        {
            boxShop.SetActive(true);
        }
        else if(dialogues[5].isComplete && !dayStart)
        {
            dayStart = true;
            songbookButton.enabled = true;
            laptopButton.enabled = true;
            yesButton.onClick.AddListener(HandleFirstDay);
        }    
        else if(dialogues[10].isComplete && !dayEnd)
        {
            dayEnd = true;
            bossImage.SetActive(false);
            //pi.SetTutorialStatus(true);   //ISSUE: Tutorial won't stay marked as completed unless done this way
            laptopButton.enabled = false;
            clockButton.enabled = true;
            clockButton.onClick.AddListener(EndFirstDay);
            //gameObject.GetComponent<Tutorial>().enabled = false;
        }

        if (dialogues[0].isComplete && !sbStart)
        {
            songbookButton.onClick.AddListener(HandleSongbook);
            songbookButton.enabled = true;
        }
        else if (sbEnd && !songbookPanel.activeInHierarchy && !dial2)
        {
            dial2 = true;
            ResetTextBox();
            manager.StartDialogue(dialogues[2]);
        }
        else if(dialogues[2].isComplete && !shopStart)
        {
            shopButton.onClick.AddListener(HandleShop);
            shopButton.enabled = true;
        }
        else if (shopEnd && !shopPanel.activeInHierarchy && !dial5)
        {
            dial5 = true;
            ResetTextBox();
            manager.StartDialogue(dialogues[5]);
        }

        if (sbStart && !sbEnd)
        {
            HandleSongbook();
        }
        else if(shopStart && !shopEnd)
        {
            HandleShop();
        }
        else if(lapStart && !lapEnd)
        {
            HandleFirstDay();
        }
    }

    public void Skip()
    {
        ResetTextBox();
        manager.StartDialogue(dialogues[10]);
    }

    public void HandleSongbook()
    {
        if (!sbStart)
        {
            sbStart = true;
            MoveTextBox(songbookPanel.transform, botMid);

            manager.StartDialogue(dialogues[1]);
            image = songbookPanel.transform.GetChild(0).GetComponent<Image>();
            image.enabled = true;
            boxSB.SetActive(false);
        }

        
        if (sbEnd == false)
        {
            if (manager.currSentence == dialogues[1].sentences[1])
            {
                image.enabled = false;
                image = songbookPanel.transform.GetChild(1).GetComponent<Image>();
                image.enabled = true;
            }
            else if (manager.currSentence == dialogues[1].sentences[3])
            {
                image.enabled = false;
            }

            if (dialogues[1].isComplete)
            {
                songbookButton.enabled = false;
                songbookPanel.transform.GetChild(2).gameObject.SetActive(true);
                sbEnd = true;
            }
        }
    }

    public void HandleShop()
    {
        if (!shopStart)
        {
            shopStart = true;
            MoveTextBox(shopPanel.transform, botMid);

            manager.StartDialogue(dialogues[3]);
            boxShop.SetActive(false);
            buyButton.onClick.AddListener(SaveSongDialogue);
        }

        if (shopEnd == false)
        {
            if(dialogues[3].isComplete && !bought)
            {
                bought = true;
                buyButton.enabled = true;
            }

            if (dialogues[4].isComplete)
            {
                shopPanel.transform.GetChild(1).gameObject.SetActive(true);
                shopEnd = true;
            }
        }
    }

    public void HandleFirstDay()
    {
        if (!lapStart)
        {
            lapStart = true;
            MoveTextBox(fader.transform, botMid);

            manager.StartDialogue(dialogues[6]);
            boxLetter.SetActive(true);
        }

        if (lapEnd == false)
        {
            if (dialogues[6].isComplete && !dial6)
            {
                dial6 = true;
                boxLetter.SetActive(false);
                typeTrack.pause = false;
            }

            if(typeTrack.typedChars.Length == 2)
            {
                typeTrack.typedChars = "done";
                typeTrack.pause = true;
                manager.StartDialogue(dialogues[7]);
            }

            if(dialogues[7].isComplete && !typeTrack.wrongToRight)
            {
                wrongTime = true;
                typeTrack.pause = false;
            }

            if (dialogues[8].isComplete && !doneSen)
            {
                doneSen = true;
                typeTrack.pause = false;
            }

            if (manager.currDialogue == dialogues[9] && !dialogues[9].isComplete)
            {
                typeTrack.pause = true;
            }

            if(letter.activeInHierarchy == false)
            {
                lapEnd = true;
                ResetTextBox();
                manager.StartDialogue(dialogues[10]);
            }
        }
    }

    public void EndFirstDay()
    {
        pi.SetTutorialStatus(true);     //ISSUE: I need tutorial to stay marked as completed when done this way
        SaveToNextScene();
    }

    public void SaveToNextScene()
    {
        fade.FadeToNextLevel();
    }

    private void SaveSongDialogue()
    {
        buyButton.gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "SOLD";
        buyButton.enabled = false;
        manager.StartDialogue(dialogues[4]);
    }

    public void MoveTextBox(Transform newParent, Vector3 newPos)
    {
        textBox.transform.SetParent(newParent);
        textBox.GetComponent<RectTransform>().localPosition = newPos;
    }

    public void ResetTextBox()
    {
        textBox.transform.SetParent(personUI.transform);
        textBox.transform.position = orgPos;
    }

    IEnumerator WaitForDialogue(Dialogue dialogue)
    {
        yield return new WaitForSeconds(3f);
        manager.StartDialogue(dialogue);
    }
}
