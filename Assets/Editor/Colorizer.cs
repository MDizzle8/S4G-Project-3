using UnityEditor;
using UnityEngine;


public class Colorizer : EditorWindow
{
    // adding variable for color
    Color _color;

    [MenuItem("Window /Colorizer")]
    public static void displayWindow()
    {
        EditorWindow.GetWindow<test>("Colorizer");
    }
    void OnGUI()
    {
        //window code
        //label
        GUILayout.Label("Color the selected objects", EditorStyles.boldLabel);

        //loading variable for text storage and asking for input
        _color = EditorGUILayout.TextField("Color", _color);

        //adding a button
        if (GUILayout.Button("COLORIZE!"))
        {
            foreach (GameObject obj in Selection.gameObjects;
            {
                Renderer renderer = obj.GetComponent<Renderer>();
            }
        }
    }

}
S