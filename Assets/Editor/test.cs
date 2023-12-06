using UnityEditor;
using UnityEngine;

public class test : EditorWindow
{
    // adding variable to store text
    string _myString = "Hello World!"
;
    [MenuItem("Window /Example")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow<test>("Example");
    }
    private void OnGUI()
    {
        //window code
        //label
        GUILayout.Label("This is a label.", EditorStyles.boldLabel);

        //loading variable for text storage and asking for input
        _myString = EditorGUILayout.TextField("Name", _myString);

        //adding a button
        if (GUILayout.Button("Press Me!"))
        {
            Debug.Log("Button was pressed");
        }
    }

}
