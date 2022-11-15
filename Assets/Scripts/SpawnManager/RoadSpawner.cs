using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RoadSpawner : MonoBehaviour
{
    public List<GameObject> roads;
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

        if (PlayerPrefs.GetInt("level", 0) <= 1)
        {
            GameObject temp = Instantiate(roads[0], nextSpawnPoint, Quaternion.identity);
            nextSpawnPoint = temp.transform.GetChild(0).transform.position;
        }
        else if (PlayerPrefs.GetInt("level", 0) <= 2)
        {
            GameObject temp = Instantiate(roads[1], nextSpawnPoint, Quaternion.identity);
            nextSpawnPoint = temp.transform.GetChild(0).transform.position;
        }
        else
        {
            GameObject temp = Instantiate(roads[2], nextSpawnPoint, Quaternion.identity);
            nextSpawnPoint = temp.transform.GetChild(0).transform.position;
        }
    }




}
