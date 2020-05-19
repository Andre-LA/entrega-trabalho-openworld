using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projetil : MonoBehaviour
{
    public bool destruirAoEncostar;
    public GameObject efeitoExplosao;

    void OnCollisionEnter(Collision col) {
        if (destruirAoEncostar) {
            Instantiate(efeitoExplosao, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
