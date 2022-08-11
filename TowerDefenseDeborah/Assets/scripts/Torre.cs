using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torre : MonoBehaviour
{
    public GameObject prefabMissil;
    private float momentoDoUltimoDisparo;
    [SerializeField] private float raioDeAlcance;
    public float tempoDeRecarga = 1f;

    private bool EstaNoRaioDeAlcance(GameObject inimigo) {

        Vector3 posicaoDoInimigoNoPlano = Vector3.ProjectOnPlane(inimigo.transform.position, Vector3.up);
        Vector3 posicaoDaTorreNoPlano = Vector3.ProjectOnPlane(this.transform.position, Vector3.up);
        float distanciaParaInimigo = Vector3.Distance (posicaoDaTorreNoPlano, posicaoDoInimigoNoPlano);

        return distanciaParaInimigo <= raioDeAlcance;
    }

    private Inimigo EscolheAlvo(){

        GameObject[] inimigos = GameObject.FindGameObjectsWithTag("Inimigo");

        foreach (GameObject inimigo in inimigos) {
            if (EstaNoRaioDeAlcance(inimigo)){
                return inimigo.GetComponent<Inimigo>();
            }
        }

        return null;
    }



    private void Atira (Inimigo inimigo){
        float tempoAtual = Time.time;
        if (tempoAtual > momentoDoUltimoDisparo + tempoDeRecarga) {
            momentoDoUltimoDisparo = tempoAtual;

            GameObject pontoDeDisparo = this.transform.Find ("CanhaoDaTorre").gameObject;
            Vector3 posicaoDoPontoDeDisparo = pontoDeDisparo.transform.position;
            GameObject projetilObject = (GameObject) Instantiate (prefabMissil, posicaoDoPontoDeDisparo, Quaternion.identity);
            Missil missil = projetilObject.GetComponent<Missil>();
            missil.DefineAlvo(inimigo);
        }
    }

    void Update(){
        Inimigo alvo = EscolheAlvo ();
        if (alvo != null) {
            //É só passar o alvo para o método atira...
            Atira (alvo);
        }
    }
}
