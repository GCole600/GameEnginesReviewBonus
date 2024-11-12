using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    private Invoker _invoker;
    private PlayerController _characterController;
    private ICommand _buttonA, _buttonD;

    void Start()
    {
        _invoker = gameObject.GetComponent<Invoker>();
        _characterController = FindObjectOfType<PlayerController>();
        _buttonA = new MoveLeft(_characterController);
        _buttonD = new MoveRight(_characterController);
    }
        
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
            _invoker.ExecuteCommand(_buttonA);

        if (Input.GetKey(KeyCode.D))
            _invoker.ExecuteCommand(_buttonD);
    }
}