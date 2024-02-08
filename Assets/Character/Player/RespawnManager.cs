using UnityEngine;
using Cinemachine;

public class RespawnManager : MonoBehaviour
{
    public static RespawnManager Instance { get; private set; }

    public GameObject playerPrefab;
    public Transform spawnPoint;
    public GameObject respawnButton; // UI Button to respawn the player
    public CinemachineVirtualCamera virtualCamera;

    private void Awake()
    {
        respawnButton.SetActive(false);

        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayerDied()
    {
        // Show the respawn button
        respawnButton.SetActive(true);
    }

    public void RespawnPlayer()
    {
        if (playerPrefab && spawnPoint)
        {
            GameObject newPlayer = Instantiate(playerPrefab, spawnPoint.position, Quaternion.identity);

            var statsCanvas = FindObjectOfType<StatsCanvas>();
            if (statsCanvas != null)
            {
                statsCanvas.AssignPlayerStats(newPlayer.GetComponent<PlayerStats>());
            }
            
            // Here we tell the virtual camera to follow the new player instance
            virtualCamera.Follow = newPlayer.transform;
            virtualCamera.LookAt = newPlayer.transform;

            var spawnManager = FindObjectOfType<SpawnManager>();
            if (spawnManager != null)
            {
                spawnManager.ResetLevelAndEnemies();
            }

            // Hide the respawn button again
            respawnButton.SetActive(false);
        }
    }
}
