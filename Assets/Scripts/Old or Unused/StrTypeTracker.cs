using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StrTypeTracker : MonoBehaviour
{
    public Text originalLetter = null;

    private string remainingWords;
    private string currentWords = "test";
    private int index;

    // Start is called before the first frame update
    void Start()
    {
        SetCurrentWords();
        index = 0;
        originalLetter.supportRichText = true;
    }

    // Update is called once per frame
    void Update()
    {
        CheckInput();
    }

    private void SetCurrentWords()
    {
        SetRemainingWords(currentWords);
    }

    private void SetRemainingWords(string newString)
    {
        remainingWords = newString;
        originalLetter.text = remainingWords;
    }

    private void CheckInput()
    {
        if(Input.anyKeyDown)
        {
            string keysPressed = Input.inputString;

            if(keysPressed.Length == 1)
            {
                EnterChar(keysPressed);
            }
        }
    }

    private void EnterChar(string typedChar)
    {
        string temp = currentWords;

        if(IsCorrectChar(typedChar))
        {
            originalLetter.text = "<color=red>" + temp[0] + "</color>";

            if (index == 0)
            {
                for (int i = 1; i < temp.Length; i++)
                {
                    originalLetter.text = originalLetter.text + temp[i];
                }
            }
            else
            {
                for (int i = 1; i < index+1; i++)
                {
                    originalLetter.text = originalLetter.text + "<color=red>" + temp[i] + "</color>";
                }
                for (int i = index+1; i < temp.Length; i++)
                {
                    originalLetter.text = originalLetter.text + temp[i];
                }
            }

            index++;

            if(IsLetterComplete())
            {
                SetCurrentWords();
            }
        }
    }

    private bool IsCorrectChar(string charToCheck)
    {
        bool status;
        string temp = "" + remainingWords[index];

        if(temp == charToCheck)
        {
            status = true;
        }
        else
        {
            status = false;
        }

        return status;
    }

    private bool IsLetterComplete()
    {
        bool status;

        if (remainingWords.Length == index)
        {
            status = true;
            index = 0;
        }
        else
        {
            status = false;
        }

        return status;
    }
}
