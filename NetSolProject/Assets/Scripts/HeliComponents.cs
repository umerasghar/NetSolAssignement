using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class HeliComponents
{
    public Rigidbody heliRigidBody;
    public float forward_force=0;
    public float rotation_force=0;
    public float sideways_force = 0;
    public float ascend_force = 0;
    public Transform projectileShoot;

}
