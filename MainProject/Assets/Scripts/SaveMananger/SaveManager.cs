//
// Script name: SaveManager.cs
//
//
// Programmer: Kentaurus
//

using UnityEngine;
using System.Collections.Generic;
using System.Collections;


public class SaveManager : MonoBehaviour
{
    #region Variables
    #endregion
    
    #region Unity API
    #endregion

    #region Public Methods
    public static bool GetBool(string key)
    {
        bool result = false;

        int intResult = PlayerPrefs.GetInt(key);

        result = intResult == 1;

        return result;
    }

    public static void SetBool(string key, bool value)
    {
        int result = 1;

        if (value)
        {
            result = 1;
        }
        else
        {
            result = 0;
        }

        PlayerPrefs.SetInt(key, result);
    }

    public static void SetInt(string key, int value)
    {
        PlayerPrefs.SetInt(key, value);
    }

    public static int GetInt(string key)
    {
        return PlayerPrefs.GetInt(key);
    }

    public static void SetFloat(string key, float value)
    {
        PlayerPrefs.SetFloat(key, value);
    }

    public static float GetFloat(string key)
    {
        return PlayerPrefs.GetFloat(key);
    }
    #endregion

    #region Protected Methods
    #endregion

    #region Private Methods
    #endregion
}