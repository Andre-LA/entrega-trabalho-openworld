using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MovimentacaoInimigo : MonoBehaviour
{
    public float distanciaMinima;
    NavMeshAgent agenteNM;

    void Awake() {
        agenteNM = GetComponent<NavMeshAgent>();
    }

    void Update() {
        Vector3 posicaoJogador = FirstPersonWalker.pontoChao;
        agenteNM.SetDestination(posicaoJogador);

        float distanciaEntreJogadorEInimigo = Vector3.Distance(transform.position, posicaoJogador);
        if (distanciaEntreJogadorEInimigo <= distanciaMinima) {
            agenteNM.isStopped = true;
        } else {
            agenteNM.isStopped = false;
        }
    }
}
