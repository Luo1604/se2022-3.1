using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using Siccity.GLTFUtility;

[RequireComponent(typeof(ARRaycastManager))]
[RequireComponent(typeof(ARAnchorManager))]
[RequireComponent(typeof(ARPlaneManager))]
public class PlacementControler : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    private GameObject prefabToPlace;
    
    ARAnchorManager anchorManager;
    ARRaycastManager arRaycastManager;
    private List<ARRaycastHit> hits = new List<ARRaycastHit>();

    public void Awake()
    {
        arRaycastManager = GetComponent<ARRaycastManager>();
        anchorManager = GetComponent<ARAnchorManager>();

        if (PlayerPrefs.GetInt("type") == 1) 
        {
            LoadModel(PlayerPrefs.GetString("path"));
        }
    }

    void LoadModel(string path)
    {
        GameObject model = Importer.LoadFromFile(path);
        model.AddComponent<MeshRenderer>();
        Debug.Log("Model loaded!");

        prefabToPlace = model;

        prefabToPlace.transform.position = new Vector3(1000, 1000, 100);
        prefabToPlace.transform.Rotate(0f, -180f, 0f); 

        CapsuleCollider cp = prefabToPlace.AddComponent<CapsuleCollider>();
        cp.center = new Vector3(0f, 1f, 0f);
        cp.radius = 1f;
        cp.height = 2f;
    }

    private bool TryGetTouchPosition(out Vector2 touchPosition)
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            touchPosition = Input.GetTouch(0).position;
            return true;
        }
        touchPosition = Vector2.zero;
        return false;
    }

    void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
        if (!TryGetTouchPosition(out Vector2 touchPosition))
        {
            return;
        }

        if (arRaycastManager.Raycast(touchPosition, hits, TrackableType.PlaneWithinPolygon))
        {
            
            var hitPose = hits[0].pose;
            CreateAnchor(hits[0]);
           
        } else if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            Destroy(hit.transform.gameObject);
            
        } 
        else 
        {
            SSTools.ShowMessage("Model phải được đặt trên mặt phẳng", SSTools.Position.bottom, SSTools.Time.twoSecond);
        }

        
    }

    private ARAnchor CreateAnchor(in ARRaycastHit hit)
    {
        ARAnchor anchor;

        ARPlane hitPlane = (ARPlane)hit.trackable;

        if (PlayerPrefs.GetInt("type") == 0) 
        {
            Debug.Log("Default.");
            anchorManager.anchorPrefab = prefab;
        }
        else
        {
            Debug.Log("From file.");
            anchorManager.anchorPrefab = prefabToPlace;
        }
        
        Pose pose = hit.pose;
        if (PlayerPrefs.GetInt("type") == 0) 
        {
            var rotationPose = prefab.GetComponent<Transform>().rotation;
            pose.rotation = Quaternion.Euler(rotationPose.x, rotationPose.y, rotationPose.z);
        }
        else
        {
            var rotationPose = prefabToPlace.GetComponent<Transform>().rotation;
            pose.rotation = Quaternion.Euler(rotationPose.x, rotationPose.y, rotationPose.z);
        }
        anchor = anchorManager.AttachAnchor(hitPlane, hit.pose);
        anchorManager.anchorPrefab = null;

        return anchor;
    }

}
