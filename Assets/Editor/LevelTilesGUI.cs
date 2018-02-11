using UnityEngine;
using UnityEditor;
using System.Collections;

[InitializeOnLoad]
public class LevelTilesGUI : Editor 
{
	static Transform m_LevelParent;
	static Transform LevelParent
	{
		get
		{
			if( m_LevelParent == null )
			{
				GameObject go = GameObject.Find( "Level" );

				if( go != null )
				{
					m_LevelParent = go.transform;
				}
			}

			return m_LevelParent;
		}
	}

	public static int SelectedTile
	{
		get
		{
			return EditorPrefs.GetInt( "SelectedEditorTile", 0 );
		}
		set
		{
			EditorPrefs.SetInt( "SelectedEditorTile", value );
		}
	}

	static LevelTiles m_LevelTiles;

	static LevelTilesGUI()
	{
		SceneView.onSceneGUIDelegate -= OnSceneGUI;
		SceneView.onSceneGUIDelegate += OnSceneGUI;

		//Make sure we load our block database. Notice the path here, which means the block database has to be in this specific location so we can find it
		//LoadAssetAtPath is a great way to load an asset from the project
		m_LevelTiles = AssetDatabase.LoadAssetAtPath<LevelTiles>( "Assets/Prefabs/Tiles/Level Tiles.asset" );
	}

	void OnDestroy()
	{
		SceneView.onSceneGUIDelegate -= OnSceneGUI;
	}

	static void OnSceneGUI( SceneView sceneView )
	{
		if( m_LevelTiles == null )
		{
			return;
		}

		DrawCustomTileButtons( sceneView );
		HandleLevelEditorPlacement();
	}

	static void HandleLevelEditorPlacement()
	{
		if( LevelEditorGUI.SelectedTool == 0 )
		{
			return;
		}

		//This method is very similar to the one in E08. Only the AddBlock function is different

		//By creating a new ControlID here we can grab the mouse input to the SceneView and prevent Unitys default mouse handling from happening
		//FocusType.Passive means this control cannot receive keyboard input since we are only interested in mouse input
		int controlId = GUIUtility.GetControlID( FocusType.Passive );

		//If the left mouse is being clicked and no modifier buttons are being held
		if( Event.current.type == EventType.MouseDown &&
			Event.current.button == 0 &&
			Event.current.alt == false &&
			Event.current.shift == false &&
			Event.current.control == false )
		{
			if( LevelEditor.MouseIsInPlayspace == true )
			{
				if( LevelEditorGUI.SelectedTool == 1 )
				{
					LevelEditorPaint.RemoveTile( LevelEditor.CurrentHandlePosition + Vector2.down );
				}

				if( LevelEditorGUI.SelectedTool == 2 )
				{
					if( SelectedTile < m_LevelTiles.Tiles.Count )
					{
						AddTile( LevelEditor.CurrentHandlePosition + Vector2.down, m_LevelTiles.Tiles[ SelectedTile ].Prefab );
					}
				}
			}
		}

		//If we press escape we want to automatically deselect our own painting or erasing tools
		if( Event.current.type == EventType.KeyDown &&
			Event.current.keyCode == KeyCode.Escape )
		{
			LevelEditorGUI.SelectedTool = 0;
		}

		HandleUtility.AddDefaultControl( controlId );
	}

	//Draw a list of our custom blocks on the left side of the SceneView
	static void DrawCustomTileButtons( SceneView sceneView )
	{
		Handles.BeginGUI();

		GUI.Box( new Rect( 0, 0, 60, sceneView.position.height - 35 ), GUIContent.none, EditorStyles.textArea );

		for( int i = 0; i < m_LevelTiles.Tiles.Count; ++i )
		{
			DrawCustomTileButton( i, sceneView.position );
		}

		Handles.EndGUI();
	}

	static void DrawCustomTileButton( int index, Rect sceneViewRect )
	{
		bool isActive = false;

		if( LevelEditorGUI.SelectedTool == 2 && index == SelectedTile )
		{
			isActive = true;
		}
			
		//By passing a Prefab or GameObject into AssetPreview.GetAssetPreview you get a texture that shows this object
		Texture2D previewImage = AssetPreview.GetAssetPreview( m_LevelTiles.Tiles[ index ].Prefab );
		GUIContent buttonContent = new GUIContent( previewImage );

		bool isToggleDown = GUI.Toggle( new Rect( 5, index * 50 + 25, 20, 20 ), isActive, buttonContent, GUI.skin.button );
		GUI.contentColor = Color.black;
		GUI.Label( new Rect( 5, index * 50 + 5, 70, 20 ), m_LevelTiles.Tiles[ index ].Name );

		//If this button is clicked but it wasn't clicked before (ie. if the user has just pressed the button)
		if( isToggleDown == true && isActive == false )
		{
			SelectedTile = index;
			LevelEditorGUI.SelectedTool = 2;
		}
	}

	public static void AddTile( Vector2 position, GameObject prefab )
	{
		if( prefab == null )
		{
			return;
		}

		GameObject newRect = (GameObject)PrefabUtility.InstantiatePrefab( prefab );
		newRect.transform.parent = LevelParent;
		newRect.transform.position = position;

		//Make sure a proper Undo/Redo step is created. This is a special type for newly created objects
		Undo.RegisterCreatedObjectUndo( newRect, "Add " + prefab.name );

		UnityEditor.SceneManagement.EditorSceneManager.MarkAllScenesDirty();
	}
}