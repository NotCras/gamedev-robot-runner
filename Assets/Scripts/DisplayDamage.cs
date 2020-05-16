using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayDamage : MonoBehaviour
{
    [SerializeField] private Canvas ouchieCanvas;
    [SerializeField] private float damageTime = 0.5f;
    
    void Start()
    {
        ouchieCanvas.enabled = false;
    }

    public void ShowDamage()
    {
        StartCoroutine(DisplayBlood());
    }

    IEnumerator DisplayBlood()
    {
        //enable canvas
        ouchieCanvas.enabled = true;
        yield return new WaitForSeconds(damageTime);
        ouchieCanvas.enabled = false;
    }


}
