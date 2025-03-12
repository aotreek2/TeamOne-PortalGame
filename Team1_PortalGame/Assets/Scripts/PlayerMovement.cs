using TMPro;
//using Unity.Android.Gradle.Manifest;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement & Camera")]
    [SerializeField] Camera playerCamera;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float walkSpeed = 5f;
    [SerializeField] private float runSpeed = 10f;
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

    private void Update()
    {
        Movement();
        Rotate();
        PickUp();
    }

    #region Handles Movment
    private void Movement()
    {
        isGrounded = IsGrounded();

        if (Input.GetKey(KeyCode.LeftShift))
        {
            moveSpeed = runSpeed;
        }
        else
        {
            moveSpeed = walkSpeed;
        }

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 move = (transform.right * moveHorizontal + transform.forward * moveVertical).normalized;
        rb.MovePosition(rb.position + move * moveSpeed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
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
        float rayLength = 1f;
        Vector3 rayOrigin = transform.position;
        Debug.DrawRay(rayOrigin, Vector3.down, Color.red, rayLength);

        if (Physics.Raycast(rayOrigin, Vector3.down, rayLength, groundLayer))
        {
            return true;
        }

        return false;
    }

void OnCollisionEnter(Collision collision)
    {
       
    }
}

