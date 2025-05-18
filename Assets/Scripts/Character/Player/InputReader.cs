using UnityEngine;

public class InputReader : MonoBehaviour
{
    private readonly string Horizontal = nameof(Horizontal);
    public float Direction { get; private set; }  
    public bool IsTryedToJump { get; private set; }

    private void Update()
    {
        Direction = Input.GetAxis("Horizontal");

        if (Input.GetKey(KeyCode.Space))
        {
            IsTryedToJump = true;
        }
    }
    public void ResetJumpState()
    {
        IsTryedToJump = false;
    }
}
