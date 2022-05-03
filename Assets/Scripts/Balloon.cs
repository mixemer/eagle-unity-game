using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour
{
    public int scorePoint = 1;

    float scaleIncreaseRate = 0.00005f;
    public float maxSize = 0.25f;
    float minSize = 0.1f;

    bool isDestroying = false;
    float destroyWaitTime = 3f;
    // Update is called once per frame
    void Update()
    {
        if (transform.localScale.x < maxSize)
        {
            transform.localScale = new Vector3(transform.localScale.x + scaleIncreaseRate, transform.localScale.y + scaleIncreaseRate, 1);
        }else
        {
            if (isDestroying) return;
            isDestroying = true;
            Invoke("DestroyThis", destroyWaitTime);
        }
    }

    void DestroyThis()
    {
        FindObjectOfType<SpawnManager>().currentCount -= 1;
        Globals.instance.SubScore();
        Destroy(gameObject);
    }
}
