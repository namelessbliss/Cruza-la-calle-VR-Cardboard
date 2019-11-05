﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructor : MonoBehaviour {

    private void OnTriggerEnter(Collider other) {
        Destroy(other.GetComponentInParent<Rigidbody>().gameObject);
    }
}
