using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameEnd : MonoBehaviour
{
    public TextMeshProUGUI endText;
    public Fader fader;

    private List<string> sentences = new List<string>();
    private string str1, str2, str3, str4, str5, theEnd;
    private bool status;
    private int place;

    // Start is called before the first frame update
    void Start()
    {
        str1 = "Felix and Evelyn finally rekindled their friendship after lost time.";
        str2 = "They hang out almost every day, and always tell each other when they are in need.";
        str3 = "Felix continued his job as a pianist for Mr. Martini's Bar and was loved by many.";
        str4 = "He also continued writing his letters during his shift, this time to many more people he missed.";
        str5 = "Felix was determined to right his wrongs and finally find his happiness, one way or another.";
        theEnd = "T H E  E N D";
        status = true;

        sentences.Add(str1);
        sentences.Add(str2);
        sentences.Add(str3);
        sentences.Add(str4);
        sentences.Add(str5);
        sentences.Add(theEnd);

        place = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ShowSentences();
    }

    public void ShowSentences()
    {
        for(int i = place; i < sentences.Count; i++)
        {
            if (status)
            {
                StartCoroutine(Wait(sentences[i]));
            }
        }
    }

    IEnumerator Wait(string sentence)
    {
        status = false;
        place++;
        endText.text = sentence;
        yield return new WaitForSeconds(9f);
        status = true;

        if (sentence == theEnd)
        {
            this.GetComponent<PlayerInteract>().SetGameStatus(true);
            fader.FadeToLevel(0);
        }
    }
}
