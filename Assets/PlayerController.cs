using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float ballSpeed;
    float x_position;
    public float maxSpeed = 10f; // Set your desired maximum speed here

    public float targetX,newX;



    // Start is called before the first frame update
    void Start()
    {
        x_position = 0;
    }

    // Update is called once per frame

    void Update()
    {
        Vector3 mousePosition = Input.mousePosition;
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hitInfo))
        {
            targetX = hitInfo.point.x;
            float currentX = transform.position.x;

            // Smoothly move towards the target position
            newX = Mathf.MoveTowards(currentX, targetX, ballSpeed * Time.deltaTime);
            transform.position = new Vector3(newX, transform.position.y, transform.position.z);
        }

        // Update the ball speed
        ballSpeed = Mathf.Clamp(ballSpeed, 0f, maxSpeed);

        // Move the ball in the z-axis with the limited speed
        transform.position += new Vector3(0, 0, - ballSpeed * Time.deltaTime);
    }

}
