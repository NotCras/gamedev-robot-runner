using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityStandardAssets.CrossPlatformInput;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] private float zoomedInFOV = 35f;
    [SerializeField] private float regularFOV = 60f;
    
    [SerializeField] private float zoomedInMouse = 0.5f;
    [SerializeField] private float regularMouse = 2f;
    
    //[SerializeField] 
    private Camera player;
    private RigidbodyFirstPersonController playerMouse;
    private bool zoomedInToggle = false;
    
    void Start()
    {
        player = FindObjectOfType<Camera>();
        playerMouse = GetComponentInParent<RigidbodyFirstPersonController>();

        SetDefaultZoom();
    }

    private void SetDefaultZoom()
    {
        player.fieldOfView = regularFOV;
        playerMouse.mouseLook.XSensitivity = regularMouse;
        playerMouse.mouseLook.YSensitivity = regularMouse;
    }
    
    void Update()
    {
        if (CrossPlatformInputManager.GetButtonDown("Fire3"))
        {
            zoomedInToggle = !zoomedInToggle;
        }
        
        if(zoomedInToggle)
        {
            ZoomIn();
        }
        else
        {
            SetDefaultZoom();
        }
        
    }

    private void ZoomIn()
    {
        player.fieldOfView = zoomedInFOV;
        playerMouse.mouseLook.XSensitivity = zoomedInMouse;
        playerMouse.mouseLook.YSensitivity = zoomedInMouse;
    }

    private void OnDisable()
    {
        SetDefaultZoom();
    }
}
