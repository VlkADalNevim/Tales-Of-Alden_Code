using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
* Class for handling the specific spell behaviour
*/
public class WindTornado : MonoBehaviour
{
    public int Identification = 5;
    private float life = 10;
    [Header("Stats")]
    // Speed
    public float windTornadoSpeed = 1f;
    public float windTornadoDamage = 0.3f;
    public static bool hasWindTornadoUnlocked = false;
    public float manaCost = 10f;
    public int windTornadoLVL = 0;

    private PlayerStats playerStats;

    private float damageInterval = 0.1f; // Time interval between damage ticks
    private List<EnemyController> enemiesInside; // List of enemies inside the fire zone

    void Start()
    {
        playerStats = FindObjectOfType<PlayerStats>();
        enemiesInside = new List<EnemyController>();
        InvokeRepeating("DealDamage", damageInterval, damageInterval);
    }

    void Awake()
    {
        Destroy(gameObject,life);
    }

    /**
    * Method for handling the entry of collider
    */
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            EnemyController enemyController = col.gameObject.GetComponent<EnemyController>();
            enemiesInside.Add(enemyController);
        }
    }

    /**
    * Method for handling the leave of collider
    */
    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            EnemyController enemyController = col.gameObject.GetComponent<EnemyController>();
            enemiesInside.Remove(enemyController);
        }
    }

    void DealDamage()
    {
        // Loop through all enemies inside the fire zone and deal damage to them
        foreach (EnemyController enemyController in enemiesInside)
        {
            var windTornadoDamageLVL = windTornadoDamage * windTornadoLVL;
            var windProficiency = windTornadoDamageLVL * playerStats.PlayerWindProficiency * 0.1f;
            var magicPower = windTornadoDamageLVL * playerStats.PlayerMagicPower * 0.1f;
            var windTornadoTotalDamage = windTornadoDamageLVL + windProficiency + magicPower;
            enemyController.TakeDamageFromMagic(windTornadoTotalDamage);
            Debug.Log(windTornadoTotalDamage);
            playerStats.PlayerMagicIncrease(0.002f);
            playerStats.PlayerWindProficiencyIncrease(0.004f);
        }
    }
}