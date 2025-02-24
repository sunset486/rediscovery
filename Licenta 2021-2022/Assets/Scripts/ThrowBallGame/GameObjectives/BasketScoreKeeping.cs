/**************************************************************************
 *                                                                        *
 *  File:        BasketScoreKeeping.cs                                    *
 *  Copyright:   (c) 2022, Andrei Petcu                                   *
 *  Description: Score keeping system in the Throw the ball! game         *
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

public class BasketScoreKeeping : MonoBehaviour
{
    private int score;
    private float posX;
    public GameObject ballReference;
    public GameObject basketReference;
    public static int scoreParsed;

    #region Setting up and transmitting the score to be parsed to the objectives manager
    private void Awake()
    {
        score = 0;
        posX = Random.Range(-2, 2.01f);
    }

    private void Update()
    {
        scoreParsed = score;
    }
    #endregion

    #region Game logic

    /// <summary>
    /// This function checks if the ball has entered the basket ring
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag(ballReference.tag))
        {
            TeleportBasket();
            posX = Random.Range(-2, 2.01f);
            IncreaseScore();
            Debug.Log("Current score: " + score);
        }
    }

    /// <summary>
    /// This function changes the position of the basket whenever a point is scored
    /// </summary>
    private void TeleportBasket()
    {
        var newPosition = new Vector3(posX, 0.875f, 2f);
        basketReference.transform.position = Vector3.Lerp(transform.position, newPosition, 1);
        
    }

    /// <summary>
    /// This function increases the game score
    /// </summary>
    private void IncreaseScore()
    {
        score++;
        AudioManagerBall.PlayPointScore();
        ScoreEncouragement(score);
    }

    /// <summary>
    /// This function plays audio clips that encourage the player to keep going with the game
    /// </summary>
    /// <param name="count"></param>
    private void ScoreEncouragement(int count)
    {
        switch (count)
        {
            case 5:
                AudioManagerBall.PlayFivePts();
                break;
            case 10:
                AudioManagerBall.PlayTenPts();
                break;
            case 15:
                AudioManagerBall.PlayFiftPts();
                break;
            case 20:
                AudioManagerBall.PlayGoodJob();
                break;
            default:
                Debug.Log("Sound not found!");
                break;
        }
    }
    #endregion
}
