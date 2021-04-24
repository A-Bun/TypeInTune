using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DayComp : MonoBehaviour
{
    public PlayerInteract player;
    public Fader fader;
    public TextMeshProUGUI dayText, dayEarningsText, totEarningsText, dayEarningsNum, totEarningsNum;
    public TextMeshProUGUI clickToContinue;

    private int day, dayEarnings, totEarnings, currDayEarnings, currTotEarnings, scoreInc = 1;
    private bool done;

    // Start is called before the first frame update
    void Start()
    {
        day = player.GetDay();
        dayText.text = "Day " + day + " - Complete";
        totEarnings = player.GetMoney();
        dayEarnings = player.GetMoney() - player.GetPrevMoney();
        currTotEarnings = player.GetPrevMoney();

        dayText.gameObject.SetActive(false);
        dayEarningsText.gameObject.SetActive(false);
        totEarningsText.gameObject.SetActive(false);
        dayEarningsNum.gameObject.SetActive(false);
        totEarningsNum.gameObject.SetActive(false);
        clickToContinue.gameObject.SetActive(false);
    }

    /* Fixed Update
     *   Trys to fade in all the TMP objects and increase the scores every fixed frame.
     */
    private void FixedUpdate()
    {
        StartFadeIn(dayText, dayText);
        StartFadeIn(dayText, dayEarningsText);
        StartFadeIn(dayEarningsText, dayEarningsNum);

        IncreaseInts();

        StartFadeIn(totEarningsText, totEarningsNum);

        //ShowClickToContinue();
    }

    /* Update
     *   Trys to fade in all the TMP objects and increase the scores every frame.
     */
    void Update()
    {
        //    StartFadeIn(dayText, dayText);
        //    StartFadeIn(dayText, dayEarningsText);
        //    StartFadeIn(dayEarningsText, dayEarningsNum);

        //    IncreaseInts();

        //    StartFadeIn(totEarningsText, totEarningsNum);

        if (!done)
        {
            ShowClickToContinue();
        }
    }

    /* Start Fade In
     *   Parameters: TextMeshProUGUI visibleText, TextMeshProUGUI fadingText
     *   Fades in the specified text (fadingText) once the other specified text (visibleText)
     *   is fully visible.
     */
    public void StartFadeIn(TextMeshProUGUI visibleText, TextMeshProUGUI fadingText)
    {
        // the first condition is only used for the first call to StartFadeIn
        if (fadingText == dayText || visibleText.alpha == 1)
        {
            fadingText.gameObject.SetActive(true);
        }
    }

    /* Increase Scores
     *  Increases the scores using a visible effect
     */
    public void IncreaseInts()
    {

        // converts the ints to strings so they can be displayed
        dayEarningsNum.text = currDayEarnings.ToString();
        totEarningsNum.text = currTotEarnings.ToString();

        // makes the level score only begin increasing at the right time
        if (dayEarningsNum.alpha == 1 && totEarningsNum.alpha == 0)
        {
            // increases the level score by some increment until it reaches it's desired value
            if (currDayEarnings != dayEarnings)
            {
                currDayEarnings = currDayEarnings + scoreInc;
            }
        }
        else if (totEarningsNum.alpha == 1)  // makes the total score only begin increasing at the right time
        {
            // increases the total score by some increment until it reaches it's desired value
            if (currTotEarnings != totEarnings)
            {
                currTotEarnings = currTotEarnings + scoreInc;
            }
        }

        // only makes the total score text visible when the level score is done increasing
        if (currDayEarnings == dayEarnings)
        {
            StartFadeIn(dayEarningsNum, totEarningsText);
        }
    }

    /* Show Click To Start
     *   Shows the "Click Anywhere To Continue" Text and allows the scene to change once all scores
     *   are displayed.
     */
    public void ShowClickToContinue()
    {
        //checks if the total score is done increasing
        if (currTotEarnings == totEarnings)
        {
            clickToContinue.gameObject.SetActive(true);

            if (Input.GetMouseButtonDown(0))
            {
                done = true;
                player.SyncPrevMoney();
                player.IncDay();

                //fades to the next scene on left mouse button click
                fader.FadeToLevel(1);
                //gameObject.GetComponent<DayComp>().enabled = false;
            }
        }
    }
}
