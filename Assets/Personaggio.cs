using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Runtime.CompilerServices;

public enum EOggetto
{
    MunizioniEco,
    MunizioniPresa
}
public class Personaggio : MonoBehaviour
{
    [SerializeField] private GameManager gameManager_script;
    public List<EOggetto> munizioni;
    public int puntiVita;
    // Start is called before the first frame update
    void Start()
    {
        puntiVita = 30;
    }

    // Update is called once per frame
    void Update()
    {
        if(munizioni.Contains(EOggetto.MunizioniEco))
        {
            if (Input.GetMouseButtonDown(0))
            {
                GameObject proiettileEcologicoIstanziato = Instantiate(gameManager_script.proiettileEcologicoPrefab);
                proiettileEcologicoIstanziato.transform.position = gameManager_script.transformDellaPistola.position + gameManager_script.transformDellaPistola.forward;
                Rigidbody rigidbodyDelProiettileEcologicoIstanziato = proiettileEcologicoIstanziato.GetComponent<Rigidbody>();
                rigidbodyDelProiettileEcologicoIstanziato.AddForce(gameManager_script.transformDellaPistola.forward * gameManager_script.forzaDelRilascio);
            }
        }

        if (munizioni.Contains(EOggetto.MunizioniPresa))
        {
            if (Input.GetMouseButtonDown(0))
            {
                GameObject proiettilePresaIstanziato = Instantiate(gameManager_script.proiettilePresaPrefab);
                proiettilePresaIstanziato.transform.position = gameManager_script.transformDellaPistola.position + gameManager_script.transformDellaPistola.forward;
                Rigidbody rigidbodyDelProiettilePresaIstanziato = proiettilePresaIstanziato.GetComponent<Rigidbody>();
                rigidbodyDelProiettilePresaIstanziato.AddForce(gameManager_script.transformDellaPistola.forward * gameManager_script.forzaDelRilascio);
                
            }
        }

        if ( puntiVita<=0)
        {
            SceneManager.LoadScene(2);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject oggettoToccato = collision.gameObject;
        Nemico nemicoToccato = oggettoToccato.GetComponent<Nemico>();
        Boss bossToccato = oggettoToccato.GetComponent<Boss>();
        Vita vita = gameManager_script.barraSalute.GetComponentInChildren<Vita>();
        UnityEngine.UI.Image imageVita = vita.gameObject.GetComponent<UnityEngine.UI.Image>();
        if(nemicoToccato != null)
        {
            puntiVita = puntiVita - 10;
            imageVita.fillAmount = puntiVita/30f;
        }
        if (bossToccato != null)
        {
            puntiVita = puntiVita - 10;
            imageVita.fillAmount = puntiVita / 30f;
        }
    }





}
