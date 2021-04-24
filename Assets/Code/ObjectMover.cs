using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMover : MonoBehaviour
{
    // Start is called before the first frame update
    public SpriteRenderer spriteRenderer;
    public Vector2 destination;
    public float speed = 1;

    // Update is called once per frame
    void Update()
    {
        var position = transform.position;
        var translatedDestination = new Vector3((destination.x + destination.y) * -0.5f, (destination.y + destination.x) * -0.25f, 0);
        spriteRenderer.flipX = translatedDestination.x > position.x;
        var direction = translatedDestination - position;
        if (direction.magnitude > 0.001)
        {
            transform.localPosition = transform.localPosition + direction.normalized * (speed * Time.deltaTime);
        }
    }
}
