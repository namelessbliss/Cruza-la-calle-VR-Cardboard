using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleSpawner : MonoBehaviour {
    public GameObject prefab;
    public float spawnIntervalMin = 2;
    public float spawnIntervalMax = 6;
    float nextSpawnTime = 0;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (Time.time > nextSpawnTime)
        {
            Spawn();
            nextSpawnTime = Time.time + Random.Range(spawnIntervalMin, spawnIntervalMax);
        }
    }

    void Spawn() {
        var instance = Instantiate(prefab, transform.position, transform.rotation, transform);
    }
}
