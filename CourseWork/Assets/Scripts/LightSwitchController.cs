using UnityEngine;

public class LightSwitchController : MonoBehaviour
{
    private bool isLightOn;
    private bool isFKeyPressed = false;
    public Light pointLight;
    public Animator animator;
    public GameObject lightSwitchButtonCanva;

    void Start()
    {
        animator = GetComponent<Animator>();
        pointLight.enabled = false;
        lightSwitchButtonCanva.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            isFKeyPressed = true;
        }
        if (Input.GetKeyUp(KeyCode.F))
        {
            isFKeyPressed = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        lightSwitchButtonCanva.SetActive(true);

        if (isFKeyPressed)
        {
            isFKeyPressed = false;

            if (isLightOn)
            {
                animator.SetBool("isLightOn", false);
                isLightOn = false;
                pointLight.enabled = false;
            }
            else
            {
                animator.SetBool("isLightOn", true);
                isLightOn = true;
                pointLight.enabled = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        lightSwitchButtonCanva.SetActive(false);
    }
}
