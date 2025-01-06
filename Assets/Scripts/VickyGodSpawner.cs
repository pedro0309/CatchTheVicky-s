using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class VickyGodSpawner : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            LivesManager.instance.AddLife();
        }

        if (collision.gameObject.tag == "FishDestroyer")
        {
            Destroy(gameObject);
        }
    }
}
