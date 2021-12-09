using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MOOVE_CONSTANT : MonoBehaviour
{
    //VELOCIDAD LINEAL
    private float speed = 50;



    void Update()
    {
        //VELOCIDAD CONSTANTE HACIA ADELANTE
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

    }

    private void OnCollisionEnter(Collision otherCollider)
    {
        //CUANDO CHOCA CON LOS OBJETOS LLAMADOS OBSTACLE
        if (otherCollider.gameObject.CompareTag("OBSTACLE"))
        {
            //AL COLISIONAR CON EL PLAYER, SE DESTRUIRA EL OBJETO
            Destroy(otherCollider.gameObject);

            Destroy(gameObject);

        }
    }

 }
