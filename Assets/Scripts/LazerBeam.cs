using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerBeam : MonoBehaviour
{
    public float speed = 1;
    public AudioSource BobSound;

    private void Start()
    {
        Destroy(gameObject, 5);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Balloon"))
        {
            FindObjectOfType<SpawnManager>().currentCount -= 1;
            Destroy(collision.gameObject);
            if (BobSound) BobSound.Play();
            Globals.instance.AddScore();
        }
    }
}
