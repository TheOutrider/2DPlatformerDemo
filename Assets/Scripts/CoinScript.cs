using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    public float moveSpeed = 0.1f;
    Vector2 targetPosition;
    public float yValue = 0.5f;

    void Start()
    {

        if (gameObject.activeSelf)
        {
            InvokeRepeating("CoinMovement", 0.5f, 1.75f);
        }

    }

    void CoinMovement()
    {
        targetPosition = new Vector2(transform.position.x, transform.position.y + yValue);
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed);
        yValue = yValue * -1;
    }

    // void Update()
    // {
    //     Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //     mousePos.z = 1.0f;
    //     if (Input.GetMouseButtonDown(0))
    //     {
    //         targetPosition = mousePos;
    //         Debug.Log(targetPosition);
    //     }

    //     // transform.position = mousePos;
    // }

    //handle coin movement by o.3 y and keep speed as 0.05 and second as 1

    // private void FixedUpdate() {
    //     ClickToMove();
    // }

    // void ClickToMove()
    // {
    //     transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed);

    // }
}
