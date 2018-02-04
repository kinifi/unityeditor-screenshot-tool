/*
 * Must be located in a folder called "Editor"
 * Note: the %l is the shortcut for opening this window in unity. % = Alt/CMD button
 */

using UnityEngine;
using UnityEditor;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Assertions;

public class CaptureScreenShotEditor : EditorWindow
{

	private string m_fileLocation, m_fileName;
	private int m_superSize = 1;


	[MenuItem("Window/Screenshot Editor %l")]
	public static void ShowEditor()
	{

		//create the editor window
		CaptureScreenShotEditor editor = EditorWindow.GetWindow<CaptureScreenShotEditor>();
		//the editor window must have a min size
		editor.titleContent = new GUIContent("Screenshot");
		// editor.minSize = new Vector2 (600, 400);
		//call the init method after we create our window
		editor.Init();

	}


	private void Init()
	{

	}

	private void OnGUI()
	{
		GUILayout.Space(10);

		GUILayout.Label("Name the screenshot. Do not include file types", EditorStyles.helpBox);
		GUILayout.BeginHorizontal();
		m_fileName = EditorGUILayout.TextField("File Name: ", m_fileName);
		if(GUILayout.Button("Clear File Name", EditorStyles.miniButtonRight))
		{
			m_fileName = "";
		}
		GUILayout.EndHorizontal();

		GUILayout.Space(10);

		//screenshot size
		GUILayout.Label("What Size do you want? 1 = Normal Camera Resolution", EditorStyles.helpBox);
		m_superSize = EditorGUILayout.IntField("Size of screenshot", m_superSize);

		GUILayout.Space(10);

		//file save location
		GUILayout.Label("Where do you want to save this screenshot?", EditorStyles.helpBox);
		GUILayout.BeginHorizontal();
		if(GUILayout.Button("Select Save Location", EditorStyles.miniButtonLeft))
		{
			m_fileLocation = EditorUtility.OpenFolderPanel( "Save Location", "", "" );
		}

		if(GUILayout.Button("Clear Save Location", EditorStyles.miniButtonRight))
		{
			m_fileLocation = "";
		}

		GUILayout.EndHorizontal();


		GUILayout.Space(20);
		GUILayout.Label("This will take some time to write to a file. Be patient.", EditorStyles.helpBox);
		if(GUILayout.Button("Capture Screenshot"))
		{
			CaptureScreen();

			Debug.Log("Screenshot taken! May take time to write to disk depending on how big it is.");
			Debug.Log("Save Location: " + m_fileLocation + "/" + m_fileName + ".png");
		}

		
	}

	//captures a screenshot at the designated save location, file name, supersize
	public void CaptureScreen()
	{
        ScreenCapture.CaptureScreenshot(m_fileLocation + "/" + m_fileName + ".png", m_superSize);
	}


	//UNITY EVENTS START

	public void PlaymodeChanged()
	{

		Repaint();
	}

	public void OnLostFocus ()
	{

		Repaint();
	}

	public void OnFocus()
	{

		Repaint();
	}

	public void OnProjectChange ()
	{

		Repaint();
	}

	public void OnSelectionChange ()
	{

		Repaint();
	}
	//UNITY EVENTS END


}
