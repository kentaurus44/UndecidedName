//
// Script name: CharacterNPCInfoEditor.cs
//
//
// Programmer: Kentaurus
//

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;

[CustomEditor(typeof(CharacterNPCInfo))]
public class CharacterNPCInfoEditor : Editor
{
    #region Variables
    private CharacterNPCInfo m_CharacterNPCInfo;
    #endregion

    #region Unity API
    #endregion

    #region Public Methods
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        DisplayGUI();

        m_CharacterNPCInfo = (CharacterNPCInfo)target;
    }
    #endregion

    #region Protected Methods
    #endregion

    #region Private Methods
    private void DisplayGUI()
    {
        if (GUILayout.Button("Load Characters"))
        {
            m_CharacterNPCInfo.Load();
        }

        if (GUILayout.Button("Save Characters"))
        {
            if (m_CharacterNPCInfo.CharactersNPC.Count > 0)
            {
                m_CharacterNPCInfo.Save();
            }
            else
            {
                Debug.Log("Failed to save", m_CharacterNPCInfo.gameObject);
            }
        }

        if (GUILayout.Button("Clear Characters"))
        {
            m_CharacterNPCInfo.Clear();
        }
    }
    #endregion
}
