using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProiettilePresa : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Invoke("Distruggi", 5f);
    }

    public void Distruggi()
    {
        Destroy(gameObject); //Destroy(gameObject,5);
    }
}
