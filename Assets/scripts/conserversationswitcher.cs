using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
using System.Collections;
using UnityEngine.Events;
public class conserversationswitcher : MonoBehaviour
{
    public GameObject objectToDisable;
    public GameObject objectToEnable;
    public GameObject extraObjectToEnable;
    public GameObject [] extraObjectsToEnable;
    public GameObject[] extraObjectsToDisable;
    public UnityEvent OnMouse;
    public bool IsInTransition = false;
    
    private void OnMouseDown()
    {
        if (IsInTransition) return;

        if (objectToDisable != null)
            objectToDisable.SetActive(false);

        if (objectToEnable != null)
            objectToEnable.SetActive(true);

        if (extraObjectToEnable != null)
            extraObjectToEnable.SetActive(true);

        foreach (GameObject g in extraObjectsToEnable)
        {
            if (g != null) g.SetActive(true);
        }

        foreach (GameObject g in extraObjectsToDisable)
        {
            if (g != null) g.SetActive(false);
        }

        OnMouse?.Invoke();

        Debug.Log("Clicked");
    }
}

