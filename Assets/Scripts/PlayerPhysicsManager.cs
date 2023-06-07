using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPhysicsManager : MonoBehaviour
{
    public Rigidbody PlayerPhysic;

    public CapsuleCollider GroundedBox;

    public bool isGrounded;

    public float maxVelocity;

    public float velocity;

    public float speedMultiplier;

    private void Start()
    {
        this.isGrounded = false;
    }

    private void FixedUpdate()
    {
        if (!isGrounded)
        {
            this.PlayerPhysic.drag = 0f;
        }

        this.velocity = maxVelocity * speedMultiplier;

        PlayerPhysic.velocity = new Vector3(Mathf.Clamp(PlayerPhysic.velocity.x, -velocity, velocity), Mathf.Clamp(PlayerPhysic.velocity.y, -100000f, 100000f), Mathf.Clamp(PlayerPhysic.velocity.z, -velocity, velocity));
    }
}
