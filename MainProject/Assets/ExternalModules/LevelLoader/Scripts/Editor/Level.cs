//
// Script name: Level
//
//
// Programmer: Kentaurus
//

using UnityEditor;

namespace LevelLoader
{
	public class Level
	{
		[MenuItem("Kentaurus/LeveLoader/Open...")]
		public static void Open()
		{
			LevelEditor window = (LevelEditor)EditorWindow.GetWindow(typeof(LevelEditor));
			window.Show();
		}
	}
}