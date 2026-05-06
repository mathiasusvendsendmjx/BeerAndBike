using UnityEngine;

public class ShakeAnimation : MonoBehaviour
{
    private bool _isShaking = false;

    public Vector2 ShakeIntensity = new Vector3(.05f, .1f);

    private Vector3 _initialScale;

    public void StartShaking()
    {
        _initialScale = transform.localScale;
        _isShaking = true;
    }

    void Update()
    {
        if (_isShaking )
        {
            transform.localScale = _initialScale + new Vector3(Random.Range(-1f, 1f) * ShakeIntensity.x, Random.Range(-1f, 1f) * ShakeIntensity.y);
        }
    }
}