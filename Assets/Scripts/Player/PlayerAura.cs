using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAura : MonoBehaviour
{
    /*
     * 0 = No aura effects applied
     * 1 = Basic aura levels
     * 2 = Advanced aura effects
     */
    [SerializeField] int auraLvl = 0;
    bool auraApplied = false;

    private void Update()
    {
        auraApplied = auraLvl > 0;
        if (!auraApplied)
        {
            DisableAura();
            return;
        } else
        {
            AppliedAura();
        }
    }

    private void AppliedAura()
    {
        Time.timeScale = .85f;
    }

    private void DisableAura()
    {
        Time.timeScale = 1f;
    }
}