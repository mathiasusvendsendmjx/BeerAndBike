using System.Collections;
using Unity.Mathematics;
using UnityEngine;

public class FadeIn : MonoBehaviour
{
    public float min = 0f;
    public float max = 0.14f;

    void Start()
    {
        transform.localScale =  new Vector3(0, 0, math.lerp(min, max, 0));
    }



}
