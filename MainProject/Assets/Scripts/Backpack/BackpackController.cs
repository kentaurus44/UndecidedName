//
// Script name: BackpackController.cs
//
//
// Programmer: Kentaurus
//

using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class BackpackController : MonoBehaviour
{
    #region Variables
    [SerializeField] protected Button m_OpenBackpack;
    [SerializeField] protected Button m_CloseBackpack;
    [SerializeField] protected PanelMover m_PanelMover;
    [SerializeField] protected Inventory m_Inventory;
    #endregion

    #region Unity API
    protected void Awake()
    {
        DisablePanel();
        EnableBackpack(false);
        m_PanelMover.HideImmediately();
    }
    #endregion

    #region Public Methods
    public void OpenBackpack()
    {
        EnablePanel(true);
        EnableBackpack(true);
        m_PanelMover.Show();
    }

    public void CloseBackpack()
    {
        EnableBackpack(false);
        m_PanelMover.Hide(DisablePanel);
    }

    public void Init(GameProgressTracker progress)
    {
        m_Inventory.Init(progress);
    }

    #endregion

    #region Protected Methods
    #endregion

    #region Private Methods
    private void EnableBackpack(bool enable)
    {
        m_OpenBackpack.gameObject.SetActive(!enable);
        m_CloseBackpack.gameObject.SetActive(enable);
    }
    private void DisablePanel()
    {
        EnablePanel(false);
    }

    private void EnablePanel(bool enable)
    {
        m_PanelMover.gameObject.SetActive(enable);
    }
    #endregion
}