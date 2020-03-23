using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;

public class Launcher : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (CrossPlatformInputManager.GetButtonDown("ViewAll"))
        {
            SceneManager.LoadScene("MainScene");
        }
    }
}
