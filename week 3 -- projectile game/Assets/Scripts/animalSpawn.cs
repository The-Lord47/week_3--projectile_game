using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animalSpawn : MonoBehaviour
{
    public int xspawnRange;
    public int xspawnBoundary;
    public int zspawnRange;
    public int zspawnBoundary;
    public int spawnTime = 2;
    private float timer;
    public GameObject[] animals;
    public Transform projectileParent;

    private float xCoord;
    private float zCoord;

    private int animalSelection;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer > spawnTime)
        {
            xCoord = Random.Range(xspawnBoundary, xspawnBoundary + xspawnRange) * (Random.Range(0, 2) * 2 - 1);
            zCoord = Random.Range(zspawnBoundary, zspawnBoundary + zspawnRange) * (Random.Range(0, 2) * 2 - 1);

            animalSelection = Random.Range(0, 4);

            Instantiate(animals[animalSelection], new Vector3(xCoord, 0, zCoord), new Quaternion(0, 0, 0, 0), projectileParent); 

            timer = 0;
        }
        

        
    }
}
