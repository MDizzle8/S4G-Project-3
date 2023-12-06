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

    //Create the cloner function
    private void CloneAsset()
    {
        //throw error if trying to clone but field is empty
        if (_assetToClone == null)
        {
            Debug.LogError("Error: Please Assign an Asset to Clone.");
            return;
        }

        //throws error if name field is empty
        if (_assetName == string.Empty)
        {
            Debug.LogError("Error: Please Assign an Asset Name.");
            return;
        }

        //here we set up the random spawns
        Vector2 _spawnZone = Random.insideUnitCircle * _assetSpawnZone; //randomly selects spawn positions within zone
        Vector3 _spawnPos = new Vector3(_spawnZone.x, 0f, _spawnZone.y); //positions asset at those^ coords

        //this bit creates the clone to place at location determined above
        GameObject _clonedAsset = Instantiate(_assetToClone, _spawnPos, Quaternion.identity);
        _clonedAsset.name = _assetName + _assetNum; //renames clone
        _clonedAsset.transform.localScale = Vector3.one * _assetScale; //uses scale slide to determine asset size on spawn

        _assetNum++; //increases assetNum each time button is pressed
    }
}
