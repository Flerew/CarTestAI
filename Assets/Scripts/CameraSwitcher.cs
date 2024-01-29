using UnityEngine;
using UnityEngine.UI;

public class CameraSwitcher : MonoBehaviour
{
    public Camera mainCamera;
    public Camera camera1;
    public Camera camera2;
    public Camera camera3;

    public Button camera1Button;
    public Button camera2Button;
    public Button camera3Button;
    public Button mainCameraButton; // ����� ������ ��� �������� � ������� ������

    void Start()
    {
        // �������� ������ ������� ������ ��� ������
        mainCamera.enabled = true;
        camera1.enabled = false;
        camera2.enabled = false;
        camera3.enabled = false;

        // ��������� ������ ��� ��������� ������� ������� ������
        camera1Button.onClick.AddListener(ActivateCamera1);
        camera2Button.onClick.AddListener(ActivateCamera2);
        camera3Button.onClick.AddListener(ActivateCamera3);
        mainCameraButton.onClick.AddListener(ActivateMainCamera); // ��������� ����� ��� ����� ������
    }

    void ActivateCamera1()
    {
        mainCamera.enabled = false;
        camera1.enabled = true;
        camera2.enabled = false;
        camera3.enabled = false;
    }

    void ActivateCamera2()
    {
        mainCamera.enabled = false;
        camera1.enabled = false;
        camera2.enabled = true;
        camera3.enabled = false;
    }

    void ActivateCamera3()
    {
        mainCamera.enabled = false;
        camera1.enabled = false;
        camera2.enabled = false;
        camera3.enabled = true;
    }

    void ActivateMainCamera() // ����� ��� �������� � ������� ������
    {
        mainCamera.enabled = true;
        camera1.enabled = false;
        camera2.enabled = false;
        camera3.enabled = false;
    }
}
