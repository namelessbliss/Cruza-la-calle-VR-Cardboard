using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaneSpawner : MonoBehaviour {
    public GameObject[] lanePrefabs;

    // Start is called before the first frame update
    void Start() {
        CreateRandomLane(0);
        CreateRandomLane(10);
        CreateRandomLane(20);
        CreateRandomLane(30);
        CreateRandomLane(40);
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
