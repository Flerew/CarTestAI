using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrivePointController : MonoBehaviour
{
    public List<GameObject> nextDrivePoints;
    public bool isRightDrivePoint;

    private void OnTriggerEnter(Collider other)
    {
        SetCarDrivePoint(other);
    }

    public void SetCarDrivePoint(Collider other)
    {
        if (other.gameObject.TryGetComponent(out CarAI carAI))
        {
            if (carAI.drivePoint == gameObject)
            {
                if (nextDrivePoints.Count > 0)
                {
                    GameObject nextDrivePoint = nextDrivePoints[Random.Range(0, nextDrivePoints.Count)];
                    carAI.CheckNextDrivePoint(nextDrivePoint);
                    carAI.SetDrivePoint(nextDrivePoint);
                }
                else
                {
                    carAI.canChangeDrivePoint = true;
                }
            }
        }
    }
}