using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShortRoadEvent : MonoBehaviour
{
    RoadSpawner roadSpawner;
    // Start is called before the first frame update
    void Start()
    {
        roadSpawner = GameObject.FindObjectOfType<RoadSpawner>();
        SpawnObstacle();
    }

    private void OnTriggerExit(Collider other)
    {
        roadSpawner.SpawnRoad();
        Destroy(gameObject, 2);
    }

    public GameObject obstPref;

    public void SpawnObstacle()
    {
        int obstSpawnIndex = Random.Range(5, 8);
        Transform spawnPoint = transform.GetChild(obstSpawnIndex).transform;
        Instantiate(obstPref, spawnPoint.position, Quaternion.identity, transform);
    }
}
