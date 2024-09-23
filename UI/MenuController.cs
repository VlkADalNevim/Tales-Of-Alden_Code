using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/**
* MenuController class for handling menus
*/
public class MenuController : MonoBehaviour
{
    [Header("Objects")]
    // Menu
    [SerializeField] private GameObject Menu;
    private static bool GameIsPaused = false;
    private static bool MenuOpened = false;

    // Skill Tree
    [SerializeField] private GameObject SkillTree;
    private static bool SkillTreeOpened = false;

    // Inventory
    [SerializeField] private GameObject Inventory;
    private static bool InventoryOpened = false;

    // HUD
    [SerializeField] private GameObject HUD;
    [SerializeField] private GameObject activeQuest;
    public bool questMenuOpened = false;
    [SerializeField] private GameObject victoryScreen;

    [Header("Inventory")]
    [SerializeField] private TMP_Text currentHealth;
    [SerializeField] private TMP_Text maxHealth;
    [SerializeField] private TMP_Text movementSpeed;
    [SerializeField] private TMP_Text strenght;
    [SerializeField] private TMP_Text currentMana;
    [SerializeField] private TMP_Text maxMana;
    [SerializeField] private TMP_Text magicPower;
    [SerializeField] private TMP_Text fireProficiency;
    [SerializeField] private TMP_Text windProficiency;
    [SerializeField] private TMP_Text gold;

    [Header("SkillTree")]
    [SerializeField] private TMP_Text magicPower2;
    [SerializeField] private TMP_Text fireProficiency2;
    [SerializeField] private TMP_Text windProficiency2;
    [SerializeField] private TMP_Text fireBallLVLText;
    [SerializeField] private TMP_Text fireZoneLVLText;
    [SerializeField] private TMP_Text fireBarrierLVLText;
    [SerializeField] private TMP_Text windPushLVLText;
    [SerializeField] private TMP_Text windTornadoLVLText;
    [SerializeField] private TMP_Text windAreaPushLVLText;
    [SerializeField] private TMP_Text XP;
    
    [Header("Controllers")]
    [SerializeField] private PlayerStats playerStats;
    [SerializeField] private PlayerHealthManager playerHealthManager;
    [SerializeField] private WeaponController weaponController;
    [SerializeField] private PlayerManaManager playerManaManager;
    [SerializeField] private HotBarSlots hotBarSlots1;
    [SerializeField] private HotBarSlots hotBarSlots2;
    [SerializeField] private HotBarSlots hotBarSlots3;
    [SerializeField] private QuestGiver questGiver;
    [SerializeField] private QuestController questController;

    [Header("Skills")]
    [SerializeField] private FireBall fireBall;
    [SerializeField] private FireZone fireZone;
    [SerializeField] private FireBarrier fireBarrier;
    [SerializeField] private WindPush windPush;
    [SerializeField] private WindTornado windTornado;
    [SerializeField] private WindAreaPush windAreaPush;
    

    void Start()
    {
        UpdateSkills();
    }

    /**
    * Update method to handle the user key input
    * Sets specific UI active and another inactive
    * @return void
    */
    void Update()
    {
        if (questGiver.thirdQuestCompleted)
        {
            victoryScreen.SetActive(true);
            PauseGame();
        }

        if (Input.GetButtonDown("tab"))
        {
            if (GameIsPaused && !SkillTreeOpened && !InventoryOpened && !questMenuOpened)
            {
                ResumeGame();
                Menu.SetActive(false);
                HUD.SetActive(true);
                MenuOpened = false;
                if (questGiver.startedQuestLine && questController.activeQuests)
                {
                    activeQuest.SetActive(true);
                }
            }
            else if (!SkillTreeOpened && !InventoryOpened && !questMenuOpened)
            {
                PauseGame();
                Menu.SetActive(true);
                HUD.SetActive(false);
                MenuOpened = true;
                activeQuest.SetActive(false);
            }
        }

        if (Input.GetButtonDown("Skill Tree"))
        {
            if (GameIsPaused && !MenuOpened && !InventoryOpened && !questMenuOpened)
            {
                ResumeGame();
                SkillTree.SetActive(false);
                HUD.SetActive(true);
                SkillTreeOpened = false;
                if (questGiver.startedQuestLine && questController.activeQuests)
                {
                    activeQuest.SetActive(true);
                }
                hotBarSlots1.OnChange();
                hotBarSlots2.OnChange();
                hotBarSlots3.OnChange();
            }
            else if (!MenuOpened && !InventoryOpened && !questMenuOpened)
            {
                PauseGame();
                SkillTree.SetActive(true);
                HUD.SetActive(false);
                SkillTreeOpened = true;
                magicPower2.text = (playerStats.PlayerMagicPower.ToString("F1"));
                XP.text = (playerStats.PlayerXP.ToString());
                fireProficiency2.text = (playerStats.PlayerFireProficiency.ToString("F1"));
                windProficiency2.text = (playerStats.PlayerWindProficiency.ToString("F1"));
                activeQuest.SetActive(false);
            }
                
        }

        if (Input.GetButtonDown("Inventory"))
        {
            if (GameIsPaused && !MenuOpened && !SkillTreeOpened && !questMenuOpened)
            {
                ResumeGame();
                Inventory.SetActive(false);
                HUD.SetActive(true);
                InventoryOpened = false;
                if (questGiver.startedQuestLine && questController.activeQuests)
                {
                    activeQuest.SetActive(true);
                }
            }
            else if (!MenuOpened && !SkillTreeOpened && !questMenuOpened)
            {
                gold.text = playerStats.Gold.ToString("F0");
                currentHealth.text = playerHealthManager.CurrentHealth.ToString("F0");
                maxHealth.text = playerHealthManager.MaxHealth.ToString("F0");
                movementSpeed.text = (playerStats.PlayerMoveSpeed.ToString("F1"));
                strenght.text = (playerStats.PlayerStrenght.ToString("F1"));
                currentMana.text = (playerManaManager.CurrentMana.ToString("F0"));
                maxMana.text = (playerManaManager.MaxMana.ToString("F0"));
                magicPower.text = (playerStats.PlayerMagicPower.ToString("F1"));
                fireProficiency.text = (playerStats.PlayerFireProficiency.ToString("F1"));
                windProficiency.text = (playerStats.PlayerWindProficiency.ToString("F1"));
                activeQuest.SetActive(false);
                PauseGame();
                Inventory.SetActive(true);
                HUD.SetActive(false);
                InventoryOpened = true;
            }
        }
    }

    /**
    * GoToMainMenu method to handle switching to main menu scene
    * @return void
    */
    public void GoToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    /**
    * ExitGame method to handle exiting the game
    * @return void
    */
    public void ExitGame()
    {
        Application.Quit();
    }

    /**
    * PauseGame method to handle pausing the game
    * Stops time, sets cursor to visible and disables players ability to attack
    * @return void
    */
    public void PauseGame()
    {
        Time.timeScale = 0f;
        GameIsPaused = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        weaponController.canAttack = false; 
    }

    /**
    * ResumeGame method to handle resuming the game
    * Resumes time, sets cursor to invisible and allows players to attack
    * @return void
    */
    public void ResumeGame()
    {
        Time.timeScale = 1f;
        GameIsPaused = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        weaponController.canAttack = true;
    }

    /**
    * UpdateSkills method to update skill levels
    * @return void
    */
    public void UpdateSkills()
    {
        XP.text = (playerStats.PlayerXP.ToString());
        fireBallLVLText.text = (fireBall.fireBallLVL.ToString());
        fireZoneLVLText.text = (fireZone.fireZoneLVL.ToString());
        fireBarrierLVLText.text = (fireBarrier.fireBarrierLVL.ToString());
        windPushLVLText.text = (windPush.windPushLVL.ToString());
        windTornadoLVLText.text = (windTornado.windTornadoLVL.ToString());
        windAreaPushLVLText.text = (windAreaPush.windAreaPushLVL.ToString());
    }

    /**
    * SaveGame method to handle saving the game
    * @return void
    */
    public void SaveGame()
    {
        DataPersisteneManager.instance.SaveGame();
    }

    /**
    * GoToMainMenu method to handle loading the game
    * @return void
    */
    public void LoadGame()
    {
        DataPersisteneManager.instance.LoadGame();
    }
}
