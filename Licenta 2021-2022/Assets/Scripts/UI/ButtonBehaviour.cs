/**************************************************************************
 *                                                                        *
 *  File:        ButtonBehaviour.cs                                       *
 *  Copyright:   (c) 2022, Andrei Petcu                                   *
 *  Description: Menu and submenu button logic for the main screen        *
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

public class ButtonBehaviour : MonoBehaviour
{
    #region Loading menus and submenus
    /// <summary>
    /// This function loads the game select submenu
    /// </summary>
    public void LoadSelect()
    {
        Debug.Log("Game select menu");
        UserInterfaceManager.OpenMenu(MenuList.SELECT_GAME_MENU, gameObject);
        AudioManagerMenu.PlaySelectGame();
    }

    /// <summary>
    /// This function loads the options submenu
    /// </summary>
    public void LoadOptions()
    {
        Debug.Log("Options menu");
        UserInterfaceManager.OpenMenu(MenuList.OPTIONS_MENU, gameObject);
        AudioManagerMenu.PlaySelectOptions();
    }

    /// <summary>
    /// This function loads the main menu initial screen
    /// </summary>
    public void LoadMain()
    {
        Debug.Log("Main menu");
        UserInterfaceManager.OpenMenu(MenuList.MAIN_MENU, gameObject);
        AudioManagerMenu.PlayReturnToMain();
        
    }

    /// <summary>
    /// This function loads the Bunny Farm submenu
    /// </summary>
    public void LoadBunnySubMenu()
    {
        Debug.Log("Bunny Farm menu");
        UserInterfaceManager.OpenMenu(MenuList.BUNNY_GAME_SUBMENU, gameObject);
        AudioManagerMenu.PlaySelectBunny();
    }

    /// <summary>
    /// This function loads the Throw the ball! submenu
    /// </summary>
    public void LoadBallSubMenu()
    {
        Debug.Log("Bunny Farm menu");
        UserInterfaceManager.OpenMenu(MenuList.BALL_GAME_SUBMENU, gameObject);
        AudioManagerMenu.PlaySelectBall();
    }
    /// <summary>
    /// This function stops the instructions from reading
    /// </summary>
    public void ReturnFromBunnySubMenu()
    {
        AudioManagerMenu.StopBunnyInstr();
    }

    /// <summary>
    /// This function stops the instructions from reading
    /// </summary>
    public void ReturnFromBallSubMenu()
    {
        AudioManagerMenu.StopBallInstr();
    }

    /// <summary>
    /// This function exits the game
    /// </summary>
    public void ExitGame()
    {
        Debug.Log("Exit");
        AudioManagerMenu.PlayExitGame();
        StartCoroutine(ExitWaitTime());
    }

    /// <summary>
    /// Coroutine for simulating a game exiting process
    /// </summary>
    /// <returns>WaitForSeconds delay</returns>
    private IEnumerator ExitWaitTime()
    {
        yield return new WaitForSeconds(2f);
        Application.Quit();
    }
    #endregion
}
