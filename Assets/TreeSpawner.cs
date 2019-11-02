﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeSpawner : MonoBehaviour {

    public GameObject treePrefab;

    // Start is called before the first frame update
    void Start() {
        CreateTree();
        CreateTree();
        CreateTree();
    }

    void CreateTree() {
        var tree = Instantiate(treePrefab);
        //Obtiene la ubicacion del padre
        tree.transform.parent = transform;
        // establece la posicion del arbol en el padre de forma random
        tree.transform.localPosition = new Vector3(Random.Range(-50, 50), 0, Random.Range(-5, 5));
    }

    // Update is called once per frame
    void Update() {

    }
}
