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

    public enum eEvent
    {
        RECEIVE,
        GIVE,
        EVENT
    }
    #endregion

    #region Unity API
    protected GameProgressTracker m_Progress;
    #endregion

    #region Public Methods
    public void LoadGameProgress(GameProgressTracker progress)
    {
        m_Progress = progress;
        m_Progress.Reset();
    }

    public void TriggerEvent(eEvent evt, string name)
    {
        switch (evt)
        {
            case eEvent.EVENT:
                m_Progress.CompleteEvent(name);
                break;
            case eEvent.RECEIVE:
                m_Progress.ReceiveItem(name);
                break;
            case eEvent.GIVE:
                m_Progress.GiveItem(name);
                break;
        }
    }

    public bool Contains(eTracked tracked, string item)
    {
        bool result = false;

        switch (tracked)
        {
            case eTracked.ITEM:
                result = m_Progress.HasItem(item);
                break;
            case eTracked.EVENT:
                result = m_Progress.IsEventCompleted(item);
                break;
        }

        return result;
    }
    #endregion

    #region Protected Methods
    #endregion

    #region Private Methods
    #endregion
}