using System;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class CarAI : MonoBehaviour
{
    [SerializeField] private List<Vector3> _paths = null;
    [SerializeField] private float _arriveDistance = 3f;
    [SerializeField] private float _lastPointArriveDistance = 1f;
    [SerializeField] private float _turningAngleOffset = 5f;
    [SerializeField] private Vector3 _currentTargetPosition;

    private int _index = 0;

    private bool _stop;
    public bool Stop 
    {
        get { return _stop; }
        set { _stop = value; }
    }

    [field: SerializeField]
    public UnityEvent<Vector2> OnDrive { get; set; }

    private void Start()
    {
        if(_paths == null || _paths.Count == 0)
        {
            Stop = true;
        }
        else
        {
            _currentTargetPosition = _paths[_index];
        }
    }

    public void SetPath(List<Vector3> paths)
    {
        if(_paths.Count == 0)
        {
            Destroy(gameObject); 
        }
        this._paths = paths;
        _index = 0;
        _currentTargetPosition = this._paths[_index];

        Vector3 relativePoint = transform.InverseTransformPoint(this._paths[_index + 1]);

        float angle = Mathf.Atan2(relativePoint.x, relativePoint.z) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, angle, 0);
        Stop = false;
    }

    private void Update()
    {
        CheckIfArrived();
        Drive();
    }

    private void Drive()
    {
        if(Stop)
        {
            //OnDrive?.Invoke
        }
    }

    private void CheckIfArrived()
    {
        if(Stop == false)
        {
            float distanceToCheck = _arriveDistance;
            if(_index == _paths.Count - 1 )
            {
                distanceToCheck = _lastPointArriveDistance;
            }
            if(Vector3.Distance(_currentTargetPosition, transform.position) < distanceToCheck)
            {
                SetNextTargetIndex();
            }
        }
    }

    private void SetNextTargetIndex()
    {
        _index++;
        if(_index >= _paths.Count)
        {
            Stop = true;
            Destroy(gameObject);
        }
        else
        {
            _currentTargetPosition = _paths[_index];
        }
    }
}
