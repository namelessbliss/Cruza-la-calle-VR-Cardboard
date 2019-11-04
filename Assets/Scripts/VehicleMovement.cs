using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleMovement : MonoBehaviour {

    float velocity = 1000;
    // Start is called before the first frame update
    void Start() {

    }

    void FixedUpdate() {
        GetComponent<Rigidbody>().MovePosition(transform.position - transform.right * velocity * Time.deltaTime);
    }
}
