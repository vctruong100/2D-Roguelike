using System.Collections;
using TMPro;
using UnityEngine;

public class StatsCanvas : MonoBehaviour
{
    public GameObject statsCanvas;
    public TMP_Text levelText;
    public TMP_Text healthText;
    public TMP_Text damageText;
    public TMP_Text speedText;

    private PlayerStats playerStats;

    private void OnEnable()
    {
        // Start the coroutine when the StatsCanvas becomes active
        if (statsCanvas.activeSelf)
        {
            StartCoroutine(UpdateUIPeriodically());
        }
    }

    private void OnDisable()
    {
        // Stop the coroutine when the StatsCanvas becomes inactive
        StopCoroutine(UpdateUIPeriodically());
    }

    private void Start()
    {
        statsCanvas.SetActive(false); // Hide the stats canvas initially
        playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
    }

    private IEnumerator UpdateUIPeriodically()
    {
        while (true)
        {
            if (statsCanvas.activeSelf)
            {
                UpdateUI();
            }
            yield return new WaitForSeconds(1.0f); // Update every second, adjust as needed
        }
    }

    public void ToggleStatsCanvas()
    {
        statsCanvas.SetActive(!statsCanvas.activeSelf);
    }

    public void AssignPlayerStats(PlayerStats playerStats)
    {
        this.playerStats = playerStats;
    }

    public void UpdateUI()
    {
        if (playerStats != null)
        {
            levelText.text = playerStats.level.ToString();
            healthText.text = playerStats.max_health.GetValue().ToString();
            damageText.text = playerStats.damage.GetValue().ToString();
            speedText.text = playerStats.moveSpeed.ToString();
        }
        else
        {
            Debug.LogError("playerStats is null in UpdateUI.");
        }
    }

}
