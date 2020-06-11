using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaixaDeSom : MonoBehaviour
{
    public AudioClip clipeSom;
    AudioSource audioSrc;

    void Awake() {
        audioSrc = GetComponent<AudioSource>();
    }

    void Start() {
        audioSrc.clip = clipeSom;
        audioSrc.Play();
        Destroy(gameObject, clipeSom.length);
    }
}
