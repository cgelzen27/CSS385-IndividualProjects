using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneSpawner : MonoBehaviour
{
    private float xRange = 13;
    private float yRange = 8;
    public GameObject planeObj;
    // Start is called before the first frame update
    void Start()
    {
        EventManager.current.EnemiesDestroyedEvent += SpawnAPlane;
        for (int i = 0; i < 10; i++)
        {
            float xSpawn = Random.Range(-xRange, xRange);
            float ySpawn = Random.Range(-yRange, yRange);
            Instantiate(planeObj, new Vector3(xSpawn, ySpawn, 0), planeObj.transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnAPlane()
    {
        float xSpawn = Random.Range(-xRange, xRange);
        float ySpawn = Random.Range(-yRange, yRange);
        Instantiate(planeObj, new Vector3(xSpawn, ySpawn, 0), planeObj.transform.rotation);
    }
    private void OnDisable()
    {
        EventManager.current.EnemiesDestroyedEvent -= SpawnAPlane;
    }
}
