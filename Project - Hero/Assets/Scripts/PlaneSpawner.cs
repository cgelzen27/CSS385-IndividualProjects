using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneSpawner : MonoBehaviour
{
    public float xRange = 15;
    public float yRange = 10;
    public GameObject planeObj;
    // Start is called before the first frame update
    void Start()
    {
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
}
