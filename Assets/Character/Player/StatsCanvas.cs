using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;

public class StatsCanvas : MonoBehaviour
{
    public GameObject statsCanvas;
    public PlayerStats playerStats;

    public TMP_Text levelText;
    public TMP_Text healthText;
    public TMP_Text damageText;
    public TMP_Text speedText;

    private void Start()
    {
        statsCanvas.SetActive(false); // Hide the stats canvas initially
    }

    public void ToggleStatsCanvas()
    {
        statsCanvas.SetActive(!statsCanvas.activeSelf);
    }

    public void UpdateUI()
    {
        // Update the UI elements with player stats
        levelText.text = playerStats.GetLevel();
        healthText.text = playerStats.GetHealth();
        damageText.text = playerStats.GetDamage();
        speedText.text = playerStats.GetMoveSpeed();
    }
}
