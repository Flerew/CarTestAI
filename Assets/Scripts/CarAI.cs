using UnityEngine;
using UnityEngine.AI;

public class CarAI : MonoBehaviour
{
    public GameObject drivePoint;

    private NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        agent.destination = drivePoint.transform.position;
    }
}
