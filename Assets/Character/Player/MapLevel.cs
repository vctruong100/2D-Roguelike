using UnityEngine;
using TMPro;

public class MapLevel : MonoBehaviour
{
    public TMP_Text levelText; // Reference to the "Level" TextMeshPro text element
    public TMP_Text numberText; // Reference to the dynamic number TextMeshPro text element

    public int currentLevel = 1;

    void Start()
    {
        UpdateLevelText();
    }

    void Update()
    {
        // nothing
    }

    public void IncreaseLevel()
    {
        currentLevel++;
        UpdateLevelText();
    }

    void UpdateLevelText()
    {
        levelText.text = "Level:";
        numberText.text = currentLevel.ToString();

        // Choose a common font size for both texts
        float commonFontSize = 25f;

        levelText.fontSize = commonFontSize;
        numberText.fontSize = commonFontSize;

        // You can add additional logic to handle scaling based on screen size if needed.

        // Ensure the text is always at the top right corner
        RectTransform rectTransform = GetComponent<RectTransform>();
        rectTransform.anchoredPosition = new Vector2(-10f, -10f); // Adjust the values based on your design.
    }
}
