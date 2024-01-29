using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
public class carMove : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private FixedJoystick _joystick;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _turnSpeed;
    [SerializeField] private ParticleSystem _driftParticles; // ������ �� ������� ������ ��� ������

    private void FixedUpdate()
    {
        float moveHorizontal = _joystick.Horizontal;
        float moveVertical = _joystick.Vertical;

        float rotationAngle = moveHorizontal * _turnSpeed;
        Vector3 movement = transform.forward * moveVertical * _moveSpeed;

        _rigidbody.AddTorque(transform.up * rotationAngle, ForceMode.Impulse);
        _rigidbody.AddForce(movement, ForceMode.Force);

        if (Mathf.Abs(moveHorizontal) > 0.5f && _rigidbody.velocity.magnitude > 5f) // ���������, ��� ������ ��������� � �������� � ����������� ���������
        {
            if (!_driftParticles.isPlaying) // ���� ������� ������ �� �������, ��������� ��
            {
                _driftParticles.Play();
            }
        }
        else
        {
            if (_driftParticles.isPlaying) // ���� ������� ������ �������, ������������� ��
            {
                _driftParticles.Stop();
            }
        }
    }
}
