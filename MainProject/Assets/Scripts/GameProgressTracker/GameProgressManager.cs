//
// Script name: GameProgressManager.cs
//
//
// Programmer: Kentaurus
//

using UnityEngine;

using System.Collections;


public class GameProgressManager : SingletonComponent<GameProgressManager>
{
    #region Variables
    public enum eTracked
    {
        NOTHING,
        ITEM,
        EVENT
    }
    #endregion

    #region Unity API
    [SerializeField] protected GameProgressTracker m_Progress;
    #endregion

    #region Public Methods
    public void LoadGameProgress(GameProgressTracker progress)
    {
        m_Progress = progress;
    }

    public bool Contains(eTracked tracked, string item)
    {
        bool result = false;

        switch (tracked)
        {
            case eTracked.ITEM:
                result = VerifyItem(item);
                break;
            case eTracked.EVENT:
                result = VerifyEvent(item);
                break;
        }

        return result;
    }
    #endregion

    #region Protected Methods
    protected bool VerifyItem(string item)
    {
        return m_Progress.HasItem(item);
    }

    protected bool VerifyEvent(string evt)
    {
        return m_Progress.EventCompleted(evt);
    }
    #endregion

    #region Private Methods
    #endregion
}