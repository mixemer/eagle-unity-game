using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonMovement : MonoBehaviour
{
    public float speed = 1;
    public bool randomSpeed = true;

    const float maxspeed = 2;
    const float minspeed = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        if (randomSpeed)
        {
            RandomSpeed();
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = new Vector3(transform.position.x, transform.position.y + speed * Time.deltaTime, 0);
        transform.position = newPos;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("TopBound") ||
            collision.gameObject.CompareTag("BottomBound") ||
            collision.gameObject.CompareTag("Balloon"))
        {
            speed *= -1;
        }
    }

    void RandomSpeed()
    {
        speed = Random.Range(minspeed, maxspeed);
    }
}
