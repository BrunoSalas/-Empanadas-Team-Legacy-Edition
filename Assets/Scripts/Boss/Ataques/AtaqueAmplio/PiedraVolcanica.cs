using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiedraVolcanica : MonoBehaviour
{
    public GameObject piedraVolca;
    public GameObject targetAdel;
    public GameObject targetJuga;

    float tiempo;

    public float tiempoAparicion;
    public float tiempoEspera;

    public int creacion;

    public float targetAdelX;
    public float targetAdelY;
    public float targetAdelZ;

    public float targetJugaX;
    public float targetJugaY;
    public float targetJugaZ;

    float tiempoGuardado;
    public float guardarT;
    
    public float respaldoJugaX;
    public float respaldoJugaY;
    public float respaldoJugaZ;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //target normal
        targetAdelX = targetAdel.transform.position.x;
        targetAdelY = targetAdel.transform.position.y;
        targetAdelZ = targetAdel.transform.position.z;
        
        //targer del jugador
        targetJugaX = targetJuga.transform.position.x;
        targetJugaY = targetJuga.transform.position.y;
        targetJugaZ = targetJuga.transform.position.z;


        tiempoGuardado = tiempoGuardado + 1 * Time.deltaTime;

        tiempo = tiempo + Time.deltaTime * 1;
   
        if (tiempoGuardado >= guardarT)
        {
            GuardarPosicion();

            tiempoGuardado = 0;
        }

        if (respaldoJugaX == targetJugaX && respaldoJugaY == targetJugaY && respaldoJugaZ == targetJugaZ)
        {
            Debug.Log("A");

            if (tiempo <= tiempoAparicion)
            {
                LugarAparicionJuga();

            }
            else if (tiempo >= tiempoEspera)
            {
                tiempo = 0;

                creacion = 1;

                Debug.Log("b");
            }
        }
        else
        {

            if (tiempo <= tiempoAparicion)
            {
                LugarAparicionAdel();

                Debug.Log("a");

            }
            else if (tiempo >= tiempoEspera)
            {
                tiempo = 0;

                Debug.Log("D");
                creacion = 1;
            }
        }
    }

    public void LugarAparicionJuga()
    {
        Vector3 spawnPierdra = new Vector3(targetJugaX, targetJugaY + 10, targetJugaZ);

        if (creacion == 1)
        {
            Instantiate(piedraVolca, spawnPierdra, transform.rotation);

            creacion = 2;
        }
    }


    public void GuardarPosicion()
    {

        respaldoJugaX = targetJugaX;
        respaldoJugaY = targetJugaY;
        respaldoJugaZ = targetJugaZ;

    }

    public void LugarAparicionAdel()
    {
        Vector3 spawnPierdra = new Vector3(targetAdelX, targetAdelY + 10, targetAdelZ);

        if (creacion == 1)
        {
            Instantiate(piedraVolca, spawnPierdra, transform.rotation);

            creacion = 2;
        }
    }
}
