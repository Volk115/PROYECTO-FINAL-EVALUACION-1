using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SPAWN_MANAGER : MonoBehaviour
{
    //EJES EN LOS QUE APARECERAN ALEATORIAMENTE
    private float ejeX;
    private float ejeY;
    private float ejeZ;
    
    //CADA VEZ APARECERAN EN UNA POSICION DIFERENTE
    private Vector3 spawnPos;

    //DECISION DE QUE OBSTACULO APARECERA (DE LOS PREFABS)
    public GameObject OBSTACLE;

    //TIEMPO DE APARICION
    public float timeStart = 1f;
    public float timeSpawn = 5f;

    //GENERADOR POR TIEMPO, LUGAR Y OBJETO
    void Start()
    {
        InvokeRepeating("SpawnManager", timeStart, timeSpawn);
    }

    //LIMITES DONDE APARECERAN LOS OBSTACULOS
    public void SpawnManager()
    {
        ejeX = Random.Range(200, -200);
        ejeY = Random.Range(0, 200);
        ejeZ = Random.Range(-100, 200);

        spawnPos = new Vector3(ejeX, ejeY, ejeZ);

        Instantiate(OBSTACLE, spawnPos, OBSTACLE.transform.rotation);
    }
}
