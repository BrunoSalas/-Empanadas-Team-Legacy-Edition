using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorJugador : MonoBehaviour
{
    private ModeloJugador modeloJugador;
    
    void Start()
    {
        modeloJugador = GetComponent<ModeloJugador>();
        
    }


    void Update()
    {
        Movimiento();
        Rotacion();
        Vida();
    }

    void Vida()
    { 
    }

    void Rotacion()
    {
        modeloJugador.rotacionX -= Input.GetAxis("Mouse Y") * Time.deltaTime * modeloJugador.velocidadRotacion;//Herencia de la clase ModeloJugador
        modeloJugador.rotacionY += Input.GetAxis("Mouse X") * Time.deltaTime * modeloJugador.velocidadRotacion;//Herencia de la clase ModeloJugador

        transform.rotation = Quaternion.Euler(0, modeloJugador.rotacionY, 0);//Herencia de la clase ModeloJugador
        GameObject.FindWithTag("MainCamera").transform.rotation = Quaternion.Euler(modeloJugador.rotacionX, modeloJugador.rotacionY, 0);//Herencia de la clase ModeloJugador
    }

    void Movimiento()
    {
        Rigidbody rb_mj = modeloJugador.rb; //Herencia de la clase ModeloJugador
        float velocidadMov_mj = modeloJugador.velocidadMov; //Herencia de la clase ModeloJugador
        float movHorizontal = Input.GetAxisRaw("Horizontal");
        float movVertical = Input.GetAxisRaw("Vertical");

        if (movHorizontal != 0.0f || movVertical != 0.0f)
        {
             Vector3 direccion = transform.forward * movVertical + transform.right * movHorizontal;

           rb_mj.MovePosition(transform.position + direccion* velocidadMov_mj * Time.deltaTime);
        }
    }
}