using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeDetection : MonoBehaviour
{
    private bool tap, swipeLeft, swipeRight, swipeUp;
    private Vector2 startTouch, swipeDelta;

    private bool isDragin = false;

    public Vector2 SwipeDelta { get { return swipeDelta; }}
    public bool SwipeLeft {  get { return swipeLeft; } }
    public bool SwipeRight {  get { return swipeRight; } }
    public bool SwipeUp { get { return swipeUp; } }
    public bool Tap { get { return tap; } }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        tap = swipeLeft = swipeRight = swipeUp = false;

        // input detection
        #region Standalone Inputs
        if(Input.GetMouseButtonDown(0))
        {
            tap = true;
            isDragin = true;
            startTouch = Input.mousePosition;

        }
        else if (Input.GetMouseButtonUp(0))
        {
            isDragin = false;
            Reset();
        }
        #endregion
        #region Standalone Inputs touch
        if (Input.touches.Length > 0)
        {
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                isDragin = true;
                tap = true;
                startTouch = Input.touches[0].position;
            }else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            {
                isDragin = false;
                Reset();
            }
        }
        #endregion

        // Calculate the distances

        swipeDelta = Vector2.zero;
        if(isDragin)
        {
            if(Input.touches.Length > 0)
            {
                swipeDelta = Input.touches[0].position - startTouch;
            }
            else if ( Input.GetMouseButton(0))
            {
                swipeDelta = (Vector2)Input.mousePosition - startTouch;
            }               
        }

        // Did we cross the deadZone?

        if (swipeDelta.magnitude > 125)
        {
            // which direction?
            float x = swipeDelta.x;
            float y = swipeDelta.y;

            if(Mathf.Abs(x) > Mathf.Abs(y))
            {

                //left o right
                if(x < 0)
                {
                    swipeLeft = true;
                }
                else
                {
                    swipeRight = true;
                }
            }
            else
            {
                // Up or down
                if ( y > 0)
                {
                    swipeUp = true;
                }
            }
            Reset();
        }
    }

   


    private void Reset()
    {
        startTouch = swipeDelta = Vector2.zero;
        isDragin = false;
    }
}