/**************************************************************************
 *                                                                        *
 *  File:        ResetBallOnGround.cs                                     *
 *  Copyright:   (c) 2022, Andrei Petcu                                   *
 *  Description: Ball resetting logic for Throw the ball!                 *
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

public class ResetBallOnGround : MonoBehaviour
{
    private GameObject ballInstance;
    public GameObject ballReference;
    public GameObject ballSpawnPoint;
    public BallSpawner ballSpawner;

    #region Spawning a ball for the first time
    private void Awake()
    {
        ballInstance = Instantiate(ballReference, ballSpawnPoint.transform.position, ballSpawnPoint.transform.rotation);
    }
    #endregion

    #region Ball reset logic

    /// <summary>
    /// This function checks if the ball has fallen on the ground
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(ballInstance.tag))
        {
            Debug.Log("Ball has fallen to the ground");
        }
    }

    /// <summary>
    /// This function removes the ball when it has fallen and spawns a new instance of its prefab
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag(ballInstance.tag))
        {
            Destroy(ballInstance);
            StartCoroutine(pauseUntilRespawn());
            ballInstance = ballSpawner.SpawnBallAgain();
            StopCoroutine(pauseUntilRespawn());
        }
    }
    
    /// <summary>
    /// Coroutine for delaying the spawn time of the ball
    /// </summary>
    /// <returns>WaitForSeconds timer</returns>
    private IEnumerator pauseUntilRespawn()
    {
        yield return new WaitForSeconds(1f);
    }
    #endregion
}
