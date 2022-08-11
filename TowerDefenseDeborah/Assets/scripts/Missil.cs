using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missil : MonoBehaviour
{

    [SerializeField] private int pontosDeDano;
    public float velocidade = 10;
    private Inimigo alvo;
    

    void Start()
    {
        AutoDestroiDepoisDeSegundos (10);
    }

    public void DefineAlvo(Inimigo inimigo) {
        alvo = inimigo;
    }

    private void AutoDestroiDepoisDeSegundos(float segundos) {
        Destroy (this.gameObject, segundos);
    }

     private void AlteraDirecao(){
        Vector3 direcaoDoMissil = transform.position;
        Vector3 direcaoDoInimigo = alvo.transform.position;
        Vector3 novaDirecao = direcaoDoInimigo - direcaoDoMissil;
        transform.rotation = Quaternion.LookRotation (novaDirecao);
    }


    void OnTriggerEnter (Collider elementoColidido) {
        if (elementoColidido.CompareTag ("Inimigo")) {
            Destroy (this.gameObject);
            Inimigo inimigo = elementoColidido.GetComponent<Inimigo>();
            inimigo.RecebeDano(pontosDeDano);
        }
    }

    private void Anda(){
        Vector3 posicaoAtual = transform.position;
        Vector3 frente = transform.forward;
        Vector3 deslocamento = frente * velocidade * Time.deltaTime;
        transform.position = posicaoAtual + deslocamento;
    }

    


    void Update()
    {
        Anda();
        if (alvo != null) {
        AlteraDirecao ();
        }
    }
}
