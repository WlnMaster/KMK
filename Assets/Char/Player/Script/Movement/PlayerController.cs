using UnityEngine.InputSystem;
using UnityEngine;

public class PlayersMovement : MonoBehaviour
{
    public float walkspeed = 5f;
    
    Vector2 moveInput;

    private bool _isMoving = false;
    public bool IsMoving { get 
        { 
            return _isMoving; 
        
        } 
        private set
        { 
            _isMoving = value;
            anim.SetBool(AnimationStrings.isMoving, value);
        } 
    }

    Rigidbody2D rb;
    Animator anim;
   

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(moveInput.x * walkspeed * Time.fixedDeltaTime, rb.velocity.y);

        // Rotate the player based on movement
        if (rb.velocity.x > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0); // No rotation for right movement
        }
        else if (rb.velocity.x < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0); // Rotate 180 degrees for left movement
        }
        // Set the "isRunning" parameter in the Animator based on the moveInput
        
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();

        IsMoving = moveInput != Vector2.zero;
    }
    
    
}
