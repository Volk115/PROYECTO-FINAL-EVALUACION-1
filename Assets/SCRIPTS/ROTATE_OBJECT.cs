using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ROTATE_OBJECT : MonoBehaviour
{
    //VELOCIDAD DE ROTACION
    public float rotateSpeed = 800;

    //SE LLAMA AL SCRIPT PLAYER CONTROLLER
    public PLAYER_CONTROLLER playerControllerScript;

    void Start()
    {
        //BUSCA AL SCRIPT DEL COLISIONADOR
         playerControllerScript = FindObjectOfType<PLAYER_CONTROLLER>();
    }

    //SI EL JUGADOR PIERDE, SE PARA EL TIEMPO (ASI COMO EL MOVIMIENTO DEL VEHICULO Y LAS ELICES)
    void Update()
    {
        if (!playerControllerScript.gameOver)
        {
            transform.Rotate(Vector3.up * Time.deltaTime * rotateSpeed);
        }
    }
}
