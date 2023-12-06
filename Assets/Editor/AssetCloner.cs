using UnityEditor;
using UnityEngine;

public class AssetCloner : EditorWindow
{

    //variables for things to edit
    string _assetName = "";
    int _assetNum = 1;
    GameObject _assetToClone;
    float _assetScale;
    float _assetSpawnZone = 5f;

    //adds window to menu
    [MenuItem("Tools/Asset Cloner")]


    // funtion that displays the window
    public static void showWindow()
    {
        GetWindow(typeof(AssetCloner)); //this is a method inherited from the editor window class we put up top
    }

    //labels and buttons code
    private void OnGUI()
    {
        //overall label
        GUILayout.Label("Clone Asset", EditorStyles.boldLabel);

        //variables to load for inputs
        _assetName = EditorGUILayout.TextField("Asset Name", _assetName);
        _assetNum = EditorGUILayout.IntField("Asset Num", _assetNum);
        _assetToClone = EditorGUILayout.ObjectField("Asset to Clone", _assetToClone,
            typeof(GameObject), false) as GameObject;
        _assetScale = EditorGUILayout.Slider("Asset Scale", _assetScale, 0.5f, 3f);
        _assetSpawnZone = EditorGUILayout.FloatField("Asset Spawn Zone", _assetSpawnZone);

        //add button to activate clone
        if (GUILayout.Button("Clone"))
        {
            CloneAsset();
        }
    }
}
