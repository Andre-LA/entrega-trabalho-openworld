using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventosAnimacao : MonoBehaviour
{
    public IA ia;
    public ThirdPersonWalker trdPWalker;

    SistemaSom sistemaDeSom;

    void Awake() {
        sistemaDeSom = GameObject.FindWithTag("MainCamera").GetComponent<SistemaSom>();
    }

    public void AnimEvt_InimigoAtaque() {
        ia.Atacar();
    }

    public void AnimEvt_EfeitoSonoro_Passo() {
        sistemaDeSom.Emitir(SistemaSom.EfeitoSonoro.Passo);
    }

    public void AnimEvt_EfeitoSonoro_Golpe() {
        sistemaDeSom.Emitir(SistemaSom.EfeitoSonoro.Golpe);
    }
}
