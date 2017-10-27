//
// Script name: GameController.cs
//
//
// Programmer: Kentaurus
//

using UnityEngine;

using System.Collections;


public class GameController : MonoBehaviour
{
    #region Variables
	[SerializeField] protected DirectionalInputController m_InputController;
	[SerializeField] protected PlayerController m_PlayerController;
    [SerializeField] protected CameraController m_CameraController;
    [SerializeField] protected CameraPerimeter m_Perimeter;
    #endregion
    
    #region Unity API
	protected void Awake()
	{
        CustomCamera.CameraManager.Instance.Init();
        TouchAction.TouchManager.Instance.Init();

        m_InputController.RegisterObserver(m_PlayerController);
        m_CameraController.Init();
        m_CameraController.LoadPerimeter(m_Perimeter);
        m_InputController.Init();
    }

	protected void OnDestroy()
	{
		m_InputController.UnregisterObserver(m_PlayerController);
	}
    #endregion

    #region Public Methods
    #endregion

    #region Protected Methods
    #endregion

    #region Private Methods
    #endregion
}