using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIStamina : MonoBehaviour
{

    public Slider staminaSlider;

    public float maxStamina = 100;

    public float currentStamina;

    private float regenerateStaminaTime = 0.1f;
    private float regenerateAmount = 2;

    private float losingStaminaTime = 0.1f;

    private Coroutine myCoroutineLosing;

    private Coroutine myCoroutineRegenerate;

    void Start()
    {
        currentStamina = maxStamina;
        staminaSlider.maxValue = maxStamina;
        staminaSlider.value = maxStamina;
    }

    public void UseStamina(float amount)
    {
        if (currentStamina - amount > 0)
        {

            //if (myCoroutineRegenerate != null)
            //{
            //    StopCoroutine(myCoroutineRegenerate);
            //}

            if (myCoroutineLosing != null)
            {
                StopCoroutine(myCoroutineLosing);
            }


            myCoroutineLosing = StartCoroutine(LosingStaminaCoroutine(amount));

            if (myCoroutineRegenerate != null)
            {
                StopCoroutine(myCoroutineRegenerate);
            }

            myCoroutineRegenerate = StartCoroutine(RegenerateStaminaCoroutine());


        }
        else
        {
            FindObjectOfType<Player>().isSprinting = false;
        }
    }

    //public void StopStamina()
    //{

    //    if (myCoroutineLosing != null)
    //    {
    //        StopCoroutine(myCoroutineLosing);
    //    }
    //    if (myCoroutineRegenerate != null)
    //    {
    //        StopCoroutine(myCoroutineRegenerate);
    //    }

    //    myCoroutineRegenerate = StartCoroutine(RegenerateStaminaCoroutine());
    //}

    private IEnumerator LosingStaminaCoroutine(float amount)
    {
        while (currentStamina >= 0)
        {
            currentStamina -= amount;

            staminaSlider.value = currentStamina;

            yield return new WaitForSeconds(losingStaminaTime);
        }

        myCoroutineLosing = null;

        FindObjectOfType<Player>().isSprinting = false;
    }

    private IEnumerator RegenerateStaminaCoroutine()
    {

        yield return new WaitForSeconds(1);

        while (currentStamina < maxStamina)
        {
            currentStamina += regenerateAmount;
            staminaSlider.value = currentStamina;

            yield return new WaitForSeconds(regenerateStaminaTime);
        }

        myCoroutineRegenerate = null;

    }
}
