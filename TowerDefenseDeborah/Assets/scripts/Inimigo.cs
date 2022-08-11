using UnityEngine;
using System.Collections;

public class Inimigo : MonoBehaviour
{

    public void RecebeDano(int pontosDeDano) {
        vida -= pontosDeDano;
        if (vida <= 0) {
        Destroy(this.gameObject);
        }
    }

    [SerializeField] private int vida;

    void Start ()
    {

        UnityEngine.AI.NavMeshAgent agente = GetComponent<UnityEngine.AI.NavMeshAgent>();
        GameObject fimDoCaminho = GameObject.Find ("fimDoCaminho");
        Vector3 posicaoDoFimDoCaminho = fimDoCaminho.transform.position;
        agente.SetDestination (posicaoDoFimDoCaminho);

    }

    void Update ()
    {

    }

}

