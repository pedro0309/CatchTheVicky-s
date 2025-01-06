
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityRandom = UnityEngine.Random;

public class FishSpawner : MonoBehaviour
{
    public static FishSpawner instance;
    private GameObject[] prefabFishes; //Array donde se almaceraran los fishes encontrados
    private Transform myTransform;
    private int randomFish;
    private float randomFishXPosition;
    [SerializeField]private float _delaySpawnFishTime;
    public float DelaySpawnFishTime { get => _delaySpawnFishTime; set => _delaySpawnFishTime = value; }

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        myTransform = GetComponent<Transform>();
    }

    public void GetFishes()
    {
        prefabFishes = GameObject.FindGameObjectsWithTag("Fish");
        foreach (var item in prefabFishes)
        {
            item.SetActive(false);
            item.transform.parent = myTransform; //Hace hijo a cada item encontrado (fish), de myTransform
        }
    }

    private void SpawnFish()
    {
        randomFish = UnityRandom.Range(0, prefabFishes.Length);
        randomFishXPosition = Random.value * 0.8f + 0.1f; //Se crea un valor entre 0.1 y 0.9 (para evitar los peces pegados al borde de la pantalla) y se asigna a randomFishXPosition
        GameObject tempFishPrefab = Instantiate(prefabFishes[randomFish],
                                                            new Vector3 (Camera.main.ViewportToWorldPoint(new Vector3(randomFishXPosition, 0, 0)).x,
                                                                         Camera.main.ViewportToWorldPoint(Vector3.one).y + 2f ,0),
                                                                         Quaternion.identity);
        tempFishPrefab.SetActive(true);
    }
    
    IEnumerator SpawnFishes()
    {
        yield return new WaitForSeconds(2f);
        while (true)
        {
            SpawnFish();
            yield return new WaitForSeconds(DelaySpawnFishTime);
        }
    }

    public void StartSpawnFishes()
    {
        StartCoroutine("SpawnFishes");
    }

    public void StopSpawnFishes()
    {
        StopCoroutine("SpawnFishes");
    }
}
