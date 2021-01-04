using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SteveMovement : MonoBehaviour
{
    private float movementSpeed = 1f;
    private float accelerationRate = 1.2f;
    private float decelerationRate = 0.8f;
    private float maxMovementSpeed = 5;
    private bool sateenvarjo = false;
    private Rigidbody2D rb;
    Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        KeyInput();

    }
    private void FixedUpdate()
    {
        Movement();
        
    }

    public void KeyInput()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }
    public void Movement()
    {
        

        if(movementSpeed < maxMovementSpeed && (movement.x != 0 || movement.y != 0)){
            movementSpeed = movementSpeed * accelerationRate;
        }
        
        if(movement.x == 0 && movement.y == 0 && movementSpeed > 1)
        {
            movementSpeed = movementSpeed * decelerationRate;
        }

        if (movementSpeed < 1) movementSpeed = 1;

        transform.position = transform.position + new Vector3(movement.x * movementSpeed * Time.deltaTime, movement.y * movementSpeed * Time.deltaTime, 0);
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "TaskTrigger")
        {
            if(sateenvarjo == true)
            {
                //TaskButton.interactable = true;
            }
        }
        if(collision.gameObject.tag == "ItemTrigger")
        {
            sateenvarjo = true;
            Destroy(collision.gameObject);
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "TaskTrigger")
        {
            //TaskButton.interactable = false;
        }
    }

}
