/**************************************************************************
 *                                                                        *
 *  File:        RedPenObjective.cs                                       *
 *  Copyright:   (c) 2022, Andrei Petcu                                   *
 *  Description: Game logic for the red pen in Bunny Farm                 *
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

public class RedPenObjective : ObjectivesManager_BunnyFarm
{
    private int redPenScore = 0;
    private GameObject bunnyInstance;
    public static bool redIsComplete;
    public GameObject disabler;
    public BunnySpawner bunnySpawner;

    #region Spawning bunny
    private void Awake()
    {
        bunnyInstance = Instantiate(bunnyPrefab, new Vector3(-11, 0, Random.Range(-2, 3)), Quaternion.identity);
        redIsComplete = false;
    }
    #endregion

    #region Red pen logic

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
        Debug.Log("Bunny placed in red pen");
        Debug.Log("Current red pen score: " + redPenScore);

    }

    /// <summary>
    /// This function increases the number of bunnies on the pen
    /// </summary>
    private void IncreaseScore()
    {
        redPenScore++;
        bunnySpawner.SpawnNewBunny();
    }

    /// <summary>
    /// This function checks if all of the bunnies are placed
    /// </summary>
    private void ScoreCountCheck()
    {
        if (redPenScore == 3)
        {
            redIsComplete = true;
            AudioManagerBunnyGame.PlayRedComplete();
            Debug.Log("red pen is now full");
            Debug.Log("red pen objective complete!");
            disabler.SetActive(true);
        }
    }
    #endregion
}