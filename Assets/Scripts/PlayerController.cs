using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Variables para Control del Jugador
    public bool IsMoving { get => _isMoving; set => _isMoving = value; }
    private bool _isMoving;
    public float moveSpeed { get => _moveSpeed; set => _moveSpeed = value; }
    private float _moveSpeed = 10;
    private Transform myTransform;

    //Variables para Control de Cámara
    private float leftViewportLimit;
    private float rightViewportLimit;
    private float playerOffset = 2f;
    public static PlayerController instance;
    void Start()
    {
        instance = this;
        myTransform = GetComponent<Transform>(); //Creamos myTransform para que Unity no esté calculando cada vez que SetMovement sea llamado para obtener su posicion, si no desde el inicio almacenarlo y ahorrarnos llamadas de transform.position
        leftViewportLimit = Camera.main.ViewportToWorldPoint(Vector3.zero).x + playerOffset;//Asignamos en leftViewportLimit la posición del Mundo con respecto al Viewport. (0 en X es el limite Izquierdo)
                                                                                            //Le restamos el margen del Player con el playerOffset para que ejecute el limite correctamente dandole espacio al Player

        rightViewportLimit = Camera.main.ViewportToWorldPoint(Vector3.right).x - playerOffset; //Asignamos en rightViewportLimit el limite en X (1 en X del limite Derecho)

        //Con left y right ViewportLimit ya tenemos los Limites de ambos lados, falta aplicarlos
    }

    void Update()
    {
        if (_isMoving) //Si es True, ejecutará lo siguiente
        {
            SetMovement();
        }
        //Aplicar limites left y right de ViewportLimit
        if (myTransform.position.x > rightViewportLimit)
            SetLimitPlayerPosition(rightViewportLimit);
        if (myTransform.position.x < leftViewportLimit)
            SetLimitPlayerPosition(leftViewportLimit);
    }

    private void SetLimitPlayerPosition(float limit)
    {
        myTransform.position = new Vector3(limit, transform.position.y, 0);
    }

    private void SetMovement()
    {
        float inputX = Input.GetAxis("Horizontal");
        myTransform.position += Vector3.right * (inputX * _moveSpeed * Time.deltaTime);
    }
}
