using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageAirCraft : MonoBehaviour
{
    public GameObject[] spawnPoint;
    public float spawnRate=4;
    private float nextSpawn=0;
    public GameObject[] airCraftObject;
    public List<AirCraft> airCraft;
    public AirCraft currentAirCraft;
    private int indexAir = 0;
    public bool[] Lines;
    public float heightLines = 8;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time> nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            InisialAirCraft();
        }
    }
    public void InisialAirCraft()
    {
        int AirType = Random.Range(0, airCraftObject.Length);
        int Point = Random.Range(0, spawnPoint.Length);

        GameObject cloneAirCraft = Instantiate(airCraftObject[AirType], spawnPoint[Point].transform.position, spawnPoint[Point].transform.rotation);
        currentAirCraft = cloneAirCraft.GetComponent<AirCraft>();
        currentAirCraft.currentLine = 0;
        
        if (Point == 0)/// spawnpoint=leftpoint
        {
            currentAirCraft.direction = AirCraft.Direction.west;
        }
        if (Point == 1)///  spawnpoint=rightpoint
        {
            currentAirCraft.direction = AirCraft.Direction.east;
        }
        currentAirCraft.leftPoint = spawnPoint[0].transform;
        currentAirCraft.rightPoint = spawnPoint[1].transform;
        currentAirCraft.letMove = true;
        indexAir++;
    }
}
