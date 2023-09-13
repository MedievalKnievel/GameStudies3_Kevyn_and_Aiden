using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    public float speed = 5.0f;
    public float weaponSpeed = 10f;
    public float jumpForce = 1.0f;
    private Vector2 movementInput;
    private bool grounded = true;
    private bool bubble = false;
    private bool pull;
    private PlayerControls controls;
    private CharacterController controller;
    private Vector3 velocity;
    private float gravity = -9.8f;
    public Transform ground;
    public float distanceToGround = 0.4f;
    private float fallspeed = -2f;
    public LayerMask groundMask;
    private Vector2 move;
    public GameObject weapon;
    public GameObject cam;
    public GameObject player;
    private Transform weaponTrans;
    public Rigidbody weaponRb;
    public GameObject startPos;
    private GameObject target;
    private GameObject destination;
    private bool hasWeapon = true;     

    void Awake()
    {
        controls = new PlayerControls();
        controller = GetComponent<CharacterController>();
        weaponRb = weapon.GetComponent<Rigidbody>();
        weaponRb.isKinematic = true;
    }
    
    void FixedUpdate()
    {
       Gravity();
       PlayerMovement();
       ObjMove();
       print(bubble);
    }

    public void onMove(InputAction.CallbackContext context)
    {
         move = context.ReadValue<Vector2>();
    }

    private void PlayerMovement()
    {
        Vector3 movement = (move.y * transform.forward) + (move.x * transform.right);
        controller.Move(movement * speed * Time.deltaTime);
    }

    public void onThrow(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            ThrowObject();
        }
    }

    public void onCatch(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            CatchObject();
        }
    }

    public void onJump(InputAction.CallbackContext context)
    {
        if(context.started && grounded)
        {
            velocity.y = Mathf.Sqrt(jumpForce * fallspeed * gravity);
        }
    }

    public void ThrowObject()
    {
        if(hasWeapon)
        {
        weaponRb.isKinematic = false;
        weapon.transform.SetParent(null);
        weaponRb.AddRelativeForce(Vector3.forward * 25f, ForceMode.Impulse);
        hasWeapon = false;
        }
    }

    public void CatchObject()
    {
        if(!hasWeapon)
        {
        if(!bubble)
        {
            weaponRb.isKinematic = true;
            target = weapon;
            destination = player;
            pull = true;
        }
        if(bubble && weaponRb.isKinematic)
        {
            controller.enabled = false;
            target = player;
            destination = weapon;
            pull = true;
        }
        }
    }


    private void Gravity()
    {
        grounded = Physics.CheckSphere(ground.position, distanceToGround, groundMask);

        if(bubble)
        {
            fallspeed = -2f;
        }
        if(!bubble)
        {
            fallspeed = -5f;
        }
        if(grounded && velocity.y < 0)
        {
            velocity.y = fallspeed;
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    private void ObjMove()
    {
        if(pull)
        {
        var step = weaponSpeed * Time.deltaTime;
        target.transform.position = Vector3.MoveTowards(target.transform.position, destination.transform.position, step);

         if(Vector3.Distance(target.transform.position, destination.transform.position) < 1f)
         {
            weapon.transform.position = startPos.transform.position;
            weapon.transform.rotation = startPos.transform.rotation;
            weapon.transform.SetParent(cam.transform);
            pull = false;
            controller.enabled = true;
            bubble = false;
            hasWeapon = true;
         }
    

        }
    }

    private void OnTriggerStay(Collider col)
    {
        if(col.gameObject.CompareTag("bubble"))
        {
            bubble = true;
        }else{ 
            bubble = false;
        }
    }

    private void OnTriggerExit(Collider col)
    {
        bubble = false;
    }

    private void OnEnable()
    {
        controls.Enable();
    }
    private void OnDisable()
    {
        controls.Disable();
    }
}
/*   

     References:
     1. [Code Bot]. (2021, February 2). Unity 3D - New Input System, First Person Control [Video]. Youtube.com. https://www.youtube.com/watch?v=w4IMYgpqgdQ

*/