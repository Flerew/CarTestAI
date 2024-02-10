using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.AI;

public class CarAI : MonoBehaviour
{
    public float stopDistanceAgainstCar = 10f;
    public GameObject drivePoint;
    public bool canChangeDrivePoint = true;
    public bool driveOnRightWay;
    public GameObject frontCar;

    private NavMeshAgent agent;
    private Rigidbody rb;
    private float defaultAgentSpeed;
    private float defaultAgentAngularSpeed;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
        defaultAgentSpeed = agent.speed;
        defaultAgentAngularSpeed = agent.angularSpeed;
    }

    private void FixedUpdate()
    {
        rb.velocity = Vector3.zero;
    }

    public void SetNextDrivePoint(GameObject nextDrivePoint, bool isRightDrivePoint)
    {
        SetAgentPoint(nextDrivePoint);
        driveOnRightWay = isRightDrivePoint;
    }

    public void CheckNextDrivePoint(GameObject nextDrivePoint)
    {
        if (nextDrivePoint.TryGetComponent(out DrivePointController nextDrivePointController))
        {
            if (nextDrivePointController.nextDrivePoints.Count == 0)
            {
                canChangeDrivePoint = true;
            }
            else
            {
                canChangeDrivePoint = false;
            }
            driveOnRightWay = nextDrivePointController.isRightDrivePoint;
        }
    }

    public void SetDrivePoint(GameObject point)
    {
        if (point.TryGetComponent(out DrivePointController drivePointController))
        {
            if (drivePointController.nextDrivePoints.Count > 0)
            {
                canChangeDrivePoint = false;

                SetAgentPoint(point);
            }

            if (canChangeDrivePoint)
            {
                SetAgentPoint(point);
            }
        }
    }

    public void CheckAnotherCarDistance(Collider other)
    {
        if (other == null)
        {
            SetAgentSpeeds(defaultAgentSpeed, defaultAgentAngularSpeed);
        }

        else
        {
            GameObject car = other.gameObject;

            if (car.tag == "Car" || car.tag == "Player" && car == frontCar)
            {

                float distance = Vector3.Distance(transform.position, car.transform.position);
                if (distance > stopDistanceAgainstCar)
                {
                    SetAgentSpeeds(defaultAgentSpeed, defaultAgentAngularSpeed);
                }
                else if (distance <= stopDistanceAgainstCar)
                {
                    SetAgentSpeeds(0, 0);
                }

            }
        }
    }

    private void SetAgentSpeeds(float agentSpeed, float agentAngularSpeed)
    {
        agent.speed = agentSpeed;
        agent.angularSpeed = agentAngularSpeed;
    }

    public void SetAgentPoint(GameObject point)
    {
        drivePoint = point;
        agent.destination = point.transform.position;
    }
}
