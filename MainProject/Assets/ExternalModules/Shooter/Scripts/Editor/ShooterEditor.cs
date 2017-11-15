//
// Script name: ShooterEditor
//
//
// Programmer: Kentaurus
//

using UnityEngine;
using UnityEngine.Events;
using UnityEditor;

namespace Shooter
{
	public abstract class ShooterEditor
	{
		#region Variables
		private string PATH_TO_PARAMETERS = "Assets/Resources/Parameters/{1}/{0}.asset";

		protected ScriptableObject m_ScriptableObject;
		protected string m_Name = "";

		#endregion

		#region Unity API
		#endregion

		#region Public Methods
		public virtual void Init()
		{
			// STUB
		}

		public virtual void DisplayEditor()
		{
			// STUB
		}

		public virtual void CreateScriptableObject()
		{
			if (m_Name == null || m_ScriptableObject == null)
			{
				Debug.LogError("Nothing to create.");
				return;
			}

			string path = string.Format(PATH_TO_PARAMETERS, m_Name, m_ScriptableObject.GetType().Name);

			AssetDatabase.CreateAsset(m_ScriptableObject, path);
	        AssetDatabase.SaveAssets();
	        EditorUtility.FocusProjectWindow();
			Selection.activeObject = m_ScriptableObject;
		}

		public virtual void Clear()
		{
			// STUB
		}
		#endregion

		#region Protected Methods
		#endregion

		#region Private Methods
		#endregion

	}
}