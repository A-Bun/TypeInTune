using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TypeTrackerV2 : MonoBehaviour
{
    public TextMeshProUGUI originalLetter = null;
    public Image wrong;
    public bool pause;
    public int numMistakes;
    
    public LetterInteract letIn;
    private List<string> remainingWords = new List<string>();
    private List<string> fullLetter = new List<string>();
    private int sentenceIndex, charIndex;


    // Start is called before the first frame update
    void Start()
    {
        letIn = GetComponent<LetterInteract>();
        pause = false;
        wrong.gameObject.SetActive(false);
        sentenceIndex = 0;
        charIndex = 0;
        numMistakes = 0;
        originalLetter.richText = true;
        fullLetter = letIn.letter.sentences;
        SetCurrentWords();
    }

    // Update is called once per frame
    void Update()
    {
        if (!letIn.LetterStatus() && !pause)
        {
            CheckInput();
        }
    }

    private void SetCurrentWords()
    {
        SetRemainingWords(fullLetter);
    }

    private void SetRemainingWords(List<string> newString)
    {
        remainingWords = newString;
        for (int i = 0; i < remainingWords.Count; i++)
        {
            // assumes separating space is already included in sentence (NO newlines!!)
            originalLetter.text = originalLetter.text + remainingWords[i];
        }
    }

    private void CheckInput()
    {
        if (Input.anyKeyDown)
        {
            string keysPressed = Input.inputString;

            if (keysPressed.Length == 1)
            {
                EnterChar(keysPressed);
            }
        }
    }

    private void EnterChar(string typedChar)
    {
        List<string> tempStr = fullLetter;
        int tempIndex = charIndex;
        bool ignore = false;

        if (IsCorrectChar(typedChar))
        {
            originalLetter.text = "<color=green>" + tempStr[0][0] + "</color>";

            if (sentenceIndex == 0 && charIndex == 0)
            {
                originalLetter.text = originalLetter.text + "<color=red>" + tempStr[0][1] + "</color>";

                for (int i = sentenceIndex; i < tempStr.Count; i++)
                {
                    if (i > 0)
                    {
                        originalLetter.text = originalLetter.text + tempStr[i][0];
                    }
                    for (int j = 1; j < tempStr[i].Length; j++)
                    {
                        if (!(i == 0 && j == 1))
                        {
                            originalLetter.text = originalLetter.text + tempStr[i][j];
                        }
                    }

                }
            }
            else
            {
                for (int i = 0; i < sentenceIndex + 1; i++)
                {
                    if (i > 0)
                    {
                        originalLetter.text = originalLetter.text + "<color=green>" + tempStr[i][0] + "</color>";
                    }
                    if (i == sentenceIndex)
                    {
                        for (int j = 1; j < charIndex + 1; j++)
                        {
                            originalLetter.text = originalLetter.text + "<color=green>" + tempStr[i][j] + "</color>";
                        }
                    }
                    else
                    {
                        for (int j = 1; j < tempStr[i].Length; j++)
                        {
                            originalLetter.text = originalLetter.text + "<color=green>" + tempStr[i][j] + "</color>";
                        }
                    }
                }

                if (tempIndex + 1 != tempStr[sentenceIndex].Length)
                {
                    originalLetter.text = originalLetter.text + "<color=red>" + tempStr[sentenceIndex][tempIndex + 1] + "</color>";
                }
                else if(sentenceIndex+1 != fullLetter.Count)
                {
                    originalLetter.text = originalLetter.text + "<color=red>" + tempStr[sentenceIndex+1][0] + "</color>";
                    ignore = true;
                }

                for (int i = sentenceIndex; i < tempStr.Count; i++)
                {
                    for (int j = tempIndex + 1; j < tempStr[i].Length; j++)
                    {
                        if(ignore)
                        {
                            ignore = false;
                            continue;
                        }
                        else if (!(i == sentenceIndex && j == tempIndex + 1))
                        {
                            originalLetter.text = originalLetter.text + tempStr[i][j];
                        }
                    }

                    tempIndex = -1;
                }
            }



            if (IsLetterComplete())
            {
                letIn.SetLetterToComplete();
                Debug.Log("end!");
            }
            else
            {
                charIndex++;
                if (charIndex == tempStr[sentenceIndex].Length)
                {
                    letIn.SetSentenceToComplete(sentenceIndex);
                    sentenceIndex++;
                    charIndex = 0;
                }
            }
        }
    }

    private bool IsCorrectChar(string charToCheck)
    {
        bool status;
        string temp = "" + remainingWords[sentenceIndex][charIndex];

        if (temp == charToCheck)
        {
            status = true;
            wrong.gameObject.SetActive(false);
        }
        else
        {
            status = false;
            wrong.gameObject.SetActive(true);
            numMistakes++;
        }

        return status;
    }

    private bool IsLetterComplete()
    {
        bool status;

        if (remainingWords.Count - 1 == sentenceIndex && remainingWords[sentenceIndex].Length - 1 == charIndex)
        {
            status = true;
            letIn.SetSentenceToComplete(sentenceIndex);
            sentenceIndex = 0;
            charIndex = 0;
        }
        else
        {
            status = false;
        }

        return status;
    }
}
