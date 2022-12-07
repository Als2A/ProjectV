using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_HandBobCam : MonoBehaviour
{
    [Header("References")]
    Scr_PlayerMovement Player;

    [Space]

    [Header("BobHead")]
    public float IdleBob_Amount;
    public float IdleBob_Speed;
    [Space]
    public float WalkBob_Amount;
    public float WalkBob_Speed;
    [Space]
    public float SprintBob_Amount;
    public float SprintBob_Speed;
    [Space]
    private float BobDefaultY;
    public float BobTimer;

    // Start is called before the first frame update
    void Start()
    {
        Player = transform.parent.parent.GetComponent<Scr_PlayerMovement>();

        BobDefaultY = transform.localPosition.y;
    }

    // Update is called once per frame
    void Update()
    {
        HandBob();
    }

    public void HandBob()
    {
        if (!Player.isGrounded) return;

        BobTimer += Time.deltaTime * (Player.isSprinting ? SprintBob_Amount : Player.isWalking ? WalkBob_Amount : IdleBob_Amount);

        transform.localPosition = new Vector3(
        transform.localPosition.x, BobDefaultY + Mathf.Sin(BobTimer) * (Player.isSprinting ? SprintBob_Speed : Player.isWalking ? WalkBob_Speed : IdleBob_Speed),
        transform.localPosition.z);

    }
}
