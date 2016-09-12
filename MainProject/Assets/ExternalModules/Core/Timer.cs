//
// Script name: Timer
//
//
// Programmer: Kentaurus
//

using UnityEngine;
using System.Collections;

public class Timer 
{
	#region Variables
	public System.Action OnTimerDone;

	private float m_CurrentTime = -1f;
	private float m_TargetTime = -1f;

	private bool m_IsTimerPlaying = false;
	private bool m_ClearActions = false;

	public bool IsTimerPlaying
	{
		get { return m_IsTimerPlaying; }
	}

	public float Ratio
	{
		get { return m_CurrentTime / m_TargetTime; }
	}

	#endregion

	#region Unity API
	public Timer() {}
	#endregion

	#region Public Methods
	public void StartTimer(float time, System.Action onTimerDone = null, bool clearActions = false)
	{
		m_ClearActions = clearActions;
		m_TargetTime = time;
		m_CurrentTime = 0f;
		OnTimerDone += onTimerDone;
		m_IsTimerPlaying = true;
	}

	public void OnUpdate()
	{
		if (!m_IsTimerPlaying)
		{
			return;
		}

		m_CurrentTime += Time.deltaTime;

		if (m_CurrentTime >= m_TargetTime)
		{
			OnTimerComplete();
		}
	}
	#endregion

	#region Protected Methods
	#endregion

	#region Private Methods
	private void OnTimerComplete()
	{
		m_IsTimerPlaying = false;
		if (OnTimerDone != null)
		{
			System.Action callback = OnTimerDone;
			if (m_ClearActions)
			{
				OnTimerDone = null;
				m_ClearActions = false;
			}
			callback();
		}
	}
	#endregion

}
