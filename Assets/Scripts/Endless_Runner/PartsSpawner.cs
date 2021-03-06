using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartsSpawner: MonoBehaviour
{
    [SerializeField] GameObject[] prefabs;
    GameObject LastPart;
    private bool lock1=true;
    private int numberOfTiles = 15;
    private float Zspawn = 30f;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(prefabs[1],Vector3.zero,Quaternion.identity);
        LastPart = Instantiate(prefabs[0],new Vector3(0, 0,Zspawn),Quaternion.identity);
        numberOfTiles--;
        AudioManager.instance.StopAll();
        AudioManager.instance.Play("Endless_Runner");
        AudioManager.instance.Play("Beach");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(!LastPart) return;
        if(numberOfTiles <= 0 && lock1 && LastPart.transform.position.z <= 30f){
            lock1=false;
            SpawnePart(2);

        }
        if (LastPart.transform.position.z <= 30f && numberOfTiles > 0){
            SpawnePart(0);
        }
        if(!lock1 && LastPart.transform.position.z <= 0) LastPart.GetComponent<Part>().Speed = 0;
        
    }
    private void SpawnePart(int index){
        LastPart = Instantiate(prefabs[index],new Vector3(0, 0, Zspawn+30f),Quaternion.identity);
        numberOfTiles--;
    }
    
}
