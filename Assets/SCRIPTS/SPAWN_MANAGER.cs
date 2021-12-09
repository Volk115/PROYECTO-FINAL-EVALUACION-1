using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SPAWN_MANAGER : MonoBehaviour
{
    //EJES EN LOS QUE APARECERAN ALEATORIAMENTE
    private float ejeX;
    private float ejeY;
    private float ejeZ;
    
    private Vector3 spawnPos;

    public GameObject OBSTACLE;

    public float timeStart = 1f;

    public float timeSpawn = 5f;

    void Start()
    {
        InvokeRepeating("SpawnManager", timeStart, timeSpawn);
    }

    public void SpawnManager()
    {
        ejeX = Random.Range(200, -200);
        ejeY = Random.Range(0, 200);
        ejeZ = Random.Range(-100, 200);

        spawnPos = new Vector3(ejeX, ejeY, ejeZ);

        Instantiate(OBSTACLE, spawnPos, OBSTACLE.transform.rotation);

    }
}
