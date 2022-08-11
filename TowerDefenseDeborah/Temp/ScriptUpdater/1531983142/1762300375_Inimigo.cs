using UnityEngine;
using System.Collections;

public class Inimigo : MonoBehaviour
{
 void Start ()
{
UnityEngine.AI.NavMeshAgent agente = GetComponent<UnityEngine.AI.NavMeshAgent>();
GameObject fimDoCaminho = GameObject.Find ("FimDoCaminho");
Vector3 posicaoDoFimDoCaminho = fimDoCaminho.transform.position;
agente.SetDestination (posicaoDoFimDoCaminho);

}

// Update is called once per frame
 void Update ()
{

}

}

