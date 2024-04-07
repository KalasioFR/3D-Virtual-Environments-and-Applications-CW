using UnityEngine;

public class InputManager : MonoBehaviour
{
    private PlayerInputs playerInput;
    private PlayerInputs.OnFootActions onFoot;
    private PlayerMotor motor;
    private PlayerLook look;

    void Awake()
    {
        playerInput = new PlayerInputs();
        onFoot = playerInput.OnFoot;

        motor = GetComponent<PlayerMotor>();
        look = GetComponent<PlayerLook>();

        onFoot.Sprint.started += ctx => motor.Sprint();
        onFoot.Sprint.canceled += ctx => motor.Sprint();
        onFoot.Jump.performed += ctx => motor.Jump();
    }

    void FixedUpdate()
    {
        motor.ProcessMove(onFoot.Movement.ReadValue<Vector2>());
    }

    private void LateUpdate()
    {
        look.ProcessLook(onFoot.Look.ReadValue<Vector2>());
    }

    private void OnEnable()
    {
        onFoot.Enable();
    }

    private void OnDisable()
    {
        onFoot.Disable();
    }
}
