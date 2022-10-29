using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(DialogueObject))]
public class DialogueEditor : Editor
{
    
    public override void OnInspectorGUI() {
        base.OnInspectorGUI();

        EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);
    }

}
