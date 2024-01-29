using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    public List<GameObject> carPrefabs;

    private void Start()
    {
        SpawnRandomCar(SelectCarPrefab());
    }

    private void SpawnRandomCar(GameObject car)
    {
        Instantiate(car, transform);
    }

    private GameObject SelectCarPrefab()
    {
        return carPrefabs[Random.Range(0, carPrefabs.Count)];
    }
}
