using TMPro;
//using Unity.Android.Gradle.Manifest;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement & Camera")]
    [SerializeField] Camera playerCamera;
    [SerializeField] private float walkSpeed = 3f;
    [SerializeField] private float runSpeed = 7f;
    [SerializeField] private float jumpForce = 300f;
    private float lookSpeed = 2f;
    private float lookXLimit = 45f;
    Vector3 moveDirection = Vector3.zero;
    float rotationX = 0;
    public bool canMove = true;

    [Header("Pickup Related")]
    private bool isHolding;
    [SerializeField] private Transform playerHand;

    [Header("Ground/Jump")]
    private bool isGrounded;
    [SerializeField] private LayerMask groundLayer;
    private float groundCheckDistance = 1f;

    [Header("Script Related")]
    Rigidbody rb;
    

    void Start()
    {
        rb = GetComponent<Rigidbody>(); //finds character controller component
        Cursor.lockState = CursorLockMode.Locked; //locks and hides cursor
        Cursor.visible = false;
    }

    private void FixedUpdate()
    {
        Movement();
    }

    void Update()
    {
        Rotate();
        PickUp();
    }

    #region Handles Movment
    private void Movement()
    {
        isGrounded = IsGrounded();

        if (Input.GetKey(KeyCode.LeftShift))
        {
            walkSpeed = runSpeed;
        }
        else
        {
            walkSpeed = 3f;
        }

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 forward = Camera.main.transform.forward;
        Vector3 right = Camera.main.transform.right;
        forward.y = 0; // keeps the movement horizontal
        right.y = 0;
        forward.Normalize();
        right.Normalize();

        Vector3 movement = (forward * moveVertical + right * moveHorizontal).normalized;
        rb.MovePosition(transform.position + movement * walkSpeed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce);
        }
    }

    #endregion

    #region Handles Rotation
    private void Rotate()
    {
        if (canMove)
        {
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }
    }
    #endregion

    #region Handles PickUp
    private void PickUp()
    {
        if (Input.GetKeyDown(KeyCode.E) && isHolding == false)
        {
            HandleRayCast();
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            Drop();
        }
    }

    #endregion

    #region Handles RayCast
    void HandleRayCast()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 2f))
        {
            // Check if the hit object is interactive (tag or layer check, etc.)
            if (hit.collider.CompareTag("Cube"))
            {
                // Pickup the object
                PickupObject(hit.collider.gameObject);
                isHolding = true;
            }

        }
    }
    #endregion

    #region Handles Pickups
    void PickupObject(GameObject obj)
    {
        obj.GetComponent<Rigidbody>().isKinematic = true;
        obj.transform.SetParent(playerHand); // handTransform is the transform of the player's hand
        obj.transform.position = playerHand.position;

    }
    void Drop()
    {
        GameObject obj;
        obj = playerHand.transform.GetChild(0).gameObject;
        obj.GetComponent<Rigidbody>().isKinematic = false;
        playerHand.DetachChildren();
        isHolding = false;
    }

    #endregion


    bool IsGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, groundCheckDistance + 0.1f, groundLayer);
    }

void OnCollisionEnter(Collision collision)
    {
       
    }
}

