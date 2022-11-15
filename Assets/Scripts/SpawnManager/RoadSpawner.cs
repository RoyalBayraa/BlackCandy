using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RoadSpawner : MonoBehaviour
{
    public GameObject road;
    Vector3 nextSpawnPoint;
    //private float offset = 100f;

    // Start is called before the first frame update
    private void Start()
    {
        for(int i = 0; i<15; i++)
        {
            SpawnRoad();
        }
    }

    public void SpawnRoad()
    {
        GameObject temp = Instantiate(road, nextSpawnPoint, Quaternion.identity);
        nextSpawnPoint = temp.transform.GetChild(0).transform.position;
    }




}
