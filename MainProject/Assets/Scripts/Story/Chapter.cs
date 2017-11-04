//
// Script name: Chapter.cs
//
//
// Programmer: Kentaurus
//

using UnityEngine;

using System.Collections;


public class Chapter : MonoBehaviour
{
    #region Variables
    [SerializeField] protected Area[] m_Areas;
    [SerializeField] protected GameProgressTracker m_ProgressTracker;

    public GameProgressTracker ProgressTracker
    {
        get { return m_ProgressTracker; }
    }
    #endregion

    #region Unity API
    #endregion

    #region Public Methods
    public Area GetInitalArea()
    {
        Area area = null;

        for (int i = 0; i < m_Areas.Length; ++i)
        {
            if (m_Areas[i].InitialArea)
            {
                area = m_Areas[i];
            }
        }

        return area;
    }
    #endregion

    #region Protected Methods
    #endregion

    #region Private Methods
    #endregion
}