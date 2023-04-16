using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector2 move = new Vector2(Input.GetAxisRaw("Vertical"), -Input.GetAxisRaw("Horizontal"));
        var velocity = ((transform.up * move.y) + (transform.right * move.x)).normalized * 500 *Time.deltaTime;
        rb.velocity = (velocity);
        //rb.MovePosition(rb.position + move * .1f);
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, Input.mousePosition.x * -.19f));
        //rb.MoveRotation(Quaternion.Euler(new Vector3(0, 0, Input.mousePosition.x * -.19f)));
    }
}
