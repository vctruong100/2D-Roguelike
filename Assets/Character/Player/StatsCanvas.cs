using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class StatsCanvas : MonoBehaviour
{
    public GameObject statsCanvas;
    public TMP_Text levelText;
    public TMP_Text healthText;
    public TMP_Text damageText;
    public TMP_Text speedText;
    public TMP_Text armorText;
    public TMP_Text pointsText;
    public Button healthButton;
    public Button damageButton;
    public Button speedButton;
    public Button armorButton;


        private PlayerStats playerStats;
    GameObject statsPanel;
    private void Start()
    {
        Transform statsPanelTransform = transform.Find("Stats Panel");
        if (statsPanelTransform != null)
        {
            statsPanel = statsPanelTransform.gameObject;
            statsPanel.SetActive(false);
        }
        playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
    
    }


    private IEnumerator UpdateUIPeriodically()
    {
        while (true) {
            UpdateUI();
            yield return new WaitForSeconds(1.0f);
            Debug.Log("Updated UI");
        }
    }

    public void ToggleStatsCanvas()
    {
        UpdateUI();
        statsPanel.SetActive(!statsPanel.activeSelf);
    }

    public void AssignPlayerStats(PlayerStats newPlayerStats)
    {
        playerStats = newPlayerStats;
        UpdateUI(); // Update the UI to reflect the new player's stats
    }

    public void UpdateUI()
    {
        if (playerStats != null)
        {
            levelText.text = playerStats.level.ToString();
            healthText.text = playerStats.max_health.GetValue().ToString();
            damageText.text = playerStats.damage.GetValue().ToString();
            speedText.text = playerStats.moveSpeed.ToString();
            armorText.text = playerStats.armor.GetValue().ToString();
            pointsText.text = playerStats.points.ToString();

            healthButton.interactable = playerStats.points > 0;
            damageButton.interactable = playerStats.points > 0;
            speedButton.interactable = playerStats.points > 0 && playerStats.moveSpeed < playerStats.maxSpeed;
            armorButton.interactable = playerStats.points > 0;
        }
        else
        {
            Debug.LogError("playerStats is null in UpdateUI.");
        }
    }


    public void IncreaseHealth()
    {
        if (playerStats.points > 0)
        {
            playerStats.points--;
            playerStats.max_health.AddAttributes(1); // Increase health by 1
            UpdateUI();
        }
    }

    public void IncreaseDamage()
    {
        if (playerStats.points > 0)
        {
            playerStats.points--;
            playerStats.damage.AddAttributes(1); // Increase damage by 1
            UpdateUI();
        }
    }

    public void IncreaseSpeed()
    {
        if (playerStats.points > 0)
        {
            playerStats.points--;
            playerStats.moveSpeed += 0.5f; 
            if (playerStats.moveSpeed >= playerStats.maxSpeed)
            {
                playerStats.moveSpeed = playerStats.maxSpeed;
                speedButton.interactable = false;
            }
            UpdateUI();
        }
    }

    public void IncreaseArmor()
    {
        if (playerStats.points > 0)
        {
            playerStats.points--;
            playerStats.armor.AddAttributes(1); // Increase armor by 1
            UpdateUI();
        }
    }
}
