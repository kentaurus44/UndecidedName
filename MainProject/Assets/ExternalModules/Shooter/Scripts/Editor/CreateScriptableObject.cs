using UnityEngine;
using System.Collections;
using UnityEditor;

namespace Shooter
{
	public class MakeScriptableObject 
	{
		[MenuItem("Kentaurs/Create/Scriptable Object")]
		public static void CreateScriptableObject()
		{
			CreateScriptableObjectWindow window = (CreateScriptableObjectWindow)EditorWindow.GetWindow(typeof(CreateScriptableObjectWindow));
			window.Show();
		}
	}
}