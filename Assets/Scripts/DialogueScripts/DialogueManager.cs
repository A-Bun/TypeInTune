using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    private Queue<string> sentences;
    private bool isTextBox;
    private string prevSentence;
    public Dialogue currDialogue;
    public TextMeshProUGUI dialogueText;
    public Image textBox;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        if (textBox != null)
        {
            textBox.gameObject.SetActive(false);
            isTextBox = true;
        }

        prevSentence = dialogueText.text;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartDialogue(Dialogue dialogue)
    {
        currDialogue = dialogue;
        sentences.Clear();

        if (isTextBox)
        {
            textBox.gameObject.SetActive(true);
            animator.SetBool("IsOpen", true);
        }

        for(int i = 0; i < dialogue.sentences.Length; i++)
        {
            sentences.Enqueue(dialogue.sentences[i]);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        string sentence;
        if (dialogueText.text != prevSentence)
        {
            StopAllCoroutines();
            dialogueText.text = prevSentence;
        }
        else
        {
            if (sentences.Count == 0)
            {
                EndDialogue();
                return;
            }

            sentence = sentences.Dequeue();
            StopAllCoroutines();
            StartCoroutine(TypeSentence(sentence));
        }
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        prevSentence = sentence;

        for (int i = 0; i < sentence.Length; i++)
        {
            dialogueText.text += sentence[i];
            yield return new WaitForSeconds(0.05f);
        }
    }

    private void EndDialogue()
    {
        Debug.Log("End of convo");
        
        if (isTextBox)
        {
            animator.SetBool("IsOpen", false);
        }

        currDialogue.isComplete = true;
    }
}
