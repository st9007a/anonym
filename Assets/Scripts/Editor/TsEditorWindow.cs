﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

public class TsEditorWindow : EditorWindow
{

    string NewMachineName = "";
    List<Rect> windows = new List<Rect>();

    [MenuItem("Custom/ts Structure")]
    static void Init()
    {
        GetWindow(typeof(TsEditorWindow));
    }

    private void OnGUI()
    {

        GUILayout.BeginVertical();
        GUILayout.BeginArea(new Rect(10, 10, 200, 500));

        GUILayout.Label("Id: 1");

        GUILayout.BeginHorizontal();
        GUILayout.Label("Name :", GUILayout.Width(50));
        NewMachineName = GUILayout.TextField(NewMachineName, 15);
        GUILayout.EndHorizontal();

        if (GUILayout.Button("Add"))
        {
            windows.Add(new Rect(200, 100, 100, 100));
        }
        GUILayout.EndArea();
        GUILayout.EndVertical();


        BeginWindows();
        for (int i = 0; i < windows.Count; i++)
        {
            windows[i] = GUI.Window(i, windows[i], WindowFunction, "Box1");
        }
        EndWindows();
    }

    void WindowFunction(int windowId)
    {
        GUI.DragWindow();
    }

}
