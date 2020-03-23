using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityStandardAssets.CrossPlatformInput;


//This script is to control the popcorn machine placement proces
public class ARPlacementAndPlaneDetection : MonoBehaviour
{
    ARPlaneManager m_ARPlaneManager;
    ARPlacementManager m_ARPlacementManager;

    public GameObject placeButton;
    //public GameObject adjustButton;
    public GameObject scaleSlider;
    public GameObject card;
    public GameObject nextButton;


    private void Awake()
    {
        m_ARPlaneManager = GetComponent<ARPlaneManager>();
        m_ARPlacementManager = GetComponent<ARPlacementManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        card = GameObject.FindGameObjectWithTag("card");

        //If the player is not the master client, then this player should wait for master client to place the popcorn machine
            placeButton.SetActive(true);
            scaleSlider.SetActive(true);
          
    }


    // Update is called once per frame
    void Update()
    {

        //Player decide to place the popcorn machine
        if (CrossPlatformInputManager.GetButtonDown("Place"))
        {
            nextButton.SetActive(true);
            Debug.Log("Card Placed!");
            DisableARPlacementAndPlaneDetection();

        }
       
    }

    public void DisableARPlacementAndPlaneDetection()
    {
        m_ARPlaneManager.enabled = false;
        m_ARPlacementManager.enabled = false;

        setAllPlanesActiveOrDeactive(false);
        placeButton.SetActive(false);
        scaleSlider.SetActive(false);
        //adjustButton.SetActive(true);
        
    }

    public void EnableARPlacementAndPlaneDetection()
    {
        m_ARPlaneManager.enabled = true;
        m_ARPlacementManager.enabled = true;
        setAllPlanesActiveOrDeactive(true);
        placeButton.SetActive(true);
        scaleSlider.SetActive(true);
        //adjustButton.SetActive(false);
      
    }

    private void setAllPlanesActiveOrDeactive(bool value)
    {
        foreach (var plane in m_ARPlaneManager.trackables)
        {
            plane.gameObject.SetActive(value);
        }
    }

}
