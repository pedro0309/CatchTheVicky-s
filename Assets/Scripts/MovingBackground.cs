using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RandomUnity = UnityEngine.Random;

public class MovingBackground : MonoBehaviour
{
    public static MovingBackground instance;
    private GameObject cloudWhite1, cloudWhite2, cloudBlue1, cloudBlue2;
    private GameObject waveFront, waveMiddle, waveBack;
    private Vector2 initialPosition1, initialPosition2;
    private Vector2 initialWavePosition1, initialWavePosition2, initialWavePosition3;
    private Vector2 targetPosition1, targetPosition2;
    private Vector2 targetWavePosition1, targetWavePosition2, targetWavePosition3;
    private float speed1 = 0.05f, speed2 = 0.07f;
    private float speedWave1 = 1.0f, speedWave2 = 0.7f, speedWave3 = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        cloudWhite1 = GameObject.Find("CloudWhite1");
        cloudWhite2 = GameObject.Find("CloudWhite2");
        cloudBlue1 = GameObject.Find("CloudBlue1");
        cloudBlue2 = GameObject.Find("CloudBlue2");
        waveBack = GameObject.Find("WaveBack");
        waveMiddle = GameObject.Find("WaveMiddle");
        waveFront = GameObject.Find("WaveFront");
        InitializePositionsAndSpeed();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 posCloudWhite1 = cloudWhite1.transform.position;
        Vector3 posCloudWhite2 = cloudWhite2.transform.position;
        Vector3 posCloudBlue1 = cloudBlue1.transform.position;
        Vector3 posCloudBlue2 = cloudBlue2.transform.position;
        Vector3 posWaveBack = waveBack.transform.position;
        Vector3 poswaveMiddle = waveMiddle.transform.position;
        Vector3 poswaveFront = waveFront.transform.position;
        MovingBackGround();
    }

    private void InitializePositionsAndSpeed()
    {
        //speed = RandomUnity.Range(0.5f, 3f);
        initialPosition1 = new Vector2(-20f, 3);
        targetPosition1 = new Vector2(16, 3);
        initialPosition2 = new Vector2(-6f, 2.5f);
        targetPosition2 = new Vector2(30f, 2.7f);

        initialWavePosition1 = new Vector2(-1.33f, -4.1f);
        initialWavePosition2 = new Vector2(-1.72f, -4.26f);
        initialWavePosition3 = new Vector2(-1.3f, -4.47f);

        targetWavePosition1 = new Vector2(0.37f, -4.1f);
        targetWavePosition2 = new Vector2(-0.01f, -4.26f);
        targetWavePosition3 = new Vector2(0.37f, -4.47f);
    }

    public void MovingBackGround()
    {
            cloudWhite1.transform.position = Vector2.MoveTowards(cloudWhite1.transform.position, targetPosition1, (speed1 * Time.deltaTime));
            
            cloudWhite2.transform.position = Vector2.MoveTowards(cloudWhite2.transform.position, targetPosition2, (speed2 * Time.deltaTime));

            cloudBlue1.transform.position = Vector2.MoveTowards(cloudBlue1.transform.position, targetPosition1, (speed1 * Time.deltaTime));

            cloudBlue2.transform.position = Vector2.MoveTowards(cloudBlue2.transform.position, targetPosition2, (speed2 * Time.deltaTime));

            waveBack.transform.position = Vector2.MoveTowards(waveBack.transform.position, targetWavePosition1, (speedWave1 * Time.deltaTime));

            waveMiddle.transform.position = Vector2.MoveTowards(waveMiddle.transform.position, targetWavePosition2, (speedWave2 * Time.deltaTime));

            waveFront.transform.position = Vector2.MoveTowards(waveFront.transform.position, targetWavePosition3, (speedWave3 * Time.deltaTime));
            
            
            if ((Vector2)cloudWhite1.transform.position == targetPosition1)
            {
                cloudWhite1.transform.position = initialPosition1;
            }

            if ((Vector2)cloudWhite2.transform.position == targetPosition2)
            {
                cloudWhite2.transform.position = initialPosition2;
            }

            if ((Vector2)cloudWhite1.transform.position == targetPosition1)
            {
                cloudBlue1.transform.position = initialPosition1;
            }

            if ((Vector2)cloudWhite2.transform.position == targetPosition2)
            {
                cloudBlue2.transform.position = initialPosition2;
            }

            if ((Vector2)waveBack.transform.position == targetWavePosition1)
            {
                waveBack.transform.position = initialWavePosition1;
            }

            if ((Vector2)waveMiddle.transform.position == targetWavePosition2)
            {
                waveMiddle.transform.position = initialWavePosition2;
            }

            if ((Vector2)waveFront.transform.position == targetWavePosition3)
            {
                waveFront.transform.position = initialWavePosition3;
            }
    }
}
