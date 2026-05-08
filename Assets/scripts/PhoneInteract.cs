using UnityEngine;

public class PhoneInteract : MonoBehaviour
{
    [Header("Blinking")]
    public float blinkSpeed = 1f;
    public Color blinkColor = Color.white;

    [Header("References")]
    public GameObject conversationCanvas;
    public IntroManager introManager;

    private Material[] _mats;
    private bool _clicked = false;

    void Start()
    {
        _mats = GetComponent<Renderer>().materials;
        foreach (var m in _mats)
            m.EnableKeyword("_EMISSION");
    }

    void Update()
    {
        if (_clicked) return;
        float t = Mathf.PingPong(Time.time * blinkSpeed, 1f);
        foreach (var m in _mats)
            m.SetColor("_EmissionColor", blinkColor * t * 2f);
    }

    private void OnMouseDown()
    {
        if (_clicked) return;
        _clicked = true;

        // Stop blinking
        foreach (var m in _mats)
            m.SetColor("_EmissionColor", Color.black);

        if (conversationCanvas != null)
            conversationCanvas.SetActive(true);

        if (introManager != null)
            introManager.StartIntro();
    }
}