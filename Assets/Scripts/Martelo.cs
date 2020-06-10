using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Martelo : MonoBehaviour
{
    public float dano;

    void OnTriggerEnter(Collider col) {
        if (col.gameObject.CompareTag("Inimigo")) {
            Vida vidaInimigo = col.gameObject.GetComponent<Vida>();
            vidaInimigo.vida = vidaInimigo.vida - dano;
        }
    }
}
