using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public static LevelController instance;
    private int levelScore, level;
    public float newMoveSpeed;
    private TextMeshProUGUI levelTextUI, notice;
    Color orange = new Color(1.0f, 0.65f, 0.0f);
    private int temp;

    private void Awake()
    {
        levelTextUI = GameObject.Find("LevelTextUI").GetComponent<TextMeshProUGUI>();
    }
    // Start is called before the first frame update
    void Start()
    {
        notice = GameObject.Find("ScoreTextPointsUI").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckScoreAndUpdateLevel();
    }

    private void CheckScoreAndUpdateLevel()
    {
        levelScore = ScoreManager.instance.score;
        LivesManager.instance.SetColorNumberLive();

        if (levelScore >= 0 && levelScore <= 4) //Level 1
        {
            FishSpawner.instance.DelaySpawnFishTime = 3.7f;
            levelTextUI.text = "Level 1";
            levelTextUI.color = Color.green;
            PlayerController.instance.moveSpeed = 10f;
            print("moveSpeed: " + PlayerController.instance.moveSpeed);
            print("Live Counter" + LivesManager.instance.liveCounter);
        }
        else if (levelScore >= 5 && levelScore <= 9) //Level 2
        {
            FishSpawner.instance.DelaySpawnFishTime = 3.1f;
            levelTextUI.text = "Level 2";
            PlayerController.instance.moveSpeed = 12f;
            print("moveSpeed: " + PlayerController.instance.moveSpeed);
            print("Live Counter" + LivesManager.instance.liveCounter);
        }
        else if (levelScore >= 10 && levelScore <= 14) //Level 3
        {
            FishSpawner.instance.DelaySpawnFishTime = 2.55f;
            levelTextUI.text = "Level 3";
            PlayerController.instance.moveSpeed = 14f;
            print("Live Counter" + LivesManager.instance.liveCounter);
            print("moveSpeed: " + PlayerController.instance.moveSpeed);

            if (levelScore == 12)
            {
                notice.text = "VAS MUY BIEN!";
                StartCoroutine(HideNoticeAfterDelay());
            }
        }
        else if (levelScore >= 15 && levelScore <= 20) //Level 4
        {
            FishSpawner.instance.DelaySpawnFishTime = 2.2f;
            levelTextUI.text = "Level 4";
            levelTextUI.color = Color.yellow;
            PlayerController.instance.moveSpeed = 16f;
            print("Live Counter" + LivesManager.instance.liveCounter);
            print("moveSpeed: " + PlayerController.instance.moveSpeed);
        }
        else if (levelScore >= 21 && levelScore <= 27) //Level 5
        {
            FishSpawner.instance.DelaySpawnFishTime = 1.95f;
            levelTextUI.text = "Level 5";
            levelTextUI.color = Color.yellow;
            PlayerController.instance.moveSpeed = 18f;
            print("Live Counter" + LivesManager.instance.liveCounter);
            print("moveSpeed: " + PlayerController.instance.moveSpeed);
        }
        else if (levelScore >= 28 && levelScore <= 35) //Level 6
        {
            FishSpawner.instance.DelaySpawnFishTime = 1.65f;
            levelTextUI.text = "Level 6";
            levelTextUI.color = Color.yellow;
            PlayerController.instance.moveSpeed = 20f;
            LivesSpawner.instance.StartSpawnVickysGods();
            print("Live Counter" + LivesManager.instance.liveCounter);
            print("moveSpeed: " + PlayerController.instance.moveSpeed);
            if (levelScore == 32)
            {
                notice.text = "TU PUEDES!";
                StartCoroutine(HideNoticeAfterDelay());
            }
        }
        else if (levelScore >= 36 && levelScore <= 40) //Level 7
        {
            FishSpawner.instance.DelaySpawnFishTime = 1.34f;
            levelTextUI.text = "Level 7";
            levelTextUI.color = orange;
            PlayerController.instance.moveSpeed = 22f;
            print("Live Counter" + LivesManager.instance.liveCounter);
            print("moveSpeed: " + PlayerController.instance.moveSpeed);
        }
        else if (levelScore >= 41 && levelScore <= 45) //Level 8
        {
            FishSpawner.instance.DelaySpawnFishTime = 1.1f;
            levelTextUI.text = "Level 8";
            PlayerController.instance.moveSpeed = 24f;
            print("Live Counter" + LivesManager.instance.liveCounter);
            print("moveSpeed: " + PlayerController.instance.moveSpeed);
        }
        else if (levelScore >= 46 && levelScore <= 50) //Level 9
        {
            FishSpawner.instance.DelaySpawnFishTime = 0.9f;
            levelTextUI.text = "Level 9";
            PlayerController.instance.moveSpeed = 26.5f;
            LivesSpawner.instance.StartSpawnVickysGods();
            print("Live Counter" + LivesManager.instance.liveCounter);
            print("moveSpeed: " + PlayerController.instance.moveSpeed);
        }
        else if (levelScore >= 51 && levelScore <= 55) //Level 10
        {
            FishSpawner.instance.DelaySpawnFishTime = 0.7f;
            levelTextUI.color = Color.red;
            levelTextUI.text = "Level 10";
            PlayerController.instance.moveSpeed = 28.5f;
            LivesSpawner.instance.StartSpawnVickysGods();
            print("Live Counter" + LivesManager.instance.liveCounter);
            print("moveSpeed: " + PlayerController.instance.moveSpeed);
        }
        else if (levelScore >= 56 && levelScore <= 60) //Level 10
        {
            FishSpawner.instance.DelaySpawnFishTime = 0.7f;
            levelTextUI.color = Color.red;
            levelTextUI.text = "Level 11";
            PlayerController.instance.moveSpeed = 28.5f;
            LivesSpawner.instance.StartSpawnVickysGods();
            print("Live Counter" + LivesManager.instance.liveCounter);
        }

    }
    private IEnumerator HideNoticeAfterDelay()
    {
        yield return new WaitForSeconds(1.8f);
        notice.text = ""; // O el valor que quieras para ocultar el mensaje
    }
}
