/**************************************************************************
 *                                                                        *
 *  File:        UserInterfaceManager.cs                                  *
 *  Copyright:   (c) 2022, Andrei Petcu                                   *
 *  Description: Menu state machine used for loading menus and submenus   *
 *                                                                        *
 *  This code and information is provided "as is" without warranty of     *
 *  any kind, either expressed or implied, including but not limited      *
 *  to the implied warranties of merchantability or fitness for a         *
 *  particular purpose. You are free to use this source code in your      *
 *  applications as long as the original copyright notice is included.    *
 *                                                                        *
 **************************************************************************/
using UnityEngine;

public class UserInterfaceManager : MonoBehaviour
{
    public static bool isLoaded { get; private set; }
    public static GameObject mainMenu, selectMenu, optionsMenu, bunnySubMenu, ballSubMenu;

    #region Initialization of menu objects
    /// <summary>
    /// This function instantiates the static variabiles with references of the menu GameObjects
    /// </summary>
    public static void Init()
    {
        GameObject canvas = GameObject.Find("MainMenu");
        mainMenu = canvas.transform.Find("MainMenuPanel").gameObject;
        selectMenu = canvas.transform.Find("SelectGamePanel").gameObject;
        optionsMenu = canvas.transform.Find("OptionsPanel").gameObject;
        bunnySubMenu = canvas.transform.Find("BunnyFarmPanel").gameObject;
        ballSubMenu = canvas.transform.Find("ThrowBallPanel").gameObject;

        isLoaded = true;
    }
    #endregion

    #region Menu state machine

    /// <summary>
    /// This function checks the current menu state and loads it accordingly
    /// </summary>
    /// <param name="menu"></param>
    /// <param name="currentMenu"></param>
    public static void OpenMenu(MenuList menu, GameObject currentMenu)
    {
        if (!isLoaded)
            Init();

        if (currentMenu != null)
        {
            switch (menu)
            {
                case MenuList.MAIN_MENU:
                    mainMenu.SetActive(true);
                    break;
                case MenuList.SELECT_GAME_MENU:
                    selectMenu.SetActive(true);
                    break;
                case MenuList.OPTIONS_MENU:
                    optionsMenu.SetActive(true);
                    break;
                case MenuList.BUNNY_GAME_SUBMENU:
                    bunnySubMenu.SetActive(true);
                    break;
                case MenuList.BALL_GAME_SUBMENU:
                    ballSubMenu.SetActive(true);
                    break;
                default:
                    Debug.Log("No canvas found!");
                    break;
            }
        }
        currentMenu.SetActive(false);
    }
    #endregion
}
