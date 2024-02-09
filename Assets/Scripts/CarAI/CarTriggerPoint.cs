using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarTriggerPoint : MonoBehaviour
{
    private CarAI carAI;
    private bool driveOnRightWay;

    private void Awake()
    {
        carAI = GetComponentInParent<CarAI>();
    }

    private void OnTriggerEnter(Collider other)
    {
        SetNextDrivePoint(other);
    }

    private void SetNextDrivePoint(Collider other)
    {
        if (other.gameObject.TryGetComponent(out DrivePointController drivePointController))
        {
            driveOnRightWay = carAI.driveOnRightWay;
            bool canChangeDrivePoint = carAI.canChangeDrivePoint;

            if (driveOnRightWay == drivePointController.isRightDrivePoint && canChangeDrivePoint)
            {
                GameObject drivePoint = other.gameObject;

                carAI.SetDrivePoint(drivePoint);
            }
        }
    }
}
