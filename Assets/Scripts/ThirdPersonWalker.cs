using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonWalker : MonoBehaviour
{
    public float velocidadeMov;
    public float deslocamentoAltura;
    public LayerMask camadaChao;
    public Animator anim;

    Transform tr;
    Rigidbody rb;
    Transform trCam;

    void Awake() {
        tr = GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
        trCam = GameObject.FindWithTag("Tripe").GetComponent<Transform>();
    }

    void FixedUpdate() {
        // receber dados de entrada do jogador
        float movH = Input.GetAxis("Horizontal");
        float movV = Input.GetAxis("Vertical");

        Vector3 mov = new Vector3(movH, 0, movV);

        // rotacionar o jogador na direção do movimento
        tr.LookAt(tr.position + trCam.TransformDirection(mov) * 5);

        if (mov.magnitude > 1f)
            mov.Normalize();

        // andança do jogador
        tr.Translate(0, 0, mov.magnitude * velocidadeMov * Time.deltaTime);

        // alimentando parâemtro anim
        anim.SetFloat("velocidade", mov.magnitude);

        // acompanhar chão
        RaycastHit hit;
        bool rcBateuNoChao = Physics.Raycast(
            tr.position,
            Vector3.down,
            out hit,
            Mathf.Infinity,
            camadaChao
        );

        if (rcBateuNoChao) {
            Vector3 pos = tr.position;
            pos.y = hit.point.y + deslocamentoAltura;
            tr.position = pos;
        }

        // zerar inercia
        rb.velocity = Vector3.zero;
    }
}
