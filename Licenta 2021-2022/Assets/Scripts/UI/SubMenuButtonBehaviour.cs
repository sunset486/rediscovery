/**************************************************************************
 *                                                                        *
 *  File:        SubMenuButtonBehaviour.cs                                *
 *  Copyright:   (c) 2022, Andrei Petcu                                   *
 *  Description: Game submenu button logic for loading into a minigame    *
 *               and using QoL functionalities                            *
 *                                                                        *
 *  This code and information is provided "as is" without warranty of     *
 *  any kind, either expressed or implied, including but not limited      *
 *  to the implied warranties of merchantability or fitness for a         *
 *  particular purpose. You are free to use this source code in your      *
 *  applications as long as the original copyright notice is included.    *
 *                                                                        *
 **************************************************************************/
using UnityEngine;

public class SubMenuButtonBehaviour : MonoBehaviour
{
    private GameStates state;
    #region Starting the games and UI functionalities

    /// <summary>
    /// This function loads the Bunny Farm minigame after pressing the button
    /// </summary>
    public void BunnyGameStart()
    {
        state = GameStates.BUNNY_GAME;
        GameStatesManager.LoadScreen(state);
    }

    /// <summary>
    /// This function loads the Throw the ball! minigame after pressing the button
    /// </summary>
    public void BallGameStart()
    {
        state = GameStates.BALL_GAME;
        GameStatesManager.LoadScreen(state);
    }

    /// <summary>
    /// This function plays text-to-speech audio related to Bunny Farm
    /// </summary>
    public void ReadBunnyInstr()
    {
        AudioManagerMenu.PlayBunnyInstructions();
    }

    /// <summary>
    /// This function plays text-to-speech audio related to Throw the ball!
    /// </summary>
    public void ReadBallInstrt()
    {
        AudioManagerMenu.PlayBallInstructions();
    }
    #endregion
}
