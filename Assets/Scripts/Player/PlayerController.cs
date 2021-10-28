using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : PlayerBehavior
{
    [SerializeField] private KeyCode upButton;
    [SerializeField] private KeyCode downButton;

    // Start is called before the first frame update
    void Start()
    {
        Init(); 
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        if (Input.GetKey(upButton)) Move(1);
        else if (Input.GetKey(downButton)) Move(-1);
        else Move(0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("Ball"))
        {
            lastContactPoint = collision.GetContact(0);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("Ball"))
        {
            trajectoryOrigin = transform.position;
        }
    }
}
