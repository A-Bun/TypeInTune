using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
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

    public PlayerData(PlayerInfo player)
    {
        //player.SaveOwnedSongs();

        day = player.day;
        currMoney = player.currMoney;
        prevDayMoney = player.prevDayMoney;
        currScene = player.currScene;
        ownedMusic = player.ownedMusic;
        ownedPianos = player.ownedPianos;
        comDialogues = player.comDialogues;
        comLetters = player.comLetters;
        introCompleted = player.introCompleted;
        tutorialCompleted = player.tutorialCompleted;
        gameCompleted = player.gameCompleted;
    }
}
