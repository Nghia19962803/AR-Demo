using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class InteractionWithPlane : MonoBehaviour
{
    public ARRaycastManager raycastManager;
    public GameObject prefab;

    public Camera arCam;

    private List<ARRaycastHit> hits = new List<ARRaycastHit>();
    private void Update()
    {
        Touch touch = Input.GetTouch(0);
        Ray ray = arCam.ScreenPointToRay(touch.position);
        if (raycastManager.Raycast(ray, hits, TrackableType.Planes))
        {
            Pose pose = hits[0].pose;
            Instantiate(prefab, pose.position, pose.rotation);
        }
    }
}
