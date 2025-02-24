/**************************************************************************
 *                                                                        *
 *  File:        IndicatorsBehaviour.cs                                   *
 *  Copyright:   (c) 2022, Andrei Petcu                                   *
 *  Description: Manages how the UI elements should behave in Bunny Farm  *
 *                                                                        *
 *                                                                        *
 *  This code and information is provided "as is" without warranty of     *
 *  any kind, either expressed or implied, including but not limited      *
 *  to the implied warranties of merchantability or fitness for a         *
 *  particular purpose. You are free to use this source code in your      *
 *  applications as long as the original copyright notice is included.    *
 *                                                                        *
 **************************************************************************/
using System.Collections.Generic;
using UnityEngine;

public class IndicatorsBehaviour : MonoBehaviour
{
    private GameObject player;

    private List<GameObject> texts;
    private GameObject factoryTag;
    private GameObject redTag;
    private GameObject greenTag;
    private GameObject blueTag;

    [SerializeField] public GameObject indicators;

    #region Loading Bunny Farm UI elements and their behaviour

    /// <summary>
    /// This function searches for the game objects containing the UI elements and the player controlled-objects
    /// </summary>
    private void Awake()
    {
        texts = new List<GameObject>();
        player = GameObject.Find("XR Origin"); 
        indicators = GameObject.Find("Indicators");
        Init();
    }
     /// <summary>
     /// This function calls the RotationFunc() function below on every game frame
     /// </summary>
    private void Update()
    {
        RotationFunc();
    }

    /// <summary>
    /// This function adds a list of all of the UI elements present in the game scene
    /// </summary>
    private void Init()
    {
        factoryTag = indicators.transform.Find("BunnyFactoryTag").gameObject;
        redTag = indicators.transform.Find("RedPenTag").gameObject;
        greenTag = indicators.transform.Find("GreenPenTag").gameObject;
        blueTag = indicators.transform.Find("BluePenTag").gameObject;

        texts.Add(factoryTag);
        texts.Add(redTag);
        texts.Add(greenTag);
        texts.Add(blueTag);
    }

    /// <summary>
    /// This function rotates the UI elements according to the player character's position on the map
    /// </summary>
    private void RotationFunc()
    {
        foreach (GameObject text in texts)
        {
            text.transform.LookAt(player.transform);
        }
    }
    #endregion
}
