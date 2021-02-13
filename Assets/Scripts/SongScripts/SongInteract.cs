using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongInteract : MonoBehaviour
{
    private Song song;
    private AudioSource audioS;
    public float currTime;
    public int salary;
    private TypeTrackerV2 ttv2;
    private int index;
    private float interval;

    // Start is called before the first frame update
    void Start()
    {
        ttv2 = gameObject.GetComponent<TypeTrackerV2>();
        song = ttv2.letIn.letter.song;
        audioS = GetComponent<AudioSource>();
        audioS.clip = song.songAudio;
        audioS.Stop();
        salary = song.songSalary[0];
        song.songDuration = song.songAudio.length;
        currTime = 0;
        index = 0;
        interval = (song.songDuration / ttv2.letIn.letter.interval);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateSalary();
        PlayOrPause();
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
            ttv2.pause = false;
            SaveCurrTime();
        }
    }

    public void SaveCurrTime()
    {
        currTime = audioS.time;
    }
}
