using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventosAnimacao : MonoBehaviour
{
    public IA ia;

    public void AnimEvt_InimigoAtaque() {
        ia.Atacar();
    }
}
