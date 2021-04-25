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
    void Start()
    {
        _timeStart = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (targetTransform.localScale.x < 1)
        {
            targetTransform.localScale = Vector3.Lerp(targetTransform.localScale, new Vector3(1, 1, 1), (Time.time - _timeStart)/5);
        }

        var newZ = Mathf.Lerp(camera.transform.position.z, -18.7f, (Time.time - _timeStart) / 5);
        camera.transform.position = new Vector3(camera.transform.position.x, camera.transform.position.y, newZ);
    }
}
