using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;



public class FallingTire : MonoBehaviour
{
    [SerializeField] GameObject tirePrefab;
    private float minX = -10, maxX = 10;
    private float timeMin = 2, timeMax = 7;
    
    // Start is called before the first frame update
    void Start()
    {
        Invoke("SpawnTires", Random.Range(timeMin, timeMax));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnTires()
    { 
        float randPosX = Random.Range(minX, maxX);
        tirePrefab = Instantiate(tirePrefab, new Vector2(randPosX, transform.position.y), Quaternion.identity);
   
        Destroy(tirePrefab, 15);
        Invoke("SpawnTires", Random.Range(timeMin, timeMax));
    
    }
}
