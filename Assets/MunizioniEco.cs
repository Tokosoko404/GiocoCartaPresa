using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MunizioniEco : MonoBehaviour
{
    [SerializeField] private GameManager gameManager_script;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject oggettoEntrato = other.gameObject;
        Personaggio personaggioEntrato = oggettoEntrato.GetComponent<Personaggio>();
        if (personaggioEntrato != null)
        {
            audioSource.PlayOneShot(gameManager_script.suonoCartaEco, 1);
            if (personaggioEntrato.munizioni.Count == 0) 
            {
                personaggioEntrato.munizioni.Add(gameManager_script.munizioniEco);
            }
            if (personaggioEntrato.munizioni.Contains(EOggetto.MunizioniPresa)) 
            {
                personaggioEntrato.munizioni.Add(gameManager_script.munizioniEco);
                personaggioEntrato.munizioni.Remove(gameManager_script.munizioniPresa);
            }
            if (personaggioEntrato.munizioni.Contains(EOggetto.MunizioniEco))
            {
                personaggioEntrato.munizioni.Remove(gameManager_script.munizioniPresa);
            }

        }
    }
}
