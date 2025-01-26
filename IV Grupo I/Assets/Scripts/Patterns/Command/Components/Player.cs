using Patterns.Command.Interfaces;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour, IPlayerReceiver
{

    //private Vector3 _newPosition;

    //Movement
    public float speed = 10f;
    public float jump = 3f;
    public bool isSprinting;
    public float staminaUseAmount = 5;
    public float sprintingSpeedMultiplier = 1.5f;
    private float sprintSpeed = 1;
    public CharacterController characterController;

    //Collisions
    public Transform collision;
    public Transform collisionCeil;
    public float radius = 0.3f;
    public LayerMask collisionMask;
    bool isTouching;
    public float gravity = -9.8f;
    Vector3 velocity;

    //Stats
    public int HP = 100;
    public int HP_Max = 100;

    //UI
    private UIStamina staminaSlider;
    private Slider slider;

    //Audios
    public AudioSource caminar;
    public AudioSource salto;
    public AudioSource pocaVida;
    public AudioSource correr;
    public AudioSource dano;
    public AudioSource agotado;

    // interfaz
    GameObject sangre;


    private void Awake()
    {
        
        GameObject go = GameObject.FindGameObjectWithTag("Vida");
        slider = go.GetComponent<Slider>();
        staminaSlider = FindObjectOfType<UIStamina>();
        slider.maxValue = HP_Max;
        slider.value = HP;
        sangre = GameObject.FindGameObjectWithTag("Sangre");
    }

    public void SetHP(int HP)
    {
        this.HP = HP;
        slider.value = HP;
    }


    public void Jump()
    {
        isTouching = Physics.CheckSphere(collision.position, radius, collisionMask);


        if (isTouching)
        {
            velocity.y = Mathf.Sqrt(jump * -2 * gravity);
        }
    }

    public void MoveRight(float x)
    {
        Vector3 move = transform.right * x;

        characterController.Move(move * speed * Time.deltaTime * sprintSpeed);
        if (!caminar.isPlaying || isSprinting)
        {
            caminar.Play();
        }
    }

    public void MoveForward(float z)
    {

        Vector3 move = transform.forward * z;

        characterController.Move(move * speed * Time.deltaTime * sprintSpeed);
        if (!caminar.isPlaying || isSprinting)
        {
            caminar.Play();
        }
    }

    public void TakeDamage(int damage)
    {
        dano.Play();
        HP = Mathf.Max(0, HP - damage);
        slider.value = HP;
        if (HP <= 0)
        {
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene(2);
        }
        if (HP < 30)
        {
            pocaVida.Play();
            sangre.GetComponent<RawImage>().enabled = true;

        }
    }

    public void Health(int health)
    {
        HP = Mathf.Min(HP_Max, HP + health);
        slider.value = HP;

        if (HP > 30)
        {
            pocaVida.Stop();
            sangre.GetComponent<RawImage>().enabled = false;
        }
    }

    public void Sprint()
    {
        isSprinting = !isSprinting;

        if (isSprinting)
        {
            staminaSlider.UseStamina(staminaUseAmount);
            correr.Play();
            caminar.Stop();
        }

        else
        {
            staminaSlider.UseStamina(0);
            correr.Stop();
            if (staminaSlider.currentStamina < 10 && !agotado.isPlaying) { agotado.Play(); }
        }



    }

    void Update()
    {
        
        isTouching = Physics.CheckSphere(collision.position, radius, collisionMask);

        if (isSprinting)
        {
            sprintSpeed = sprintingSpeedMultiplier;
            if (!correr.isPlaying) correr.Play();
        }

        else
        {
            sprintSpeed = 1;
            if (correr.isPlaying) correr.Stop();
            if (staminaSlider.currentStamina < 10 && !agotado.isPlaying) { agotado.Play(); }
        }

        if (isTouching && velocity.y < 0)
        {
            velocity.y = -3f;
            
        }

        velocity.y += gravity * Time.deltaTime;

        characterController.Move(velocity * Time.deltaTime);

    }

}
