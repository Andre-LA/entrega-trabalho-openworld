using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject projetil;
    public Transform origemTiro;
    public float forcaTiro, intervalo;
    public bool automatico;

    float tempo1, tempo2;

    void Start() {
        tempo1 = Time.time;
        tempo2 = tempo1;
    }

    void Update() {
        tempo2 = Time.time;

        if (tempo2 - tempo1 <= intervalo) {
            return;
        }

        bool deveAtirar = false;

        if (automatico) {
            deveAtirar = Input.GetMouseButton(0);
        } else {
            deveAtirar = Input.GetMouseButtonDown(0);
        }

        if (deveAtirar) {
            tempo1 = tempo2;
            Atirar();
        }
    }

    void Atirar() {
        GameObject novoTiro = Instantiate<GameObject>(projetil, origemTiro.position, transform.rotation);
        Rigidbody novoTiro_rb = novoTiro.GetComponent<Rigidbody>();
        novoTiro_rb.AddForce(transform.forward * forcaTiro, ForceMode.Impulse);
    }
}
