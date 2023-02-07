using System;
using System.IO;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using Siccity.GLTFUtility;

public class ModelLoader : MonoBehaviour
{    

    string FileType;
    
    GameObject wrapper;
    string filePath;

    private void Start()
    {
        FileType = NativeFilePicker.ConvertExtensionToFileType("glb");
        NativeFilePicker.Permission permission = NativeFilePicker.PickFile((path) =>
			{
				if( path == null )
					Debug.Log( "Operation cancelled" );
				else
					Debug.Log( "Picked file: " + path );
                    filePath = path;
			}, new string[] { FileType } );
        wrapper = new GameObject
        {
            name = "Model"
        };
        LoadModel(filePath);
    }

    string GetFilePath(string url)
    {
        string[] pieces = url.Split('/');
        string filename = pieces[pieces.Length - 1];

        return $"{filePath}{filename}";
    }

    void LoadModel(string path)
    {
        ResetWrapper();
        GameObject model = Importer.LoadFromFile(path);
        model.transform.SetParent(wrapper.transform);

        wrapper.AddComponent<Rotation3D>();
        wrapper.transform.position = new Vector3(0, -3, 0);
        wrapper.transform.localScale = new Vector3(4f, 4f, 4f);
        wrapper.transform.Rotate(0f, -180f, 0f); 
    }

    IEnumerator GetFileRequest(string url, Action<UnityWebRequest> callback)
    {
        using(UnityWebRequest req = UnityWebRequest.Get(url))
        {
            req.downloadHandler = new DownloadHandlerFile(GetFilePath(url));
            yield return req.SendWebRequest();
            callback(req);
        }
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