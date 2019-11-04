using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    //Elevancion del salto en grados 
    public float jumpElevationInDegrees = 45;
    //Rapidez de salto en metros por segundo
    public float[] jumpSpeedInMps = { 350, 700, 1000 };
    //Estado del jugador
    bool isOnGround;
    // Distancia entre el salto y el suelo
    public float jumpGroundClearance = 2;
    //Tolerancia de rapidez
    public float jumpSpeedTolerance = 5;

    int collisionCount = 0;
    int hopCount = 0;

    // Start is called before the first frame update
    void Start() {

    }
    //Incrementa el valor del contador cuando se detecta colision con otro objeto
    void OnCollisionEnter() {
        collisionCount++;
    }

    //Disminuye valor al contador cuando salta
    void OnCollisionExit() {
        collisionCount--;
    }

    // Update is called once per frame
    void Update() {
        //Debug.Log("contador " + collisionCount);
        //0 implica que el jugador ha saltado y esta en el aire
        isOnGround = collisionCount > 0;

        if (isOnGround)
        {
            hopCount = 0;
        }

        if (GvrPointerInputModule.Pointer.TriggerDown && hopCount < jumpSpeedInMps.Length)
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

            var jumpVector = unnormalizedJumpDirection.normalized * jumpSpeedInMps[hopCount];

            Debug.DrawRay(transform.position, jumpVector, Color.blue);

            //Salto
            GetComponent<Rigidbody>().AddForce(jumpVector, ForceMode.VelocityChange);
        }

    }
}
