using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
using System.Collections;
public class conserversationswitcher : MonoBehaviour
    
   {
    public GameObject objectToDisable;
    public GameObject objectToEnable;

    void Start()
    {
        objectToDisable.SetActive(true);
        objectToEnable.SetActive(false);
        Debug.Log("Start");
    }
     private void OnMouseDown()
    {
        objectToDisable.SetActive(false);
        objectToEnable.SetActive(true);
        Debug.Log("Clicked");
    }
     
}

