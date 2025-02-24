/**************************************************************************
 *                                                                        *
 *  File:        BounceBallSound.cs                                       *
 *  Copyright:   (c) 2022, Andrei Petcu                                   *
 *  Description: Script for playing a sound when the ball touches the     *
 *               basket in Throw the ball!                                *
 *                                                                        *
 *  This code and information is provided "as is" without warranty of     *
 *  any kind, either expressed or implied, including but not limited      *
 *  to the implied warranties of merchantability or fitness for a         *
 *  particular purpose. You are free to use this source code in your      *
 *  applications as long as the original copyright notice is included.    *
 *                                                                        *
 **************************************************************************/
using UnityEngine;

public class BounceBallSound : MonoBehaviour
{
    public GameObject ball;

    /// <summary>
    /// This function checks if the ball collides with the basket
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == ball.gameObject)
            AudioManagerBall.PlayBallBounce();
    }
}
