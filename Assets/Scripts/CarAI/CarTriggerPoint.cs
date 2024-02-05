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
            if (driveOnRightWay == drivePointController.isRightDrivePoint)
            {
                GameObject drivePoint = other.gameObject;

                carAI.SetDrivePoint(drivePoint, drivePointController);
            }
        }
    }
}
