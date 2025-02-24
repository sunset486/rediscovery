/**************************************************************************
 *                                                                        *
 *  File:        BlueDisablerColl.cs                                      *
 *  Copyright:   (c) 2022, Andrei Petcu                                   *
 *  Description: Activates the blue disabler when the blue pen is full    *
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

public class BlueDisablerColl : ObjectivesManager_BunnyFarm
{
    public GameObject bluepen;

    /// <summary>
    /// This function checks if the disabler collides with its pen
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(bluepen.tag))
            EndFlag();
        if(other.name == "BunnyMain(Clone)")
            other.enabled = false;
    }
}
