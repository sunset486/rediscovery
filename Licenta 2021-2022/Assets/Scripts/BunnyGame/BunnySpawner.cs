/**************************************************************************
 *                                                                        *
 *  File:        BunnySpawner.cs                                          *
 *  Copyright:   (c) 2022, Andrei Petcu                                   *
 *  Description: Implements the bunny spawning mechanic in Bunny Farm     *
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

public class BunnySpawner : MonoBehaviour
{
    public GameObject bunny;
    private static GameObject staticBunny;

    #region Spawning bunnies

    /// <summary>
    /// This function sets a static reference with the GameObject of the bunny prefab item
    /// </summary>
    private void Awake()
    {
        staticBunny = bunny.gameObject;
    }

    /// <summary>
    /// This function instantiates an instance of the static bunny object reference
    /// </summary>
    /// <returns> bunny GameObject </returns>
    public GameObject SpawnNewBunny()
    {
        GameObject obj = null;
        try
        {
            obj = Instantiate(staticBunny, new Vector3(-11, 0, Random.Range(-2, 3)), Quaternion.identity);
            
        }
        catch(UnityException ue)
        {
            Debug.LogError(ue.Message);
        }
        return obj;
    }
    #endregion
}
