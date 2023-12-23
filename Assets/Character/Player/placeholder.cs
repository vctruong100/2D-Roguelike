// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// [CreateAssetMenu(fileName = "PlayerStats", menuName = "ScriptableObjects/PlayerStats", order = 1)]
// public class PlayerStats : ScriptableObject
//     //public PLayerInitialStats initialStats;
//     [Header("Default initialize values")]
//     [SerializeField] private int _health;
//     [SerializeField] private int _damage;
//     [SerializeField] private double _moveSpeed;
//     [SerializeField] private int _regenRate;
//     [SerializeField] private int _regenHp;
//     [SerializeField] private int _maxSpeed;
//     [SerializeField] private int _level;
//     private double currentExp;
//     private double expToNextLevel;
//     private int _currentHealth;
//     private bool isPlayerAlive = true;
//     Animator animator;
//     Rigidbody2D rb;

//     public float Health {
//         set {
//             if (value != _currentHealth) {
//                 _currentHealth = Mathf.Max(value, 0);
//                 HealthChanged?.Invoke(_currentHealth);
//             };
//         }
//         get {
//             return _currentHealth;
//         }
//     }

//     public int Damage { get; set; }
//     public double MoveSpeed { get; set; }
//     public int RegenRate { get; set; }
//     public int RegenHp { get; set; }
//     public int MaxSpeed { get; set; }
//     public int Level { get; set; }

//     public UnityAction<int> HealthChanged;

//     public void InitDefaults() {
//         Health = _health;
//         Damage = _damage;
//         MoveSpeed = _moveSpeed;
//         RegenRate = _regenRate;
//         RegenHp = _regenHp;
//         MaxSpeed = _maxSpeed;
//         Level = _level;
//     }

//     private void Start() {
//         animator = GetComponent<Animator>();
//         rb = GetComponent<Rigidbody2D>();
//         ResetPlayerStats();
//         StartCoroutine(RegenerateHealth());
//     }

//     private IEnumerator RegenerateHealth()
//     {
//         while (isPlayerAlive)
//         {
//             yield return new WaitForSeconds(regenRate);

//             // Increase current health by 1
//             currentHealth = Mathf.Min(health, currentHealth + regenHp);
//             Debug.Log("Current health: " + currentHealth);
//         }
//     }

//     public void Die() {
//         isPlayerAlive = false;
//         animator.SetTrigger("Die");
//     }

//     public void CalculateExpToNextLevel() {
//         expToNextLevel = 100 + 100.0 * level * level * 0.8;
//     }

//     public void AddExp(int exp) {
//         currentExp += exp;
//         Debug.Log("Exp: " + currentExp + "/" + expToNextLevel);
//         Debug.Log("Level: " + level);

//         if(currentExp >= expToNextLevel) {
//             LevelUp();
//         }
//     }

//     private void LevelUp() {
//         level++;
//         currentExp = currentExp - expToNextLevel;
//         CalculateExpToNextLevel();
//     }

//     public void RemovePlayer() {
//         Destroy(gameObject);
//     }
//     // private void ResetPlayerStats() {
//     //     Debug.Log("Resetting player stats");
//     //     level = initialStats.initial_level;
//     //     health = initialStats.initial_health;
//     //     currentHealth = health;
//     //     damage = initialStats.initial_damage;
//     //     moveSpeed = initialStats.initial_moveSpeed;
//     //     regenRate = initialStats.initial_regenRate;
//     //     regenHp = initialStats.initial_regenHp;
//     //     maxSpeed = initialStats.initial_maxSpeed;
//     //     currentExp = initialStats.initial_currentExp;
//     //     expToNextLevel = initialStats.initial_expToNextLevel;
//     // }

//     public int GetLevel() {
//         return level;
//     }

//     public float GetHealth() {
//         return health;
//     }
    
//     public float GetCurrentHealth() {
//         return currentHealth;
//     }
//     public float GetDamage() {
//         return damage;
//     }

//     public float GetMoveSpeed() {
//         return moveSpeed;
//     }

//     public float GetMaxSpeed() {
//         return maxSpeed;
//     }

//     public double GetExp() {
//         return currentExp;
//     }
// }

// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class PlayerStats : MonoBehaviour
// {
//     public PLayerInitialStats initialStats;
//     private float health;
//     private float currentHealth;
//     private float damage;
//     private float moveSpeed;
//     private float regenRate;
//     private float regenHp;
//     private float maxSpeed;
//     private int level;
//     private double currentExp;
//     private double expToNextLevel;

//     private bool isPlayerAlive = true;

//     public float Health {
//         set {
//             currentHealth = value;
//             if(currentHealth <= 0) {
//                 Die();
//             }
//             else {
//                 animator.SetTrigger("Hit");
//             }
//         }
//         get {
//             return currentHealth;
//         }
//     }

//     Animator animator;
//     Rigidbody2D rb;
//     private void Start() {
//         animator = GetComponent<Animator>();
//         rb = GetComponent<Rigidbody2D>();
//         ResetPlayerStats();
//         StartCoroutine(RegenerateHealth());
//     }

//     private IEnumerator RegenerateHealth()
//     {
//         while (isPlayerAlive)
//         {
//             yield return new WaitForSeconds(regenRate);

//             // Increase current health by 1
//             currentHealth = Mathf.Min(health, currentHealth + regenHp);
//             Debug.Log("Current health: " + currentHealth);
//         }
//     }

//     public void Die() {
//         isPlayerAlive = false;
//         animator.SetTrigger("Die");
//     }

//     public void CalculateExpToNextLevel() {
//         expToNextLevel = 100 + 100.0 * level * level * 0.8;
//     }

//     public void AddExp(int exp) {
//         currentExp += exp;
//         Debug.Log("Exp: " + currentExp + "/" + expToNextLevel);
//         Debug.Log("Level: " + level);

//         if(currentExp >= expToNextLevel) {
//             LevelUp();
//         }
//     }

//     private void LevelUp() {
//         level++;
//         currentExp = currentExp - expToNextLevel;
//         CalculateExpToNextLevel();
//     }

//     public void RemovePlayer() {
//         Destroy(gameObject);
//     }
//     private void ResetPlayerStats() {
//         Debug.Log("Resetting player stats");
//         level = initialStats.initial_level;
//         health = initialStats.initial_health;
//         currentHealth = health;
//         damage = initialStats.initial_damage;
//         moveSpeed = initialStats.initial_moveSpeed;
//         regenRate = initialStats.initial_regenRate;
//         regenHp = initialStats.initial_regenHp;
//         maxSpeed = initialStats.initial_maxSpeed;
//         currentExp = initialStats.initial_currentExp;
//         expToNextLevel = initialStats.initial_expToNextLevel;
//     }

//     public int GetLevel() {
//         return level;
//     }

//     public float GetHealth() {
//         return health;
//     }
    
//     public float GetCurrentHealth() {
//         return currentHealth;
//     }
//     public float GetDamage() {
//         return damage;
//     }

//     public float GetMoveSpeed() {
//         return moveSpeed;
//     }

//     public float GetMaxSpeed() {
//         return maxSpeed;
//     }

//     public double GetExp() {
//         return currentExp;
//     }
// }
