using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendToggle : MonoBehaviour
{
    public LibPdInstance pdPatch;
    public LibPdInstance pdPatch_Spatial;
    public float chordfloat;
    public spawnfindobject manager;

    public GameObject player;
    public GameObject cat;
    public float distanceBetweenObjects;

    public void Start()
    {
        manager = GameObject.Find("animalmanager").GetComponent<spawnfindobject>();
        player =  GameObject.Find("Player");
        cat =  this.transform.gameObject;
    }

    void Update()
    {
        distanceBetweenObjects = Vector3.Distance(player.transform.position, cat.transform.position);
        manager.distanceCatPlayer = distanceBetweenObjects;
        manager.chord_count = chordfloat;
        // Debug.Log(distanceBetweenObjects.ToString("0.00"));

        // if (distanceBetweenObjects > 4.0f)
        // {
        //     pdPatch_Spatial.SendFloat("chordUnity", 0f);
        //     Debug.Log("maj");
        // }
        // else 
        // {
        //     pdPatch_Spatial.SendFloat("chordUnity", 1f);
        //     Debug.Log("min");
        // }

        if (distanceBetweenObjects > 2.0f)
        {
            chordfloat -= 0.01f;
            if (chordfloat < 0 )
            {
                chordfloat = 0f;
            }
            pdPatch_Spatial.SendFloat("chordUnity", chordfloat);
            Debug.Log("maj");
        }
        else 
        {   
            chordfloat += 0.01f;
            if (chordfloat > 1 )
            {
                chordfloat = 1f;
            }
            
            pdPatch_Spatial.SendFloat("chordUnity", chordfloat);
            Debug.Log("min");
        }

    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Debug.Log("Staying");
            if (Input.GetKeyDown(KeyCode.Space))
            {
                pdPatch.SendBang("triggerOn");
                Debug.Log("pressed Once");
                this.gameObject.GetComponentInChildren<SkinnedMeshRenderer>().enabled = true;
                Destroy(this.gameObject.transform.GetChild(2).gameObject);
                StartCoroutine(destroyCat());
            }
            
        }
    }

    /*void OnMouseDown()
    {
        
        pdPatch.SendBang("triggerOn");
        Debug.Log("pressed Once");
        Destroy(this.gameObject.GetComponentInChildren<SkinnedMeshRenderer>());
        StartCoroutine(destroyCat());

    }*/

    IEnumerator destroyCat()
    {
        yield return new WaitForSeconds(0.3f);
        manager.found = true;

        yield return new WaitForSeconds(6f);
        Destroy(this.gameObject);
    }
}
