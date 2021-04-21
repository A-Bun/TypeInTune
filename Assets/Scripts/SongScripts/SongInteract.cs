using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SongInteract : MonoBehaviour
{
    private Song song;
    private AudioSource audioS;
    private float currTime, interval;
    private int salary, index, currMins, currSecs, ten, sixty;
    private TypeTrackerV2 ttv2;
    private bool waitToEnd, tutComp, dial9;
    private TextMeshProUGUI tempText;
    private Tutorial tutorial;

    public GameObject blocker, songInfo, errorInfo;
    public PlayerInteract pi;

    // Start is called before the first frame update
    void Start()
    {
        blocker.SetActive(true);
        ttv2 = gameObject.GetComponent<TypeTrackerV2>();
        song = ttv2.letIn.letter.song;
        audioS = GetComponent<AudioSource>();
        audioS.clip = song.songAudio;
        audioS.Stop();
        salary = song.songSalary[0];
        song.songDuration = song.songAudio.length;
        currTime = 0;
        index = 0;
        //interval = (song.songDuration / ttv2.letIn.letter.interval);
        interval = song.interval;
        waitToEnd = false;
        ten = 10;
        sixty = 60;
        songInfo.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = song.songTitle;
        tempText = songInfo.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        songInfo.SetActive(true);
        errorInfo.SetActive(true);
        
    }

    // Update is called once per frame
    void Update()
    {
        tutComp = ttv2.tutComplete;
        tutorial = ttv2.tut;
        blocker.SetActive(true);

        if (tutComp)
        {
            UpdateSalary();
        }
        PlayOrPause();
        SetSongbook();

        if (waitToEnd)
        {
            EndSong();
        }
    }

    public int NumMistakes()
    {
        return ttv2.numMistakes;
    }

    public void UpdateSalary()
    {
        int id = 0;

        for(int i = 0; i < song.salaryMarks.Count; i++)
        {
            if(NumMistakes() >= song.salaryMarks[i])
            {
                id = i;
            }
            else
            {
                break;
            }

        }

        salary = song.songSalary[id];
    }

    public void PlayOrPause()
    {
        if(!ttv2.letIn.letter.isComplete)
        {
            Check();
        }
        else
        {
            PauseClip(true);
            waitToEnd = true;
        }
    }

    public void Check()
    {
        if (ttv2.letIn.letter.completedSentences[index] == true)
        {
            ttv2.pause = true;
            index++;
            PlayClip();
        }

        PauseClip(false);
    }

    public void PlayClip()
    {
        audioS.Play();
    }

    public void PauseClip(bool complete)
    {
        if (complete)
        {
            audioS.UnPause();
        }
        else if (audioS.time >= (currTime + interval))
        {
            audioS.Pause();

            if(!tutComp && !tutorial.dialogues[9].isComplete && !dial9)
            {
                dial9 = true;
                tutorial.manager.StartDialogue(tutorial.dialogues[9]);
            }

            if (tutComp)
            {
                ttv2.pause = false;
            }
            SaveCurrTime();
        }

        if(!tutComp && tutorial.dialogues[9].isComplete && !audioS.isPlaying)
        {
            ttv2.pause = false;
        }
    }

    public void SaveCurrTime()
    {
        currTime = audioS.time;
    }

    public void EndSong()
    {
        if (audioS.time == audioS.clip.length)
        {
            waitToEnd = false;

            if (tutComp)
            {
                song.totalMistakes += NumMistakes();
            }

            song.timesPlayed += 1;
            song.totalMoney += salary;
            pi.IncMoney(salary);
            
            blocker.SetActive(false);
            songInfo.SetActive(false);
            errorInfo.SetActive(false);
            gameObject.SetActive(false);
        }
    }

    public void SetSongbook()
    {
        string totalTime;

        totalTime = song.DetailedDuration();
        errorInfo.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = NumMistakes().ToString();
        currMins = (int)(audioS.time / sixty);
        currSecs = (int)(audioS.time - (currMins * sixty));

        if (currSecs < ten)
        {
            tempText.text = currMins + ":0" + currSecs + "/" + totalTime;
        }
        else
        {
            tempText.text = currMins + ":" + currSecs + "/" + totalTime;
        }
    }
}
