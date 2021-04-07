using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Songbook : MonoBehaviour
{
    public Button prevSong, nextSong;
    public TextMeshProUGUI title, artist, times, money, mistakes, duration;
    private List<Song> allSongs = new List<Song>();
    private List<Song> ownedSongs = new List<Song>();
    private Song currSong;
    private int index;
    private AudioSource audioS;

    // Start is called before the first frame update
    void Start()
    {
        allSongs.AddRange(Resources.LoadAll<Song>("Songs"));
        HideUnowned();
        index = 0;
        audioS = gameObject.GetComponent<AudioSource>();
        currSong = ownedSongs[index];
        audioS.clip = currSong.songAudio;
        SetSongInfo();

        prevSong.gameObject.SetActive(false);

        if (ownedSongs.Count == 1)
        {
            nextSong.gameObject.SetActive(false);
        }
    }

    private void HideUnowned()
    {
        for(int i = 0; i < allSongs.Count; i++)
        {
            if(allSongs[i].status)
            {
                ownedSongs.Add(allSongs[i]);
            }
        }
    }

    public void AddSong(Song newSong)
    {
        newSong.status = true;
        ownedSongs.Add(newSong);
    }

    public void SetSongInfo()
    {
        title.text = currSong.songTitle;
        artist.text = currSong.songArtist;
        times.text = "Total times played: " + currSong.timesPlayed.ToString();
        money.text = "Total money made: $" + currSong.totalMoney.ToString();
        mistakes.text = "Total mistakes made: " + currSong.totalMistakes.ToString();
        duration.text = "Song Duration - " + currSong.DetailedDuration();

        audioS.clip = currSong.songAudio;
    }

    public void GoToNextSong()
    {
        index++;
        currSong = ownedSongs[index];
        prevSong.gameObject.SetActive(true);

        SetSongInfo();

        if (index >= (ownedSongs.Count-1))
        {
            nextSong.gameObject.SetActive(false);
        }
        else
        {
            nextSong.gameObject.SetActive(true);
        }
    }

    public void GoToPrevSong()
    {
        index--;
        currSong = ownedSongs[index];
        nextSong.gameObject.SetActive(true);

        SetSongInfo();

        if (index <= 0)
        {
            prevSong.gameObject.SetActive(false);
        }
        else
        {
            prevSong.gameObject.SetActive(true);
        }
    }

    public void PlaySong()
    {
        if (audioS.time == 0)
        {
            audioS.Play();
        }
        else if (!audioS.isPlaying)
        {
            audioS.UnPause();
        }
    }

    public void PauseSong()
    {
        if (audioS.isPlaying)
        {
            audioS.Pause();
        }
    }

    public void StopSong()
    {
        if (audioS.isPlaying)
        {
            audioS.Stop();
        }
    }

    public void RestartSong()
    {
        if (audioS.time > 0)
        {
            audioS.Stop();
            audioS.Play();
        }
    }

    public void CloseSongbook()
    {
        index = 0;
        currSong = ownedSongs[index];
        SetSongInfo();
        audioS.Stop();
        prevSong.gameObject.SetActive(false);
        nextSong.gameObject.SetActive(true);
    }
}
