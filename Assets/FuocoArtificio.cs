using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuocoArtificio : MonoBehaviour
{
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(audioSource.clip, 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
