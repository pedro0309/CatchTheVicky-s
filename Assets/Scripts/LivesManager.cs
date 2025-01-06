using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI; //Tenemos que acceder al Componente de Imagen

public class LivesManager : MonoBehaviour
{
    public static LivesManager instance;
    public int liveCounter = 5;
    public TextMeshProUGUI livesTextUI;
    public Color orange = new Color(1.0f, 0.65f, 0.0f);

    void Awake()
    {
        instance = this;
        
    }
    private void Start()
    {
        livesTextUI = GameObject.Find("LivesTextUI").GetComponent<TextMeshProUGUI>();
        
    }

    public void RemoveLife()
    {
        if (liveCounter > 0)
        {
            liveCounter--;
            livesTextUI.text = liveCounter.ToString();
        }
        if (liveCounter <= 0)
        {
            GameManager.instance.GameOver();
        }
        print(liveCounter);
    }

    public void AddLife()
    {
        if (liveCounter > 0 && liveCounter < 5)
        {
            liveCounter++;
            livesTextUI.text = liveCounter.ToString();
        }
        print(liveCounter);

    }
    
    public void SetColorNumberLive()
    {
        if (liveCounter == 5)
            livesTextUI.color = Color.green;

        if (liveCounter == 4)
            livesTextUI.color = Color.green;

        if (liveCounter == 3)
            livesTextUI.color = Color.yellow;

        if (liveCounter == 2)
            livesTextUI.color = orange;

        if (liveCounter == 1)
            livesTextUI.color = Color.red;
    }
}
