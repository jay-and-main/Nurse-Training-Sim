using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BedController : MonoBehaviour
{
    public InputActionReference bedActionUp;
    public InputActionReference bedActionDown;

    public GameObject bed;
    void Start()
    {

    }
    void FixedUpdate()
    {
        float bedValueUp = bedActionUp.action.ReadValue<float>();
        float bedValueDown = bedActionDown.action.ReadValue<float>();
        Vector3 bedPosition = bed.transform.position;
        if (bed.transform.position.y > 0.1f)
        {
            bed.transform.position = new Vector3(bedPosition.x, 0.1f, bedPosition.z);
        }
        if (bed.transform.position.y < 0.05f)
        {
            bed.transform.position = new Vector3(bedPosition.x, 0.05f, bedPosition.z);
        }
        bedPosition.y += bedValueUp / 50;
        bedPosition.y -= bedValueDown / 50;
        bed.transform.position = bedPosition;
    }
}
