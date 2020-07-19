using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [HideInInspector] public static bool allManagersAreReadyToBeUsed;

    private void Start()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }

        StartCoroutine(AllManagersReady());
    }

    /// <summary>
    /// Are all managers ready to be used?
    /// Sets the "allManagersAreReadyToBeUsed" variable accordingly
    /// </summary>
    /// <returns></returns>
    private IEnumerator AllManagersReady()
    {
        // If all managers are already ready to be used, get out of the coroutine immediately
        if (allManagersAreReadyToBeUsed)
        {
            yield break;
        }

        // Otherwise wait until they are ready, and set "allManagersAreReadyToBeUsed" equal to true
        while (!allManagersAreReadyToBeUsed)
        {
            allManagersAreReadyToBeUsed = BlocksManager.Instance != null && StatsManager.Instance != null &&
                                          InputManager.Instance != null && AudioManager.Instance != null &&
                                          UIManager.Instance != null;
            yield return null;
        }

        allManagersAreReadyToBeUsed = true;
    }
}