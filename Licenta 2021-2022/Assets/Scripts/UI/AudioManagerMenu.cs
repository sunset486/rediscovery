/**************************************************************************
 *                                                                        *
 *  File:        AudioManagerMenu.cs                                      *
 *  Copyright:   (c) 2022, Andrei Petcu                                   *
 *  Description: Audio managing class for the sound effects used in       *
 *               the main menu                                            *
 *                                                                        *
 *  This code and information is provided "as is" without warranty of     *
 *  any kind, either expressed or implied, including but not limited      *
 *  to the implied warranties of merchantability or fitness for a         *
 *  particular purpose. You are free to use this source code in your      *
 *  applications as long as the original copyright notice is included.    *
 *                                                                        *
 **************************************************************************/
using UnityEngine;

public class AudioManagerMenu : MonoBehaviour
{
    public AudioSource selectGame, selectOptions, selectBunny, bunnyInstructions, selectBall, ballInstructions, returnToMain, exitGame;
    private static AudioSource sg, so, sb1, sb1_i, sb2, sb2_i, rtm, eg;

    #region Static variable initialization
    32private void Awake()
    {
        sg = selectGame.GetComponent<AudioSource>();
        so = selectOptions.GetComponent<AudioSource>();
        sb1 = selectBunny.GetComponent<AudioSource>();
        sb1_i = bunnyInstructions.GetComponent<AudioSource>();
        sb2 = selectBall.GetComponent<AudioSource>();
        sb2_i = ballInstructions.GetComponent<AudioSource>();
        rtm = returnToMain.GetComponent<AudioSource>();
        eg = exitGame.GetComponent<AudioSource>();
    }
    #endregion

    #region Static audio functions
    /// <summary>
    /// This function plays text-to-speech audio of selecting the game submenu
    /// </summary>
    public static void PlaySelectGame()
    {
        sg.Play();
    }

    /// <summary>
    /// This function plays text-to-speech audio of selecting the options submenu
    /// </summary>
    public static void PlaySelectOptions()
    {
        so.Play();
    }

    /// <summary>
    /// This function plays text-to-speech audio of selecting the Bunny Farm game submenu
    /// </summary>
    public static void PlaySelectBunny()
    {
        sb1.Play();
    }
    /// <summary>
    /// This function plays text-to-speech audio of reading the Bunny Farm instructions
    /// </summary>
    public static void PlayBunnyInstructions()
    {
        sb1_i.Play();
    }

    /// <summary>
    /// This function plays text-to-speech audio of selecting the Throw the Ball! game submenu
    /// </summary>
    public static void PlaySelectBall()
    {
        sb2.Play();
    }
    /// <summary>
    /// This function plays text-to-speech audio of reading the Throw the Ball! instructions
    /// </summary>
    public static void PlayBallInstructions()
    {
        sb2_i.Play();
    }

    /// <summary>
    /// This function stops the Bunny Farm instructions audio when leaving its submenu
    /// </summary>
    public static void StopBunnyInstr()
    {
        sb1_i.Stop();
    }
    /// <summary>
    /// This function stops the Throw the Ball! instructions audio when leaving its submenu
    /// </summary>
    public static void StopBallInstr()
    {
        sb2_i.Stop();
    }

    /// <summary>
    /// This function plays text-to-speech audio of returning to the main menu
    /// </summary>
    public static void PlayReturnToMain()
    {
        rtm.Play();
    }

    /// <summary>
    /// This function plays text-to-speech audio of exiting the game
    /// </summary>
    public static void PlayExitGame()
    {
        eg.Play();
    }
    #endregion
}
