using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class LetterPicker : MonoBehaviour
{
    public PlayerInfo player;
    public GameObject letInt;
    public Button laptop, clockButton;
    
    private LetterInteract letterInteract;
    private List<Letter> allLetters;
    private string tutLetter = "TutorialLetter";
    private Letter firstLetter, secLetter, thirdLetter;
    private bool first, second;

    void Start()
    {
        clockButton.enabled = false;
        letterInteract = letInt.GetComponent<LetterInteract>();
        LoadLetters();

        if (!player.tutorialCompleted)
        {
            SetLetterInteract(FindLetter(tutLetter));
        }
        else
        {
            laptop.enabled = true;
            FindTodaysLetters();
        }
    }

    void Update()
    {
        if (player.day > 0)
        {
            ChangeLetters();
        }

        if(thirdLetter != null && thirdLetter.isComplete)
        {
            laptop.enabled = false;
            clockButton.enabled = true;
        }
        else if(player.day == 4 && !FindLetter("Letter10").isComplete)
        {
            clockButton.enabled = false;
        }
        else if(player.day == 4 && FindLetter("Letter10").isComplete)
        {
            clockButton.enabled = true;
        }
        else if (player.day != 5 && player.day != 0 && thirdLetter == null)
        {
            clockButton.enabled = true;
        }
    }

    public void LoadLetters()
    {
        object[] letterObj = Resources.LoadAll("Letters", typeof(Letter));

        allLetters = new List<Letter>();
        for (int i = 0; i < letterObj.Length; i++)
        {
            // casts the letter objects back to letters and adds it to letter array
            allLetters.Add((Letter)letterObj[i]);
        }
    }

    public Letter FindLetter(string toFind)
    {
        Letter foundLetter = null;

        for (int i = 0; i < allLetters.Count; i++)
        {
            if(allLetters[i].title == toFind)
            {
                foundLetter = allLetters[i];
            }
        }

        return foundLetter;
    }

    public void FindTodaysLetters()
    {
        int stringInt;
        string lastComLetter, findLetter, temp;
        lastComLetter = player.comLetters[player.comLetters.Count-1];

        if(lastComLetter == tutLetter)
        {
            findLetter = "Letter1";
        }
        else
        {
            stringInt = (int.Parse(lastComLetter.Substring(6)) + 1);
            findLetter = "Letter" + stringInt.ToString();
        }

        firstLetter = FindLetter(findLetter);
        SetLetterInteract(firstLetter);

        stringInt = (int.Parse(findLetter.Substring(6)) + 1);
        temp = "Letter" + stringInt.ToString();

        secLetter = FindLetter(temp);

        stringInt = (int.Parse(temp.Substring(6)) + 1);
        temp = "Letter" + stringInt.ToString();

        thirdLetter = FindLetter(temp);
    }

    public void ChangeLetters()
    {
        if(firstLetter != null && firstLetter.isComplete && secLetter != null && !first)
        {
            if (!letInt.GetComponent<AudioSource>().isPlaying)
            {
                first = true;
                SetLetterInteract(secLetter);
                letterInteract.PickRandomSong();
                while (letterInteract.letter.song.songTitle == "Twinkle Twinkle Little Star")
                {
                    letterInteract.PickRandomSong();
                }

                letInt.GetComponent<SongInteract>().newSong = true;
            }
        }
        else if(secLetter != null && secLetter.isComplete && thirdLetter != null && !second)
        {
            if(!letInt.GetComponent<AudioSource>().isPlaying)
            {
                second = true;
                SetLetterInteract(thirdLetter);
                letterInteract.PickRandomSong();
                while (letterInteract.letter.song.songTitle == "Twinkle Twinkle Little Star")
                {
                    letterInteract.PickRandomSong();
                }

                letInt.GetComponent<SongInteract>().newSong = true;
            }
        }
    }

    public void SetLetterInteract(Letter toSet)
    {
        letterInteract.letter = toSet;
    }

}
