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
}
