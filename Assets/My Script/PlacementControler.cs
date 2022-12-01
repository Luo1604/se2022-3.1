using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))]
[RequireComponent(typeof(ARAnchorManager))]
[RequireComponent(typeof(ARPlaneManager))]
public class PlacementControler : MonoBehaviour

{
    // comment
    [SerializeField]
    private GameObject prefabToPlace;
    
    ARAnchorManager anchorManager;
    ARRaycastManager arRaycastManager;
    private List<ARRaycastHit> hits = new List<ARRaycastHit>();

    public void Awake()
    {
        arRaycastManager = GetComponent<ARRaycastManager>();
        anchorManager = GetComponent<ARAnchorManager>();

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
        if (!TryGetTouchPosition(out Vector2 touchPosition))
        {
            return;
        }

        if (arRaycastManager.Raycast(touchPosition, hits, TrackableType.PlaneWithinPolygon))
        {
            var hitPose = hits[0].pose;
            CreateAnchor(hits[0]);
        } else
        {
            SSTools.ShowMessage("Model phải được đặt trên mặt phẳng", SSTools.Position.bottom, SSTools.Time.twoSecond);
        }
    }

    private ARAnchor CreateAnchor(in ARRaycastHit hit)
    {
        ARAnchor anchor;
        ARPlane hitPlane = (ARPlane)hit.trackable;

        anchorManager.anchorPrefab = prefabToPlace;
        anchor = anchorManager.AttachAnchor(hitPlane, hit.pose);
        anchorManager.anchorPrefab = null;
        return anchor;
    }
}
