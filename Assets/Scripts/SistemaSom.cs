using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SistemaSom : MonoBehaviour
{
    public enum EfeitoSonoro {
        Tic = 0,
        Golpe,
        Aaagh,
        Toc,
        Passo,
        InimigoAtingido,
        Pulo
    }

    public GameObject caixaSomPrefab;
    public AudioClip[] sons;

    public void Emitir(EfeitoSonoro efeito) {
        GameObject novaCaixa = Instantiate<GameObject>(caixaSomPrefab, transform.position, Quaternion.identity);
        CaixaDeSom novaCaixa_Comp = novaCaixa.GetComponent<CaixaDeSom>();

        int som_numero = (int)efeito;
        AudioClip somEfeitoSonoro = sons[som_numero];
        novaCaixa_Comp.clipeSom = somEfeitoSonoro;
    }
}
