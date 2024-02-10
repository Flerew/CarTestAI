using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

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
        RememberFrontCar(other.gameObject);

    }

    private void OnTriggerStay(Collider other)
    {
        RememberFrontCar(other.gameObject);
        carAI.CheckAnotherCarDistance(other);
    }

    private void OnTriggerExit(Collider other)
    {
        ForgetFrontCar(other.gameObject);
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

    private void RememberFrontCar(GameObject car)
    {
        if (carAI.frontCar == null)
        {
            if (car.tag == "Player" || car.tag == "Car")
            {
                carAI.frontCar = car;
            }
        }
    } 

    private void ForgetFrontCar(GameObject car)
    {
        if (car.tag == "Player" || car.tag == "Car")
        {
            Debug.Log("forget");
            carAI.frontCar = null;
            carAI.CheckAnotherCarDistance(null);
        }
    }
}
