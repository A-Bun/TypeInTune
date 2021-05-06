using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TMPPage : MonoBehaviour
{
    public TextMeshProUGUI letterText;
    public Button nextButton, prevButton;

    // Start is called before the first frame update
    void Start()
    {
        prevButton.gameObject.SetActive(false);
        nextButton.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        SetNextButton();
        SetPrevButton();
    }

    public void ShowNextPage()
    {
        if (letterText.pageToDisplay+1 < letterText.textInfo.pageCount)
        {
            nextButton.gameObject.SetActive(true);
            letterText.pageToDisplay++;
        }
        else if(letterText.pageToDisplay + 1 == letterText.textInfo.pageCount)
        {
            letterText.pageToDisplay++;
            nextButton.gameObject.SetActive(false);
        }
        else
        {
            nextButton.gameObject.SetActive(false);
        }
        
    }

    public void ShowPrevPage()
    {
        if (letterText.pageToDisplay-1 > 1)
        {
            prevButton.gameObject.SetActive(true);
            letterText.pageToDisplay--;
        }
        else if((letterText.pageToDisplay - 1 == 1))
        {
            prevButton.gameObject.SetActive(false);
            letterText.pageToDisplay--;
        }
        else
        {
            prevButton.gameObject.SetActive(false);
        }
    }

    public void SetNextButton()
    {
        if (letterText.pageToDisplay + 1 <= letterText.textInfo.pageCount)
        {
            nextButton.gameObject.SetActive(true);
        }
    }
    
    public void SetPrevButton()
    {
        if (letterText.pageToDisplay - 1 >= 1)
        {
            prevButton.gameObject.SetActive(true);
        }
    }
}
