//
// Script name: CreateScriptableObjectWindow
//
//
// Programmer: Kentaurus
//

using UnityEngine;
using System.Collections;
using UnityEditor;
using System;

namespace Shooter
{
	public class CreateScriptableObjectWindow : EditorWindow 
	{
		#region Variables
		protected string[] LIST_OF_STRING_SCRIPTABLE_OBJECT = new String[]
		{
			"Create Projectile",
			"Create Launcher"
		};

		protected static readonly System.Type[] LIST_OF_SCRIPTABLE_OBJECT = new System.Type[]
		{
			typeof(CreateProjectileEditor),
			typeof(CreateLauncherEditor)
		};

		protected ShooterEditor m_CurrentSelected = null;
		protected int m_SelectedIndex = 0;
		protected int m_LastIndex = -1;
		#endregion

		#region Unity API
		protected virtual void OnGUI()
		{
			m_SelectedIndex = EditorGUILayout.Popup(m_SelectedIndex, LIST_OF_STRING_SCRIPTABLE_OBJECT);

			if (m_LastIndex != m_SelectedIndex)
			{
				if (m_CurrentSelected != null)
				{
					m_CurrentSelected.Clear();
				}

				m_CurrentSelected = (ShooterEditor)System.Activator.CreateInstance(LIST_OF_SCRIPTABLE_OBJECT[m_SelectedIndex]);

				m_CurrentSelected.Init();
				m_LastIndex = m_SelectedIndex;
			}

			if (m_CurrentSelected == null)
			{
				return;
			}

			m_CurrentSelected.DisplayEditor();

			EditorGUILayout.BeginHorizontal();

			if (GUILayout.Button("Create Scriptable Object"))
			{
				m_CurrentSelected.CreateScriptableObject();
			}

			if (GUILayout.Button("Clear"))
			{
				m_CurrentSelected.Clear();
			}

			EditorGUILayout.EndHorizontal();
		}
		#endregion

		#region Public Methods
		#endregion

		#region Protected Methods
		#endregion

		#region Private Methods
		#endregion

	}
}