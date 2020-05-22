using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projetil : MonoBehaviour
{
    public bool destruirAoEncostar;
    public GameObject efeitoExplosao;

    void OnCollisionEnter(Collision col) {
        if (col.gameObject.tag == "Inimigo") {
            Vida vida = col.gameObject.GetComponent<Vida>();
            vida.vida = vida.vida - 200;
        }

        if (destruirAoEncostar) {
            Instantiate(efeitoExplosao, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
