using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiedraVolcanica : MonoBehaviour
{
    public GameObject parteNucleo;
    public GameObject targetAdel;
    public GameObject targetJuga;
    public float time;
    public int sale;

    public float targetAdelX;
    public float targetAdelY;
    public float targetAdelZ;

    public float targetJugaX;
    public float targetJugaY;
    public float targetJugaZ;

    public float T;
    
    public float x;
    public float y;
    public float z;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //target jugador cambio
        targetAdelX = targetAdel.transform.position.x;
        targetAdelY = targetAdel.transform.position.y;
        targetAdelZ = targetAdel.transform.position.z;
        
        targetJugaX = targetJuga.transform.position.x;
        targetJugaY = targetJuga.transform.position.y;
        targetJugaZ = targetJuga.transform.position.z;
        
        //ultTim = ultTim + 1 * Time.deltaTime;


         T = T + 1 * Time.deltaTime;

        time = time + Time.deltaTime * 1;
   
        if (T >= 3f)
        {
            GuardarPosicion();


            T = 0;
        }

        if (x == targetJugaX && y == targetJugaY && z == targetJugaZ)
        {
            Debug.Log("A");

            if (time <= 1)
            {
                LugarAparicionJuga();

                //A = false;
            }
            else if (time >= 3)
            {
                time = 0;

                //B = false;
                sale = 1;

                Debug.Log("b");
            }
        }
        else
        {

            if (time <= 1)
            {
                LugarAparicionAdel();

                Debug.Log("a");

            }
            else if (time >= 3)
            {
                time = 0;

                Debug.Log("D");
                sale = 1;
            }
        }
    }

    public void LugarAparicionJuga()
    {
        Vector3 spawnNucleo = new Vector3(targetJugaX, targetJugaY + 10, targetJugaZ);

        if (sale == 1)
        {
            Instantiate(parteNucleo, spawnNucleo, transform.rotation);

            //T = 0;


            sale = 2;
        }
    }


    public void GuardarPosicion()
    {

        x = targetJugaX;
        y = targetJugaY;
        z = targetJugaZ;

        Debug.Log("rq");
    }

    public void LugarAparicionAdel()
    {
        Vector3 spawnNucleo = new Vector3(targetAdelX, targetAdelY + 10, targetAdelZ);

        if (sale == 1)
        {
            Instantiate(parteNucleo, spawnNucleo, transform.rotation);

           // T = 0;
            sale = 2;
        }
    }
}
