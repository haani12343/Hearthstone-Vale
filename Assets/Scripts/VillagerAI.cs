using UnityEngine;
using UnityEngine.AI;
public class VillagerAI : MonoBehaviour
{
    public Transform[] points;
    private NavMeshAgent agent;
    private int currentPoint = 0;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        if (points.Length > 0)
            agent.SetDestination(points[0].position);
    }
    void Update()
    {
        if (points.Length == 0) return;
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
         currentPoint = (currentPoint + 1) % points.Length;
         agent.SetDestination(points[currentPoint].position);
        }
    }
}