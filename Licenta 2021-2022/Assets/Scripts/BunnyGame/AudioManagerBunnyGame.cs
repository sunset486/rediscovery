/**************************************************************************
 *                                                                        *
 *  File:        AudioManagerBunnyGame.cs                                 *
 *  Copyright:   (c) 2022, Andrei Petcu                                   *
 *  Description: Audio managing class for the sound effects used in       *
 *               Bunny Farm                                               *
 *                                                                        *
 *  This code and information is provided "as is" without warranty of     *
 *  any kind, either expressed or implied, including but not limited      *
 *  to the implied warranties of merchantability or fitness for a         *
 *  particular purpose. You are free to use this source code in your      *
 *  applications as long as the original copyright notice is included.    *
 *                                                                        *
 **************************************************************************/
using UnityEngine;

public class AudioManagerBunnyGame : MonoBehaviour
{
    public AudioSource bunnyPlaced, redComplete, greenComplete, blueComplete, penFull, gameComplete;
    private static AudioSource bp, rc, gc, bc, pf, gcFinish;

    #region Static variable initialization
    private void Awake()
    {
        bp = bunnyPlaced.GetComponent<AudioSource>();
        rc = redComplete.GetComponent<AudioSource>();
        gc = greenComplete.GetComponent<AudioSource>();
        bc = blueComplete.GetComponent<AudioSource>();
        pf = penFull.GetComponent<AudioSource>();
        gcFinish = gameComplete.GetComponent<AudioSource>();
    }
    #endregion

    #region Static audio functions

    /// <summary>
    /// This function plays a sound everytime a bunny is placed inside a pen
    /// </summary>
    public static void PlayBunnyPlaced()
    {
        bp.Play();
    }

    /// <summary>
    /// This function plays a sound when the red pen is full
    /// </summary>
    public static void PlayRedComplete()
    {
        rc.Play();
    }

    /// <summary>
    /// This function plays a sound when the green pen is full
    /// </summary>
    public static void PlayGreenComplete()
    {
        gc.Play();
    }

    /// <summary>
    /// This function plays a sound when the blue pen is full
    /// </summary>
    public static void PlayBlueComplete()
    {
        bc.Play();
    }

    /// <summary>
    /// This function plays a warning when a pen is too full (unused)
    /// </summary>
    public static void PlayPenFull()
    {
        pf.Play();
    }

    /// <summary>
    /// This function plays a sound when all pens are full
    /// </summary>
    public static void PlayGameComplete()
    {
        gcFinish.Play();
    }

    /// <summary>
    /// This function is used to prevent overlapping announcement sounds when completing the game
    /// </summary>
    public static void StopGameAnnouncements()
    {
        rc.Stop();
        gc.Stop();
        bc.Stop();
        PlayGameComplete();
    }
    #endregion
}
