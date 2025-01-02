using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AggroRangeBoss : MonoBehaviour
{
    [SerializeField] private Boss boss_script;
    // Start is called before the first frame update
    void Start()
    {

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
            boss_script.aggro = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        GameObject oggettoUscito = other.gameObject;
        Personaggio personaggioUscito = oggettoUscito.GetComponent<Personaggio>();
        if (personaggioUscito)
        {
            boss_script.aggro = false;

        }
    }
}