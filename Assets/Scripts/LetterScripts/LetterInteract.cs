using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LetterInteract : MonoBehaviour
{
    public Letter letter;
    public Songbook songbook;
    private int songIndex;
    private List<Song> songs = new List<Song>();
    private List<Song> allSongs = new List<Song>();

    // Start is called before the first frame update
    void Start()
    {
        if (letter.paper != null)
        {
            GetComponent<Image>().sprite = letter.paper;
        }

        allSongs.AddRange(Resources.LoadAll<Song>("Songs"));
        HideUnowned();

        if (letter.title != "TutorialLetter")
        {
            letter.song = null;
            songIndex = Random.Range(0, songs.Count);
            letter.song = songs[songIndex];
        }

        letter.song.interval = (int)letter.song.songDuration / letter.sentences.Count;
    }
    private void HideUnowned()
    {
        for (int i = 0; i < allSongs.Count; i++)
        {
            if (allSongs[i].owned)
            {
                songs.Add(allSongs[i]);
            }
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetLetter()
    {
        letter.sentences.Clear();
        for (int i = 0; i < letter.completedSentences.Count; i++)
        {
            letter.completedSentences[i] = false;
        }
        letter.isComplete = false;
        letter.paper = null;
    }

    public void ClearCompletes()
    {
        for (int i = 0; i < letter.completedSentences.Count; i++)
        {
            letter.completedSentences[i] = false;
        }

        letter.isComplete = false;
    }

    public void GetLetterTitle()
    {
        Debug.Log(letter.title);
    }

    public void PrintSentences()
    {
        for(int i = 0; i < letter.sentences.Count; i++)
        {
            Debug.Log(letter.sentences[i]);
        }
    }

    public void SetLetterToComplete()
    {
        letter.isComplete = true;
    }

    public void SetSentenceToComplete(int index)
    {
        letter.completedSentences[index] = true;
    }

    public bool LetterStatus()
    {
        return letter.isComplete;
    }
}
