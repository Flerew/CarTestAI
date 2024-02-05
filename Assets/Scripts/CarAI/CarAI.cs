using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.AI;

public class CarAI : MonoBehaviour
{
    public GameObject drivePoint;
    public bool canChangeDrivePoint = true;
    public bool driveOnRightWay;

    private NavMeshAgent agent;
    private Rigidbody rb;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent(out DrivePointController drivePointController))
        {
            SetNextDrivePoint(drivePointController);
        }
    }

    public void SetNextDrivePoint(DrivePointController drivePointController)
    {
        if (driveOnRightWay == drivePointController.isRightDrivePoint)
        {
            if (drivePointController.nextDrivePoints.Count > 0)
            {
                List<GameObject> points = drivePointController.nextDrivePoints;
                drivePoint = points[Random.Range(0, points.Count)];
                SetAgentPoint(drivePoint);
                CheckNextDrivePoint(drivePoint);
            }
            else
            {
                canChangeDrivePoint = true;
            }
        }
    }

    private void CheckNextDrivePoint(GameObject nextDrivePoint)
    {
        if (drivePoint.TryGetComponent(out DrivePointController nextDrivePointController))
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

    public void SetDrivePoint(GameObject point, DrivePointController drivePointController)
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

    private void SetAgentPoint(GameObject point)
    {
        drivePoint = point;
        agent.destination = point.transform.position;
    }
}
