using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Waypoint))]
public class WaypointEditor : Editor
{
    Waypoint WaypointTarget => target as Waypoint;

    private void OnSceneGUI()
    {
        Handles.color = Color.red;
        if (WaypointTarget.Points == null)
        {
            return;
        }

        for (int i=0; i< WaypointTarget.Points.Length; i++)
        {
            EditorGUI.BeginChangeCheck();
            //Crear Handle
            Vector2 actualPoint = WaypointTarget.ActualPosition + WaypointTarget.Points[i];
            Vector2 newPoint = Handles.FreeMoveHandle(actualPoint, Quaternion.identity, 7f,
                new Vector2(3f, 3f), Handles.SphereHandleCap);

            //crear texto
            GUIStyle text = new GUIStyle();
            text.fontStyle = FontStyle.Bold;
            text.fontSize = 16;
            text.normal.textColor = Color.black;
            Vector2 alineamiento = Vector2.down * 3f + Vector2.right * 3f;
            Handles.Label(WaypointTarget.ActualPosition + WaypointTarget.Points[i] + alineamiento, $"{i+1}",text);

            if(EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(target, "Free Move Handle");
                WaypointTarget.Points[i] = newPoint - WaypointTarget.ActualPosition;
            }
        }
    }
}
