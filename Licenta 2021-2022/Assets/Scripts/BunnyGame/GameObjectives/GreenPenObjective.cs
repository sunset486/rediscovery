/**************************************************************************
 *                                                                        *
 *  File:        GreenPenObjective.cs                                     *
 *  Copyright:   (c) 2022, Andrei Petcu                                   *
 *  Description: Game logic for the green pen in Bunny Farm               *
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

public class GreenPenObjective : ObjectivesManager_BunnyFarm
{
    private int greenPenScore = 0;
    private GameObject bunnyInstance;
    public static bool greenIsComplete;
    public GameObject disabler;
    public BunnySpawner bunnySpawner;

    #region Spawning bunny
    private void Awake()
    {
        bunnyInstance = Instantiate(bunnyPrefab, new Vector3(-11, 0, Random.Range(-2, 3)), Quaternion.identity);
        greenIsComplete = false;
    }
    #endregion

    #region Green pen logic
    /// <summary>
    /// This function checks if the bunny instance is colliding with the pen
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(bunnyInstance.tag))
        {
            IncreaseScore();
            AudioManagerBunnyGame.PlayBunnyPlaced();
            ScoreCountCheck();
        }
        Debug.Log("Bunny placed in green pen");
        Debug.Log("Current green pen score: " + greenPenScore);
    }


    /// <summary>
    /// This function increases the number of bunnies on the pen
    /// </summary>
    private void IncreaseScore()
    {
        greenPenScore++;
        bunnySpawner.SpawnNewBunny();
    }

    /// <summary>
    /// This function checks if all of the bunnies are placed
    /// </summary>
    private void ScoreCountCheck()
    {
        if (greenPenScore == 3)
        {
            greenIsComplete = true;
            AudioManagerBunnyGame.PlayGreenComplete();
            Debug.Log("Green pen is now full");
            Debug.Log("Green pen objective complete!");
            disabler.SetActive(true);
        }
    }
    #endregion
}