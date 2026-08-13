using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody _rb;
    InputAction _moveAction;
    InputAction _jumpAction;
    int jumpHeight = 10;
    Vector3 _jumpUp;
    float speed = 4;

    bool on_floor = false;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _moveAction = InputSystem.actions.FindAction("Move");
        _jumpAction = InputSystem.actions.FindAction("Jump");
        _jumpUp = Vector3.up * jumpHeight;
    }

    void Update()
    {
        if(_moveAction.IsPressed())
        {
            var movVal = _moveAction.ReadValue<Vector2>();
            var mov = new Vector3(movVal.x, 0f, movVal.y);
            mov *= (speed * Time.deltaTime);
            transform.Translate(mov, Space.World);
        }


        if (_jumpAction.WasPressedThisFrame() && on_floor == true)
        {
            _rb.AddForce(_jumpUp, ForceMode.Impulse);
            on_floor = false;
        }
    }

    void OnCollisionEnter(Collision rect)
    {
        if (rect.collider.CompareTag("Ground"))
        {
            on_floor = true;
        }
    }
}
