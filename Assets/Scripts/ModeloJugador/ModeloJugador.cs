using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeloJugador : MonoBehaviour
{
    public Rigidbody rb;
    public float velocidadMov;
    public float rotacionX;
    public float rotacionY;
    public float rotacionZ;
    public float velocidadRotacion;
    public float salto = 0.4f;
    public float empujeSalto = 10;
    public bool enElSuelo;
    void Start()
    {
        enElSuelo = true;
    }

    
}
