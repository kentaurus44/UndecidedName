//
// Script name: TempControlVisual.cs
//
//
// Programmer: Kentaurus
//

using UnityEngine;

using System.Collections;


public class TempControlVisual : MonoBehaviour
{
    #region Variables
    private static readonly Color ACTIVE_COLOR = Color.red;
    private static readonly Color INACTIVE_COLOR = Color.white;

    [SerializeField] protected Renderer m_Renderer;
    #endregion

    #region Unity API
    #endregion

    #region Public Methods
    public void Active()
    {
        SetColor(ACTIVE_COLOR);
    }

    public void Inactive()
    {
        SetColor(INACTIVE_COLOR);
    }
    #endregion

    #region Protected Methods
    #endregion

    #region Private Methods
    private void SetColor(Color color)
    {
        m_Renderer.material.color = color;
    }
    #endregion
}