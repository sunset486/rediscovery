/**************************************************************************
 *                                                                        *
 *  File:        ObjectivesManager_BunnyFarm.cs                           *
 *  Copyright:   (c) 2022, Andrei Petcu                                   *
 *  Description: Objective manager for the Bunny Farm game                *
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

public class ObjectivesManager_BunnyFarm : MonoBehaviour
{
    private bool redCheck;
    private bool greenCheck;
    private bool blueCheck;
    public GameObject bunnyPrefab;
    public static bool loadingFlag;

    #region Initializing the manager
    private void Start()
    {
        redCheck = false;
        greenCheck = false;
        blueCheck = false;
        loadingFlag = false;
    }

    /// <summary>
    /// This function tracks the flags of the pen objectives and checks if the game should end
    /// </summary>
    private void Update()
    {
        redCheck = TrackGameProgress(RedPenObjective.redIsComplete);
        greenCheck = TrackGameProgress(GreenPenObjective.greenIsComplete);
        blueCheck = TrackGameProgress(BluePenObjective.blueIsComplete);

        if (loadingFlag)
        {
            StartCoroutine(GameComplete());
            loadingFlag = false;
        }
    }
    #endregion


    #region Objectives logic

    /// <summary>
    /// This function sets the boolean value of a game check dependent on the flags of a pen
    /// </summary>
    /// <param name="progress"></param>
    /// <returns> boolean value of objectives check vars</returns>
    private bool TrackGameProgress(bool progress)
    {
        bool set;
        if (!progress)
            set = false;
        else
            set = true;
        return set;
    }

    /// <summary>
    /// Coroutine for returning the player back to the main menu when the game is complete
    /// </summary>
    /// <returns></returns>
    public static IEnumerator GameComplete()
    {
        AudioManagerBunnyGame.StopGameAnnouncements();
        Debug.Log("Congratulations! You have put all the bunnies in the pens");
        var goToMain = GameStates.MAIN_MENU_GAME;
        yield return new WaitForSeconds(5.0f);
        GameStatesManager.LoadScreen(goToMain);
    }

    /// <summary>
    /// This function is called in the disablers' scripts for sending the flag to the coroutine
    /// </summary>
    protected void EndFlag()
    {
        if (redCheck && blueCheck && greenCheck)
        {
            loadingFlag = true;
            bunnyPrefab.SetActive(false);
        }
    }
    /// <summary>
    /// This functions keeps the bunny prefab active to prevent missing bunnies when starting the game again
    /// </summary>
    private void OnDestroy()
    {
        bunnyPrefab.SetActive(true);
    }
    #endregion
}
