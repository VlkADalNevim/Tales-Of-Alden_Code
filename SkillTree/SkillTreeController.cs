using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
* SkillTreeController class for handling spell lvl uping
*/
public class SkillTreeController : MonoBehaviour
{
    [Header("Spells")]
    [SerializeField] private FireBall fireBall;
    [SerializeField] private FireZone fireZone;
    [SerializeField] private FireBarrier fireBarrier;

    [SerializeField] private WindPush windPush;
    [SerializeField] private WindTornado windTornado;
    [SerializeField] private WindAreaPush windAreaPush;

    [Header("Controllers")]
    [SerializeField] private PlayerStats playerStats;

    public List<int> unlockedSpells = new List<int>();

    /**
    * FireBallLvlUp method to handle leveling up the specified skill
    * Consumes skillPoint(PlayerXP)
    * If skill is not unlocked, it is unlocked and leveled up
    * @return void
    */
    public void FireBallLvlUp()
    {
        if (FireBall.hasFireBallUnlocked && playerStats.PlayerXP > 0 && unlockedSpells.Contains(fireBall.Identification))
        {
            fireBall.fireBallLVL += 1;
            playerStats.PlayerXP -= 1;
        }
        else if (playerStats.PlayerXP > 0)
        {
            fireBall.fireBallLVL += 1;
            playerStats.PlayerXP -= 1;
            FireBall.hasFireBallUnlocked = true;
            unlockedSpells.Add(fireBall.Identification);
        }  
    }

    /**
    * FireZoneLvlUp method to handle leveling up the specified skill
    * Consumes skillPoint(PlayerXP)
    * If skill is not unlocked, it is unlocked and leveled up
    * @return void
    */
    public void FireZoneLvlUp()
    {
        if (FireZone.hasFireZoneUnlocked && playerStats.PlayerXP > 0 && unlockedSpells.Contains(fireZone.Identification))
        {
            fireZone.fireZoneLVL += 1;
            playerStats.PlayerXP -= 1;
        }
        else if (playerStats.PlayerXP > 0)
        {
            fireZone.fireZoneLVL += 1;
            playerStats.PlayerXP -= 1;
            FireZone.hasFireZoneUnlocked = true;
            unlockedSpells.Add(fireZone.Identification);
        }  
    }

    /**
    * FireBarrierLvlUp method to handle leveling up the specified skill
    * Consumes skillPoint(PlayerXP)
    * If skill is not unlocked, it is unlocked and leveled up
    * @return void
    */
    public void FireBarrierLvlUp()
    {
        if (FireBarrier.hasFireBarrierUnlocked && playerStats.PlayerXP > 0 && unlockedSpells.Contains(fireBarrier.Identification))
        {
            fireBarrier.fireBarrierLVL += 1;
            playerStats.PlayerXP -= 1;
        }
        else if (playerStats.PlayerXP > 0)
        {
            fireBarrier.fireBarrierLVL += 1;
            playerStats.PlayerXP -= 1;
            FireBarrier.hasFireBarrierUnlocked = true;
            unlockedSpells.Add(fireBarrier.Identification);
        }  
    }

    /**
    * WindPushLvlUp method to handle leveling up the specified skill
    * Consumes skillPoint(PlayerXP)
    * If skill is not unlocked, it is unlocked and leveled up
    * @return void
    */
    public void WindPushLvlUp()
    {
        if (WindPush.hasWindPushUnlocked && playerStats.PlayerXP > 0 && unlockedSpells.Contains(windPush.Identification))
        {
            windPush.windPushLVL += 1;
            playerStats.PlayerXP -= 1;
        }
        else if (playerStats.PlayerXP > 0)
        {
            windPush.windPushLVL += 1;
            playerStats.PlayerXP -= 1;
            WindPush.hasWindPushUnlocked = true;
            unlockedSpells.Add(windPush.Identification);
        }  
    }

    /**
    * WindTornadoLvlUp method to handle leveling up the specified skill
    * Consumes skillPoint(PlayerXP)
    * If skill is not unlocked, it is unlocked and leveled up
    * @return void
    */
    public void WindTornadoLvlUp()
    {
        if (WindTornado.hasWindTornadoUnlocked && playerStats.PlayerXP > 0 && unlockedSpells.Contains(windTornado.Identification))
        {
            windTornado.windTornadoLVL += 1;
            playerStats.PlayerXP -= 1;
        }
        else if (playerStats.PlayerXP > 0)
        {
            windTornado.windTornadoLVL += 1;
            playerStats.PlayerXP -= 1;
            WindTornado.hasWindTornadoUnlocked = true;
            unlockedSpells.Add(windTornado.Identification);
        }  
    }

    /**
    * WindAreaPushLvLUp method to handle leveling up the specified skill
    * Consumes skillPoint(PlayerXP)
    * If skill is not unlocked, it is unlocked and leveled up
    * @return void
    */
    public void WindAreaPushLvLUp()
    {
        if (WindAreaPush.hasWindAreaPushUnlocked && playerStats.PlayerXP > 0 && unlockedSpells.Contains(windAreaPush.Identification))
        {
            windAreaPush.windAreaPushLVL += 1;
            playerStats.PlayerXP -= 1;
        }
        else if (playerStats.PlayerXP > 0)
        {
            windAreaPush.windAreaPushLVL += 1;
            playerStats.PlayerXP -= 1;
            WindAreaPush.hasWindAreaPushUnlocked = true;
            unlockedSpells.Add(windAreaPush.Identification);
        }  
    }

}
