using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

//This script allows the popcorn machine move to the position where the player points to in their camera
public class ARPlacementManager : MonoBehaviour
{
    ARRaycastManager m_ARRaycastManager;
    static List<ARRaycastHit> raycast_Hits = new List<ARRaycastHit>();
    public Camera aRCamera;
    public GameObject card;

    private void Awake()
    {
        m_ARRaycastManager = GetComponent<ARRaycastManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        card = GameObject.FindGameObjectWithTag("card");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 centreOfScreen = new Vector3(Screen.width / 2, Screen.height / 2);
        Ray ray = aRCamera.ScreenPointToRay(centreOfScreen);
        if (m_ARRaycastManager.Raycast(ray, raycast_Hits, TrackableType.PlaneWithinPolygon))
        {
            Pose hitPose = raycast_Hits[0].pose;
            Vector3 positionToBePlaced = hitPose.position;
            card.transform.position = positionToBePlaced;
        }
    }
}
