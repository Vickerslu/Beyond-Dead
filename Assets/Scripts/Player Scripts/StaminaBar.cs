using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// https://www.youtube.com/watch?v=pfdPXrw4Cbo&t=114s
public class StaminaBar : MonoBehaviour
{
    private InputActions playerInput;

    public Slider staminaBar;

    private float maxStamina = 100f;
    private float stamina;

    [SerializeField] float regenAmount;
    [SerializeField] float useAmount;

    private WaitForSeconds regenTick = new WaitForSeconds(0.0025f);
    private Coroutine regen;

    public PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        GameObject playerObject = GameObject.Find("Player");
        player = playerObject.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Awake()
    {
        playerInput = new InputActions();
        stamina = maxStamina;
        staminaBar.value = maxStamina;
    }

    void Update()
    {
        if(playerInput.Player.SprintStart.triggered) {
            player.isSprinting = true;
            if(regen != null) {
                StopCoroutine(regen);
            }
            regen = StartCoroutine(UseStamina(useAmount));
        }
        if(playerInput.Player.SprintFinish.triggered) {
            player.isSprinting = false;
            if(regen != null) {
                StopCoroutine(regen);
            }
            regen = StartCoroutine(RegenStamina(regenAmount));
        }
    }

    private void OnEnable(){
        playerInput.Enable();
    }

    void OnDisable(){
        playerInput.Disable();
    }

    private IEnumerator RegenStamina(float amount) {
        yield return new WaitForSeconds(0.75f);
        while(stamina < maxStamina) {
            stamina += amount;
            staminaBar.value = stamina;
            yield return regenTick;
        }
    }

    private IEnumerator UseStamina(float amount) {
        while(stamina - amount >= 0) {
            stamina -= amount;
            staminaBar.value = stamina;
            yield return regenTick;
        }
        player.isSprinting = false;
    }

    public void ExtendBar() {
        RectTransform rt = this.GetComponent<RectTransform>();
        rt.sizeDelta = new Vector2 (rt.rect.width*1.5f, rt.rect.height);
        maxStamina = maxStamina*2f;
        staminaBar.maxValue = maxStamina;
        staminaBar.value = maxStamina;
    }
}
