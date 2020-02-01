using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeController : MonoBehaviour
{
    public SwipeDetection swipeControls;
    private CharacterController controller;
    private const float LANE_DISTANCE = 3.0f;

    public double topLeft = -4.5;
    public double topRight = 4.5;

    public float position = 0f;
    public float speed = 7f;
    public float gravity = 12.0f;
    public float verticalVelocity;

    private int desiredLane = 1; // 0 left , 1 center, 2 right

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (swipeControls.SwipeLeft)
        {
            MoveLane(true);


        }
        else if (swipeControls.SwipeRight)
        {
            
            MoveLane(false);
        }
        else if (swipeControls.SwipeUp)
        {
            
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
        moveVector.y = -0.1f;
        moveVector.z = -1 * speed;

        //move character
        controller.Move(moveVector * Time.deltaTime);
         
    }

    private void MoveLane(bool goingRight)
    {
        desiredLane += (goingRight) ? 1 : -1;
        desiredLane = Mathf.Clamp(desiredLane, 0, 2);
    }
}
