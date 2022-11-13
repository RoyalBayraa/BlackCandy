using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstPref, obsCoin;
    // Start is called before the first frame update
    void Start()
    {
        SpawnObstacle();
    }

    public void SpawnObstacle()
    {
        int obstSpawnIndex = Random.Range(4, 7);
        int obstSpawnIndex1 = Random.Range(7, 9);
        int obstSpawnIndex2 = Random.Range(9, 12);
        int obstSpawnIndex3 = Random.Range(12, 15);
        int obstSpawnIndex4 = Random.Range(15, 18);
        int obstSpawnIndex5 = Random.Range(18, 21);
        Transform spawnPoint = transform.GetChild(obstSpawnIndex).transform;
        Transform spawnPoint1 = transform.GetChild(obstSpawnIndex1).transform;
        Transform spawnPoint2 = transform.GetChild(obstSpawnIndex2).transform;
        Transform spawnPoint3 = transform.GetChild(obstSpawnIndex3).transform;
        Transform spawnPoint4 = transform.GetChild(obstSpawnIndex4).transform;
        Transform spawnPoint5 = transform.GetChild(obstSpawnIndex5).transform;


        Instantiate(obstPref, spawnPoint.position, Quaternion.identity, transform);
        Instantiate(obsCoin, spawnPoint1.position, Quaternion.identity, transform);
        Instantiate(obstPref, spawnPoint2.position, Quaternion.identity, transform);
        Instantiate(obsCoin, spawnPoint3.position, Quaternion.identity, transform);
        Instantiate(obstPref, spawnPoint4.position, Quaternion.identity, transform);
        Instantiate(obsCoin, spawnPoint5.position, Quaternion.identity, transform);
    }


}
