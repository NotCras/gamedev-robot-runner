using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] private AmmoSlot[] ammoSlots;
    
    
    [System.Serializable]
    private class AmmoSlot
    {
        public AmmoType ammoType;
        public int ammoAmount;
    }

    public int GetCurrentAmmo(AmmoType a)
    {
        foreach (var ammoSlot in ammoSlots)
        {
            if (ammoSlot.ammoType == a)
            {
                return ammoSlot.ammoAmount;
            }
        }
        Debug.Log("Missing ammo type.");
        return 0;
    }

    public void ReduceCurrentAmmo(AmmoType a)
    {
        foreach (var ammoSlot in ammoSlots)
        {
            if (ammoSlot.ammoType == a)
            {
                ammoSlot.ammoAmount--;
            }
        }
    }

    public void AddCurrentAmmo(AmmoType a, int add)
    {
        foreach (var ammoSlot in ammoSlots)
        {
            if (ammoSlot.ammoType == a)
            {
                ammoSlot.ammoAmount += add;
            }
        }
    }

    private AmmoSlot GetAmmoType(AmmoType a)
    {
        foreach (var ammoSlot in ammoSlots)
        {
            if (ammoSlot.ammoType == a)
            {
                return ammoSlot;
            }
        }

        return null;
    }
    
}
