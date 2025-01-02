using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Boss : MonoBehaviour
{
    [SerializeField] private GameManager gameManager_script;
    AudioSource audioSource;
    public int puntiVita;
    public NavMeshAgent navMeshAgent;
    public bool aggro;
    // Start is called before the first frame update
    void Start()
    {
        puntiVita = 12;
        navMeshAgent = gameObject.GetComponent<NavMeshAgent>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (aggro == true)
        {
            if (!audioSource.isPlaying) 
            { 
                audioSource.PlayOneShot(gameManager_script.bossTheme, 1); 
            }
            navMeshAgent.destination = gameManager_script.personaggio.transform.position;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject oggettoCheHoColpito = collision.gameObject;
        Personaggio personaggioCheHoColpito = oggettoCheHoColpito.GetComponent<Personaggio>();
        ProiettileEcologico proiettileEcologicoCheMiHaColpito = oggettoCheHoColpito.GetComponent<ProiettileEcologico>();
        ProiettilePresa proiettilePresaCheMiHaColpito = oggettoCheHoColpito.GetComponent<ProiettilePresa>();
        BarraSaluteBoss barraSaluteBoss = gameObject.GetComponentInChildren<BarraSaluteBoss>();
        Core12 core12 = barraSaluteBoss.gameObject.GetComponentInChildren<Core12>();
        Core11 core11 = barraSaluteBoss.gameObject.GetComponentInChildren<Core11>();
        Core10 core10 = barraSaluteBoss.gameObject.GetComponentInChildren<Core10>();
        Core9 core9 = barraSaluteBoss.gameObject.GetComponentInChildren<Core9>();
        Core8 core8 = barraSaluteBoss.gameObject.GetComponentInChildren<Core8>();
        Core7 core7 = barraSaluteBoss.gameObject.GetComponentInChildren<Core7>();
        Core6 core6 = barraSaluteBoss.gameObject.GetComponentInChildren<Core6>();
        Core5 core5 = barraSaluteBoss.gameObject.GetComponentInChildren<Core5>();
        Core4 core4 = barraSaluteBoss.gameObject.GetComponentInChildren<Core4>();
        Core3 core3 = barraSaluteBoss.gameObject.GetComponentInChildren<Core3>();
        Core2 core2 = barraSaluteBoss.gameObject.GetComponentInChildren<Core2>();
        Core1 core1 = barraSaluteBoss.gameObject.GetComponentInChildren<Core1>();
        if (personaggioCheHoColpito != null)
        {
            navMeshAgent.speed = 0;
            Invoke("Muovi", 1f);
        }
        if (proiettileEcologicoCheMiHaColpito != null)
        {
            puntiVita = puntiVita - 1;
            if (puntiVita == 11)
            {
                Destroy(core12.gameObject);
            }
            if (puntiVita == 10)
            {
                Destroy(core11.gameObject);
            }
            if (puntiVita == 9)
            {
                Destroy(core10.gameObject);
            }
            if (puntiVita == 8)
            {
                Destroy(core9.gameObject);
            }
            if (puntiVita == 7)
            {
                Destroy(core8.gameObject);
            }
            if (puntiVita == 6)
            {
                Destroy(core7.gameObject);
            }
            if (puntiVita == 5)
            {
                Destroy(core6.gameObject);
            }
            if (puntiVita == 4)
            {
                Destroy(core5.gameObject);
            }
            if (puntiVita == 3)
            {
                Destroy(core4.gameObject);
            }
            if (puntiVita == 2)
            {
                Destroy(core3.gameObject);
            }
            if (puntiVita == 1)
            {
                Destroy(core2.gameObject);
            }
        
        }
        if (proiettilePresaCheMiHaColpito != null)
        {
            puntiVita = puntiVita - 2;
            if (puntiVita == 10)
            {
                Destroy(core12.gameObject);
                Destroy(core11.gameObject);
            }
            if (puntiVita == 9)
            {
                Destroy(core11.gameObject);
                Destroy(core10.gameObject);
            }
            if (puntiVita == 8)
            {
                Destroy(core10.gameObject);
                Destroy(core9.gameObject);
            }
            if (puntiVita == 7)
            {
                Destroy(core9.gameObject);
                Destroy(core8.gameObject);
            }
            if (puntiVita == 6)
            {
                Destroy(core8.gameObject);
                Destroy(core7.gameObject);
            }
            if (puntiVita == 5)
            {
                Destroy(core7.gameObject);
                Destroy(core6.gameObject);
            }
            if (puntiVita == 4)
            {
                Destroy(core6.gameObject);
                Destroy(core5.gameObject);
            }
            if (puntiVita == 3)
            {
                Destroy(core5.gameObject);
                Destroy(core4.gameObject);
            }
            if (puntiVita == 2)
            {
                Destroy(core4.gameObject);
                Destroy(core3.gameObject);
            }
            if (puntiVita == 1)
            {
                Destroy(core3.gameObject);
                Destroy(core2.gameObject);
            }
            if (puntiVita == 10)
            {
                Destroy(core12.gameObject);
                Destroy(core11.gameObject);
            }
            Destroy(proiettilePresaCheMiHaColpito.gameObject);
            if (puntiVita <= 0)
            {
                if (core2 != null)
                {
                    Destroy(core2.gameObject);
                    Destroy(core1.gameObject);
                    gameObject.SetActive(false);
                    Invoke("SpawnFuocoArtificio", 0.01f);
                    gameManager_script.bossMorto = true;    
                }
                else
                {
                    Destroy(core1.gameObject);
                    gameObject.SetActive(false);
                    Invoke("SpawnFuocoArtificio", 0.01f);
                    gameManager_script.bossMorto = true;    
                }
            }
        }
    }

    public void SpawnFuocoArtificio()
    {
        GameObject fuocoArtificioPrefab = Instantiate(gameManager_script.fuocoArtificioPrefab);
        fuocoArtificioPrefab.transform.position = gameObject.transform.position;
    }
    public void Muovi() 
    {
        navMeshAgent.speed = 3.5f;

    }

}
