using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    //config params
    [SerializeField] Paddle paddle1;
    [SerializeField] float xPushMin;
    [SerializeField] float xPushMax;
    [SerializeField] float yPushMin;
    [SerializeField] float yPushMax;

    // state
    Vector2 ballToPaddleVector;
    private bool hasLaunched = false;
    private float xPush;
    private float yPush;


    // Start is called before the first frame update
    void Start()
    {
        ballToPaddleVector = transform.position - paddle1.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasLaunched)
        {
            LockBallToPaddle();
            LaunchOnMouseClick();
        }

  
    }

    private void LaunchOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            xPush = Random.Range(xPushMin, xPushMax);
            yPush = Random.Range(yPushMin, yPushMax);
            Debug.Log(xPush + " " + yPush);
            GetComponent<Rigidbody2D>().velocity = new Vector2(xPush, yPush);
            hasLaunched = true;
        }
    }

    private void LockBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePos + ballToPaddleVector;
    }
}
