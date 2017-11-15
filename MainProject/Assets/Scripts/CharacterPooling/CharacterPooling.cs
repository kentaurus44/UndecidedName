//
// Script name: CharacterPooling.cs
//
//
// Programmer: Kentaurus
//

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharacterPooling : ObjectPool<CharacterNPC> 
{
    #region Variables
    #endregion

    #region Unity API
    #endregion

    #region Public Methods
    public void LoadItems(CharacterNPCInfo info)
    {
        int targetCount = ObjectCount + info.InformationCount;

        LoadItems(targetCount);

        for (int i = 0; i < info.InformationCount; ++i)
        {
            m_UsedObject[targetCount - 1 - i].transform.SetParent(info.transform);
            m_UsedObject[targetCount - 1 - i].Load(info.CharacterInfoList[i]);
            info.SetNPC(m_UsedObject[targetCount - 1 - i]);
        }
    }

    public void UnloadItems(CharacterNPCInfo info)
    {
        for (int i = 0; i < info.CharactersNPC.Count; ++i)
        {
            ReturnItem(info.CharactersNPC[i]);
        }

        info.UnloadNPCs();
    }
    #endregion

    #region Protected Methods
    #endregion

    #region Private Methods
    #endregion
}
