using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movetest : MonoBehaviour {
    private PlayerInputActionMap PlayerInputActionMap;
    void Start() {
        PlayerInputActionMap = new PlayerInputActionMap();
        PlayerInputActionMap.Enable();
    }
    
    void Update()
    {
        Debug.Log(PlayerInputActionMap.PlayerInputMap.PlayerMoveInput.ReadValue<Vector2>());
    }
}
