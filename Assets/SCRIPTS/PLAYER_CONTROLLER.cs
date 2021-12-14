using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PLAYER_CONTROLLER : MonoBehaviour
{
    //VELOCIDAD LINEAL
    private float speed = 20;

    //VELOCIDAD DE ROTACION
    private float turnspeed = 30;
    private float horizontalInput;
    private float verticalInput;

    //LIMITES DE PANTALLA
    public float rightlim = 200;

    //PROYECTIL
    public GameObject projectilePrefab;

    //MUSICA Y EFECTOS DE SONIDO
    private AudioSource playerAudioSource;
    public AudioClip explosionClip;

    //GAMEOVER
    public bool gameOver;

    //TEXTO
    public TextMeshProUGUI scoreText;
    public int POINTS = 0;

    //APARICION DEL PLAYER
    void Start()
    {
        transform.position = new Vector3(0, 100, 0);
        POINTS = 0;
    }

    void Update()
    {
        //EN CASO DE NO PERDER LA PARTIDA
        if (!gameOver)
        {
            //VELOCIDAD CONSTANTE HACIA ADELANTE
            transform.Translate(Vector3.forward * speed * Time.deltaTime);

            //ROTACION
            transform.Rotate(Vector3.up, turnspeed * Time.deltaTime * horizontalInput);
            transform.Rotate(Vector3.left, turnspeed * Time.deltaTime * verticalInput);

            horizontalInput = Input.GetAxis("Horizontal");
            verticalInput = Input.GetAxis("Vertical");

            //LIMITES DE PANTALLA HORIZONTAL
            if (transform.position.x >= rightlim)
            {
                transform.position = new Vector3(rightlim, transform.position.y, transform.position.z);
            }

            if (transform.position.x <= -rightlim)
            {
                transform.position = new Vector3(-rightlim, transform.position.y, transform.position.z);
            }

            //LIMITES DE PANTALLA VERTICAL
            if (transform.position.y >= rightlim)
            {
                transform.position = new Vector3(transform.position.x, rightlim, transform.position.z);
            }

            if (transform.position.y <= 0)
            {
                transform.position = new Vector3(transform.position.x, 0, transform.position.z);
            }

            //LIMITES DE PANTALLA EJE Z
            if (transform.position.z >= rightlim)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, rightlim);
            }

            if (transform.position.z <= -rightlim)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, -rightlim);
            }

            //USO DE PROYECTIL
            if (Input.GetKeyDown(KeyCode.RightControl))
            {
                Instantiate(projectilePrefab, transform.position, gameObject.transform.rotation);
            }

            scoreText.text = $"Score: {POINTS} / 10";

            //AL LLEGAR A LOS 10 PUNTOS, SE GANA LA PARTIDA
            if (POINTS == 10)
            {
                gameOver = true;
                    Debug.Log("Win");
            }
        }
    }

    //COLISION
    private void OnCollisionEnter(Collision otherCollider)
    {
        //CUANDO CHOCA CON LOS OBJETOS LLAMADOS OBSTACLE
        if (otherCollider.gameObject.CompareTag("OBSTACLE"))
        {
            //AL COLISIONAR CON EL PLAYER, SE DESTRUIRA EL OBJETO
            Destroy(otherCollider.gameObject);

            //COMUNICAMOS QUE HEMOS MUERTO (GAMEOVER)
            gameOver = true;
            Debug.Log("GameOver");
        }

        //CUANDO CHOCA CON LOS OBJETOS LLAMADOS POINT
        if (otherCollider.gameObject.CompareTag("POINT"))
        {
            //AL COLISIONAR CON EL PLAYER, SE DESTRUIRA EL OBJETO
            Destroy(otherCollider.gameObject);

            POINTS = POINTS + 1;
        }
    }
}
