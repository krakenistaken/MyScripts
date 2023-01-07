using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float MoveSpeed;

    public float GroundDrag;

    [Header("Ground Check")]
    public float playerheight;
    public LayerMask WhatsGround;
    public bool grounded;

    public Transform Ori;

    float HoriInp;
    float VerInp;

    Vector3 MoveDirection;

    Rigidbody Rb;
    
    
    //
    void Start()
    {
        Rb = GetComponent<Rigidbody>();
        Rb.freezeRotation = false;
    }
    //
    private void FixedUpdate()
    {
        MovePlayer();    
    }
    //
    private void Update()
    {
        MyInp();
        //ground çeeeek
        grounded = Physics.Raycast(transform.position, Vector3.down, playerheight * 0.5f + 0.2f, WhatsGround);
        if (grounded)
            Rb.drag = GroundDrag;
        else
            Rb.drag = 0;

        speedcontrol();
    }
    //
    private void MyInp()
    {
        HoriInp = Input.GetAxisRaw("Horizontal");
        VerInp = Input.GetAxisRaw("Vertical");
    }
    //
    private void MovePlayer()
    {
        MoveDirection = Ori.forward * VerInp + Ori.right * HoriInp;
        Rb.AddForce(MoveDirection.normalized * MoveSpeed * 10f, ForceMode.Force);
    }
    //
    private void speedcontrol()
    {
        Vector3 FlatVel = new Vector3(Rb.velocity.x, 0f, Rb.velocity.z);

        if(FlatVel.magnitude > MoveSpeed)
        {
            Vector3 LimitedVel = FlatVel.normalized * MoveSpeed;
            Rb.velocity = new Vector3(LimitedVel.x, Rb.velocity.y, LimitedVel.z);
        }
    }
}
