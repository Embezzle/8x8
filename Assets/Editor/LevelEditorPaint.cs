using UnityEngine;
using UnityEditor;
using System.Collections;

[InitializeOnLoad]
public class LevelEditorPaint : Editor {
	
	static Transform m_LevelParent;
	public static Transform LevelParent
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

	static LevelEditorPaint()
	{
		SceneView.onSceneGUIDelegate -= OnSceneGUI;
		SceneView.onSceneGUIDelegate += OnSceneGUI;
	}

	void OnDestroy()
	{
		SceneView.onSceneGUIDelegate -= OnSceneGUI;
	}

	static void OnSceneGUI( SceneView sceneView )
	{
		if( LevelEditorGUI.SelectedTool == 0 )
		{
			return;
		}

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
					//If there eraser tool is selected, erase the block at the current block handle position
					RemoveTile( LevelEditor.CurrentHandlePosition );
				}

				if( LevelEditorGUI.SelectedTool == 2 )
				{
					//If the paint tool is selected, create a new block at the current block handle position
					AddTile( LevelEditor.CurrentHandlePosition );
				}
			}
		}

		//If we press escape we want to automatically deselect our own painting or erasing tools
		if( Event.current.type == EventType.KeyDown &&
			Event.current.keyCode == KeyCode.Escape )
		{
			LevelEditorGUI.SelectedTool = 0;
		}

		//Add our controlId as default control so it is being picked instead of Unitys default SceneView behaviour
		HandleUtility.AddDefaultControl( controlId );
	}

	public static void AddTile( Vector2 position )
	{
		/*GameObject newSprite = GameObject.CreatePrimitive( PrimitiveType.Cube );
		newSprite.transform.parent = LevelParent;
		newSprite.transform.position = position;

		//Make sure a proper Undo/Redo step is created. This is a special type for newly created objects
		Undo.RegisterCreatedObjectUndo( newSprite, "Add Cube" );

		//Mark the scene as dirty so it is being saved the next time the user saves
		UnityEditor.SceneManagement.EditorSceneManager.MarkAllScenesDirty();*/
	}

	public static void RemoveTile( Vector2 position )
	{
		for( int i = 0; i < LevelParent.childCount; ++i )
		{
			float distanceToTile = Vector2.Distance( LevelParent.GetChild( i ).transform.position, position );
			if( distanceToTile < 0.1f )
			{
				//Use Undo.DestroyObjectImmediate to destroy the object and create a proper Undo/Redo step for it
				Undo.DestroyObjectImmediate( LevelParent.GetChild( i ).gameObject );

				//Mark the scene as dirty so it is being saved the next time the user saves
				UnityEditor.SceneManagement.EditorSceneManager.MarkAllScenesDirty();
				return;
			}
		}
	}
}
