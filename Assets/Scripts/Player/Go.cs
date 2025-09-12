using UnityEngine;
using UnityEngine.InputSystem;

public class Go : MonoBehaviour
{
    [SerializeField] private float _speed = 1;
    private Vector2 _position;
    private GeneralActions _inputActions;

    private void Awake()
    {
        _inputActions = new GeneralActions();
    }

    private void OnEnable()
    {
        _inputActions.Enable();
        _inputActions.Move.Go.performed += ReadMove;
        _inputActions.Move.Go.canceled += ReadMove;
    }
    private void OnDisable()
    {
        _inputActions.Move.Go.performed -= ReadMove;
        _inputActions.Move.Go.canceled -= ReadMove;
        _inputActions.Disable();
    }

    private void ReadMove(InputAction.CallbackContext callbackContext)
    {
        _position = callbackContext.ReadValue<Vector2>();
    }

    private void Update()
    {
        transform.Translate(new Vector3(_position.x, 0, _position.y) * Time.deltaTime * _speed);
    }
}
