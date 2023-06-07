using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public PlayerPhysicsManager PlayerPhysicsManager;

    public float Basicforce;

    public float AirControlDivider = 2f;

    public float CurrentForce;

    public bool isController;

    public GameObject Camera;

    private void Start()
    {
        this.isController = false;
        this.CurrentForce = this.Basicforce;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.CurrentForce = !this.PlayerPhysicsManager.isGrounded ? this.Basicforce / this.AirControlDivider : this.Basicforce;

        this.gameObject.transform.position = this.PlayerPhysicsManager.PlayerPhysic.gameObject.transform.position;

        for (int i = 0; i < 20; i++)
        {
            KeyCode code = (KeyCode)System.Enum.Parse(typeof(KeyCode), "JoystickButton" + i, true);

            if (Input.GetKeyDown(code))
            {
                this.isController = true;
                Debug.Log("controller");
            }
        }

        if (this.isController)
        {
            float horizontalInput = Input.GetAxis("Vertical");
            this.PlayerPhysicsManager.PlayerPhysic.AddForce(horizontalInput * this.Camera.transform.forward * this.CurrentForce);

            float verticalInput = Input.GetAxis("Horizontal");
            this.PlayerPhysicsManager.PlayerPhysic.AddForce(verticalInput * this.Camera.transform.right * this.CurrentForce);
        }

        if (Input.GetKey(KeyCode.A))
        {
            this.isController = false;
            this.PlayerPhysicsManager.PlayerPhysic.AddForce(-this.Camera.transform.right * this.CurrentForce);
        }
        if (Input.GetKey(KeyCode.S))
        {
            this.isController = false;
            this.PlayerPhysicsManager.PlayerPhysic.AddForce(-this.Camera.transform.forward * this.CurrentForce);
        }
        if (Input.GetKey(KeyCode.D))
        {
            this.isController = false;
            this.PlayerPhysicsManager.PlayerPhysic.AddForce(this.Camera.transform.right * this.CurrentForce);
        }
        if (Input.GetKey(KeyCode.W))
        {
            this.isController = false;
            this.PlayerPhysicsManager.PlayerPhysic.AddForce(this.Camera.transform.forward * this.CurrentForce);
        }
    }
}
