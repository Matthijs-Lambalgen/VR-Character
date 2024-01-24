using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class NetworkPlayer : NetworkBehaviour
{
    public Transform head;
    public Transform leftHand;
    public Transform righthand;

    [Range(0, 1)]
    public float turnSmoothness = 0.1f;
    public Vector3 headBodyPositionOffset;
    public float headBodyYawOffset;

    public Renderer[] meshToDisable;

    public override void OnNetworkDespawn()
    {
        base.OnNetworkDespawn();
        if (IsOwner)
        {
            foreach (var item in meshToDisable)
            {
                item.enabled = false;
            }
        }
    }

    void Update()
    {
        if (IsOwner)
        {
            head.position = VRRigReferences.Singleton.head.position;
            head.rotation = VRRigReferences.Singleton.head.rotation;

            leftHand.position = VRRigReferences.Singleton.leftHand.position;
            leftHand.rotation = VRRigReferences.Singleton.leftHand.rotation;

            righthand.position = VRRigReferences.Singleton.righthand.position;
            righthand.rotation = VRRigReferences.Singleton.righthand.rotation;

            transform.position = head.position + headBodyPositionOffset;
            float yaw = head.eulerAngles.y;
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(transform.eulerAngles.x, yaw, transform.eulerAngles.z), turnSmoothness);
        }
    }
}
