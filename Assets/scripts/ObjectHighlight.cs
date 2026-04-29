using UnityEngine;

/// <summary>
/// Attach to any object you want to glow when the player looks at it.
/// 
/// SETUP:
/// 1. Tilføj dette script til dit objekt.
/// 2. Lav et Particle System (højreklik i hierarkiet -> Effects -> Particle System).
/// 3. Drag det Particle System ind i "Glow Particles" feltet i Inspectoren.
/// 4. Drag dit Main Camera ind i "Player Camera".
/// </summary>
[RequireComponent(typeof(Renderer))]
public class InteractGlow : MonoBehaviour
{
    [Header("References")]
    public Camera         playerCamera;
    public ParticleSystem glowParticles; // drag dit particle system hertil

    [Header("Glow")]
    public Color  glowColor     = new Color(0.2f, 0.85f, 1f);
    public float  glowIntensity = 2.5f;
    public float  maxDistance   = 4f;

    [Header("Outline")]
    public float  outlineScale  = 1.06f;

    // ── internals ──────────────────────────────────────────────────────────────
    private Renderer   _renderer;
    private Material[] _mats;
    private Material   _outlineMat;
    private GameObject _outlineGO;
    private float      _intensity;

    void Start()
    {
        if (playerCamera == null)
            playerCamera = Camera.main;

        // Clone all materials
        _renderer = GetComponent<Renderer>();
        _mats = _renderer.materials;
        foreach (var m in _mats)
            m.EnableKeyword("_EMISSION");

        // Outline shell
        _outlineGO = new GameObject("_Outline");
        _outlineGO.transform.SetParent(transform, worldPositionStays: false);
        _outlineGO.transform.localScale = Vector3.one * outlineScale;

        var myMesh = GetComponent<MeshFilter>();
        if (myMesh != null)
            _outlineGO.AddComponent<MeshFilter>().sharedMesh = myMesh.sharedMesh;

        _outlineMat = new Material(Shader.Find("Standard"));
        _outlineMat.SetFloat("_Mode", 3);
        _outlineMat.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
        _outlineMat.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.One);
        _outlineMat.SetInt("_ZWrite", 0);
        _outlineMat.EnableKeyword("_ALPHABLEND_ON");
        _outlineMat.EnableKeyword("_EMISSION");
        _outlineMat.renderQueue = 3000;
        _outlineMat.color = new Color(glowColor.r, glowColor.g, glowColor.b, 0f);

        var outlineRenderer = _outlineGO.AddComponent<MeshRenderer>();
        outlineRenderer.material = _outlineMat;
        outlineRenderer.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
        outlineRenderer.receiveShadows    = false;

        // Stop particles at start
        if (glowParticles != null)
            glowParticles.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
    }

    void Update()
    {
        bool looked = IsLookedAt();

        // Particles
        if (glowParticles != null)
        {
            if (looked  && !glowParticles.isEmitting) glowParticles.Play();
            if (!looked &&  glowParticles.isEmitting) glowParticles.Stop(false, ParticleSystemStopBehavior.StopEmitting);
        }

        // Glow
        float target = looked ? glowIntensity : 0f;
        _intensity = Mathf.Lerp(_intensity, target, Time.deltaTime * 5f);

        foreach (var m in _mats)
            m.SetColor("_EmissionColor", glowColor * _intensity);

        float alpha = Mathf.InverseLerp(0f, glowIntensity, _intensity);
        _outlineMat.color = new Color(glowColor.r, glowColor.g, glowColor.b, alpha * 0.6f);
        _outlineMat.SetColor("_EmissionColor", glowColor * (_intensity * 1.5f));
    }

    bool IsLookedAt()
    {
        if (playerCamera == null) return false;
        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
        return Physics.Raycast(ray, out RaycastHit hit, maxDistance)
               && hit.collider.gameObject == gameObject;
    }

    void OnDestroy()
    {
        if (_mats != null)
            foreach (var m in _mats)
                if (m) Destroy(m);
        if (_outlineMat) Destroy(_outlineMat);
    }
}