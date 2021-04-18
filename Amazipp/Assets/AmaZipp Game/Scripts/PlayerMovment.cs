using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    [Header("Movement Config")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotationSpeed;
    
    [Header("Waypoints")]
    [SerializeField] private Transform[] waypoints;
    [SerializeField] private int currentWaypointIndex;

    private bool backToHighestIndex;
    private bool moveRight = false;
    private bool moveLeft = false;
    

    private void Start()
    {
        transform.position = waypoints[0].position;
        transform.rotation = waypoints[0].rotation;
    }
    private void Update()
    {
        MoveToCurrentIndexPoint();
        DirectionInputs();
        LerpRotation();
    }

    private void MoveToCurrentIndexPoint()
    {
        transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypointIndex].position, moveSpeed * Time.deltaTime);
        if (transform.position == waypoints[currentWaypointIndex].position)
        {
            if (moveLeft)
            {
                if (currentWaypointIndex + 1 < waypoints.Length)
                {
                    currentWaypointIndex++;
                    moveLeft = false;
                }
                else
                {
                    currentWaypointIndex = 0;
                    moveLeft = false;
                }
            }

            
            if (moveRight)
            {
                moveRight = false;
                
                if (currentWaypointIndex > 0 )
                {
                    currentWaypointIndex--;
                }
                
                if (currentWaypointIndex == 0 && backToHighestIndex)
                {
                    currentWaypointIndex = waypoints.Length - 1;
                }
            }
        }
    }

    private void DirectionInputs()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            
            moveLeft = true;
        }
        
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            moveRight = true;
            
            if (currentWaypointIndex == 0)
            {
                backToHighestIndex = true;
            }
            else
            {
                backToHighestIndex = false;
            }
        }
    }

    private void LerpRotation()
    {
        var currentRotation = transform.eulerAngles;
        var waypointRotation = waypoints[currentWaypointIndex].transform.eulerAngles;
        currentRotation.y = Mathf.Lerp(currentRotation.y, waypointRotation.y,
            Time.deltaTime * rotationSpeed);
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, currentRotation.y, transform.eulerAngles.z);
    }
    
}
