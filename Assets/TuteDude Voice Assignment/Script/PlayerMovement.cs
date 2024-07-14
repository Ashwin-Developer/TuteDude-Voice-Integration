using Agora_RTC_Plugin.API_Example.Examples.Basic.JoinChannelAudio;
using Fusion;
using UnityEngine;
using NetworkRigidbody2D = Fusion.Addons.Physics.NetworkRigidbody2D;


public class PlayerMovement : NetworkBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;

    private Vector2 _moveInput;
    private Vector2 _moveVelocity;

    [SerializeField] private NetworkRigidbody2D _rb;

    public override void Spawned()
    {
        if (!HasStateAuthority)
        {
            return;
        }
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

        _rb.Rigidbody.velocity = _moveVelocity;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            JoinChannelAudio.instance.JoinChannel();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            JoinChannelAudio.instance.LeaveChannel();
        }
    }
}
