using UnityEngine;
using UnityEditor;
using System.Collections;

[InitializeOnLoad]
public class LevelEditorGUI : Editor {

	public static int SelectedTool
	{
		get 
		{ 
			return EditorPrefs.GetInt( "Selected Editor Tool", 0);
		}
		set { 
			if (value == SelectedTool) 
			{
				return;
			}

			EditorPrefs.SetInt ("Selected Editor Tool", value);

			switch (value) 
			{
			case 0:
				EditorPrefs.SetBool( "IsLevelEditorEnabled", false );

				Tools.hidden = false;
				break;
			case 1:
				EditorPrefs.SetBool( "IsLevelEditorEnabled", true );
				EditorPrefs.SetBool( "SelectBlockNextToMousePosition", false );
				EditorPrefs.SetFloat( "RectHandleColorR", Color.magenta.r );
				EditorPrefs.SetFloat( "RectHandleColorG", Color.magenta.g );
				EditorPrefs.SetFloat( "RectHandleColorB", Color.magenta.b );

				//Hide Unitys Tool handles (like the move tool) while we draw our own stuff
				Tools.hidden = true;
				break;
			default:
				EditorPrefs.SetBool( "IsLevelEditorEnabled", true );
				EditorPrefs.SetBool( "SelectBlockNextToMousePosition", true );
				EditorPrefs.SetFloat( "RectHandleColorR", Color.yellow.r );
				EditorPrefs.SetFloat( "RectHandleColorG", Color.yellow.g );
				EditorPrefs.SetFloat( "RectHandleColorB", Color.yellow.b );

				//Hide Unitys Tool handles (like the move tool) while we draw our own stuff
				Tools.hidden = true;
				break;
			}
		}
	}

	static LevelEditorGUI()
	{
		SceneView.onSceneGUIDelegate -= OnSceneGUI;
		SceneView.onSceneGUIDelegate += OnSceneGUI;

		EditorApplication.hierarchyWindowChanged -= OnSceneChanged;
		EditorApplication.hierarchyWindowChanged += OnSceneChanged;
	}

	void OnDestroy()
	{
		SceneView.onSceneGUIDelegate -= OnSceneGUI;

		EditorApplication.hierarchyWindowChanged -= OnSceneChanged;
	}

	static void OnSceneChanged()
	{
		//Tutorial hid editor on invalid scenes here
		Tools.hidden = LevelEditorGUI.SelectedTool != 0;
	}

	static void OnSceneGUI( SceneView sceneView )
	{
		/*if( IsInCorrectLevel() == false )
		{
			return;
		}*/

		DrawToolsMenu( sceneView.position );
	}

	static void DrawToolsMenu( Rect position )
	{
		//By using Handles.BeginGUI() we can start drawing regular GUI elements into the SceneView
		Handles.BeginGUI();

		//Here we draw a toolbar at the bottom edge of the SceneView
		GUILayout.BeginArea( new Rect( 0, position.height - 35, position.width, 20 ), EditorStyles.toolbar );
		{
			string[] buttonLabels = new string[] { "None", "Erase", "Paint" };

			SelectedTool = GUILayout.SelectionGrid(
				SelectedTool, 
				buttonLabels, 
				3,
				EditorStyles.toolbarButton,
				GUILayout.Width( 300 ) );
		}
		GUILayout.EndArea();

		Handles.EndGUI();
	}
}
