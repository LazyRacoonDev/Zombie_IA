using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    public Vector3 spawnLimits = new Vector3(10, 0, 10);
    public GameObject zombiePrefab;
    public GameObject[] zombies;
    public int numZombies; 
    void Start()
    {
        zombies = new GameObject[numZombies];
        for (int i = 0; i < numZombies; i++)
        {
            Vector3 spawnPosition = this.transform.position + new Vector3(Random.Range(-spawnLimits.x, spawnLimits.x), 0, Random.Range(-spawnLimits.z, spawnLimits.z));
            zombies[i] = Instantiate(zombiePrefab, spawnPosition, Quaternion.identity, this.transform);
        }
    }

    public void MessageZombies()
    {
        BroadcastMessage("StartFollowPlayer");
    }

    
}
