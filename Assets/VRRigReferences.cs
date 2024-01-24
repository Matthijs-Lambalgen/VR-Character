using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRRigReferences : MonoBehaviour
{
    public static VRRigReferences Singleton;

    public Transform head;
    public Transform leftHand;
    public Transform righthand;

    private void Awake()
    {
        Singleton = this;
    }
}
