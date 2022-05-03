using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed = 1;

    Rigidbody2D rigidbody2D;
    Vector2 input;
    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * speed * Time.deltaTime;

        Vector3 newPos = new Vector3(transform.position.x + input.x, transform.position.y + input.y, 0);
        transform.position = newPos;
    }

    private void FixedUpdate()
    {
        //rigidbody2D.AddForce(input * speed * Time.fixedDeltaTime);
    }
}
