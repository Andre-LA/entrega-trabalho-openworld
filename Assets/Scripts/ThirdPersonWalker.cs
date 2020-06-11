using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonWalker : MonoBehaviour
{
    public float velocidadeMov;
    public float deslocamentoAltura;
    public float intensidadePulo;
    public LayerMask camadaChao;
    public Animator anim;

    public GameObject projetilMagia;
    public Transform pontoTiro;
    public float forcaLancamentoMagia;

    public CapsuleCollider colisorMartelo;
    public TrailRenderer trilhaMartelo;

    Transform tr;
    Rigidbody rb;
    Transform trCam;

    public bool estaNoChao;
    public bool estaEmPulo;
    public bool estaEmMovimento;

    public bool magiaUsada;

    SistemaSom sistemaDeSom;

    public static Vector3 pontoChao;

    void Awake() {
        tr = GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
        trCam = GameObject.FindWithTag("Tripe").GetComponent<Transform>();
        sistemaDeSom = GameObject.FindWithTag("MainCamera").GetComponent<SistemaSom>();

        colisorMartelo.enabled = false;
    }

    void FixedUpdate() {
        // receber dados de entrada do jogador
        bool apertouPulo = Input.GetButtonDown("Jump");
        bool apertouAtaque = Input.GetButtonDown("Fire1");
        bool apertouMagia = Input.GetButtonDown("Fire2");

        float movH = Input.GetAxis("Horizontal");
        float movV = Input.GetAxis("Vertical");

        Vector3 mov = new Vector3(movH, 0, movV);
        if (mov.magnitude > 1f)
            mov.Normalize();

        // detecta estados
        RaycastHit chaoHit;
        estaNoChao = Physics.Raycast(
            tr.position,
            Vector3.down,
            out chaoHit,
            deslocamentoAltura + 0.05f,
            camadaChao
        );

        estaEmPulo = apertouPulo || !estaNoChao;
        estaEmMovimento = mov.magnitude > 0.1f;

        // ataque
        if (apertouAtaque && !estaEmPulo && !colisorMartelo.enabled) {
            anim.SetTrigger("atacou");
            colisorMartelo.enabled = true;
            trilhaMartelo.enabled = true;
            Invoke("DesativarMartelo", 0.2f);
        }

        // magia
        if (apertouMagia && !estaEmPulo && !colisorMartelo.enabled && !magiaUsada) {
            anim.SetTrigger("magia");
            magiaUsada = true;
            Invoke("DesativaMagia", 0.2f);

            GameObject magiaGbj = Instantiate<GameObject>(projetilMagia, pontoTiro.position, pontoTiro.rotation);
            Rigidbody magiaRb = magiaGbj.GetComponent<Rigidbody>();
            magiaRb.AddForce(magiaGbj.transform.forward * forcaLancamentoMagia, ForceMode.Impulse);
        }

        // pulo
        rb.useGravity = estaEmPulo;
        rb.constraints = (
            RigidbodyConstraints.FreezeRotationX |
            RigidbodyConstraints.FreezeRotationY |
            RigidbodyConstraints.FreezeRotationZ
        );
        if (!estaEmPulo)
            rb.constraints = rb.constraints | RigidbodyConstraints.FreezePositionY;

        if (apertouPulo && estaNoChao) {
            rb.AddForce(Vector3.up * intensidadePulo, ForceMode.Impulse);
            sistemaDeSom.Emitir(SistemaSom.EfeitoSonoro.Pulo);
        }

        // rotacionar o jogador na direção do movimento
        if (estaEmMovimento)
            tr.LookAt(tr.position + trCam.TransformDirection(mov) * 5);

        // andança do jogador
        if (estaEmMovimento)
            tr.Translate(0, 0, mov.magnitude * velocidadeMov * Time.deltaTime);

        // alimentando parâmetros anim
        anim.SetFloat("velocidade", mov.magnitude);
        anim.SetBool("estaNoChao", estaNoChao);

        // acompanhar chão
        if (!estaEmPulo) {
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

                pontoChao = hit.point;
            }

            // zerar inercia
            rb.velocity = Vector3.zero;
        }
    }

    void DesativarMartelo() {
        colisorMartelo.enabled = false;
        trilhaMartelo.enabled = false;
    }

    void DesativaMagia() {
        magiaUsada = false;
    }
}
