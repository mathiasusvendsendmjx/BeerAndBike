using System.Collections;
using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
  [SerializeField] private CanvasGroup canvasGroup;

  [SerializeField] private float fadeDuration = 5f;

  private bool fadeIn= false;

  private void Start()
  {
    if (fadeIn)
    {
      FadeIn();
    }
    else
    {
      FadeOut();
    }
  }
  public void FadeIn()
  {
    StartCoroutine(FadecanvasGroup(canvasGroup, 0f, 1f, fadeDuration));
  }
public void FadeOut()
    {
        StartCoroutine(FadecanvasGroup(canvasGroup, 1f, 0f, fadeDuration));
    }

  private IEnumerator FadecanvasGroup(CanvasGroup cg, float start, float end, float duration)
  {
    float elapsedTime = 0f;
    while (elapsedTime < duration)
    {
      elapsedTime += Time.deltaTime;
      cg.alpha = Mathf.Lerp(start, end, elapsedTime / duration); 
      yield return null;
    }
    cg.alpha = end;
  }
  
  }

