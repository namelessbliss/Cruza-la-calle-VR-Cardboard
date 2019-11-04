using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleSpawner : MonoBehaviour {
    public GameObject prefab;

    public float minTime = 2;

    public float spawnMeanTime = 2;

    float nextSpawnTime = 0;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (Time.time > nextSpawnTime)
        {
            Spawn();
            // Uso de formula de los Cuantiles -ln(1-f)*media
            nextSpawnTime = Time.time + minTime - Mathf.Log(Random.value) * spawnMeanTime;
        }
    }

    void Spawn() {
        var instance = Instantiate(prefab, transform.position, transform.rotation, transform);
    }
}
