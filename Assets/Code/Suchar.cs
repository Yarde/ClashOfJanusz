using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Suchar : MonoBehaviour
{
    // Start is called before the first frame update
    private float _startTime;
    private float _vanishTime = -1;
    public SpriteRenderer avatar;
    public bool toDestroy = false;
    void Start()
    {
        _startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - _startTime > 2 && Math.Abs(avatar.color.a - 1.0) < 0.0001)
        {
            _vanishTime = Time.time + 1;
        }

        if (_vanishTime > 0)
        {
            var color = avatar.color;
            color.a = Mathf.Lerp(1.0f, 0.0f, _vanishTime - Time.time);
            avatar.color = color;
            if (Time.time > _vanishTime)
            {
                toDestroy = true;
            }
        }
    }
}
