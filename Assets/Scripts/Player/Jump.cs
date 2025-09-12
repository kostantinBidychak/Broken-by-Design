using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class Jump : MonoBehaviour
{
    [SerializeField] private float _speed = 1;
    private bool _isGrounded = false;

    private Rigidbody _rb;
    private GeneralActions _inputActions;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _inputActions = new GeneralActions();
    }

    private void OnEnable()
    {
        _inputActions.Enable();
        _inputActions.Move.Jump.performed += DoJump;
    }
    private void OnDisable()
    {
        _inputActions.Move.Jump.performed -= DoJump;
        _inputActions.Disable();
    }

    private void DoJump(InputAction.CallbackContext callbackContext)
    {
        if (_isGrounded)
        {
            _rb.AddForce(Vector3.up * _speed, ForceMode.Impulse);
            _isGrounded = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        _isGrounded=true;
    }
}
