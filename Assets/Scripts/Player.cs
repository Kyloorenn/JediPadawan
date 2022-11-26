using UnityEngine;
using System.Collections;
using System;
using System.Diagnostics;
using UnityEngine.SceneManagement;
using System.Collections.Specialized;
using System.Runtime.InteropServices;
using System.Threading;


public class Player : MonoBehaviour
{
    [SerializeField] float speed = 1f;
    [SerializeField] BaseWeapon[] weapons;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Animator animator;
    [SerializeField] GameObject levelUpMenu;
    [SerializeField] GameObject GamePauseMenu;
    //[SerializeField] GameObject Wind;
    [SerializeField] GameObject levelUpError;
    [SerializeField] GameObject InventoryManager;
    [SerializeField] GameObject Settlement;
    // Make a material field
    public Material material;
    PlayerCamera playerCamera;
    public bool IsInvincible = false;
    public int PlayerHealth;
    public int maxHP = 100;
    public int currentEXP = 0;
    public int expToLevel = 200;
    public int currentLevel = 0;
    public AudioSource LevelUpMusic;
    public float maxstamina = 30f;
    public float currentstamina;
    private bool isdashing = false;
    public int coins = 0;
    public float forceValue;
    public float maxForce = 100;
    public bool forceEnough = true; // check if there has enough force value to cast a spell.
    public bool isParry = false; //check if player is using barrier or not.
    public float forceRestore = 8;
    public float forceRestoreRe = 8;  //record forceRestore;
    public int controlForceLv = 0; // permanent passive upgrade to decrease the cost of forceValue and the damage of force skill.
    public int EnhancedHealth = 0; //plus 30 health each level
    public int ForceTalent = 0; // get a random skill upgrade at the beginning of game.
    public int SaberMax = 4;
    public int ThrowMax = 3;
    public bool inventoryOpen; //Inventory is open by pressing KeyCode "B".
    public float killingStreak;





    void OnTriggerEnter2D(Collider2D collision)
    {
        Parry parry = GetComponent<Parry>();
        Enemy enemy = GetComponent<Enemy>();
        if (collision.gameObject.tag == "Enemy")
        {
            if (!IsInvincible)
            {
                StartCoroutine(Invincible());
                if (isParry == true)
                {
                    PlayerHealth -= 15;
                }
                else
                {
                    PlayerHealth -= 20;
                }
               
                UnityEngine.Debug.Log("Get Hit.");
                if (PlayerHealth <= 0)
                {
                     Titlemanage.saveData.goldCoins = coins;
                    Time.timeScale = 0.00001f;
                    Settlement.SetActive(true);
                    
                }
            }



        }
        
            if (collision.gameObject.tag == "Restore")
        {
            if (PlayerHealth < maxHP)
            {
                PlayerHealth += (int)(0.25 * maxHP);
                if (PlayerHealth > maxHP)
                {
                    PlayerHealth = maxHP;
                }
                UnityEngine.Debug.Log("Get Healed..");
                playerCamera.GetHealed();
            }
        }
        if (collision.gameObject.tag == "GoldRestore")
        {
            if (PlayerHealth < maxHP)
            {
                PlayerHealth += (int)(0.5 * maxHP);
                if (PlayerHealth > maxHP)
                {
                    PlayerHealth = maxHP;
                }
                UnityEngine.Debug.Log("Get Healed..");
                playerCamera.GetHealed();
            }
        }
        if (collision.gameObject.tag == "Projectile")
        {
            if (!IsInvincible)
            {
                StartCoroutine(Invincible());
                PlayerHealth -= 10;

                UnityEngine.Debug.Log("Get Hit.");
                if (PlayerHealth <= 0)
                {
                    Titlemanage.saveData.goldCoins = coins;
                    Time.timeScale = 0.00001f;
                    Settlement.SetActive(true);
                }
            }
        }
    }
    public float GetHPRatio()
    {
        return (float)PlayerHealth/maxHP;
    }
    IEnumerator Invincible()
    {
        IsInvincible = true;
        //spriteRenderer.color = UnityEngine.Color.red;
        material.SetFloat("_Flash", 0.4f);
        yield return new WaitForSeconds(0.3f);
        material.SetFloat("_Flash", 0f);
        // spriteRenderer.color = UnityEngine.Color.white;
        yield return new WaitForSeconds(0.4f);
        IsInvincible = false;
    }
    // color lerp after player chooses skill upgrade 
    IEnumerator AfterUpgrade()
    {
        material.SetFloat("_Upgrade", 0.2f);
        yield return new WaitForSeconds(0.3f);
        material.SetFloat("_Upgrade", 0.4f);
        yield return new WaitForSeconds(0.3f);
        material.SetFloat("_Upgrade", 0.6f);
        yield return new WaitForSeconds(0.3f);
        material.SetFloat("_Upgrade", 0.8f);
        yield return new WaitForSeconds(0.3f);
        material.SetFloat("_Upgrade", 1f);
        yield return new WaitForSeconds(0.6f);
        material.SetFloat("_Upgrade", 0.8f);
        yield return new WaitForSeconds(0.3f);
        material.SetFloat("_Upgrade", 0.6f);
        yield return new WaitForSeconds(0.3f);
        material.SetFloat("_Upgrade", 0.4f);
        yield return new WaitForSeconds(0.3f);
        material.SetFloat("_Upgrade", 0.2f);
        yield return new WaitForSeconds(0.3f);
        material.SetFloat("_Upgrade", 0f);        
    }
    //control the shader parameter killingSpree by coroutine
    IEnumerator StreakDown()
    {
        while (true)
        {              
                yield return new WaitForSeconds(2.5f);
            if(killingStreak >= 1)
            {
                killingStreak--;
            }                                    
        }      
    }
    
        //Button Settings
        public void OnUpgrade1Click()
    {   
        if(SaberMax > 0)
        {
            weapons[0].LevelUP();
            Time.timeScale = 1;
            levelUpMenu.SetActive(false);
            SaberMax--;
            StartCoroutine(AfterUpgrade());
        }
        else
        {
            levelUpError.SetActive(true);
        }
       
    }
    public void OnUpgrade2Click()
    {
        weapons[2].LevelUP();
        Time.timeScale = 1;
        levelUpMenu.SetActive(false);
        StartCoroutine(AfterUpgrade());
    }
    public void OnUpgrade3Click()
    {
        weapons[1].LevelUP();
        Time.timeScale = 1;
        levelUpMenu.SetActive(false);
        StartCoroutine(AfterUpgrade());
    }
    public void OnUpgrade4Click()
    {
        if (ThrowMax  > 0)
        {
            weapons[3].LevelUP();
            Time.timeScale = 1;
            levelUpMenu.SetActive(false);
            StartCoroutine(AfterUpgrade());
        }
        else
        {
            levelUpError.SetActive(true);
        }
    }
    public void OnContinueClick()
    {
        Time.timeScale = 1;
        GamePauseMenu.SetActive(false);
    }
    public void OnQuitClick()
    {
        Titlemanage.saveData.goldCoins = coins;
        SceneManager.LoadScene("Title");
    }
    private void Start()
    {   
        //persistence
        coins = Titlemanage.saveData.goldCoins;
          controlForceLv = Titlemanage.saveData.controlForceLv;
          EnhancedHealth = Titlemanage.saveData.EnhancedHealth;
          ForceTalent = Titlemanage.saveData.ForceTalent;
        maxHP += Titlemanage.saveData.EnhancedHealth * 30;
        //other initialize
        InventoryManager.SetActive(false);
        playerCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<PlayerCamera>(); //use method from PlayerCamera;
        PlayerHealth = maxHP;
        animator = GetComponent<Animator>();
        weapons[0].LevelUP();
        weapons[2].LevelUP();
        forceValue = maxForce;
        maxstamina += EnhancedHealth * 30;
        currentstamina = maxstamina;

        StartCoroutine(StreakDown());
        Settlement.SetActive(false);

        for (int i = 0; i < ForceTalent ; i++)
        {
            int randomIndex = UnityEngine.Random.Range(0, 3);
            weapons[randomIndex].LevelUP();
        }

        //Assign the material from the sprite renderer to your field
        material = spriteRenderer.material;
    }
    //gain EXP and level-up(Increase maxhealth)
    public void AddExp()
    {
        currentEXP += 20;
        if (currentEXP >= expToLevel)
        {
            currentEXP = 0;
            expToLevel += 120;
            currentLevel++;
            LevelUpMusic.Play();
            maxHP += 20;
            PlayerHealth += 20;
            
            levelUpMenu.SetActive(true);
            Time.timeScale = 0;
        }
    }
    //collect coins
    public void AddCoin(int i)
    {        
        coins+= i;
    }
    //Open Inventory
    public void OpenInventory()
    {
        InventoryManager.SetActive(true);
        inventoryOpen = true;
        Time.timeScale = 0.00001f;
    }
    public void CloseInventory()
    {
        InventoryManager.SetActive(false);
        inventoryOpen = false;
        Time.timeScale = 1;
    }
    void Update()
    {   
        //change main camera's lensblur when the game is paused
        if(Time.timeScale == 1)
        {
            playerCamera.NormalLensBlur();
        }
        else if (Time.timeScale == 0)
        {
            playerCamera.LensBlur();
        }
        //save coins
        Titlemanage.saveData.goldCoins = coins;
        //Player Move 
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");
        forceValue += Time.deltaTime * forceRestore;
        
        transform.position += new Vector3(inputX, inputY) * speed * Time.deltaTime;
        if (inputX != 0)
        {        
            //transform.localScale = new Vector3(inputX > 0 ? -1 : 1, 1, 1);
            transform.rotation = Quaternion.Euler(0, inputX > 0 ? 180: 0, 0);
        }
        
        bool isRunning = false;

        if(inputX != 0 || inputY != 0)
        {
            isRunning  = true;
        }

        // Player Accelerate
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {   
           isdashing = true;
            //Wind.SetActive(true);
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {                               
           speed = currentstamina > 0 ? 8:4;                                
        }
       
      if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            isdashing = false;
            speed = 4;
            //Wind.SetActive(false);
        }

        if(isdashing == true)
        {
            currentstamina -= (Time.deltaTime * 10);
        }
        else
        {
            currentstamina += (Time.deltaTime * 5);
        }
        if(currentstamina < 0)
        {
            currentstamina = 0;
        }
        if(currentstamina > maxstamina)
        {
            currentstamina = maxstamina;
        }
        if (forceValue < 0)
        {
            forceValue = 0;
        }
        if (forceValue > maxForce)
        {
            forceValue = maxForce;
        }

        if (forceValue == 0)
        {
            forceEnough = false;
        }
        else
        {
            forceEnough = true;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            forceRestore = 0;
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            forceRestore = forceRestoreRe;
        }
            // change player animation
            animator.SetBool("IsRunning",isRunning );

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;
            GamePauseMenu.SetActive(true);
        }
        //Open inventory with KeyCode "B"
        if (Input.GetKeyDown(KeyCode.B) && inventoryOpen == false)
        {
            OpenInventory();
            
        }
        else if(Input.GetKeyDown(KeyCode.B)&& inventoryOpen == true)
        {
            CloseInventory();
           
        }
        material.SetFloat("_KillingSpree",killingStreak);
       
        
    }
}
