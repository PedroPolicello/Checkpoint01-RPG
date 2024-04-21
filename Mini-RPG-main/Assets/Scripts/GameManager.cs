using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public InputManager inputManager;

    private void Awake()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        if(Instance != null) Destroy(this.gameObject);
        
        Instance = this;
        inputManager = new InputManager();
    }
}
