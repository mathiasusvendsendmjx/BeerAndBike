using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
using System.Collections;

public class SceneSwitchonclick : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public AudioSource audioSource;
    public string sceneName = "RebeccaHavet";

    private void OnMouseDown()
    {
        videoPlayer.Play();
        audioSource.Play();
        StartCoroutine(SceneSwitch());
    }
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private IEnumerator SceneSwitch()
    {
        yield return new WaitForSeconds((float)videoPlayer.clip.length - 1.6f);
        videoPlayer.Pause();
        SceneManager.LoadScene(sceneName);
    }
}