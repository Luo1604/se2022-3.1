using System;
using System.IO;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using Siccity.GLTFUtility;
using SimpleFileBrowser;

public class ModelLoader : MonoBehaviour
{    
    [SerializeField] private GameObject defaultModel;
    GameObject wrapper;
    string destinationPath;

    private void Start()
    {
        if (PlayerPrefs.GetInt("type") == 0) 
        {
            defaultModel.SetActive(true);
        }
        else
        {
            FileBrowser.SetFilters( true, new FileBrowser.Filter( "Models", ".glb", ".gltf" ));
            StartCoroutine( ShowLoadDialogCoroutine() );

            wrapper = new GameObject
            {
                name = "Model"
            };
        }
    }

    IEnumerator ShowLoadDialogCoroutine()
	{
		yield return FileBrowser.WaitForLoadDialog( FileBrowser.PickMode.FilesAndFolders, true, null, null, "Load Files and Folders", "Load" );

		Debug.Log( FileBrowser.Success );

		if( FileBrowser.Success )
		{
            Debug.Log("SAF:" + FileBrowser.Result[0]);
            destinationPath = Path.Combine(Application.persistentDataPath, FileBrowserHelpers.GetFilename(FileBrowser.Result[0]));
            FileBrowserHelpers.CopyFile(FileBrowser.Result[0], destinationPath);
            Debug.Log("Copied and loaded from new path:" + destinationPath);
		}
        
        Debug.Log( "Object created! Begin loading model!");
        LoadModel(destinationPath);
	}

    float getHeight() 
    {
        return Camera.main.orthographicSize *2f;
    }

    void LoadModel(string path)
    {
        ResetWrapper();
        GameObject model = Importer.LoadFromFile(path);
        Debug.Log( "Model loaded!");

        // Saved path for AR
        PlayerPrefs.SetString("path", path);
        model.transform.SetParent(wrapper.transform);

        wrapper.AddComponent<Rotation3D>();

        // Auto scale(approximately)
        Vector3 xyz = wrapper.GetComponentInChildren<MeshFilter>().mesh.bounds.size;
        Debug.Log("SiZE: " + xyz);
        float scale = getHeight() / xyz.x * 0.6f;
        
        wrapper.transform.localScale = new Vector3(scale, scale, scale);
        wrapper.transform.Rotate(0f, -180f, 0f); 
        wrapper.transform.position = new Vector3(0, -2f, 0);
    }

    void ResetWrapper()
    {
        if (wrapper != null)
        {
            foreach(Transform trans in wrapper.transform)
            {
                Destroy(trans.gameObject);
            }
        }
    }
}