using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Persecucion : MonoBehaviour
{
    public Transform objetivo;
    private NavMeshAgent agente;
    void Start()
    {
        agente = GetComponent<NavMeshAgent>();
    }

    
    void Update()
    {
        agente.destination = objetivo.position;
    }
}
