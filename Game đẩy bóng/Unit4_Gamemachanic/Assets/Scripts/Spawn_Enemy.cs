using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Enemy : MonoBehaviour
{
    public GameObject enemyprefabs;
    public GameObject potionprefabs;
    private float spawnRange = 9;
    public int enemyCount;
    public int Wavenumber = 0;
    // Start is called before the first frame update
    void Start()
    {
        //Instantiate(potionprefabs, random_vectorsp(), potionprefabs.transform.rotation);
        //SpawnEnemyWave(Wavenumber);
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy_Script>().Length;
        if (enemyCount==0)
        {
            Wavenumber++;
            SpawnEnemyWave(Wavenumber);
            Instantiate(potionprefabs, random_vectorsp(), potionprefabs.transform.rotation);
        }   
    }
    private Vector3 random_vectorsp()
    {
        float spawnposX = Random.Range(-spawnRange, spawnRange);
        float spawnposZ = Random.Range(-spawnRange, spawnRange);
        Vector3 random_vector = new Vector3(spawnposX, 1, spawnposZ);
        return random_vector;
    }
    void SpawnEnemyWave(int numberenemy)
    {
        for (int i = 0; i < numberenemy; i++)
        {
            Instantiate(enemyprefabs, random_vectorsp(), enemyprefabs.transform.rotation);
        }
    }
}
