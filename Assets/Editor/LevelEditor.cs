using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;
using UnityEditor.SceneManagement;
using System.Collections;

[InitializeOnLoad]
public class LevelEditor : Editor 
{

	public static Vector2 CurrentHandlePosition = Vector2.zero;
	public static bool MouseIsInPlayspace = true;

	static Vector2 m_OldHandlePosition = Vector2.zero;

	static LevelEditor () 
	{
		SceneView.onSceneGUIDelegate -= OnSceneGUI;
		SceneView.onSceneGUIDelegate += OnSceneGUI;
	}

	void OnDestroy() 
	{
		SceneView.onSceneGUIDelegate -= OnSceneGUI;
	}

	static void OnSceneGUI(SceneView sceneView)
	{
		
		bool isLevelEditorEnabled = EditorPrefs.GetBool( "IsLevelEditorEnabled", true );

		if( isLevelEditorEnabled == false )
		{
			return;
		}

		UpdateHandlePosition ();
		UpdateRepaint();

		DrawRectDrawPreview ();
	}

	static void UpdateHandlePosition () 
	{
		if( Event.current == null )
		{
			return;
		}
			
		Vector3 mousePos3D = HandleUtility.GUIPointToWorldRay (Event.current.mousePosition).origin;
		Vector2 mousePos2D = new Vector2 (mousePos3D.x, mousePos3D.y);
		CurrentHandlePosition = new Vector2 (Mathf.Floor (mousePos2D.x), Mathf.Ceil (mousePos2D.y));

		/*if (CurrentHandlePosition.x < 1 || CurrentHandlePosition.y > -1) 
		{
			MouseIsInPlayspace = false;
		} else 
		{
			MouseIsInPlayspace = true;
		}*/
	}

	static void UpdateRepaint() 
	{
		if (CurrentHandlePosition != m_OldHandlePosition) 
		{
			SceneView.RepaintAll ();
			m_OldHandlePosition = CurrentHandlePosition;
		}
	}

	static void DrawRectDrawPreview()
	{
		if (!MouseIsInPlayspace) 
		{
			return;
		}

		Handles.color = new Color( EditorPrefs.GetFloat( "CubeHandleColorR", 1f ), EditorPrefs.GetFloat( "CubeHandleColorG", 1f ), EditorPrefs.GetFloat( "CubeHandleColorB", 0f ) );

		DrawHandlesRect( CurrentHandlePosition );
	}

	static void DrawHandlesRect (Vector2 corner) 
	{
		Vector3 p1 = new Vector3 (corner.x, corner.y, 0);
		Vector3 p2 = p1 + new Vector3 (0, -1, 0);
		Vector3 p3 = p1 + new Vector3 (1, 0, 0);
		Vector3 p4 = p1 + new Vector3 (1, -1, 0);

		Handles.DrawLine (p1, p2);
		Handles.DrawLine (p1, p3);
		Handles.DrawLine (p2, p4);
		Handles.DrawLine (p3, p4);
	}
}
