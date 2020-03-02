using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

// MonoBevaior is the class that contains all Unity functionality
public class PlayerMovement : MonoBehaviour {
    // Regions are very useful for organizing your code
    #region Variables
    #region Editor Variables
    [SerializeField] // Serialize field lets you edit the value of a variable in the inspector
    private float speed;

    [SerializeField]
    [Tooltip("Are we using the old input system?")] // Tooltips can help explain what a variable means
    private bool oldInput;
    #endregion

    #region Private Variables
    private float xInput;
    private float yInput;
    #endregion

    #region Cached Components
    private Rigidbody2D playerRigidbody;
    #endregion
    #endregion

    #region Unity Functions
    // Awake is called as soon as the gameobject is created
    private void Awake() {
        playerRigidbody = GetComponent<Rigidbody2D>(); // Get Component gives you a reference to a component on the gameobject
    }

    // Start is called before the first frame update, but after awake
    private void Start() {

    }

    // Update is called once per frame
    private void Update() {
        if (oldInput) {
            xInput = Input.GetAxisRaw("Horizontal");
            yInput = Input.GetAxisRaw("Vertical");
        }
    }

    // FixedUpdate is called once per frame, and is used for physics updates. Put movement here!
    private void FixedUpdate() {
        moveFunction1();
        //moveFunction2();
        //moveFunction3();
    }
    #endregion

    #region Movement Functions
    private void moveFunction1() {
        Vector2 movementVector = new Vector2(xInput, yInput) * speed;
        playerRigidbody.AddForce(movementVector);
    }

    private void moveFunction2() {
        Vector2 movementVector = new Vector2(xInput, yInput) * speed * Time.fixedDeltaTime;
        playerRigidbody.MovePosition(playerRigidbody.position + movementVector);
    }

    private void moveFunction3() {
        Vector2 movementVector = new Vector2(xInput, yInput) * speed;
        playerRigidbody.velocity = movementVector;
    }
    #endregion

    #region New Input System
    private void OnMove(InputValue value) {
        if (!oldInput) {
            Vector2 moveVector = value.Get<Vector2>();

            xInput = moveVector.x;
            yInput = moveVector.y;
        }
    }
    #endregion
}
