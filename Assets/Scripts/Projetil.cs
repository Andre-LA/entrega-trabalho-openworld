using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projetil : MonoBehaviour
{
    public bool destruirAoEncostar;
    public GameObject efeitoExplosao;
    public Transform trilha;

    void OnCollisionEnter(Collision col) {
        if (col.gameObject.tag == "Inimigo") {
            Vida vida = col.gameObject.GetComponent<Vida>();
            vida.DiminuirVida(200);
        }

        if (destruirAoEncostar) {
            GameObject explosaoGbj = Instantiate<GameObject>(efeitoExplosao, transform.position, Quaternion.identity);
            trilha.SetParent(explosaoGbj.transform);
            Destroy(gameObject);
        }
    }
}
