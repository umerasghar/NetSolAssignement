using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeliController : MonoBehaviour
{
    public HeliComponents currentHeli;
    float forward=0, sideways=0, ascend=0, rotateFactor=0;
    bool isShoot = false;
    // Update is called once per frame
    void Update()
    {
        forward = Input.GetAxis("Vertical")*currentHeli.forward_force*Time.deltaTime;
        sideways = Input.GetAxis("Horizontal")*currentHeli.sideways_force*Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.R))
        {
            rotateFactor = currentHeli.rotation_force*Time.deltaTime;
        }
        if (Input.GetKeyUp(KeyCode.R))
        {
            rotateFactor = 0f;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ascend = currentHeli.ascend_force * Time.deltaTime;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            ascend = 0f;
        }
        if (Input.GetKey(KeyCode.LeftControl))
        {
            isShoot = true;
        }
    }
    private void FixedUpdate()
    {
        currentHeli.heliRigidBody.AddForce(new Vector3(sideways, ascend, forward));
        currentHeli.heliRigidBody.AddTorque(new Vector3(0f, rotateFactor, 0f));
        RaycastHit hit;
       if(Physics.Raycast(currentHeli.projectileShoot.localPosition, currentHeli.projectileShoot.forward,out hit)&&isShoot)
        {
            if (hit.collider.gameObject.tag.Equals("Enemy"))
            {
                Destroy(hit.collider.gameObject);
            }
            isShoot = false;
        }
    }

}
