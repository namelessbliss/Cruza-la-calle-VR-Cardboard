using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum LaneType { Safe, Danger }

public class LaneSpawner : MonoBehaviour {
    public GameObject[] safeLanePrefabs;
    public GameObject[] dangerousLanePrefabs;
    LaneType lastLaneType = LaneType.Safe;

    public float laneSpawnDistance = 5000;
    public float safeLaneRunProbability = 0.2f;
    //Distancia entre tipos de terrenos
    int offset = 0;

    public GameObject player;

    void Update() {

        // crear un terreno cada 1000 metros
        while (offset < laneSpawnDistance + player.transform.position.z)
        {
            CreateRandomLane(offset);
            offset += 1000;
        }
        foreach (Transform laneTransform in this.transform)
        {
            if (laneTransform.position.z + laneSpawnDistance < player.transform.position.z)
            {
                //Destruir terreno
                Destroy(laneTransform.gameObject);
            }
        }
    }

    void CreateRandomLane(float offset) {

        GameObject lane;

        if (lastLaneType == LaneType.Safe)
        {
            // Probabilidad de generar otra linea segura
            if (Random.value < safeLaneRunProbability)
            {
                lastLaneType = LaneType.Safe;
                lane = InstantiateRandomLane(safeLanePrefabs);
            }
            else
            {
                lastLaneType = LaneType.Danger;
                lane = InstantiateRandomLane(dangerousLanePrefabs);
            }
        }
        else
        {
            lastLaneType = LaneType.Safe;
            lane = InstantiateRandomLane(safeLanePrefabs);
        }

        lane.transform.SetParent(transform, false);
        lane.transform.Translate(0, 0, offset);
    }

    GameObject InstantiateRandomLane(GameObject[] lanes) {
        int laneIndex = Random.Range(0, lanes.Length);
        return Instantiate(lanes[laneIndex]);
    }
}
