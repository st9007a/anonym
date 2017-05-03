using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

public class SystemStructureEditorWindow : EditorWindow {

    string NewMachineName = "";
    int Display = 0;
    //string[] DisplayOpt = Enum.GetNames(typeof(MachineInfo.Display));

    List<Rect> windows = new List<Rect>();

    [MenuItem("Custom/System Structure")]
    static void Init() {
        GetWindow(typeof(SystemStructureEditorWindow));
    }

    private void OnGUI() {

        GUILayout.BeginVertical();
        GUILayout.BeginArea(new Rect(10, 10, 200, 500));

        GUILayout.Label("Id: 1");

        GUILayout.BeginHorizontal();
        GUILayout.Label("Name :", GUILayout.Width(50));
        NewMachineName = GUILayout.TextField(NewMachineName, 15);
        GUILayout.EndHorizontal();

        //GUILayout.BeginHorizontal();
       // GUILayout.Label("Display :", GUILayout.Width(50));
        //Display = EditorGUILayout.Popup(Display, DisplayOpt);
        //GUILayout.EndHorizontal();

        if (GUILayout.Button("Add")) {
            windows.Add(new Rect(100 + 100, 100, 100, 100));
        }
        GUILayout.EndArea();
        GUILayout.EndVertical();


        BeginWindows();
        for (int i = 0; i < windows.Count; i++) {
            windows[i] = GUI.Window(i, windows[i], WindowFunction, "Box1");
        }
        EndWindows();
    }

    void WindowFunction(int windowId) {
        GUI.DragWindow();
    }

}
