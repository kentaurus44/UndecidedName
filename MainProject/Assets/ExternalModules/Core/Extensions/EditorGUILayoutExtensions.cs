using UnityEngine;
using System.Linq;
#if UNITY_EDITOR
public static class EditorGUILayoutExtensions
{
	public static T DragAndDropArea<T>(Rect rect, string label, T defaultObject = null) where T : Object
	{
		object[] objs = DragAndDropArea(rect, label);
		if (objs != null && objs[0] != null)
		{
			if (objs[0] is T)
			{
				return objs[0] as T;
			}
			else
			{
#if UNITY_EDITOR
				Debug.LogErrorFormat("<color=red>{0}</color> is not supported at this drop location.", (objs[0] as Object).name);
#endif
			}
		}
		return defaultObject;
	}

	public static Object[] DragAndDropArea(Rect rect, string label)
	{
		Event evt = Event.current;
		GUI.Box(rect, label);

		var eventType = Event.current.type;

		if (rect.Contains(evt.mousePosition) && (eventType == EventType.DragUpdated || eventType == EventType.DragPerform))
		{
			// Show a copy icon on the drag
			UnityEditor.DragAndDrop.visualMode = UnityEditor.DragAndDropVisualMode.Copy;

			if (eventType == EventType.DragPerform)
			{
				UnityEditor.DragAndDrop.AcceptDrag();
				return UnityEditor.DragAndDrop.objectReferences;
			}

			Event.current.Use();
		}

		return null;
	}

	/// <summary>
	/// Function that finds all scripts inheriting from a certain class
	/// </summary>
	/// <returns>The class.</returns>
	/// <typeparam name="T">The 1st type parameter.</typeparam>
	public static System.Type[] GetClass<T>()
	{
		System.Type[] types = System.Reflection.Assembly.GetExecutingAssembly().GetTypes();
		return (from System.Type type in types
				where type.IsSubclassOf(typeof(T))
				select type).ToArray();
	}
}
#endif