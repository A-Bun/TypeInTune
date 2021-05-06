using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfo : MonoBehaviour
{
    public int day;
    public int currMoney;
    public int prevDayMoney;
    public int currScene;
    public List<string> ownedMusic;
    public List<string> ownedPianos;
    public List<string> comDialogues;
    public List<string> comLetters;
    public bool introCompleted;
    public bool tutorialCompleted;
    public bool gameCompleted;
    public Fader fader;

    private List<Song> allMusic;
    private List<Image> allPianos;
    private List<Dialogue> allDialogues;
    private List<Letter> allLetters;

    void Update()
    {
        currScene = fader.GetCurrentLevelIndex();
    }

    // Make functions that load all completed dialogues, completed letters, owned songs, and owned pianos
    //      from the resources folder.
    // Call these functions when SaveGame() is called to save them into these list variables.
    // Call these functions when LoadGame() is called to overwrite the things in the resources folder.

    public void SaveOwnedSongs()
    {
        // casts each song to an object and loads it into an object array
        object[] songObj = Resources.LoadAll("Songs", typeof(Song));

        allMusic = new List<Song>();
        for (int i = 0; i < songObj.Length; i++)
        {
            // casts the song objects back to songs and adds it to song array
            allMusic.Add((Song)songObj[i]);

            if (allMusic[i].owned && !ownedMusic.Contains(allMusic[i].songTitle))
            {
                ownedMusic.Add(allMusic[i].songTitle);
            }
        }
    }

    public void LoadOwnedSongs()
    {
        // casts each song to an object and loads it into an object array
        object[] songObj = Resources.LoadAll("Songs", typeof(Song));

        allMusic = new List<Song>();
        for (int i = 0; i < songObj.Length; i++)
        {
            // casts the song objects back to songs and adds it to song array
            allMusic.Add((Song)songObj[i]);

            if(ownedMusic.Contains(allMusic[i].songTitle))
            {
                allMusic[i].owned = true;
            }
            else
            {
                allMusic[i].owned = false;
            }
        }
    }

    public void SaveOwnedPianos()
    {
        // to be determined...
    }

    public void LoadOwnedPianos()
    {
        // to be determined...
    }

    public void SaveCompletedDialogues()
    {
        // casts each dialogue to an object and loads it into an object array
        object[] dialObj = Resources.LoadAll("Dialogues", typeof(Dialogue));

        allDialogues = new List<Dialogue>();
        for (int i = 0; i < dialObj.Length; i++)
        {
            // casts the dialogue objects back to dialogues and adds it to dialogue array
            allDialogues.Add((Dialogue)dialObj[i]);

            if (allDialogues[i].isComplete && !comDialogues.Contains(allDialogues[i].name))
            {
                comDialogues.Add(allDialogues[i].name);
            }
        }
    }

    public void LoadCompletedDialogues()
    {
        // casts each dialogue to an object and loads it into an object array
        object[] dialObj = Resources.LoadAll("Dialogues", typeof(Dialogue));

        allDialogues = new List<Dialogue>();
        for (int i = 0; i < dialObj.Length; i++)
        {
            // casts the dialogue objects back to dialogues and adds it to dialogue array
            allDialogues.Add((Dialogue)dialObj[i]);

            if (comDialogues.Contains(allDialogues[i].name))
            {
                allDialogues[i].isComplete = true;
            }
            else
            {
                allDialogues[i].isComplete = false;
            }
        }
    }

    public void SaveCompletedLetters()
    {
        // casts each letter to an object and loads it into an object array
        object[] letterObj = Resources.LoadAll("Letters", typeof(Letter));

        allLetters = new List<Letter>();
        for (int i = 0; i < letterObj.Length; i++)
        {
            // casts the letter objects back to letters and adds it to letter array
            allLetters.Add((Letter)letterObj[i]);

            if (allLetters[i].isComplete && !comLetters.Contains(allLetters[i].title))
            {
                comLetters.Add(allLetters[i].title);
            }
        }
    }

    public void LoadCompletedLetters()
    {
        // casts each letter to an object and loads it into an object array
        object[] letterObj = Resources.LoadAll("Letters", typeof(Letter));

        allLetters = new List<Letter>();
        for (int i = 0; i < letterObj.Length; i++)
        {
            // casts the letter objects back to letters and adds it to letter array
            allLetters.Add((Letter)letterObj[i]);

            if (comLetters.Contains(allLetters[i].title))
            {
                for (int j = 0; j < allLetters[i].completedSentences.Count; j++)
                {
                    allLetters[i].completedSentences[j] = true;
                }
                allLetters[i].isComplete = true;
            }
            else
            {
                for(int j = 0; j < allLetters[i].completedSentences.Count; j++)
                {
                    allLetters[i].completedSentences[j] = false;
                }
                allLetters[i].isComplete = false;
            }
        }
    }

    public void ResetSongs()
    {
        string title;

        // casts each song to an object and loads it into an object array
        object[] songObj = Resources.LoadAll("Songs", typeof(Song));

        allMusic = new List<Song>();
        for (int i = 0; i < songObj.Length; i++)
        {
            // casts the song objects back to songs and adds it to song array
            allMusic.Add((Song)songObj[i]);

            allMusic[i].timesPlayed = 0;
            allMusic[i].totalMistakes = 0;
            allMusic[i].totalMoney = 0;

            title = allMusic[i].songTitle;

            if (title == "Twinkle Twinkle Little Star" || title == "Cerberus Fossae" ||
                title == "Anna's Hummingbird" || title == "Prelude in E minor")
            {
                allMusic[i].owned = true;
            }
            else
            {
                allMusic[i].owned = false;
            }
        }
    }

    public void ResetPianos()
    {
        // to be determined...
    }

    public void ResetDialogues()
    {
        // casts each dialogue to an object and loads it into an object array
        object[] dialObj = Resources.LoadAll("Dialogues", typeof(Dialogue));

        allDialogues = new List<Dialogue>();
        for (int i = 0; i < dialObj.Length; i++)
        {
            // casts the dialogue objects back to dialogues and adds it to dialogue array
            allDialogues.Add((Dialogue)dialObj[i]);

            allDialogues[i].isComplete = false;
        }
    }

    public void ResetLetters()
    {
        // casts each letter to an object and loads it into an object array
        object[] letterObj = Resources.LoadAll("Letters", typeof(Letter));

        allLetters = new List<Letter>();
        for (int i = 0; i < letterObj.Length; i++)
        {
            // casts the letter objects back to letters and adds it to letter array
            allLetters.Add((Letter)letterObj[i]);

            for (int j = 0; j < allLetters[i].completedSentences.Count; j++)
            {
                allLetters[i].completedSentences[j] = false;
            }
            allLetters[i].isComplete = false;
        }
    }
}
