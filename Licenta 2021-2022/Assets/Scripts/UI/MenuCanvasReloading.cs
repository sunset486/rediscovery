/**************************************************************************
 *                                                                        *
 *  File:        MenuCanvasReloading.cs                                   *
 *  Copyright:   (c) 2022, Andrei Petcu                                   *
 *  Description: Singleton class for reinstancing the static members of   *
 *               the UserInterfaceManager class                           *
 *                                                                        *
 *  This code and information is provided "as is" without warranty of     *
 *  any kind, either expressed or implied, including but not limited      *
 *  to the implied warranties of merchantability or fitness for a         *
 *  particular purpose. You are free to use this source code in your      *
 *  applications as long as the original copyright notice is included.    *
 *                                                                        *
 **************************************************************************/
using UnityEngine;

public class MenuCanvasReloading : MonoBehaviour
{
    public GameObject menuCanvas;
    #region Singleton menu instancing

    /// <summary>
    /// Singleton instances for reloading the main menu and avoiding null references
    /// </summary>
    private void Awake()
    {
        try
        {
            UserInterfaceManager.mainMenu = menuCanvas.transform.GetChild(1).gameObject;
            UserInterfaceManager.selectMenu = menuCanvas.transform.GetChild(2).gameObject;
            UserInterfaceManager.optionsMenu = menuCanvas.transform.GetChild(3).gameObject;
            UserInterfaceManager.bunnySubMenu = menuCanvas.transform.GetChild(4).gameObject;
            UserInterfaceManager.ballSubMenu = menuCanvas.transform.GetChild(5).gameObject;
        }
        catch(UnityException ue)
        {
            Debug.LogError(ue.Message);
        }
    }
    #endregion
}
