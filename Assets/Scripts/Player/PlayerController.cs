using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{

    Rigidbody rb;

    public float movementSpeed = 4;
    public float movementSpeedWhileShoot = 4;
    private Vector3 moveVelocity;
    Vector3 lookPos;

    private Camera mainCamera;

    public GunController gun;

    public bool useController;

    public GameObject crosshair;
    public GameObject crosshairController;
    public Transform crosshairPos;

    public Animator playerAnimator;

    Transform cam;
    Vector3 camForward;
    Vector3 move;
    Vector3 moveInput;
    float forwardAmount;
    float turnAmount;


    //Dash
    public float dashSpeed;
    public bool isDashing;
    public bool canDash;
    public float currentDashCD;
    public float dashCD;
    private Vector3 moveVelocityDash;
    public Slider dashSlider;
    public GameObject dashParticles;
    public GameObject head;

    //HP 
    public Slider healthSlider;
    public TextMeshProUGUI healthText;

    //Pause
    public bool pauseEnabled;
    public GameObject pauseMenu;
    public GameObject gameCanvas;
    public GameObject continueButton;

    //Upgrades
    public bool isUpgrading;
    public LevelLoader levelLoader;

    public EventSystem eventSystem;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        useController = true;
        healthSlider.value = GameManager.playerHealth;
        healthText.text = GameManager.playerHealth.ToString();
        rb = GetComponent<Rigidbody>();
        mainCamera = Camera.main;
        canDash = false;
        cam = mainCamera.transform;
    }
    public void SetPlayerLevels()
    {
        gun.bulletDamage = 1 + GameManager.currentPlayerAttackLevel;
        gun.cadency = 0.25f - GameManager.currentPlayerCadency * 0.02f;
        if(gun.cadency <= 0.05f)
        {
            gun.cadency = 0.05f;
        }
        movementSpeed = 1 + GameManager.currentPlayerMovementSpeed * 0.25f;
        movementSpeedWhileShoot = 0.75f + +GameManager.currentPlayerMovementSpeed * 0.15f;
        playerAnimator.SetFloat("AnimationsSpeed", 1 + GameManager.currentPlayerMovementSpeed * 0.25f);
        GameObject[] bullets = GameObject.FindGameObjectsWithTag("PlayerBullets");
        foreach (GameObject bullet in bullets)
        {
            bullet.transform.localScale = new Vector3(0.03f + GameManager.currentPlayerBulletSize * 0.01f, 0.03f + GameManager.currentPlayerBulletSize * 0.01f, 0.03f + GameManager.currentPlayerBulletSize * 0.01f);
            bullet.SetActive(false);
        }
        healthSlider.maxValue = GameManager.maxHealth;
        healthSlider.value = GameManager.playerHealth;
        healthText.text = healthSlider.value.ToString();
    }



    // Update is called once per frame
    void Update()
    {
        if (isUpgrading==false)
        {
            if (pauseEnabled == false)
            {
                Movement();
                if (!useController)
                {
                    crosshair.SetActive(true);
                    crosshairController.SetActive(false);
                    LookPC();
                    ShootPC();
                    crosshairPC();
                    MakeDashPC();
                }
                else
                {
                    crosshair.SetActive(false);
                    crosshairController.SetActive(true);
                    LookController();
                    ShootController();
                    MakeDashController();
                }

                if (!isDashing)
                    currentDashCD -= Time.deltaTime;
                dashSlider.value = 2 - currentDashCD;
                if (currentDashCD <= 0)
                {
                    dashSlider.value = 2;
                    canDash = true;
                }
            }
            Pause();
        }
        
    }

    public void Pause()
    {
        if(Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown("joystick button 7"))
        {
            //check if game is already paused        
            if (pauseEnabled == true)
            {
                //unpause the game
                pauseEnabled = false;
                Time.timeScale = 1;
                Cursor.visible = false;
                pauseMenu.gameObject.SetActive(false);
                gameCanvas.gameObject.SetActive(true);
                AudioManager.instance.PlaySFX4("ButtonPress");
            }

            //else if game isn't paused, then pause it
            else if (pauseEnabled == false)
            {
                pauseEnabled = true;
                Time.timeScale = 0;
                Cursor.visible = true;
                eventSystem.SetSelectedGameObject(continueButton);
                pauseMenu.gameObject.SetActive(true);
                gameCanvas.gameObject.SetActive(false);
                AudioManager.instance.PlaySFX4("ButtonPress");
            }
        }
    }

    public void PauseOff()
    {
        pauseEnabled = false;
        Time.timeScale = 1;
        Cursor.visible = false;
        pauseMenu.gameObject.SetActive(false);
        gameCanvas.gameObject.SetActive(true);
        AudioManager.instance.PlaySFX4("ButtonPress");
    }

    private void MakeDashController()
    {
        if (Input.GetAxisRaw("R1") > 0.0f || Input.GetAxisRaw("L1") > 0.0f)
        {
            if (canDash==true)
            {
                StartCoroutine(Dashing());
                currentDashCD = dashCD;
                canDash = false;
            }
        }
    }

    private void MakeDashPC()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetMouseButtonDown(2))
        {
            if (canDash == true)
            {
                StartCoroutine(Dashing());
                currentDashCD = dashCD;
                canDash = false;
            }
        }
    }

    public void Movement()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(horizontal, 0, vertical).normalized;

        if (gun.isFiring == false)
        {
            moveVelocity = movement * movementSpeed;
            moveVelocityDash=moveVelocity;
        }
        else
        {
            moveVelocity = movement * movementSpeedWhileShoot;
            moveVelocityDash = moveVelocity*1.17f;
        }

        if (cam != null)
        {
            camForward = Vector3.Scale(cam.up, new Vector3(1, 0, 1)).normalized;
            move = vertical * camForward + horizontal * cam.right;
        }
        else
        {
            move = vertical * Vector3.forward + horizontal * Vector3.right;
        }

        Move(move);

    }

    private void Move(Vector3 move)
    {
        if (move.magnitude > 1)
        {
            move.Normalize();
        }

        moveInput = move;

        ConvertMoveInput();
        UpdateAnimator();
    }

    private void ConvertMoveInput()
    {
        Vector3 localMove = transform.InverseTransformDirection(moveInput);
        turnAmount = localMove.x;

        forwardAmount = localMove.z;
    }

    private void UpdateAnimator()
    {
        playerAnimator.SetFloat("SpeedVertical", forwardAmount, 0.1f, Time.deltaTime);
        playerAnimator.SetFloat("SpeedHorizontal", turnAmount, 0.1f, Time.deltaTime);
    }


    public void LookPC()
    {
        if (!isDashing)
        {
            Vector3 positionOnScreen = mainCamera.WorldToViewportPoint(transform.position);
            Vector3 mouseOnScreen = (Vector2)mainCamera.ScreenToViewportPoint(Input.mousePosition);

            Vector3 direction = mouseOnScreen - positionOnScreen;

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90.0f;
            transform.rotation = Quaternion.Euler(new Vector3(0, -angle, 0));
        }
    }

    private void crosshairPC()
    {
        Vector3 pos = Input.mousePosition;
        pos.z = 1;
        crosshair.gameObject.transform.position = pos;
    }

    public void LookController()
    {
        Vector3 playerDirection = Vector3.right * Input.GetAxisRaw("RHorizontal") + Vector3.forward * (-Input.GetAxisRaw("RVertical"));
        if (!isDashing)
        {
            Vector3 movement = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
            if (playerDirection.sqrMagnitude > 0.1f)
            {
                transform.rotation = Quaternion.LookRotation(playerDirection, Vector3.up);
                crosshairController.SetActive(true);
            }
            else
            {
                crosshairController.SetActive(false);
                gun.isFiring = false;
                playerAnimator.SetBool("Shoot", false);
                if (moveVelocity != Vector3.zero)
                {
                    transform.rotation = Quaternion.LookRotation(movement, Vector3.up);
                }
            }
        }
        crosshairController.gameObject.transform.localPosition = crosshairPos.position + (playerDirection * 1.2f);
    }

    private void ShootController()
    {
        if (!isDashing)
        {
            if (Input.GetAxisRaw("R2") > 0.0f || Input.GetAxisRaw("L2") > 0.0f)
            {
                gun.isFiring = true;
                playerAnimator.SetBool("Shoot", true);
            }
            else if (Input.GetAxisRaw("R2") <= 0.0f || Input.GetAxisRaw("L2") <= 0.0f)
            {
                gun.isFiring = false;
                playerAnimator.SetBool("Shoot", false);
            }
        }
        else
        {
            gun.isFiring = false;
        }
    }



    public void ShootPC()
    {
        if (!isDashing)
        {
            if (Input.GetMouseButtonDown(0))
            {
                gun.isFiring = true;
                playerAnimator.SetBool("Shoot", true);
            }
            if (Input.GetMouseButtonUp(0))
            {
                gun.isFiring = false;
                playerAnimator.SetBool("Shoot", false);
            }
        }
        else
        {
            gun.isFiring = false;
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = moveVelocity;
    }

    IEnumerator Dashing()
    {
        isDashing = true;
        playerAnimator.SetBool("Dash", true);
        yield return new WaitForSeconds(0.1f);
        Instantiate(dashParticles,head.transform.position,transform.rotation);
        Vector3 movement = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        rb.AddForce(movement * dashSpeed, ForceMode.Impulse);
        AudioManager.instance.PlaySFX3("Dash");
        playerAnimator.SetBool("Dash", false);
        yield return new WaitForSeconds(0.5f);
        isDashing = false;

    }

    public void TakeDamage(int amount)
    {
        int r = UnityEngine.Random.Range(0, 3);
        if (r == 0)
        {
            AudioManager.instance.PlaySFX4("PlayerHurt");
        }
        else if (r == 1)
        {
            AudioManager.instance.PlaySFX4("PlayerHurt2");
        }
        else if (r == 2)
        {
            AudioManager.instance.PlaySFX4("PlayerHurt3");
        }
        GameManager.playerHealth -= amount;
        healthSlider.value = GameManager.playerHealth;
        healthText.text = GameManager.playerHealth.ToString();
        if (GameManager.playerHealth <= 0)
        {
            levelLoader.LoadLevel(0);
        }
    }
}
