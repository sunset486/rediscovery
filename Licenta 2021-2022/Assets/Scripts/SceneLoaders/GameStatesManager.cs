/**************************************************************************
 *                                                                        *
 *  File:        GameStatesManager.cs                                     *
 *  Copyright:   (c) 2022, Andrei Petcu                                   *
 *  Description: State machine for managing the loading of game scenes    *
 *                                                                        *
 *                                                                        *
 *  This code and information is provided "as is" without warranty of     *
 *  any kind, either expressed or implied, including but not limited      *
 *  to the implied warranties of merchantability or fitness for a         *
 *  particular purpose. You are free to use this source code in your      *
 *  applications as long as the original copyright notice is included.    *
 *                                                                        *
 **************************************************************************/
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStatesManager : MonoBehaviour
{
    #region Loading game scenes
    /// <summary>
    /// This static function loads game scenes by checking the current state of the game state machine
    /// </summary>
    /// <param name="state"></param>
    public static void LoadScreen(GameStates state)
    {
        switch (state)
        {
            case GameStates.BUNNY_GAME:
                SceneManager.LoadSceneAsync("BunnyGame", LoadSceneMode.Single);
                Debug.Log("Bunny Farm - loaded");
                break;
            case GameStates.BALL_GAME:
                SceneManager.LoadSceneAsync("ThrowBallGame", LoadSceneMode.Single);
                Debug.Log("Throw the ball! - loaded");
                break;
            case GameStates.MAIN_MENU_GAME:
                SceneManager.LoadSceneAsync("ReDiscovery", LoadSceneMode.Single);
                Debug.Log("Main menu screen - loaded");
                break;
            default:
                Debug.Log("No scene found!");
                break;
        }
    }

    /// <summary>
    /// This function prevents the main menu from duplicating into scenes where it is not supposed to load
    /// </summary>
    private void OnDestroy()
    {
        Destroy(GameObject.FindGameObjectWithTag("Main Menu"));
    }
    #endregion
}
