//
// Script name: CreateLauncherEditor
//
//
// Programmer: Kentaurus
//

using UnityEngine;
using System.Collections;
using UnityEditor;

namespace Shooter
{
	public class CreateLauncherEditor : ShooterEditor 
	{
		#region Variables
		protected LauncherParameters Launcher
		{
			get { return m_ScriptableObject as LauncherParameters; }
		}

		#endregion

		#region Unity API
		#endregion

		#region Public Methods
		public override void Init()
		{
			base.Init();
			m_ScriptableObject = ScriptableObject.CreateInstance<LauncherParameters>();
		}

		public override void DisplayEditor()
		{
			base.DisplayEditor();
			m_Name = GetInputField("Name", m_Name);
			Launcher.LaunchVelocity = GetInputField("Launch Velocity", Launcher.LaunchVelocity);
			Launcher.ReloadTime = GetInputField("Reload Time", Launcher.ReloadTime);
		}

		public override void Clear()
		{
			base.Clear();
			m_ScriptableObject = ScriptableObject.CreateInstance<LauncherParameters>();
		}
		#endregion

		#region Protected Methods
		protected int GetInputField(string labelName, int variable)
		{
			EditorGUILayout.BeginHorizontal();
			EditorGUILayout.LabelField(labelName);
			string value = GUILayout.TextField(variable.ToString());
			EditorGUILayout.EndHorizontal();
			int result = 0;
			int.TryParse(value, out result);
			return result;
		}

		protected float GetInputField(string labelName, float variable)
		{
			EditorGUILayout.BeginHorizontal();
			EditorGUILayout.LabelField(labelName);
			string value = GUILayout.TextField(variable.ToString());
			EditorGUILayout.EndHorizontal();
			float result = 0;
			float.TryParse(value, out result);
			return result;
		}

		protected string GetInputField(string labelName, string variable)
		{
			EditorGUILayout.BeginHorizontal();
			EditorGUILayout.LabelField(labelName);
			string value = GUILayout.TextField(variable.ToString());
			EditorGUILayout.EndHorizontal();
			return value;
		}
		#endregion

		#region Private Methods
		#endregion

	}
}