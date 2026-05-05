using System.Collections;
using Unity.Mathematics;
using UnityEngine;

public class FadeIn : MonoBehaviour
{
    private MeshRenderer Material;
    public AnimationCurve AnimationCurve = new AnimationCurve(
        new Keyframe(0f, 0f),
        new Keyframe(1f, 1f)
    );

    private conserversationswitcher ConversationSwitcher = null;
    private InteractGlow InteractGlow = null;

    private Color _startColor;
    private Color _endColor;

    public float WaitTimeBefore = 1f;
    public float FadeInTime = .3f;
    public float WaitTimeAFter = .1f;

    private float _timer = 0f;

    IEnumerator Start()
    {
        Material = GetComponent<MeshRenderer>();
        ConversationSwitcher = GetComponent<conserversationswitcher>();
        InteractGlow = GetComponent<InteractGlow>();

         _startColor = Material.material.color;
        _endColor = Material.material.color;

        _startColor.a = 0f;

        Material.material.color = _startColor;

        yield return new WaitForSeconds(WaitTimeBefore);

        _timer = 0f;

        while (_timer <= FadeInTime)
        {
            _timer += Time.deltaTime;

            float delta = _timer / FadeInTime;

            delta = AnimationCurve.Evaluate(delta);

            Material.material.color = Color.Lerp(_startColor, _endColor, delta);

            yield return new WaitForEndOfFrame();
        }

        Material.material.color = _endColor;

        yield return new WaitForSeconds(WaitTimeAFter);
        
        if (ConversationSwitcher != null)
            ConversationSwitcher.IsInTransition = false;
        if (InteractGlow != null)
            InteractGlow.IsInTransition = false;
    }
}
