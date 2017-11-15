//
// Script name: CharacterNPC.cs
//
//
// Programmer: Kentaurus
//

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharacterNPC : MonoBehaviour 
{
    #region Variables
    #endregion

    #region Unity API
    #endregion

    #region Public Methods
    public void Load(CharacterNPCInfo.CharacterInfo info)
    {
        transform.localPosition = info.Position;
    }
    #endregion

    #region Protected Methods
    #endregion

    #region Private Methods
    #endregion
}
