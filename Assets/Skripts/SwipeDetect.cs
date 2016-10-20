using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

class SwipeDetect
{
    private float fingerStartTime = 0.0f;
    private Vector2 fingerStartPos = Vector2.zero;

    private bool isSwipe = false;
    private float minSwipeDist = 50.0f;
    private float maxSwipeTime = 0.5f;
    private static bool[] swipeDirect = { false, false, false, false };
    public static bool[] SwipeDirect
    {
        get
            { return swipeDirect; }
        private set { }
    }


    public void SwipeDet()
    {

        if (Input.touchCount > 0)
        {

            foreach (Touch touch in Input.touches)
            {
                switch (touch.phase)
                {
                    case TouchPhase.Began:
                        // this is a new touch 
                        isSwipe = true;
                        fingerStartTime = Time.time;
                        fingerStartPos = touch.position;
                        break;

                    case TouchPhase.Canceled:
                        // The touch is being canceled 
                        isSwipe = false;
                        break;

                    case TouchPhase.Ended:

                        float gestureTime = Time.time - fingerStartTime;
                        float gestureDist = (touch.position - fingerStartPos).magnitude;

                        if (isSwipe && gestureTime < maxSwipeTime && gestureDist > minSwipeDist)
                        {
                            Vector2 direction = touch.position - fingerStartPos;
                            Vector2 swipeType = Vector2.zero;

                            if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
                            {
                                // the swipe is horizontal:
                                swipeType = Vector2.right * Mathf.Sign(direction.x);
                            }
                            else
                            {
                                // the swipe is vertical:
                                swipeType = Vector2.up * Mathf.Sign(direction.y);
                            }

                            if (swipeType.x != 0.0f)
                            {
                                if (swipeType.x > 0.0f)
                                {
                                    swipeDirect[2] = true;
                                    swipeDirect[1] = false;
                                    swipeDirect[0] = false;
                                    swipeDirect[3] = false;
                                }
                                else
                                {
                                    swipeDirect[3] = true;
                                    swipeDirect[0] = false;
                                    swipeDirect[2] = false;
                                    swipeDirect[1] = false;
                                }
                            }

                            if (swipeType.y != 0.0f)
                            {
                                if (swipeType.y > 0.0f)
                                {
                                    swipeDirect[0] = true;
                                    swipeDirect[1] = false;
                                    swipeDirect[2] = false;
                                    swipeDirect[3] = false;
                                }
                                else
                                {
                                    swipeDirect[1] = true;
                                    swipeDirect[3] = false;
                                    swipeDirect[2] = false;
                                    swipeDirect[0] = false;
                                }
                            }

                        }

                        break;
                }
            }
        }

    }

}
