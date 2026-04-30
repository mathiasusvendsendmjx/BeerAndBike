using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
using System.Collections;
public class conserversationswitcher : MonoBehaviour
    
   {
    public GameObject objectToDisable;
    public GameObject objectToEnable;

    
     private void OnMouseDown()
    {
        objectToDisable.SetActive(false);
        objectToEnable.SetActive(true);
        Debug.Log("Clicked");
    }
     
}

