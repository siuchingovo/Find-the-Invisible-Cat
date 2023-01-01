using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnfindobject : MonoBehaviour
{

    public GameObject catspawn;
    public float distanceCatPlayer;
    public float chord_count;
    public bool found;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 randomSpawnPosition= new Vector3(Random.Range(-5,6),1/2,Random.Range(-3,7));
        Instantiate(catspawn,randomSpawnPosition,Quaternion.identity);
        found = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 randomSpawnPosition= new Vector3(Random.Range(-5,6), 1/2, Random.Range(-3,7));
        if(found == true)
        {
            Instantiate(catspawn,randomSpawnPosition,Quaternion.identity);
            found = !found;
        }
    }
}
