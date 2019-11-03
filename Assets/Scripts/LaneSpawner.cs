using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaneSpawner : MonoBehaviour {
    public GameObject[] lanePrefabs;

    // Start is called before the first frame update
    void Start() {
        //Distancia entre tipos de terrenos
        int offset = 1000;
        // crear un terreno cada 1000 metros
        while (offset < 50000)
        {
            CreateRandomLane(offset);
            offset += 1000;
        }
    }

    void CreateRandomLane(float offset) {
        int laneIndex = Random.Range(0, lanePrefabs.Length);
        var lane = Instantiate(lanePrefabs[laneIndex]);
        lane.transform.parent = transform;
        lane.transform.Translate(0, 0, offset);
    }

    // Update is called once per frame
    void Update() {

    }
}
