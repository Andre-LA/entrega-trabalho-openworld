using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleguiado : MonoBehaviour
{
    public float intensidadePropulsao;

    Transform trPlayer;
    Vector3 posicaoAlvo;

    Rigidbody rb;

    void Start() {
        trPlayer = GameObject.FindWithTag("Player").GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
    }

    void Update() {
        RaycastHit hit;
        if (Physics.Raycast(trPlayer.position, trPlayer.forward, out hit, Mathf.Infinity)) {
            posicaoAlvo = hit.point;
        }

        if (posicaoAlvo.magnitude > 0.01f)
            transform.LookAt(posicaoAlvo);

        rb.AddForce(transform.forward * intensidadePropulsao, ForceMode.Force);
    }
}
