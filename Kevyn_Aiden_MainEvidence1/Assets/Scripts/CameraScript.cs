using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraScript : MonoBehaviour
{
   private PlayerControls controls;
   public float sens = 100f;
   private Vector2 mouseLook;
   private float xRotation = 0f;
   public Transform playerBody;

   void Awake()
   {
        controls = new PlayerControls();
        Cursor.lockState = CursorLockMode.Locked;
   }

    void Update()
    {
        Look();
    }

    private void Look()
    {
        mouseLook = controls.Player.Look.ReadValue<Vector2>();

        float mouseX = mouseLook.x * sens * Time.deltaTime;
        float mouseY = mouseLook.y * sens * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        playerBody.Rotate(Vector3.up * mouseX);
    }

   private void OnEnable()
   {
        controls.Enable();
   }

   private void onDisable()
   {
        controls.Disable();
   }
}
/*   

     References:
     1. [Code Bot]. (2021, February 2). Unity 3D - New Input System, First Person Control [Video]. Youtube.com. https://www.youtube.com/watch?v=w4IMYgpqgdQ

*/