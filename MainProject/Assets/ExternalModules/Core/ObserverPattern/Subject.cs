﻿//
// Script name: Subject
//
//
// Programmer: Kentaurus
//

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Subject : MonoBehaviour, ISubject
{
	#region Variables
	[SerializeField] protected List<IObserver> m_Observers = new List<IObserver>();
	#endregion

	#region Unity API
	protected virtual void OnDestroy()
	{
		for (int i = 0; i < m_Observers.Count; ++i)
		{
			m_Observers.Clear();
		}
	}
	#endregion

	#region Public Methods
	public virtual void RegisterObserver(IObserver observer)
	{
		if (!m_Observers.Contains(observer))
		{
			m_Observers.Add(observer);
		}
	}

	public virtual void UnregisterObserver(IObserver observer)
	{
		if (m_Observers.Contains(observer))
		{
			m_Observers.Remove(observer);
		}
	}

	public virtual void NotifyObservers(params object[] args)
	{
		for (int i = 0; i < m_Observers.Count; ++i)
		{
			if (m_Observers[i] != null)
			{
				m_Observers[i].OnNotify(this as ISubject, args);
			}
		}
	}
	#endregion

	#region Protected Methods
	#endregion

	#region Private Methods
	#endregion

}
