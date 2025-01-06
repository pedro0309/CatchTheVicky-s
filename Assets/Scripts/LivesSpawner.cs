using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityRandom = UnityEngine.Random;

public class LivesSpawner : MonoBehaviour
{
    public static LivesSpawner instance;
    [SerializeField]private GameObject vickyGod;
    private float randomVickyXPosition;
    private float delaySpawnVickyGodTime;
    private Transform myTransform;
    private Coroutine spawnCoroutine;
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        myTransform = GetComponent<Transform>();
    }

    public void GetVickyGod()
    {
        //vickyGod = GetComponent<GameObject>();
        vickyGod.SetActive(false);
        vickyGod.transform.parent = myTransform;
    }

    public void SpawnVickyGod()
    {
        randomVickyXPosition = Random.value * 0.8f + 0.1f; //Se crea un valor entre 0.1 y 0.9 (para evitar VickysGods pegados al borde de la pantalla) y se asigna a randomVickyXPosition
        GameObject tempVickyPrefab = Instantiate(vickyGod, new Vector3(Camera.main.ViewportToWorldPoint(new Vector3(randomVickyXPosition, 0, 0)).x,
                                                                         Camera.main.ViewportToWorldPoint(Vector3.one).y + 2f, 0),
                                                                         Quaternion.identity);
        tempVickyPrefab.SetActive(true);
    }

    IEnumerator SpawnVickysGods()
    {
        yield return new WaitForSeconds(2f);
        while (true)
        {
            SpawnVickyGod();
            yield return new WaitForSeconds(5.5f);
        }
    }

    public void StartSpawnVickysGods()
    {
        if (spawnCoroutine != null)
        {
            StopCoroutine(spawnCoroutine);
        }
        spawnCoroutine = StartCoroutine("SpawnVickysGods");
    }
    public void StopSpawnVickysGods()
    {
        if (spawnCoroutine != null)
        {
            StopCoroutine(spawnCoroutine);
            spawnCoroutine = null;
        }
    }
}
