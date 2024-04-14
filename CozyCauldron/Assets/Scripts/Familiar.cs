using UnityEngine.AI;
using UnityEngine;
using System.Collections;

public class Familiar : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public FamiliarSpawner familiarSpawner;
    public int itemToGive;
    public int itemCount;
    public bool searching;
    public Transform[] destinations; // Array of possible destinations
    public Transform cauldron; // Specific transform for the cauldron
    public NavMeshAgent agent; // NavMeshAgent for AI movement
    public float arrivalThreshold = 0.5f;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = moveSpeed;
        GoToRandomItem();

    }
    private void Update()
    {
        this.transform.rotation = Quaternion.identity;
        if (!agent.pathPending && agent.remainingDistance <= arrivalThreshold && !agent.hasPath)
        {
            ReturnToCauldron();  // Call the event function when destination is reached
        }
    }

    public void ReturnToCauldron()
    {
        agent.SetDestination(cauldron.position);
        if (!agent.pathPending && agent.remainingDistance <= arrivalThreshold && !agent.hasPath)
        {
            Debug.Log("Gotoitem");
            GoToRandomItem();  // Call the event function when destination is reached
        }
    }
    public void GoToRandomItem()
    {
        int rnd = Random.Range(0, destinations.Length);
        agent.SetDestination(destinations[rnd].position);
    }
    public void TryToFindItem()
    {
        searching = true;
        if (Random.Range(0, 100) < 10) // Example probability adjustment if needed
        {
            AssignRandomItem();
        }
        searching = false;
    }

    private void AssignRandomItem()
    {
        itemToGive = Random.Range(1, 5); // Randomly determine which item to give
        itemCount = GetRandomItemCount(); // Determine the count of the item
    }

    private int GetRandomItemCount()
    {
        int rand = Random.Range(1, 101); // Generate a random number
        if (rand <= 70) return 1;
        else if (rand <= 90) return 2;
        else return 3;
    }
}
