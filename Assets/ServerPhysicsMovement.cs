using UnityEngine;
using Unity.Netcode;
using Unity.Netcode.Components;

public class ServerPhysicsMovement : NetworkBehaviour
{

    public Rigidbody _rb;

    private Vector2 _inputVector;

    private Vector3 _vectorFuerza;

    private float _fuerza;

    

    private float _speed = 5f;

    // ...

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (!IsOwner)
        {
            return;
        }
        else
        {
            Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            AcceptMoveInputServerRpc(moveInput);
        }

    }

    [ServerRpc]
    public void AcceptMoveInputServerRpc(Vector2 moveInput)
    {
        // quickly validate and then accept input vector
        if (moveInput.sqrMagnitude > 1)
        {
            _inputVector = moveInput.normalized;
        }
        else
        {
            _inputVector = moveInput;
        }

    }

    public void AcceptForce(Vector3 direccion, float fuerza)
        { 
            _fuerza = fuerza;
            _vectorFuerza = direccion;
        }



    void FixedUpdate()
    {
        if (IsServer)
        {
            _rb.AddForce(_vectorFuerza * _fuerza, ForceMode.Impulse);
            _rb.velocity = new Vector3(_inputVector.x, 0, _inputVector.y) * _speed;
        }



    }




}