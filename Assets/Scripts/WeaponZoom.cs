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
    
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Camera>();
        player.fieldOfView = regularFOV;

        playerMouse = GetComponentInParent<RigidbodyFirstPersonController>();
        
        playerMouse.mouseLook.XSensitivity = regularMouse;
        playerMouse.mouseLook.YSensitivity = regularMouse;
    }

    // Update is called once per frame
    void Update()
    {
        if (CrossPlatformInputManager.GetButtonDown("Fire3"))
        {
            zoomedInToggle = !zoomedInToggle;
        }
        
        if(zoomedInToggle)
        {
            player.fieldOfView = zoomedInFOV;
            
            playerMouse.mouseLook.XSensitivity = zoomedInMouse;
            playerMouse.mouseLook.YSensitivity = zoomedInMouse;
        }
        else
        {
            player.fieldOfView = regularFOV;
            playerMouse.mouseLook.XSensitivity = regularMouse;
            playerMouse.mouseLook.YSensitivity = regularMouse;
        }
        
    }
}
