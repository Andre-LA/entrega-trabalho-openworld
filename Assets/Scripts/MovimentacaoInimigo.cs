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
        Vector3 posicaoJogador = ThirdPersonWalker.pontoChao;

        Vector3 posicaoPraOlhar = new Vector3(
            posicaoJogador.x,
            transform.position.y,
            posicaoJogador.z
        );
        transform.LookAt(posicaoPraOlhar);

        agenteNM.SetDestination(posicaoJogador);

        float distanciaEntreJogadorEInimigo = Vector3.Distance(transform.position, posicaoJogador);
        if (distanciaEntreJogadorEInimigo <= distanciaMinima) {
            agenteNM.isStopped = true;
        } else {
            agenteNM.isStopped = false;
        }
    }
}
