
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorJugador : MonoBehaviour
{
    private ModeloJugador modeloJugador;
    private PowerDucks powerDucks;
    private TrampaCuevaPiedras trampaPiedras;

    void Start()
    {
        modeloJugador = GetComponent<ModeloJugador>();
        powerDucks = GetComponent<PowerDucks>();

        trampaPiedras = GetComponent<TrampaCuevaPiedras>();
    }


    void Update()
    {
        Movimiento();
        Rotacion();
        Vida();
        UsoDePower();
       // Trampas();

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

    public void UsoDePower()
    {
        if (Input.GetKeyDown(KeyCode.Q) && modeloJugador.patos >= 1)//Herencia de la clase ModeloJugador
        {
            powerDucks.PoderDos();//Herencia de la clase PowerDucks
            powerDucks.PoderUno();//Herencia de la clase PowerDucks
            
        }
            
    }

    
   /* public void Trampas()
    {
        if (modeloJugador.encimaDeTrampa == true)
        {
            trampaPiedras.TrampaSegundo();//Herencia de la clase TrampaCuevaPiedras
            modeloJugador.encimaDeTrampa = false;//Herencia de la clase ModeloJugador
        }
    }
    */
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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            modeloJugador.enElSuelo = false; //Herencia de la clase ModeloJugador
            rb_mj.AddForce(0, modeloJugador.empujeSalto, 0, ForceMode.Impulse);

        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Piso"))
        {
            modeloJugador.enElSuelo = true;//Herencia de la clase ModeloJugador
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Trampa"))
        {
            modeloJugador.encimaDeTrampa = true;//Herencia de la clase ModeloJugador
        }
    }
  
}