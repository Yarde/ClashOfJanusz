using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;
using UnityEngine;

public class JellyAnimation : MonoBehaviour
{

    public float min = 0.8f;
    public float max = 1.2f;
    public Vector2 jellyTimeRange;

    public float _jellyTime;
    
    private Vector3 _desiredScale;
    private float _swapTime;
    
    // Start is called before the first frame update
    void Start()
    {
        _desiredScale = new Vector3(min, max, 1.0f);
        _swapTime = Time.time;
        _jellyTime = Random.Range(jellyTimeRange.x, jellyTimeRange.y);
    }

    private void FlipScale()
    {
        var flippedX = _desiredScale.y;
        var flippedY = _desiredScale.x;
        _desiredScale = new Vector3(flippedX, flippedY, 1.0f);
        _swapTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - _swapTime > _jellyTime)
        {
            FlipScale();
        }
        else
        {
            transform.localScale = Vector3.Lerp(transform.localScale, _desiredScale, (Time.time - _swapTime)/_jellyTime);
        }
    }
}
