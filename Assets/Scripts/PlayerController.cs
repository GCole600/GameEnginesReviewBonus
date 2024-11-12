using UnityEngine;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float playerSpeed = 2.0f;
    private float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;

    [SerializeField] private PluginTester pluginTester;
    
    public enum Direction
    {
        Left,
        Right
    }
    
    private void Start()
    {
        controller = gameObject.AddComponent<CharacterController>();
    }
    
    void Update()
    {
        playerSpeed = pluginTester.MovementSpeed;
        jumpHeight = pluginTester.JumpHeight;
        
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        // Makes the player jump
        if (Input.GetKey(KeyCode.Space) && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -2.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }

    public void Move(Direction direction)
    {
        switch (direction)
        {
            case Direction.Left:
                controller.Move(Vector3.left * (Time.deltaTime * playerSpeed));
                break;
            case Direction.Right:
                controller.Move(Vector3.right * (Time.deltaTime * playerSpeed));
                break;
        }
    }
}
