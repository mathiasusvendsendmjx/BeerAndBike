using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
using System.Collections;
public class conserversationswitcher : MonoBehaviour
{
    public GameObject objectToDisable;
    public GameObject objectToEnable;
    public GameObject extraObjectToEnable;

    public bool IsInTransition = false;
    
    private void OnMouseDown()
    {
        if (IsInTransition) return;

        objectToDisable.SetActive(false);
        objectToEnable.SetActive(true);

        if (extraObjectToEnable != null)
            extraObjectToEnable.SetActive(true);

        Debug.Log("Clicked");
    }
}

