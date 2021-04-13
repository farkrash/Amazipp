using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    [SerializeField] private Transform[] laneTransforms;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private int currentPosOnLaneIndex;
    [SerializeField] private int nextPosOnLaneIndex;
    [SerializeField] private bool moveRight = false;
    [SerializeField] private bool moveLeft = false;
    private bool started = false;
    private bool calculatedPos = true;

    private void Start()
    {
        transform.position = laneTransforms[0].position;
        transform.rotation = laneTransforms[0].rotation;
        nextPosOnLaneIndex = 1;
    }
    private void Update()
    {
        MoveToCurrentIndexPoint();
        DirectionInputs();
    }

    private void MoveToCurrentIndexPoint()
    {
        transform.position = Vector3.MoveTowards(transform.position, laneTransforms[currentPosOnLaneIndex].position, moveSpeed * Time.deltaTime);
        if (transform.position == laneTransforms[currentPosOnLaneIndex].position)
        {
            //transform.rotation = laneTransforms[currentPosOnLaneIndex].rotation;
            LerpRotation();

            if (moveLeft && currentPosOnLaneIndex + 1 <laneTransforms.Length)
            {
                nextPosOnLaneIndex = currentPosOnLaneIndex + 1;
                currentPosOnLaneIndex++;
                moveLeft = false;
            }
            if (moveRight)
            {
                moveRight = false;
                
                if (currentPosOnLaneIndex  > 0)
                {
                    nextPosOnLaneIndex = currentPosOnLaneIndex - 1;
                    currentPosOnLaneIndex--;
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
        }
    }

    private void LerpRotation()
    {
        var currentRotation = transform.eulerAngles;
        var waypointRotation = laneTransforms[nextPosOnLaneIndex].transform.eulerAngles;
        currentRotation.y = Mathf.Lerp(currentRotation.y, waypointRotation.y,
            Time.deltaTime * rotationSpeed);
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, currentRotation.y, transform.eulerAngles.z);

    }
    /*
    private void Awake()
    {
        posOnLaneIndex = -1;
    }
    private void Update()
    {
        /*
        if (started)
        {
            nextPosOnLaneIndex = posOnLaneIndex + 1;
            previousPosOnLaneIndex = posOnLaneIndex - 1;
        }
        
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            calculateDirRight();
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            calculateDirLeft();
        }
        if (moveLeft)
        {
            AdvanceOnLaneHorizontal();
        }
        if (moveRight)
        {
            RetreatOnLaneHorizontal();
        }
    }
    
    private void AdvanceOnLaneHorizontal()
    {
        if (laneTransforms[nextPosOnLaneIndex] != null)
        {
            transform.position = new Vector3(Mathf.Lerp(transform.position.x, laneTransforms[nextPosOnLaneIndex].position.x, Time.deltaTime * speed),
                transform.position.y, Mathf.Lerp(transform.position.z, laneTransforms[nextPosOnLaneIndex].position.z, Time.deltaTime * speed));
        }
    }
    private void RetreatOnLaneHorizontal()
    {
        if (laneTransforms[nextPosOnLaneIndex] != null)
        {
            transform.position = new Vector3(Mathf.Lerp(transform.position.x, laneTransforms[previousPosOnLaneIndex].position.x, Time.deltaTime * speed)
                ,transform.position.y, Mathf.Lerp(transform.position.z, laneTransforms[previousPosOnLaneIndex].position.z, Time.deltaTime * speed));
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("StopPoint"))
        {
            //posOnLaneIndex++;
            moveLeft = false;
            moveRight = false;
            calculatedPos = true;
        }
    }

    private void calculateDirLeft()
    {
        if (calculatedPos)
        {
            nextPosOnLaneIndex = posOnLaneIndex + 1;
            started = true;
            moveLeft = true;
            moveRight = false;
            calculatedPos = false;
        }
    }
    private void calculateDirRight()
    {
        if (calculatedPos)
        {
            previousPosOnLaneIndex = posOnLaneIndex - 1;
            moveRight = true;
            moveLeft = false;
            calculatedPos = false;
        }
    }
    */
}
