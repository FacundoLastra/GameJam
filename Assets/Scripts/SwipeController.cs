using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeController : MonoBehaviour
{
    public SwipeDetection swipeControls;
    private CharacterController controller;
    public float LANE_DISTANCE = 3.0f;
    public float TURN_SPEED = 0.05f;

    public float jumpForce = 1.0f;

    public double topLeft = -4.5;
    public double topRight = 4.5;

    public float position = 0f;
    public float speed = 7f;
    public float gravity = 12.0f;
    public float verticalVelocity;

    private int desiredLane = 1; // 0 left , 1 center, 2 right

    // ANIMATIONS

    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (swipeControls.SwipeLeft)
        {

            MoveLane(false);

        }
        else if (swipeControls.SwipeRight)
        {
            MoveLane(true);
            
        }
    
        // calculate where we should be in the future

        Vector3 targetPosition = transform.position.z * Vector3.forward;

        if( desiredLane == 0)
        {
            targetPosition += Vector3.left * LANE_DISTANCE;
        } else if (desiredLane == 2)
        {
            targetPosition += Vector3.right * LANE_DISTANCE;
        }


        // calculate our move delta

        Vector3 moveVector = Vector3.zero;
        moveVector.x = (targetPosition - transform.position).normalized.x * speed;

        bool isGrounder = isGrounded();

        anim.SetBool("Grounded", isGrounder);
        // calculate Y
        if (isGrounder)
        {
            verticalVelocity = -0.1f;
            if (swipeControls.SwipeUp)
            {
                // jump mecanic
                anim.SetTrigger("Jump");
                verticalVelocity = jumpForce;
            }

        }
        moveVector.y = verticalVelocity;
        moveVector.z = speed;

        //move character
        controller.Move(moveVector * Time.deltaTime);

        // rotate character to he is going
        Vector3 dir = controller.velocity;
        if (dir != Vector3.zero)
        {
            dir.y = 0;
            transform.forward = Vector3.Lerp(transform.forward, dir, TURN_SPEED);
        }

       
        
         
    }

    private void MoveLane(bool goingRight)
    {
        desiredLane += (goingRight) ? 1 : -1;
        desiredLane = Mathf.Clamp(desiredLane, 0, 2);
    }

    private bool isGrounded()
    {
        Ray groundRay = new Ray(
            new Vector3(
                controller.bounds.center.x,
                (controller.bounds.center.y - controller.bounds.extents.y) + 0.2f,
                controller.bounds.center.z),
            Vector3.down);

        return Physics.Raycast(groundRay, 0.2f + 0.1f);
            

    }
}
