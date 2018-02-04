
/*
* 1. Must be located in a "Editor" Folder in your Assets folder
* 2. Must have a script that is in the "typeof(SCRIPT HERE)" line that exists
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(CaptureScreenshotPlaymode))]
public class CaptureScreenShotInspector : Editor
{


	private string m_fileLocation, m_fileName;
	private int m_superSize = 1;

    public override void OnInspectorGUI()
    {

    	if(EditorApplication.isPlaying == true)
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

			GUILayout.Label("File Location: " + m_fileLocation);

			if(GUILayout.Button("Select Save Location", EditorStyles.miniButtonLeft))
			{
				m_fileLocation = EditorUtility.OpenFolderPanel( "Save Location", "", "" );
			}

			if(GUILayout.Button("Clear Save Location", EditorStyles.miniButtonRight))
			{
				m_fileLocation = "";
			}

			GUILayout.Space(20);
			GUILayout.Label("This will take some time to write to a file. Be patient.", EditorStyles.helpBox);
			if(GUILayout.Button("Capture Screenshot"))
			{

				CaptureScreen();

				Debug.Log("Screenshot taken! May take time to write to disk depending on how big it is.");
				Debug.Log("Save Location: " + m_fileLocation + "/" + m_fileName + ".png");
			}

		}
		else
		{
			GUILayout.Space(10);
			GUILayout.Label("Must Be In PlayMode for menu to display");
		}

    }


	//captures a screenshot at the designated save location, file name, supersize
	public void CaptureScreen()
	{
        ScreenCapture.CaptureScreenshot(m_fileLocation + "/" + m_fileName + ".png", m_superSize);
	}
}