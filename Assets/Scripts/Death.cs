using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour {

    public GameObject UICanvas;

    public void OnDeath() {
        //acitva la interfaz con opcion de jugar de nuevo o salir
        UICanvas.SetActive(true);
        GetComponent<Rigidbody>().isKinematic = true;
    }
}
