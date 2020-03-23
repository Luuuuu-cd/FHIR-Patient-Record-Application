using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.UI;

//This script allows user to use a slider to control the scale of the popcorn
public class ScaleController : MonoBehaviour
{
    ARSessionOrigin m_ARSessionOrigin;
    public GameObject card;
    public Slider scaleSlider;

    private void Awake()
    {
        m_ARSessionOrigin = GetComponent<ARSessionOrigin>();
    }
    // Start is called before the first frame update
    void Start()
    {
        card = GameObject.FindGameObjectWithTag("card");
        scaleSlider.onValueChanged.AddListener(OnSliderValueChanged);
    }

    public void OnSliderValueChanged(float value)
    {
        if (scaleSlider != null)
        {
            m_ARSessionOrigin.transform.localScale = Vector3.one / value;
        }
    }
}
