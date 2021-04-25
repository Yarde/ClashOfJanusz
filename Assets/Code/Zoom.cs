using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoom : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Transform targetTransform;
    [SerializeField] private Camera camera;

    private float _timeStart;
    private float startingCameraZ;

    private float pauseTime = 1;
    private float readyToGoTime = 6;
    void Start()
    {
        _timeStart = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time < _timeStart + pauseTime)
        {
            return;
        }
        if (targetTransform.localScale.x < 1)
        {
            targetTransform.localScale = Vector3.Lerp(targetTransform.localScale, new Vector3(1, 1, 1), (Time.time - _timeStart)/readyToGoTime);
        }

        var newZ = Mathf.Lerp(camera.transform.position.z, -18.7f, (Time.time - _timeStart) / readyToGoTime);
        camera.transform.position = new Vector3(camera.transform.position.x, camera.transform.position.y, newZ);
    }
}
