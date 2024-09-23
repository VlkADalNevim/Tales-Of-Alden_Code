using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/**
* SkillSlot class for handling spell casting and slot spell controll
*/
public class SkillSlot : MonoBehaviour, IDropHandler
{
    [Header("Basics")]
    public bool isFull = false;
    public int skillInSlot;

    [Header("Objects")]
    [SerializeField] private Transform fireBallSpawnPoint;
    [SerializeField] private Transform insideSpawnPoint;
    [SerializeField] private GameObject fireBallPrefab;
    [SerializeField] private Transform fireZoneSpawnPoint;
    [SerializeField] private GameObject fireZonePrefab;
    [SerializeField] private GameObject fireBarrierObject;

    [SerializeField] private GameObject windPushPrefab;
    [SerializeField] private GameObject windTornadoPrefab;
    [SerializeField] private GameObject windAreaPushPrefab;

    [SerializeField] private GameObject waterBoublePrefab;
    [SerializeField] private GameObject waterWavePrefab;
    [SerializeField] private GameObject waterWhirpoolPrefab;

    [SerializeField] private GameObject lightningBoltPrefab;
    [SerializeField] private GameObject lightningStrikePrefab;
    [SerializeField] private GameObject lightningStormPrefab;

    [Header("Controllers")]
    [SerializeField] private PlayerManaManager playerManaManager;
    [SerializeField] private SkillTreeController skillTreeController;

    [Header("Spells")]
    [SerializeField] private FireBall fireBall;
    public float fireBallCooldownTimer = 0f;
    [SerializeField] private FireZone fireZone;
    public float fireZoneCooldownTimer = 0f;
    [SerializeField] private FireBarrier fireBarrier;
    public float fireBarrierCooldownTimer = 0f;

    [SerializeField] private WindPush windPush;
    public float windPushCooldownTimer = 0f;
    [SerializeField] private WindTornado windTornado;
    public float windTornadoCooldownTimer = 0f;
    [SerializeField] private WindAreaPush windAreaPush;
    public float windAreaPushCooldownTimer = 0f;

    [SerializeField] private WaterBouble waterBouble;
    public float waterBoubleCooldownTimer = 0f;
    [SerializeField] private WaterWave waterWave;
    public float waterWaveCooldownTimer = 0f;
    [SerializeField] private WaterWhirpool waterWhirpool;
    public float waterWhirpoolCooldownTimer = 0f;

    [SerializeField] private LightningBolt lightningBolt;
    public float lightningBoltCooldownTimer = 0f;
    [SerializeField] private LightningStrike lightningStrike;
    public float lightningStrikeCooldownTimer = 0f;
    [SerializeField] private LightningStorm lightningStorm;
    public float lightningStormCooldownTimer = 0f;

    [Header("Controls")]
    public KeyCode castSpellKey = KeyCode.Q;

    void Update()
    {
        // update cooldown timer
        if (fireBallCooldownTimer > 0f)
        {
            fireBallCooldownTimer -= Time.deltaTime;
        }
        if (fireZoneCooldownTimer > 0f)
        {
            fireZoneCooldownTimer -= Time.deltaTime;
        }
        if (fireBarrierCooldownTimer > 0f)
        {
            fireBarrierCooldownTimer -= Time.deltaTime;
        }

        if (windPushCooldownTimer > 0f)
        {
            windPushCooldownTimer -= Time.deltaTime;
        }
        if (windTornadoCooldownTimer > 0f)
        {
            windTornadoCooldownTimer -= Time.deltaTime;
        }
        if (windAreaPushCooldownTimer > 0f)
        {
            windAreaPushCooldownTimer -= Time.deltaTime;
        }

        if (waterBoubleCooldownTimer > 0f)
        {
            waterBoubleCooldownTimer -= Time.deltaTime;
        }
        if (waterWaveCooldownTimer > 0f)
        {
            waterWaveCooldownTimer -= Time.deltaTime;
        }
        if (waterWhirpoolCooldownTimer > 0f)
        {
            waterWhirpoolCooldownTimer -= Time.deltaTime;
        }
        

        if(Input.GetKeyDown(castSpellKey))
        {
            Debug.Log(skillInSlot);
            if(skillInSlot == 1)
            {
                Debug.Log("ShootFireBall");
                ShootFireBall();
            }
            else if(skillInSlot == 2)
            {
                Debug.Log("ShootFireZone");
                ShootFireZone();
            }
            else if(skillInSlot == 3)
            {
                Debug.Log("ActivateFireBarrier");
                ActivateFireBarrier();
            }
            else if(skillInSlot == 4)
            {
                Debug.Log("ShootWindPush");
                ShootWindPush();
            }
            else if(skillInSlot == 5)
            {
                Debug.Log("ShootTornado");
                ShootTornado();
            }
            else if(skillInSlot == 6)
            {
                Debug.Log("ShootTornado");
                ShootWindAreaPush();
            }
        }
    }

    /**
    * OnDrop method handles the logic for when a draggable object is dropped onto this skill slot.
    * @param eventData The pointer event data that contains information about the event(skill).
    * @return void
    */
    public void OnDrop(PointerEventData eventData)
    {
        GameObject dropped = eventData.pointerDrag;
        DraggableSkill draggableSkill = dropped.GetComponent<DraggableSkill>();
        draggableSkill.cloneParent = transform;
        if(skillTreeController.unlockedSpells.Contains(draggableSkill.spellID))
        {
            if (transform.childCount == 0 && !isFull) 
            {
                isFull = true;
                skillInSlot = draggableSkill.spellID;
                Debug.Log(skillInSlot);
            }
            else
            {
                Debug.Log("Skill slot is already full, cannot drop skill here.");
                Destroy(draggableSkill.clone);
            }
        }
    }

    /**
    * ShootFireBall method handles the logic of summoning the specified spell
    * Spell is summoned only if cooldown timer isn't higher than 0
    * Spell is summoned and is being shot moving forward
    * @return void
    */
    void ShootFireBall()
    {
        if(FireBall.hasFireBallUnlocked && playerManaManager.CurrentMana - fireBall.manaCost >= 0)
        {
            if (fireBallCooldownTimer <= 0f) // check if cooldown is over
            {
                var bullet = Instantiate(fireBallPrefab, fireBallSpawnPoint.position, fireBallSpawnPoint.rotation);
                bullet.GetComponent<Rigidbody>().velocity = fireBallSpawnPoint.forward * fireBall.fireBallSpeed;
                playerManaManager.PlayerUsesMana(fireBall.manaCost);
                fireBallCooldownTimer = 4f; // reset cooldown timer
            }
            else
            {
                Debug.Log("Fireball is on cooldown");
            }
        }
    }

    /**
    * ShootFireZone method handles the logic of summoning the specified spell
    * Spell is summoned only if cooldown timer isn't higher than 0
    * @return void
    */
    void ShootFireZone()
    {
        if(FireZone.hasFireZoneUnlocked && playerManaManager.CurrentMana - fireZone.manaCost >= 0)
        {
            if (fireZoneCooldownTimer <= 0f) // check if cooldown is over
            {
                var zone = Instantiate(fireZonePrefab, fireZoneSpawnPoint.position, fireZoneSpawnPoint.rotation);
                playerManaManager.PlayerUsesMana(fireZone.manaCost);
                fireZoneCooldownTimer = 10f; // reset cooldown timer
            }
            else
            {
                Debug.Log("Fireball is on cooldown");
            }
        }
    }

    /**
    * ActivateFireBarrier method handles the logic of summoning the specified spell
    * Spell is summoned only if cooldown timer isn't higher than 0
    * Game object is set active for a specified amount of time
    * @return void
    */
    void ActivateFireBarrier()
    {
        if(FireBarrier.hasFireBarrierUnlocked && playerManaManager.CurrentMana - fireZone.manaCost >= 0 && !fireBarrierObject.activeSelf)
        {
            if (fireBarrierCooldownTimer <= 0f) // check if cooldown is over
            {
                fireBarrierObject.SetActive(true);
                playerManaManager.PlayerUsesMana(fireBarrier.manaCost);
                fireBarrierCooldownTimer = 10f; // reset cooldown timer
            }
            else
            {
                Debug.Log("FireBarrier is on cooldown");
            }
        }
    }

    /**
    * ShootWindPush method handles the logic of summoning the specified spell
    * Spell is summoned only if cooldown timer isn't higher than 0
    * Spell is summoned and is being shot moving forward
    * @return void
    */
    void ShootWindPush()
    {
        if(WindPush.hasWindPushUnlocked && playerManaManager.CurrentMana - windPush.manaCost >= 0)
        {
            if (windPushCooldownTimer <= 0f) // check if cooldown is over
            {
                var bullet = Instantiate(windPushPrefab, fireBallSpawnPoint.position, fireBallSpawnPoint.rotation);
                bullet.GetComponent<Rigidbody>().velocity = fireBallSpawnPoint.forward * windPush.windPushSpeed;
                playerManaManager.PlayerUsesMana(windPush.manaCost);
                windPushCooldownTimer = 3f; // reset cooldown timer
            }
            else
            {
                Debug.Log("windPush is on cooldown");
            }
        }
    }

    /**
    * ShootTornado method handles the logic of summoning the specified spell
    * Spell is summoned only if cooldown timer isn't higher than 0
    * Spell is summoned and is being shot moving forward
    * @return void
    */
    void ShootTornado()
    {
        if(WindTornado.hasWindTornadoUnlocked && playerManaManager.CurrentMana - windTornado.manaCost >= 0)
        {
            if (windTornadoCooldownTimer <= 0f) // check if cooldown is over
            {
                var bullet = Instantiate(windTornadoPrefab, fireZoneSpawnPoint.position, fireZoneSpawnPoint.rotation);
                bullet.GetComponent<Rigidbody>().velocity = fireZoneSpawnPoint.forward * windTornado.windTornadoSpeed;
                playerManaManager.PlayerUsesMana(windTornado.manaCost);
                windTornadoCooldownTimer = 12f; // reset cooldown timer
            }
            else
            {
                Debug.Log("windTornado is on cooldown");
            }
        }
    }

    /**
    * ShootWindAreaPush method handles the logic of summoning the specified spell
    * Spell is summoned only if cooldown timer isn't higher than 0
    * Spell is summoned and is being shot moving forward
    * @return void
    */
    void ShootWindAreaPush()
    {
        if(WindAreaPush.hasWindAreaPushUnlocked && playerManaManager.CurrentMana - windAreaPush.manaCost >= 0)
        {
            if (windAreaPushCooldownTimer <= 0f) // check if cooldown is over
            {
                // create the four wind push objects
                for (int i = 0; i < 4; i++)
                {
                    // calculate the rotation of the object based on the current iteration
                    Quaternion rotation = Quaternion.Euler(0f, i * 90f, 0f);
                    
                    // instantiate the object with the calculated rotation
                    var bullet = Instantiate(windAreaPushPrefab, insideSpawnPoint.position, insideSpawnPoint.rotation * rotation);
                    
                    // set the velocity of the object based on the rotation
                    bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * windPush.windPushSpeed;
                }
                playerManaManager.PlayerUsesMana(windAreaPush.manaCost);
                windAreaPushCooldownTimer = 5f; // reset cooldown timer
            }
            else
            {
                Debug.Log("windAreaPush is on cooldown");
            }
        }
    }
}
