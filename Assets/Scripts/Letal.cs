using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Letal : MonoBehaviour {

    Death deathComponent;

    private void Start() {
        deathComponent = FindObjectOfType<Death>();
    }

    private void OnCollisionEnter(Collision collision) {
        deathComponent.OnDeath();
    }
}
