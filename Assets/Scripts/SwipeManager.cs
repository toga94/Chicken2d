using System;
using UnityEngine;
using UnityEngine.Events;

public class SwipeManager : MonoBehaviour
{
    public float swipeThreshold = 50f;
    public float minusswipeThreshold = 50f;
    public float timeThreshold = 0.3f;

    public UnityEvent OnSwipeLeft;
    public UnityEvent OnSwipeUpLeft;
    public UnityEvent OnSwipeDownLeft;
    public UnityEvent OnSwipeRight;
    public UnityEvent OnSwipeUpRight;
    public UnityEvent OnSwipeDownRight;
    public UnityEvent OnSwipeUp;
    public UnityEvent OnSwipeDown;

    private Vector2 fingerDown;
    private DateTime fingerDownTime;
    private Vector2 fingerUp;
    private DateTime fingerUpTime;

    public bool isMobile;

    private void Start()
    {
        isMobile = Application.isMobilePlatform;
    }

    private void Update()
    {
        if (!isMobile)
        {
            if (Input.GetMouseButtonDown(0))
            {
                fingerDown = Input.mousePosition;
                fingerUp = Input.mousePosition;
                fingerDownTime = DateTime.Now;
            }
            if (Input.GetMouseButtonUp(0))
            {
                fingerDown = Input.mousePosition;
                fingerUpTime = DateTime.Now;
                CheckSwipe();
            }
        }
        else {
            foreach (Touch touch in Input.touches)
            {
                if (touch.phase == TouchPhase.Began)
                {
                    fingerDown = touch.position;
                    fingerUp = touch.position;
                    fingerDownTime = DateTime.Now;
                }
                if (touch.phase == TouchPhase.Ended)
                {
                    fingerDown = touch.position;
                    fingerUpTime = DateTime.Now;
                    CheckSwipe();
                }
            }
        }

    }

    private void CheckSwipe()
    {
        float duration = (float)fingerUpTime.Subtract(fingerDownTime).TotalSeconds;
        if (duration > timeThreshold) return;

        float deltaX = fingerDown.x - fingerUp.x;
        float deltaY = fingerDown.y - fingerUp.y;
        Vector2 deltaAbs= new Vector2(Mathf.Abs(deltaX), Mathf.Abs(deltaY));



        if (deltaAbs.x > swipeThreshold)
        {
            if (deltaX > 0)
            {
                OnSwipeRight.Invoke();
                Debug.Log("right");
            }
            else if (deltaX < 0)
            {
                OnSwipeLeft.Invoke();
                Debug.Log("left");
            }
        }
        if (deltaAbs.y > swipeThreshold)
        {
            if (deltaY > 0)
            {
                OnSwipeUp.Invoke();
                Debug.Log("up");
            }
            else if (deltaY < 0)
            {
                OnSwipeDown.Invoke();
                Debug.Log("down");
            }
        }

        fingerUp = fingerDown;
    }
}