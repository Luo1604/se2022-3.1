using System;
using System.IO;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using Siccity.GLTFUtility;
using SimpleFileBrowser;

public class ModelLoader : MonoBehaviour
{    
    GameObject wrapper;
    string destinationPath;

    private void Start()
    {
        FileBrowser.SetFilters( true, new FileBrowser.Filter( "Models", ".glb", ".gltf" ));
        StartCoroutine( ShowLoadDialogCoroutine() );

        wrapper = new GameObject
        {
            name = "Model"
        };
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

    void LoadModel(string path)
    {
        ResetWrapper();
        GameObject model = Importer.LoadFromFile(path);
        Debug.Log( "Model loaded!");
        model.transform.SetParent(wrapper.transform);

        wrapper.AddComponent<Rotation3D>();
        wrapper.transform.position = new Vector3(0, -3, 0);
        wrapper.transform.localScale = new Vector3(4f, 4f, 4f);
        wrapper.transform.Rotate(0f, -180f, 0f); 
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