using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class GroundTypeManager : MonoBehaviour
{
    public PlayerPhysicsManager playerPhysicsManager;

    public GroundType[] groundType;

    private void OnTriggerStay(Collider other)
    {
        Debug.Log(other.gameObject.tag);
        switch (other.gameObject.tag)
        {
            case "Dirt":
                UpdatePhysicsParam(GroundTypeEnum.Dirt);
                break;
            case "Grass":
                UpdatePhysicsParam(GroundTypeEnum.Grass);
                break;
            case "Ice":
                UpdatePhysicsParam(GroundTypeEnum.Ice);
                break;
            case "Metal":
                UpdatePhysicsParam(GroundTypeEnum.Metal);
                break;
        }
    }

    private void UpdatePhysicsParam(GroundTypeEnum enumerator)
    {
        this.playerPhysicsManager.PlayerPhysic.drag = groundType[(int)enumerator].Friction;
        this.playerPhysicsManager.maxVelocity = groundType[(int)enumerator].MaxVelocity;
        this.playerPhysicsManager.isGrounded = true;
    }

    private void OnTriggerExit(Collider other)
    {
        this.playerPhysicsManager.isGrounded = false;
    }
}