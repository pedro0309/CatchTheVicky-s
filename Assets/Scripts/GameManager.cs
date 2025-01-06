using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //Importar la libreria que permite el cambio de Scenes

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private GameObject gameOverPanel;
    [SerializeField]private bool isGameOver = false;

    void Awake()
    {
        instance = this;
        gameOverPanel = GameObject.Find("Game Over Panel");
        gameOverPanel.SetActive(false);
    }
    private void Start()
    {
        StartGame();
    }

    public void StartGame()
    {
        isGameOver = false;
        FishSpawner.instance.GetFishes();
        FishSpawner.instance.StartSpawnFishes();
        GameObject.Find("Player").GetComponent<PlayerController>().IsMoving = true; //Busca el GO "Player", y obtiene el Componente PlayerController (script) y toma del PlayerController, la propiedad IsMoving y la coloca en true. EMPIEZA A MOVER EL PLAYER EN POCAS PALABRAS
        LivesSpawner.instance.GetVickyGod();
        //MovingBackground.instance.MovingBackGround();
    }

    public void GameOver()
    {
        isGameOver = true;
        FishSpawner.instance.StopSpawnFishes();
        GameObject.Find("Player").GetComponent<PlayerController>().IsMoving = false; //Forzamos el isMoving del Player a false (LO DETENEMOS)
        gameOverPanel.SetActive(true);
        LivesSpawner.instance.StopSpawnVickysGods();
        Music1Controller.instance.StopMusic();
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }    

    public void LoadScene(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
    }
}
