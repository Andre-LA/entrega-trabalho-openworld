using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grude : MonoBehaviour
{
    void OnCollisionEnter(Collision col) {
        Destroy(GetComponent<Rigidbody>());
        transform.SetParent(col.transform);
        Destroy(GetComponent<Grude>());
    }
}
