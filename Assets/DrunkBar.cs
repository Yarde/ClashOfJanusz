using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class DrunkBar : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private SpriteRenderer bar;
    public float level;
    private static float FULL_BAR_SCALE = 0.7f;

    // Update is called once per frame
    void Update()
    {
        if (level < 75)
        {
            bar.color = Color.red;
        }
        else
        {
            bar.color = Color.green;
        }

        var transform = bar.gameObject.transform.localScale;
        bar.gameObject.transform.localScale = new Vector3(level / 100 * FULL_BAR_SCALE, transform.y, transform.z);
    }
}
