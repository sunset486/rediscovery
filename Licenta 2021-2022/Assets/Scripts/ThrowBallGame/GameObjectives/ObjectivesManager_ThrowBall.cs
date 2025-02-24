/**************************************************************************
 *                                                                        *
 *  File:        ObjectivesManager_ThrowBall.cs                           *
 *  Copyright:   (c) 2022, Andrei Petcu                                   *
 *  Description: Objective manager for the Throw the ball! game           *
 *                                                                        *
 *                                                                        *
 *  This code and information is provided "as is" without warranty of     *
 *  any kind, either expressed or implied, including but not limited      *
 *  to the implied warranties of merchantability or fitness for a         *
 *  particular purpose. You are free to use this source code in your      *
 *  applications as long as the original copyright notice is included.    *
 *                                                                        *
 **************************************************************************/
using System.Collections;
using UnityEngine;
using TMPro;

public class ObjectivesManager_ThrowBall: MonoBehaviour
{
    [SerializeField] private float time;
    public TextMeshProUGUI timeDisplay;
    public TextMeshProUGUI endText;
    public TextMeshProUGUI scoreText;
    private bool timeRunOut;

    #region Setting up and counting the timer down
    private void Awake()
    {
        timeRunOut = false;
        endText.enabled = false;
        scoreText.enabled = false;
    }

    void Update()
    {
        if(!timeRunOut)
            UpdateTime();
    }
    #endregion

    #region Timer logic

    /// <summary>
    /// This function updates the time until it reaches zero
    /// </summary>
    private void UpdateTime()
    {
        time -= Time.deltaTime;
        var minutes = Mathf.FloorToInt(time / 60);
        var seconds = Mathf.FloorToInt(time - minutes * 60);

        string timeFormat = string.Format("{0:0}:{1:00}", minutes, seconds);

        timeDisplay.text = timeFormat;

        if(time < 0)
        {
            timeRunOut = true;
            scoreText.text = BasketScoreKeeping.scoreParsed.ToString();
            StartCoroutine(GameComplete());
        }
    }

    /// <summary>
    /// Coroutine for returning the player to the main menu when the timer runs out
    /// </summary>
    /// <returns>WaitForSeconds timer</returns>
    private IEnumerator GameComplete()
    {
        timeDisplay.enabled = false;
        endText.enabled = true;
        scoreText.enabled = true;
        AudioManagerBall.PlayEndGame();
        var goToMain = GameStates.MAIN_MENU_GAME;
        yield return new WaitForSeconds(5.0f);
        GameStatesManager.LoadScreen(goToMain);
    }
    #endregion
}
