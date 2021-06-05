using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave
{
    public string waveName;
    public int NoOfEnemies;
    public GameObject[] typeOfEnemies;
    public float spawnInterval;

    public float timeBtwWave;

    public bool quarterBeatTiming;
    public bool halfBeatTiming;
    public bool threeFourBeatTiming;
    public bool fullBeatTiming;

    
}
public class Mapping : MonoBehaviour
{
    [Header("Mapping")]
    [SerializeField] Wave[] waves;
    private Wave currentWave;
}
