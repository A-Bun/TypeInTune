using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    public Player player;
    public GameObject personUI, blocker, songbookPanel, shopPanel, boxSB, boxShop, boxLap;
    public Button songbookButton, shopButton, laptop;
    public DialogueManager manager;
    public Sprite redBox;
    public List<Dialogue> dialogues = new List<Dialogue>();
    private bool sbStart, sbEnd, shopStart, shopEnd, lapStart, lapEnd;
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
            laptop.enabled = false;
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
        //else if(manager.currSentence == dialogues[2].sentences[0])

        if (dialogues[0].isComplete && !sbStart)
        {
            songbookButton.onClick.AddListener(HandleSongbook);
            songbookButton.enabled = true;
        }
        //else if (sbEnd && !songbookPanel.activeInHierarchy && !shopStart)
        //{
        //    ResetTextBox();
        //    manager.StartDialogue(dialogues[2]);
        //}

        if (sbStart && !sbEnd)
        {
            HandleSongbook();
        }
    }

    public void HandleSongbook()
    {
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
                songbookPanel.transform.GetChild(2).gameObject.SetActive(true);
            }

            if (dialogues[1].isComplete)
            {
                songbookPanel.transform.GetChild(3).gameObject.SetActive(true);
                sbEnd = true;
            }
        }
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
