//
// Script name: CameraPerimeter.cs
//
//
// Programmer: Kentaurus
//

using UnityEngine;

using System.Collections;

public class CameraPerimeter : MonoBehaviour
{
    #region Variables
    public Vector3 m_Size;

    public Vector3 Center
    {
        get { return transform.position; }
    }

    public Vector3 Size
    {
        get { return m_Size; }
    }
    #endregion

    #region Unity API
#if UNITY_EDITOR
    protected void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawLine(new Vector3(LeftExtend(), DownExtend(), 0f), new Vector3(LeftExtend(), UpExtend(), 0f));
        Gizmos.DrawLine(new Vector3(RightExtend(), DownExtend(), 0f), new Vector3(RightExtend(), UpExtend(), 0f));
        Gizmos.DrawLine(new Vector3(LeftExtend(), UpExtend(), 0f), new Vector3(RightExtend(), UpExtend(), 0f));
        Gizmos.DrawLine(new Vector3(LeftExtend(), DownExtend(), 0f), new Vector3(RightExtend(), DownExtend(), 0f));
    }
#endif
    #endregion

    #region Public Methods
    public float RightExtend()
    {
        return Center.x + (Size.x / 2f);
    }

    public float LeftExtend()
    {
        return Center.x - (Size.x / 2f);
    }

    public float UpExtend()
    {
        return Center.y + (Size.y / 2f);
    }

    public float DownExtend()
    {
        return Center.y - (Size.y / 2f);
    }
    #endregion

    #region Protected Methods
    #endregion

    #region Private Methods
    #endregion
}