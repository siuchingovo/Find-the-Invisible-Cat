using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchCat : MonoBehaviour
{
    AudioSource audioSource;
    public MeshRenderer mesh; // GetComponent<MeshRenderer>();

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        Debug.Log("GetComponent<AudioSource>()");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision");
        if (collision.gameObject.name == "Player"){
            Debug.Log("Collision Player");
            audioSource.Play();
            mesh.enabled = true;
        }
            
    }
}
