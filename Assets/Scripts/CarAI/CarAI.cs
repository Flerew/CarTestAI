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

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
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
                canChangeDrivePoint = false;
            }
            else
            {
                canChangeDrivePoint = true;
            }
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
            Debug.Log(point.name);

            SetAgentPoint(point);
        }
    }

    private void SetAgentPoint(GameObject point)
    {
        drivePoint = point;
        agent.destination = point.transform.position;
    }
}
