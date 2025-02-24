/**************************************************************************
 *                                                                        *
 *  File:        AudioManagerBall.cs                                      *
 *  Copyright:   (c) 2022, Andrei Petcu                                   *
 *  Description: Audio managing class for the sound effects used in       *
 *               Throw the ball!                                          *
 *                                                                        *
 *  This code and information is provided "as is" without warranty of     *
 *  any kind, either expressed or implied, including but not limited      *
 *  to the implied warranties of merchantability or fitness for a         *
 *  particular purpose. You are free to use this source code in your      *
 *  applications as long as the original copyright notice is included.    *
 *                                                                        *
 **************************************************************************/
using UnityEngine;

public class AudioManagerBall : MonoBehaviour
{
    public AudioSource pointScore, ballBounce, endGame, fivePts, tenPts, fiftPts, goodJob;
    private static AudioSource ps, bb, eg, fp1, tp, fp2, gj;

    #region Static variabile initialization

    private void Awake()
    {
        ps = pointScore.GetComponent<AudioSource>();
        bb = ballBounce.GetComponent<AudioSource>();
        eg = endGame.GetComponent<AudioSource>();
        fp1 = fivePts.GetComponent<AudioSource>();
        tp = tenPts.GetComponent<AudioSource>();
        fp2 = fiftPts.GetComponent<AudioSource>();
        gj = goodJob.GetComponent<AudioSource>();
    }
    #endregion

    #region Static audio functions

    /// <summary>
    /// This function plays a sound when a point is scored
    /// </summary>
    public static void PlayPointScore()
    {
        ps.Play();
    }

    /// <summary>
    /// This function plays a sound when the ball collides with the basket
    /// </summary>
    public static void PlayBallBounce()
    {
        bb.Play();
    }

    /// <summary>
    /// This function plays a sound when the game is complete
    /// </summary>
    public static void PlayEndGame()
    {
        eg.Play();
    }

    /// <summary>
    /// This function plays a sound when five points are scored
    /// </summary>
    public static void PlayFivePts()
    {
        fp1.Play();
    }

    /// <summary>
    /// This function plays a sound when ten points are scored
    /// </summary>
    public static void PlayTenPts()
    {
        tp.Play();  
    }

    /// <summary>
    /// This function plays a sound when 15 points are scored
    /// </summary>
    public static void PlayFiftPts()
    {
        fp2.Play();
    }

    /// <summary>
    /// This function plays a sound when 20 points are scored
    /// </summary>
    public static void PlayGoodJob()
    {
        gj.Play();
    }
    #endregion
}
