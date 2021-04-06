using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Tutorial : MonoBehaviour
{
    public Player player;
    public GameObject personUI, blocker, songbookPanel, shopPanel, boxSB, boxShop, boxLap;
    public Button songbookButton, shopButton, laptopButton, buyButton;
    public DialogueManager manager;
    public List<Dialogue> dialogues = new List<Dialogue>();
    private bool sbStart, sbEnd, shopStart, shopEnd, lapStart, lapEnd, dial2, dial5, dayStart;
    private Image image;
    private GameObject textBox;
    private Vector3 orgPos, pos;

    void Start()
    {
        if(player.tutorialCompleted)
        {
            gameObject.GetComponent<Tutorial>().enabled = false;
        }
        else
        {
            textBox = personUI.transform.GetChild(1).gameObject;
            orgPos = textBox.transform.position;
            blocker.SetActive(true);
            songbookButton.enabled = false;
            shopButton.enabled = false;
            laptopButton.enabled = false;
            buyButton.enabled = false;
            songbookPanel.transform.GetChild(3).gameObject.SetActive(false);
            shopPanel.transform.GetChild(1).gameObject.SetActive(false);
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
            laptopButton.onClick.AddListener(HandleFirstDay);
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
    }

    public void HandleSongbook()
    {
        GameObject temp = songbookPanel.transform.GetChild(2).gameObject;

        if (!sbStart)
        {
            sbStart = true;
            pos = new Vector3(0f, 0f, 0f);
            MoveTextBox(songbookPanel.transform, pos);

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
            else if (manager.currSentence == dialogues[1].sentences[4])
            {
                image.enabled = false;
                temp.SetActive(true);
            }

            if (dialogues[1].isComplete)
            {
                temp.SetActive(false);
                songbookButton.enabled = false;
                songbookPanel.transform.GetChild(3).gameObject.SetActive(true);
                sbEnd = true;
            }
        }
    }

    public void HandleShop()
    {
        if (!shopStart)
        {
            shopStart = true;
            pos = new Vector3(0f, 0f, 0f);
            MoveTextBox(shopPanel.transform, pos);

            manager.StartDialogue(dialogues[3]);
            boxShop.SetActive(false);
            buyButton.onClick.AddListener(SaveSongDialogue);
        }

        if (shopEnd == false)
        {
            if(dialogues[3].isComplete)
            {
                buyButton.enabled = true;
            }

            if (dialogues[4].isComplete)
            {
                buyButton.enabled = false;
                shopPanel.transform.GetChild(1).gameObject.SetActive(true);
                shopEnd = true;
            }
        }
    }

    public void HandleFirstDay()
    {

    }

    private void SaveSongDialogue()
    {
        buyButton.gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "SOLD";
        manager.StartDialogue(dialogues[4]);
    }

    public void MoveTextBox(Transform newParent, Vector3 newPos)
    {
        textBox.transform.SetParent(newParent);
        textBox.transform.position = newPos;
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
