using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vida : MonoBehaviour
{
    public float vida;
    public SistemaSom.EfeitoSonoro efeitoSonoroDano;

    SistemaSom sistemaDeSom;

    void Awake() {
        sistemaDeSom = GameObject.FindWithTag("MainCamera").GetComponent<SistemaSom>();
    }

    public void DiminuirVida(float dano) {
        vida = vida - dano;
        sistemaDeSom.Emitir(efeitoSonoroDano);
    }
}
