//
// Script name: CharacterNPCInfo.cs
//
//
// Programmer: Kentaurus
//

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharacterNPCInfo : MonoBehaviour
{
    #region Variables
    [System.Serializable]
    public struct CharacterInfo
    {
        public Vector3 Position;

        public CharacterInfo(CharacterNPC info)
        {
            Position = info.transform.localPosition;
        }
    }

    [SerializeField] protected List<CharacterInfo> m_CharacterInfo = new List<CharacterInfo>();
    [SerializeField] protected List<CharacterNPC> m_Characters = new List<CharacterNPC>();

#if UNITY_EDITOR
    [SerializeField] protected CharacterNPC m_NPC;
#endif

    public List<CharacterNPC> CharactersNPC
    {
        get { return m_Characters; }
    }

    public int InformationCount
    {
        get { return m_CharacterInfo.Count; }
    }

    public List<CharacterInfo> CharacterInfoList
    {
        get { return m_CharacterInfo; }
    }
    #endregion

    #region Unity API
    #endregion

    #region Public Methods
    public void SetNPC(CharacterNPC npc)
    {
        m_Characters.Add(npc);
    }
    
    public void UnloadNPCs()
    {
        m_Characters.Clear();
    }

#if UNITY_EDITOR
    public void Load()
    {
        m_NPC.gameObject.SetActive(true);
        CharacterNPC npc;
        for (int i = 0; i < m_CharacterInfo.Count; ++i)
        {
            npc = Instantiate<CharacterNPC>(m_NPC);
            npc.transform.SetParent(transform);
            npc.Load(m_CharacterInfo[i]);
            m_Characters.Add(npc);
        }
        m_NPC.gameObject.SetActive(false);
    }

    public void Save()
    {
        m_CharacterInfo.Clear();

        for (int i = 0; i < m_Characters.Count; ++i)
        {
            m_CharacterInfo.Add(new CharacterInfo(m_Characters[i]));
        }
    }

    public void Clear()
    {
        for (int i = 0; i < m_Characters.Count; ++i)
        {
            DestroyImmediate(m_Characters[i].gameObject);
        }
        m_Characters.Clear();
    }
#endif
    #endregion

    #region Protected Methods
    #endregion

    #region Private Methods
    #endregion
}
