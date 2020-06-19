using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    public string cenaAlvo;
    public Transform pontoRetorno;

    public bool deveAtivarRetorno;
    public int id;

    static bool deveRetornar;
    static int idRetorno;

    Color transparente = new Color(0, 0, 0, 0);

    void Start() {
        Time.timeScale = 1;
        if (deveRetornar && id == idRetorno) {
            GameObject jogadorGbj = GameObject.FindWithTag("Player");
            Transform jogadorTr = jogadorGbj.GetComponent<Transform>();
            jogadorTr.position = pontoRetorno.position;
            jogadorTr.rotation = pontoRetorno.rotation;
        }
    }

    void OnTriggerEnter(Collider col) {
        if (col.tag == "Player") {
            Time.timeScale = 0;
            if (deveAtivarRetorno) {
                deveRetornar = true;
            }
            idRetorno = id;
            StartCoroutine(CarregarCena());
        }
    }

    IEnumerator CarregarCena() {
        Transicao transicao = FindObjectOfType<Transicao>();
        transicao.IniciarTransicao(transparente, Color.black);
        yield return new WaitUntil(() => transicao.acabou);
        SceneManager.LoadScene(cenaAlvo);
    }
}
