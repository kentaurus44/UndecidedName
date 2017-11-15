//
// Script name: BaseTouch
//
//
// Programmer: Kentaurus
//

using UnityEngine;
using System.Collections;

namespace TouchAction
{
	public class BaseTouch : Subject, ITouchable
	{
		#region Variables
		public const string TOUCH_BEGIN = "TOUCH_BEGIN";
		public const string TOUCH_MOVED = "TOUCH_MOVED";
		public const string TOUCH_ENDED = "TOUCH_ENDED";
		[SerializeField] protected bool m_SwallowTouch = true;
		#endregion

		#region Unity API
		public System.Action OnTouchBeginAction;
		public System.Action OnTouchMovedAction;
		public System.Action OnTouchEndedAction;
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
			bool isTouch = m_SwallowTouch;

			if (isTouch)
			{
				if (OnTouchBeginAction != null)
				{
					OnTouchBeginAction();
				}

				NotifyObservers(TOUCH_BEGIN, evt);
			}

			return isTouch;
		}

		public virtual void OnTouchMoved(TouchEvent evt)
		{
			if (OnTouchMovedAction != null)
			{
				OnTouchMovedAction();
			}

			NotifyObservers(TOUCH_MOVED, evt);
		}

		public virtual void OnTouchEnded(TouchEvent evt)
		{
			if (OnTouchEndedAction != null)
			{
				OnTouchEndedAction();
			}

			NotifyObservers(TOUCH_ENDED, evt);
		}
		#endregion

	}
}