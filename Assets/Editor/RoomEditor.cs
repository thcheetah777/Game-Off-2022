using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Room))]
public class RoomEditor : Editor
{
    public override void OnInspectorGUI() {
        base.OnInspectorGUI();

        Room room = (Room)target;

        if (GUILayout.Button("Set to camera size"))
        {
            room.SetRoomSizeToCamera();
        }
    }
}
