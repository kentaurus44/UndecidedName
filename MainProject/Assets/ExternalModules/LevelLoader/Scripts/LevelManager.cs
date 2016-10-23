//
// Script name: LevelManager
//
//
// Programmer: Kentaurus
//

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace LevelLoader
{
	public class LevelManager : SingletonComponent<LevelManager>
	{
		#region Variables

		[SerializeField] protected static Dictionary<string, View> m_Views = new Dictionary<string, View>();
		[SerializeField] protected View m_ViewResource = null;
		#endregion

		#region Unity API
		#endregion

		#region Public Methods
		public override void Init()
		{
			base.Init();
		}

		public void Load(string name)
		{
			if (!m_Views.ContainsKey(name))
			{
				Debug.LogFormat("Loading {0}", name);
				if (m_ViewResource == null)
				{
					m_ViewResource = Resources.Load<View>(LevelLoaderConstants.VIEW_PREFAB);
				}

				View view = Instantiate<View>(m_ViewResource);
				view.name = name;
				view.transform.parent = transform;
				view.transform.localPosition = Vector3.zero;

				ViewInformation viewInformation = Resources.Load<ViewInformation>( System.IO.Path.Combine(LevelLoaderConstants.SCENE_INFORMATION_PATH, name) );
				view.Load(viewInformation);

				m_Views.Add(name, view);
			}
			else
			{
				
			}
		}

		public void Save()
		{
			Debug.Log("Save");
			SaveViews();
			View[] views = GetComponentsInChildren<View>();

			for (int i = 0; i < views.Length; ++i)
			{
				views[i].Save();
			} 
		}

		public void Clear(string name)
		{
			DestroyImmediate(m_Views[name].gameObject);
			m_Views.Remove(name);
		}

		public void ClearAll()
		{
			Debug.Log("Clearing All");
			foreach(View view in m_Views.Values)
			{
				if (view != null)
				{
					DestroyImmediate(view.gameObject);
				}
			}

			m_Views.Clear();
		}
		#endregion

		#region Protected Methods
		#endregion

		#region Private Methods
		private void SaveViews()
		{
			foreach(View view in m_Views.Values)
			{
				view.Save();
			}

			ClearAll();
		}
		#endregion

	}
}