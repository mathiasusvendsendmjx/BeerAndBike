using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;

public class conserversationswitcher : MonoBehaviour
{
    public GameObject objectToDisable;
    public GameObject objectToEnable;
    public GameObject extraObjectToEnable;
    public GameObject[] extraObjectsToEnable;
    public GameObject[] extraObjectsToDisable;
    public UnityEvent OnMouse;
    public bool IsInTransition = false;
    public float fadeDuration = 0.5f;

    private void OnMouseDown()
    {
        Execute();
    }

    public void OnClick()
    {
        Debug.Log("OnClick called");
        StartCoroutine(FadeOutThenSwitch());
    }

    void Execute()
    {
        if (IsInTransition) return;
        Debug.Log("Execute called");
        Debug.Log("objectToDisable: " + objectToDisable);
        Debug.Log("objectToEnable: " + objectToEnable);
        if (objectToDisable != null) objectToDisable.SetActive(false);
        if (objectToEnable != null) objectToEnable.SetActive(true);
        if (extraObjectToEnable != null) extraObjectToEnable.SetActive(true);
        foreach (GameObject g in extraObjectsToEnable)
            if (g != null) g.SetActive(true);
        foreach (GameObject g in extraObjectsToDisable)
            if (g != null) g.SetActive(false);
        OnMouse?.Invoke();
        Debug.Log("Clicked");
    }

    IEnumerator FadeOutThenSwitch()
    {
        if (IsInTransition) yield break;
        IsInTransition = true;

        Debug.Log("Starting fade");

        // Try UI Image first, fall back to 3D Renderer
        Image img = GetComponent<Image>();
        Renderer rend = GetComponent<Renderer>();

        float t = 0;
        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, t / fadeDuration);

            if (img != null)
            {
                Color c = img.color;
                c.a = alpha;
                img.color = c;
            }
            else if (rend != null)
            {
                Color c = rend.material.color;
                c.a = alpha;
                rend.material.color = c;
            }

            yield return null;
        }

        Debug.Log("Fade done, calling Execute");
        IsInTransition = false;
        Execute();
    }
}