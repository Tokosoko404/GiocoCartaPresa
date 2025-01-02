
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using static UnityEngine.GraphicsBuffer;
public class Nemico : MonoBehaviour
{
    [SerializeField] private GameManager gameManager_script;
    public int puntiVita;
    public NavMeshAgent navMeshAgent;
    public bool aggro;
    // Start is called before the first frame update
    void Start()
    {
        puntiVita = 6;
        navMeshAgent = gameObject.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if ( aggro == true)
        {
            navMeshAgent.destination = gameManager_script.personaggio.transform.position;
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject oggettoCheHoColpito = collision.gameObject;
        Personaggio personaggioCheHoColpito = oggettoCheHoColpito.GetComponent<Personaggio>();
        ProiettileEcologico proiettileEcologicoCheMiHaColpito = oggettoCheHoColpito.GetComponent<ProiettileEcologico>();
        ProiettilePresa proiettilePresaCheMiHaColpito = oggettoCheHoColpito.GetComponent<ProiettilePresa>();
        BarraSaluteNemico barraSaluteNemico = gameObject.GetComponentInChildren<BarraSaluteNemico>();
        Cuore6 cuore6 = barraSaluteNemico.gameObject.GetComponentInChildren<Cuore6>();
        Cuore5 cuore5 = barraSaluteNemico.gameObject.GetComponentInChildren<Cuore5>();
        Cuore4 cuore4 = barraSaluteNemico.gameObject.GetComponentInChildren<Cuore4>();
        Cuore3 cuore3 = barraSaluteNemico.gameObject.GetComponentInChildren<Cuore3>();
        Cuore2 cuore2 = barraSaluteNemico.gameObject.GetComponentInChildren<Cuore2>();
        Cuore1 cuore1 = barraSaluteNemico.gameObject.GetComponentInChildren<Cuore1>();
        if (personaggioCheHoColpito != null) 
        {
            navMeshAgent.speed = 0;
            Invoke("Muovi", 1f);
        }
        if (proiettileEcologicoCheMiHaColpito != null)
        {
            puntiVita = puntiVita - 1;
            if (puntiVita == 5)
            {
                Destroy(cuore6.gameObject);
            }
            if(puntiVita == 4)
            {
                Destroy(cuore5.gameObject);
            }
            if(puntiVita == 3)
            {
                Destroy(cuore4.gameObject);
            }
            if (puntiVita == 2)
            {
                Destroy(cuore3.gameObject);
            }
            if(puntiVita == 1)
            {
                Destroy(cuore2.gameObject);
            }
            Destroy(proiettileEcologicoCheMiHaColpito.gameObject);
            if (puntiVita <= 0)
            {
                Destroy(cuore1.gameObject);
                gameObject.SetActive(false);
                Invoke("SpawnFuocoArtificio", 0.01f);
                Invoke("SpawnCessoSano", 0.01f);
                gameManager_script.nemiciUccisi = gameManager_script.nemiciUccisi + 1;
            }
        }
        if (proiettilePresaCheMiHaColpito != null)
        {
            puntiVita = puntiVita - 2;
            if (puntiVita == 4)
            {
                Destroy(cuore6.gameObject);
                Destroy(cuore5.gameObject);
            }
            if (puntiVita == 3)
            {
                Destroy(cuore5.gameObject);
                Destroy(cuore4.gameObject);
            }
            if (puntiVita == 2)
            {
                Destroy(cuore4.gameObject);
                Destroy(cuore3.gameObject);
            }
            if (puntiVita == 1)
            {
                Destroy(cuore3.gameObject);
                Destroy(cuore2.gameObject);
            }
            Destroy(proiettilePresaCheMiHaColpito.gameObject);
            if (puntiVita <= 0)
            {
                if (cuore2 != null) 
                {
                    Destroy(cuore2.gameObject);
                    Destroy(cuore1.gameObject);
                    gameObject.SetActive(false);
                    Invoke("SpawnFuocoArtificio", 0.01f);
                    Invoke("SpawnCessoSano", 0.01f);
                    gameManager_script.nemiciUccisi = gameManager_script.nemiciUccisi + 1;
                }
                else
                {
                    Destroy(cuore1.gameObject);
                    gameObject.SetActive(false);
                    Invoke("SpawnFuocoArtificio", 0.01f);
                    Invoke("SpawnCessoSano", 0.01f);
                    gameManager_script.nemiciUccisi = gameManager_script.nemiciUccisi + 1;

                }
               
            }
        }

    }
    
    public void SpawnCessoSano()
    {
        GameObject cessoSanoIstanziato = Instantiate(gameManager_script.cessoSanoPrefab);
        cessoSanoIstanziato.transform.position = gameObject.transform.position;
        cessoSanoIstanziato.transform.rotation = gameObject.transform.rotation;
    }

    public void Victory()
    {
        SceneManager.LoadScene(3);
    }

    public void SpawnFuocoArtificio()
    {
        GameObject fuocoArtificioPrefab = Instantiate(gameManager_script.fuocoArtificioPrefab);
        fuocoArtificioPrefab.transform.position = gameObject.transform.position;
    }
    public void Muovi() 
    {
            navMeshAgent.speed= 3.5f;
    }
}
