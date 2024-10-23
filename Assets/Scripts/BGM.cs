using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] _clips;

    private void Start()
    {
       AudioSource aSource = GetComponent<AudioSource>();
        aSource.clip = _clips[Random.Range(0, 3)];
        aSource.Play();
    }
}
