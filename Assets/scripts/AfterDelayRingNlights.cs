using UnityEngine;

public class AfterDelayRingNlights : MonoBehaviour
{
    public AudioSource ringSound;
    
    public float delay = 6f;

    void Start()
    {
        Invoke("ActivateRingAndLights", delay);
    }

    private void ActivateRingAndLights()
    {
        ringSound.Play();
        
    }
}
