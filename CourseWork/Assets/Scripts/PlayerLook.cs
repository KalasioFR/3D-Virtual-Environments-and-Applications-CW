 using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public Camera cam;
    private float xRotation = 0f;
    public float xSensivity = 20f;
    public float ySensivity = 20f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    
    public void ProcessLook(Vector2 input)
    {
        float mouseX = input.x;
        float mouseY = input.y;

        xRotation -= (mouseY * Time.deltaTime) * ySensivity;
        xRotation = Mathf.Clamp(xRotation, -90, 90f);

        cam.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        transform.Rotate(Vector3.up * (mouseX * Time.deltaTime) * xSensivity);
    }
}
