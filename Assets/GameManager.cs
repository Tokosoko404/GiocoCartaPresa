
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Nemico nemico_script;
    [SerializeField] private Nemico nemico2_script;
    [SerializeField] private Nemico nemico3_script;
    public GameObject proiettileEcologicoPrefab;
    public GameObject proiettilePresaPrefab;
    public Transform transformDellaPistola;
    public float forzaDelRilascio;
    public EOggetto munizioniPresa;
    public EOggetto munizioniEco;
    public GameObject barraSalute;
    public GameObject personaggio;
    public GameObject cessoSanoPrefab;
    public GameObject fuocoArtificioPrefab;
    public MuroInvisibile muroInvisibile;
    public MuroInvisibile muroInvisibile2;
    public int nemiciUccisi;
    public bool bossMorto = false;
    public AudioClip suonoCartaPresa;
    public AudioClip suonoCartaEco;
    public AudioClip bossTheme;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            SceneManager.LoadScene(0);
        }
        if(nemiciUccisi == 3)
        {
            muroInvisibile.gameObject.SetActive(false);
            muroInvisibile2.gameObject.SetActive(false);
        }
        if (bossMorto == true)
        {
            nemico_script.Invoke("Victory", 3f);
        }

    }
}
