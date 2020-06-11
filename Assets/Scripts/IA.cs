using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IA : MonoBehaviour
{
    public enum EstadoIA {
        Atacando,
        Andando,
    }

    public EstadoIA estado;
    public float dano;
    public Animator controladorAnimacao;

    NavMeshAgent agenteNM;
    Vida vida;
    Vida vidaJogador;

    SistemaSom sistemaDeSom;

    void Awake() {
        agenteNM = GetComponent<NavMeshAgent>();
        vida = GetComponent<Vida>();
        vidaJogador = GameObject.FindWithTag("Player").GetComponent<Vida>();
        sistemaDeSom = GameObject.FindWithTag("MainCamera").GetComponent<SistemaSom>();
    }

    void Update() {
        if (agenteNM.isStopped) {
            estado = EstadoIA.Atacando;
        } else {
            estado = EstadoIA.Andando;
        }

        controladorAnimacao.SetFloat("velocidade", agenteNM.velocity.magnitude);

        if (vida.vida <= 0) {
            Destroy(gameObject);
        }
    }

    public void Atacar() {
        vidaJogador.DiminuirVida(dano);
        sistemaDeSom.Emitir(SistemaSom.EfeitoSonoro.Golpe);
    }
}
