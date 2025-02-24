/**************************************************************************
 *                                                                        *
 *  File:        BallSpawner.cs                                           *
 *  Copyright:   (c) 2022, Andrei Petcu                                   *
 *  Description: Ball spawning logic for Throw the ball!                  *
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

public class BallSpawner : MonoBehaviour
{
    public GameObject ball;
    public GameObject ballSpawnLocation;

    /// <summary>
    /// This function spawns a ball in the scene
    /// </summary>
    /// <returns>instance of the ball prefab</returns>
    public GameObject SpawnBallAgain()
    {
        GameObject obj = null;
        try
        {
            obj = Instantiate(ball, ballSpawnLocation.transform.position, ballSpawnLocation.transform.rotation);
            Debug.Log("Ball respawned");
        }
        catch(UnityException ue)
        {
            Debug.LogError(ue.Message);
        }
        return obj;
    }
}
