using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
* WeaponController class for handling the players ability to attack
*/
public class WeaponController : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField] private Animator animator;

    [Header("Controllers")]
    [SerializeField] private PlayerHealthManager playerHealthManager;
    [SerializeField] private ThirdPersonMovement thirdPersonMovement;

    public bool canAttack = true;
    private float attackCooldown = 1.7f;
    public bool IsAttacking = false;

    // Update is called once per frame
    void Update()
    {
        if (playerHealthManager.Alive)
        {
            // Player swings with sword
            if (Input.GetMouseButtonDown(0))
            {
                if (canAttack)
                {
                    SwordAttack();
                }
            }
        }
    }

    /**
    * Triggers the attack animation and disables player movement during the attack.
    * Deals damage to enemies if weapon hits.
    */
    public void SwordAttack()
    {
        thirdPersonMovement.canMove = false;
        canAttack = false;
        IsAttacking = true;
        animator.SetTrigger("attack");
        StartCoroutine(ResetAttackCooldown());
    }

    /**
    * Resets the attack cooldown after a set amount of time.
    * Enables player movement and allows the player to attack again.
    */
    IEnumerator ResetAttackCooldown()
    {
        yield return new WaitForSeconds(attackCooldown);
        thirdPersonMovement.canMove = true;
        IsAttacking = false;
        canAttack = true;
    }
}
