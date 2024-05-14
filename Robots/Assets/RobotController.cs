using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RobotController : MonoBehaviour
{
    public float fuel = 100f;
    public float fuelConsumptionRate = 1f;
    public float moveSpeed = 3.5f;
    public float sensorRange = 10f;
    public float searchDuration = 5f;  // Duration to move in one direction before changing
    public Transform resourceCollectionPoint;

    private NavMeshAgent agent;
    private GameObject targetResource;
    private bool isCollectingResource = false;
    private float searchTimer = 0f;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = moveSpeed;
        MoveInRandomDirection();
    }

    void Update()
    {
        if (fuel <= 0)
        {
            StopRobot();
            return;
        }

        if (!isCollectingResource)
        {
            SearchForResource();
        }

        ConsumeFuel();
    }

    void SearchForResource()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, sensorRange);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("Resource"))
            {
                targetResource = hitCollider.gameObject;
                agent.SetDestination(targetResource.transform.position);
                isCollectingResource = true;
                return;
            }
        }

        searchTimer += Time.deltaTime;
        if (searchTimer >= searchDuration)
        {
            searchTimer = 0f;
            MoveInRandomDirection();
        }
    }

    void MoveInRandomDirection()
    {
        Vector3 randomDirection = Random.insideUnitSphere * sensorRange;
        randomDirection += transform.position;
        NavMeshHit hit;
        NavMesh.SamplePosition(randomDirection, out hit, sensorRange, 1);
        Vector3 finalPosition = hit.position;
        agent.SetDestination(finalPosition);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Resource") && isCollectingResource)
        {
            StartCoroutine(CollectResource(other.gameObject));
        }
    }

    IEnumerator CollectResource(GameObject resource)
    {
        // Simulate resource collection time
        yield return new WaitForSeconds(2f);
        Destroy(resource);
        targetResource = null;
        isCollectingResource = false;
        ReturnToBase();
    }

    void ReturnToBase()
    {
        agent.SetDestination(resourceCollectionPoint.position);
    }

    void OnTriggerEnterBase(Collider other)
    {
        if (other.CompareTag("Base"))
        {
            // Simulate resource deposit time
            StartCoroutine(DepositResource());
        }
    }

    IEnumerator DepositResource()
    {
        yield return new WaitForSeconds(2f);
        // Code to handle depositing resource
        // For now, we just refuel the robot
        fuel = 100f;
    }

    void ConsumeFuel()
    {
        fuel -= fuelConsumptionRate * Time.deltaTime;
        if (fuel < 0)
        {
            fuel = 0;
        }
    }

    void StopRobot()
    {
        agent.isStopped = true;
        // Additional code to handle when robot stops due to lack of fuel
    }
}
