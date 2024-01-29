using UnityEngine;
using UnityEngine.UI;

public class add1monetPer2sec : MonoBehaviour
{
    public GameObject car; // ������ �� ������ ������
    public Text coinText; // ������ �� ��������� ���� ��� ����������� ���������� �������
    private int coins = 0; // ������� �������

    private void Start()
    {
        InvokeRepeating("AddCoin", 2f, 2f); // �������� ����� AddCoin ������ 2 �������
    }

    private void Update()
    {
        if (car.GetComponent<Rigidbody>().velocity.magnitude > 0) // ���������, ��������� �� ������
        {
            coinText.text = coins.ToString(); // ��������� ��������� ���� � ����������� �������
        }
    }

    private void AddCoin()
    {
        if (car.GetComponent<Rigidbody>().velocity.magnitude > 0) // ���������, ��������� �� ������
        {
            coins++; // ����������� ������� �������
            coinText.text = coins.ToString(); // ��������� ��������� ���� � ����������� �������
        }
    }
}
