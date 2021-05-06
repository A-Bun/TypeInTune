using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public PlayerInfo player;
    
    public int GetDay()
    {
        return player.day;
    }

    public void SetDay(int num)
    {
        player.day = num;
    }

    public void IncDay()
    {
        player.day += 1;
    }

    public int GetMoney()
    {
        return player.currMoney;
    }

    public void SetMoney(int amount)
    {
        player.currMoney = amount;
    }

    public void IncMoney(int amount)
    {
        player.currMoney += amount;
    }

    public bool DecMoney(int amount)
    {
        bool bought;
        if(player.currMoney - amount < 0)
        {
            bought = false;
        }
        else
        {
            bought = true;
            player.currMoney -= amount;
        }

        return bought;
    }

    public int GetPrevMoney()
    {
        return player.prevDayMoney;
    }

    public void SetPrevMoney(int amount)
    {
        player.prevDayMoney = amount;
    }

    public void SyncPrevMoney()
    {
        player.prevDayMoney = player.currMoney;
    }

    public bool GetIntroStatus()
    {
        return player.introCompleted;
    }

    public void SetIntroStatus(bool status)
    {
        player.introCompleted = status;
    }

    public bool GetTutorialStatus()
    {
        return player.tutorialCompleted;
    }

    public void SetTutorialStatus(bool status)
    {
        player.tutorialCompleted = status;
    }

    public bool GetGameStatus()
    {
        return player.gameCompleted;
    }

    public void SetGameStatus(bool status)
    {
        player.gameCompleted = status;
    }

    public void ResetProgress()
    {
        SetDay(0);
        SetMoney(0);
        SetPrevMoney(0);
        player.ownedMusic.Clear();
        player.ownedPianos.Clear();
        player.comDialogues.Clear();
        player.comLetters.Clear();
        player.ResetSongs();
        player.ResetPianos();
        player.ResetDialogues();
        player.ResetLetters();
        SetIntroStatus(false);
        SetTutorialStatus(false);
        SetGameStatus(false);

        Debug.Log("Clearing Data...");
    }
}
