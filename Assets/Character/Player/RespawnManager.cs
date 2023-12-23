using UnityEngine;
using UnityEngine.UI;

public class RespawnManager : MonoBehaviour
{
    [SerializeField] private Button respawnButton;
    [SerializeField] private GameObject playerPrefab;
    private void Start()
    {
        respawnButton.onClick.AddListener(RespawnPlayer);

        respawnButton.gameObject.SetActive(false);
    }

    public void PlayerDied()
    {
        respawnButton.gameObject.SetActive(true);
    }

    private void RespawnPlayer()
    {
        respawnButton.gameObject.SetActive(false);
        SpawnPlayer();
    }

    private void SpawnPlayer()
    {
        Instantiate(playerPrefab, transform.position, Quaternion.identity);
    }
}
