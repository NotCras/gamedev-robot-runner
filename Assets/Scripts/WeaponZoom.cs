using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] private float zoomedInFOV = 35f;
    [SerializeField] private float regularFOV = 60f;
    //[SerializeField] 
    private Camera player;

    private bool zoomedInToggle = false;
    
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Camera>();
        player.fieldOfView = regularFOV;
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
        }
        else
        {
            player.fieldOfView = regularFOV;
        }
        
    }
}
