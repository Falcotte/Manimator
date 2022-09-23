using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Background))]
public class BackgroundEditor : Editor
{
    public override void OnInspectorGUI()
    {
        Background background = (Background)target;

        DrawDefaultInspector();

        if(GUILayout.Button("Place Background"))
        {
            background.PlaceBackgroundObjects();
        }
    }
}
