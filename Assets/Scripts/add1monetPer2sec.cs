using UnityEngine;
using UnityEngine.UI;

public class add1monetPer2sec : MonoBehaviour
{
    public GameObject car; // Ссылка на объект машины
    public Text coinText; // Ссылка на текстовое поле для отображения количества монеток
    private int coins = 0; // Счетчик монеток

    private void Start()
    {
        InvokeRepeating("AddCoin", 2f, 2f); // Вызываем метод AddCoin каждые 2 секунды
    }

    private void Update()
    {
        if (car.GetComponent<Rigidbody>().velocity.magnitude > 0) // Проверяем, двигается ли машина
        {
            coinText.text = coins.ToString(); // Обновляем текстовое поле с количеством монеток
        }
    }

    private void AddCoin()
    {
        if (car.GetComponent<Rigidbody>().velocity.magnitude > 0) // Проверяем, двигается ли машина
        {
            coins++; // Увеличиваем счетчик монеток
            coinText.text = coins.ToString(); // Обновляем текстовое поле с количеством монеток
        }
    }
}
