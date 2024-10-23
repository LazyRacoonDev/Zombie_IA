using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class VisionZombie : MonoBehaviour
{
    public Camera frustum;
    public LayerMask mask; 
    public NavMeshAgent agent;
    public GameObject player;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("Player");
    }

    
    void Update()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, frustum.farClipPlane, mask);
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(frustum);

        foreach (Collider col in colliders)
        {
            RaycastHit hit;
            Ray ray = new Ray(transform.position, (col.transform.position - transform.position).normalized);
            ray.origin = ray.GetPoint(frustum.nearClipPlane);

            if(Physics.Raycast(ray, out hit, frustum.farClipPlane, mask))
            {
                if (hit.collider.gameObject.CompareTag("Player"))
                {
                    SendMessageUpwards("MessageZombies");
                }
            }
        }
    }

    public void StartFollowPlayer()
    {
        agent.SetDestination(player.transform.position);
    }   
}
