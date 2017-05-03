using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

public class SystemStructureEditorWindow : EditorWindow {

    int Id;
    string NewMachineName = "";
    MachineInfo.Display Display;
    MachineInfo.Function Function;

    List<MachineInfo> Machines = new List<MachineInfo>(); 
    List<Rect> Windows = new List<Rect>();

    [MenuItem("Custom/System Structure")]
    static void Init() {
        GetWindow(typeof(SystemStructureEditorWindow));
    }

    private void OnGUI() {

        GUILayout.BeginVertical();
        GUILayout.BeginArea(new Rect(10, 10, 200, 500));

        GUILayout.Label("Id: " + Id);

        GUILayout.BeginHorizontal();
        GUILayout.Label("Name :", GUILayout.Width(80));
        NewMachineName = GUILayout.TextField(NewMachineName, 15);
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label("Display :", GUILayout.Width(80));
        Display = (MachineInfo.Display)EditorGUILayout.EnumPopup(Display);
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label("Function :", GUILayout.Width(80));
        Function = (MachineInfo.Function)EditorGUILayout.EnumPopup(Function);
        GUILayout.EndHorizontal();

        if (GUILayout.Button("Add")) {
            Windows.Add(new Rect(200, 100, 100, 100));
            MachineInfo m = new MachineInfo();
            m.Id = Id++;
            m.Name = NewMachineName;
            m.DisplayType = Display;
            m.MachineFunc = Function;

            Machines.Add(m);

        }
        GUILayout.EndArea();
        GUILayout.EndVertical();


        BeginWindows();
        for (int i = 0; i < Windows.Count; i++) {
            Windows[i] = GUI.Window(i, Windows[i], WindowFunction, Machines[i].Name);
        }
        EndWindows();
    }

    void WindowFunction(int windowId) {
        GUI.DragWindow();
    }

}
