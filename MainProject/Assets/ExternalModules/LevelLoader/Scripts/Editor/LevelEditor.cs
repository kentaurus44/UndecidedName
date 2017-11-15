//
// Script name: LevelEditor
//
//
// Programmer: Kentaurus
//

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using System;
using System.IO;
using UnityEngine.Events;

namespace LevelLoader
{
	public class LevelEditor : EditorWindow 
	{
		#region Variables
		private int m_SelectedIndex = -1;
		public string[] m_Files = null;
		private Vector2 m_CurrentScrollPosition = Vector2.zero;
		#endregion

		#region Unity API
		protected virtual void OnGUI()
		{
			Init();

			DisplayList();

			UtilityButtons();
		}
		#endregion

		#region Public Methods
		#endregion

		#region Protected Methods
		#endregion

		#region Private Methods
		private void Init()
		{
			if (EditorApplication.isCompiling)
			{
				Refresh();
				return;
			}

			if (LevelManager.IsInstanceNull())
			{
				GameObject obj = GameObject.Find("LevelManager");

				if (obj != null)
				{
					DestroyImmediate(obj);
				}

				LevelManager.Instance.Init();
			}


			if (m_Files == null || m_Files.Length == 0)
			{
				DirectoryInfo dir = new DirectoryInfo("Assets/Resources/" + LevelLoaderConstants.SCENE_INFORMATION_PATH);
				FileInfo[] files = dir.GetFiles();
				List<string> list = new List<string>();
				for (int i = 0; i < files.Length; ++i)
				{
					if (files[i].Extension == ".asset")
					{
						list.Add(files[i].Name.Replace(files[i].Extension, ""));
					}
				}

				m_Files = list.ToArray();
			}
		}

		private void DisplayList()
		{
			m_CurrentScrollPosition = EditorGUILayout.BeginScrollView(m_CurrentScrollPosition);
			m_SelectedIndex = GUILayout.SelectionGrid(m_SelectedIndex, m_Files, 1, GUI.skin.button);
			EditorGUILayout.EndScrollView();
		}

		private void UtilityButtons()
		{
			EditorGUILayout.BeginHorizontal();
			if (GUILayout.Button("Refresh"))
			{
				Refresh();
			}

			if (GUILayout.Button("Load"))
			{
				if (m_Files.Length > 0)
				{
					LevelManager.Instance.Load(m_Files[m_SelectedIndex]);
				}
				else
				{
					Debug.LogError("LevelManager: Nothing Selected.");
				}
			}

			if (GUILayout.Button("Save"))
			{
				LevelManager.Instance.Save();
				EditorUtility.FocusProjectWindow();
			}

			if (GUILayout.Button("Clear"))
			{
				LevelManager.Instance.ClearAll();
			}
			EditorGUILayout.EndHorizontal();
		}
	
		private void Refresh()
		{
			m_SelectedIndex = -1;
			m_Files = null;
		}
		#endregion
	}
}