using Fusion;
using UnityEngine;
using NetworkRigidbody2D = Fusion.Addons.Physics.NetworkRigidbody2D;


public class PlayerMovement : NetworkBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;

    private Vector2 _moveInput;
    private Vector2 _moveVelocity;
    //[SerializeField] private Rigidbody2D _rb;
    [SerializeField] private NetworkRigidbody2D _rb;

    public override void Spawned()
    {
        if (!HasStateAuthority)
        {
            return;
        }
    }

    private void Awake()
    {
        
    }


    public override void FixedUpdateNetwork()
    {
        if (!HasStateAuthority)
        {
            return;
        }

        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        _moveInput = new Vector2(moveX, moveY).normalized;
        _moveVelocity = _moveInput * _moveSpeed;

        _rb.Rigidbody.MovePosition(_rb.Rigidbody.position + _moveVelocity * Time.fixedDeltaTime);
    }


}
