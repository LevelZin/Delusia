using UnityEngine;
using System.Collections;

public class PathFollower : MonoBehaviour
{

    [SerializeField] private Transform[] path;
    [SerializeField] private float speed = 5.0f;
    [SerializeField] private float reachDist = 1.0f;
    [SerializeField] private int currentPoint = 0;

    void Start()
    {

    }

    void Update()
    {
        float dist = Vector3.Distance (path [currentPoint].position, transform.position);

        transform.position = Vector3.MoveTowards(transform.position,path [currentPoint].position,Time.deltaTime*speed);

        if (dist <= reachDist)
        {
            currentPoint++;
        }

        if (currentPoint >= path.Length)
        {
            currentPoint = 0;
        }
    }

    void OnDrawGizmos()
    {
        if (path.Length > 0)
            for (int i = 0; i < path.Length; i++)
            {
                if (path[i] != null)
                {
                    Gizmos.DrawSphere(path[i].position,reachDist);
                }
            }
    }
}