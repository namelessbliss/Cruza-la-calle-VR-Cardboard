using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public Vector3 jumpVector;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        //Dibuja una linea en la posicion del jugador
        Debug.DrawRay(transform.position, jumpVector, Color.blue);

        //Proyecta un vector sobre un plano definido por una normal ortogonal al plano
        var projectedJumpVector = Vector3.ProjectOnPlane(jumpVector, Vector3.up);

        //Dibuja una linea en la posicion del jugador
        Debug.DrawRay(transform.position, projectedJumpVector, Color.blue);

        //Rotacion de 90°
        var radiansToRotate = Mathf.Deg2Rad * 90;
        //Rota un vector hacia un objetivo
        var rotatedJumpVector = Vector3.RotateTowards(jumpVector, Vector3.up, radiansToRotate, 0);
        Debug.DrawRay(transform.position, rotatedJumpVector.normalized, Color.blue);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Rigidbody>().AddForce(jumpVector, ForceMode.VelocityChange);
        }

    }
}
