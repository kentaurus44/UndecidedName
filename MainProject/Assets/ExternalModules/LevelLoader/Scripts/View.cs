//
// Script name: Scene
//
//
// Programmer: Kentaurus
//

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace LevelLoader
{
	public class View : MonoBehaviour 
	{
		#region Variables
		#endregion

		#region Unity API
		#endregion

		#region Public Methods
		public virtual void Load(ViewInformation scene)
		{

		}

		public void Save()
		{
			ViewInformation view = Resources.Load<ViewInformation>(Path.Combine(LevelLoaderConstants.SCENE_INFORMATION_PATH, name));

#if UNITY_EDITOR
			if (view == null)
			{
				view = view ?? ScriptableObject.CreateInstance<ViewInformation>();
				UnityEditor.AssetDatabase.CreateAsset(view , "Assets/Resources/" + LevelLoaderConstants.SCENE_INFORMATION_PATH + name + ".asset");
			}
#endif

			Save(view);

#if UNITY_EDITOR
			UnityEditor.AssetDatabase.SaveAssets();
#endif
		}
		#endregion

		#region Protected Methods
		protected virtual void Save(ViewInformation scene)
		{
			Debug.LogFormat("Saving {0}", name);
		}
		#endregion

		#region Private Methods
		#endregion

	}
}