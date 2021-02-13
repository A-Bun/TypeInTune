using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Sound : MonoBehaviour
{
    private AudioSource audioS;
    private float currTime;
    private TypeTrackerV2 ttv2;
    private int index;

    // Start is called before the first frame update
    void Start()
    {
        audioS = GetComponent<AudioSource>();
        audioS.Stop();
        ttv2 = gameObject.GetComponent<TypeTrackerV2>();
        index = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (index != ttv2.letIn.letter.completedSentences.Count)
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
        SaveCurrTime();
        audioS.Play();
    }

    public void PauseClip(bool complete)
    {
        if (audioS.time >= (currTime + 5))
        {
            audioS.Pause();
            ttv2.pause = false;
        }

        if(complete)
        {
            index = 0;
            ttv2.letIn.ClearCompletes();
        }
    }

    public void SaveCurrTime()
    {
        currTime = audioS.time;
    }
}
