using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDRotation : MonoBehaviour {

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        Camera camera = transform.parent.GetComponentInChildren<Camera>();
        var projectedLookDirection = Vector3.ProjectOnPlane(camera.transform.forward, Vector3.up);
        transform.rotation = Quaternion.LookRotation(projectedLookDirection);
    }
}
