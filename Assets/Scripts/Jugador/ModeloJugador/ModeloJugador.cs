using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeloJugador : MonoBehaviour
{
    public Rigidbody rb;
    public int habilidad;
    public int patos;
    public float maximaVida;
    public float velocidadMov;
    public float rotacionX;
    public float rotacionY;
    public float rotacionZ;
    public float velocidadRotacion;
    public float salto = 0.4f;
    public float empujeSalto = 10;
    public bool enElSuelo;
    public bool poderUsable;
    public bool paraEncimaDeTrampa; // variable para detectar trampa
    void Start()
    {
        enElSuelo = true;
    }

    
}
