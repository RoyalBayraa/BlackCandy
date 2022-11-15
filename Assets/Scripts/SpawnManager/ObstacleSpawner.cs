using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obsCoin;
    // Start is called before the first frame update
    void Start()
    {
        SpawnObstacle();
    }

    public void SpawnObstacle()
    {
        int obstSpawnIndex = Random.Range(4, 8);
        Transform spawnPoint = transform.GetChild(obstSpawnIndex).transform;
        Instantiate(obsCoin, spawnPoint.position, Quaternion.identity, transform);
    }


}
