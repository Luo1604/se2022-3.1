using System;
using System.IO;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using Siccity.GLTFUtility;
using SimpleFileBrowser;

public class ModelLoader : MonoBehaviour
{    
    [SerializeField] private GameObject plane;
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
        model.AddComponent<MeshRenderer>();
        Debug.Log( "Model loaded!");

        // Saved path for AR
        PlayerPrefs.SetString("path", path);
        model.transform.SetParent(wrapper.transform);

        Rotation3D rt = wrapper.AddComponent<Rotation3D>();
        rt.target = wrapper.transform;
        rt.cam = Camera.main;

        // Auto scale(approximately)
        Vector3 xyz = wrapper.GetComponentInChildren<MeshFilter>().mesh.bounds.size;
        Debug.Log("SiZE: " + xyz);
        Debug.Log("cam height: " + getHeight());
        float scale = getHeight() / xyz.y * 0.6f;
        
        wrapper.transform.localScale = new Vector3(scale, scale, scale);
        wrapper.transform.Rotate(0f, -180f, 0f); 
        wrapper.transform.position = new Vector3(0, -1f, 0);

        plane.transform.position = new Vector3(0, -1.3f, 0);
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