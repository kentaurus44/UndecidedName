//
// Script name: PlayerController
//
//
// Programmer: Kentaurus
//

using UnityEngine;
using System.Collections;

public class PlayerController : SubjectObserver 
{
	#region Variables
	private const float SHOOTING_DEPTH = 0f;

	[SerializeField] protected TouchAction.BaseTouch m_TouchController;
	[SerializeField] protected Shooter.BasicLauncher m_Launcher;
	[SerializeField] protected bool m_AreControlsEnabled = false;
	#endregion

	#region Unity API
	protected virtual void Awake()
	{
		m_TouchController.RegisterObserver(this);
	}

	protected override void OnDestroy()
	{
		base.OnDestroy();
		m_TouchController.UnregisterObserver(this);
	}
	#endregion

	#region Public Methods
	public virtual void EnableControls(bool isEnabled)
	{
		m_AreControlsEnabled = isEnabled;
	}
	#endregion

	#region Protected Methods
	#endregion

	#region Private Methods
	#endregion

	#region IObservable
	public override void OnNotify(ISubject subject, params object[] args)
	{
		base.OnNotify(subject, args);

		if (subject is TouchAction.BaseTouch && subject == m_TouchController)
		{
			if (!m_AreControlsEnabled)
			{
				return;
			}

			string evt = args[0].ToString();
			TouchAction.TouchEvent touchEvt = args[1] as TouchAction.TouchEvent;
			switch(evt)
			{
				case TouchAction.BaseTouch.TOUCH_BEGIN:
				break;
				case TouchAction.BaseTouch.TOUCH_MOVED:
				break;
				case TouchAction.BaseTouch.TOUCH_ENDED:
				Vector3 position = touchEvt.CurrentPosition;
				position.z = SHOOTING_DEPTH;
				m_Launcher.Fire(position);
				break;
			}
		}
	}
	#endregion

}
