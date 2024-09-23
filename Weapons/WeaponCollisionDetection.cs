using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
* WeaponCollisionDetection class for handling the collision between this gameObject(weapon) and enemy
*/
public class WeaponCollisionDetection : MonoBehaviour
{
    // Controllers for weapon and player stats
    [Header("Controllers")]
    [SerializeField] private WeaponController weaponController;
    [SerializeField] private PlayerStats playerStats;
    // Damage to be dealt by the weapon
    [SerializeField] private float weaponDamage;

    /**
    * Detects collisions between player's weapon and enemy, and reduces enemy's health and increases player's strength.
    * @param other The collider that this object has collided with.
    */
    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy" && weaponController.IsAttacking)
        {
            // Retrieve the enemy controller script and reduce enemy health
            EnemyController enemyController = other.GetComponent<EnemyController>();
            enemyController.TakeDamage(other.gameObject, weaponDamage);
            
            // Increase player strength
            playerStats.PlayerStrenghtIncrease(0.002f);
        }    
    }
}