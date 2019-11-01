using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    //Elevancion del salto en grados 
    public float jumpElevationInDegrees = 45;
    //Rapidez de salto en metros por segundo
    public float jumpSpeedInMps = 5;
    //Estado del jugador
    bool isOnGround;
    // Distancia entre el salto y el suelo
    public float jumpGroundClearance = 2;
    //Tolerancia de rapidez
    public float jumpSpeedTolerance = 5;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        isOnGround = Physics.Raycast(transform.position, -transform.up, jumpGroundClearance);
        Debug.DrawRay(transform.position, -transform.up * jumpGroundClearance);

        var speed = GetComponent<Rigidbody>().velocity.magnitude;
        //Si la rapidez ha disminuido significa que el jugador ha saltado y esta desacelerando
        bool isNearStationary = speed < jumpSpeedTolerance;
        if (GvrPointerInputModule.Pointer.TriggerDown && isOnGround && isNearStationary)
        {
            var camera = GetComponentInChildren<Camera>();

            //Dibuja una linea en la posicion del jugador
            Debug.DrawRay(transform.position, camera.transform.forward, Color.blue);

            //Proyecta un vector sobre un plano definido por una normal ortogonal al plano
            var projectedLookDirection = Vector3.ProjectOnPlane(camera.transform.forward, Vector3.up);

            //Dibuja una linea en la posicion del jugador
            Debug.DrawRay(transform.position, projectedLookDirection, Color.blue);

            //Rotacion de 90°
            var radiansToRotate = Mathf.Deg2Rad * jumpElevationInDegrees;

            //Rota un vector hacia un objetivo
            var unnormalizedJumpDirection = Vector3.RotateTowards(projectedLookDirection, Vector3.up, radiansToRotate, 0);

            var jumpVector = unnormalizedJumpDirection.normalized * jumpSpeedInMps;

            Debug.DrawRay(transform.position, jumpVector, Color.blue);

            //Salto
            GetComponent<Rigidbody>().AddForce(jumpVector, ForceMode.VelocityChange);
        }

    }
}
