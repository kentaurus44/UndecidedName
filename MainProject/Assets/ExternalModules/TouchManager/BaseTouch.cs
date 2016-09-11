﻿//
// Script name: BaseTouch
//
//
// Programmer: Kentaurus
//

using UnityEngine;
using System.Collections;

namespace TouchAction
{
	public class BaseTouch : MonoBehaviour, ITouchable
	{
		#region Variables

		[SerializeField] protected bool m_SwallowTouch = true;
		#endregion

		#region Unity API
		#endregion

		#region Public Methods
		#endregion

		#region Protected Methods
		#endregion

		#region Private Methods
		#endregion

		#region ITouchable
		public virtual bool OnTouchBegin(TouchEvent evt)
		{
			return m_SwallowTouch;
		}

		public virtual void OnTouchMoved(TouchEvent evt)
		{
			
		}

		public virtual void OnTouchEnded(TouchEvent evt)
		{

		}
		#endregion

	}
}