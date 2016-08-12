using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(Light2D))]
public class Light2DEditor : Editor {

    void OnSceneGUI() {
        Light2D light = (Light2D)target;
        Handles.color = Color.white;
        Handles.DrawWireArc(light.transform.position, Vector3.forward, Vector3.up, 360, light.viewRadius);

        Vector3 viewAngleA = light.DirFromAngle(-light.viewAngle / 2, false);
        Vector3 viewAngleB = light.DirFromAngle(light.viewAngle / 2, false);
        
        Handles.DrawLine(light.transform.position, light.transform.position + viewAngleA * light.viewRadius);
        Handles.DrawLine(light.transform.position, light.transform.position + viewAngleB * light.viewRadius);

        Handles.color = Color.red;
        foreach (Transform visibleTarget in light.visibleTargets) {
            Handles.DrawLine(light.transform.position, visibleTarget.position);
        }
    }

    [MenuItem("GameObject/Light/2D Light")]
    public static void CreateLight() {
        GameObject light = new GameObject();
        light.name = "2D Light";
        light.AddComponent<Light2D>();
        light.AddComponent<MeshFilter>();
        light.AddComponent<MeshRenderer>();
        light.transform.rotation = new Quaternion(0, 180, 0, 0);
    }
}
