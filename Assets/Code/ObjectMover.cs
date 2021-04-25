using System;
using System.Collections;
using System.Collections.Generic;
using Code.Entities;
using UnityEngine;
using Random = System.Random;

public class ObjectMover : MonoBehaviour
{
    // Start is called before the first frame update
    public SpriteRenderer spriteRenderer;
    public Vector3 destination;
    public float speed = 1;

    public float lastMoveTime;
    public float restTime = 0;
    private void Start()
    {
        lastMoveTime = 0;
        destination = GameObject.FindWithTag("GameObjectManager").GetComponent<GameObjectManager>().RandomJanuszWanderPoint();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<Janusz>().sucharTime > -1)
        {
            return;
        }
        var position = transform.position;
        var direction = destination - position;
        var currentTime = Time.time;
        if (direction.magnitude > 0.001)
        {
            spriteRenderer.flipX = destination.x > position.x;
            transform.localPosition = transform.localPosition + direction.normalized * (speed * Time.deltaTime);
            lastMoveTime = currentTime;
            if ((destination - transform.localPosition).magnitude < 0.001)
            {
                restTime = UnityEngine.Random.Range(1f, 3f);
                transform.position = destination;
            }
        }
        else
        {
            if (lastMoveTime + restTime < Time.time)
            {
                destination = GameObject.FindWithTag("GameObjectManager").GetComponent<GameObjectManager>().RandomJanuszWanderPoint();
            }
        }
    }
}
