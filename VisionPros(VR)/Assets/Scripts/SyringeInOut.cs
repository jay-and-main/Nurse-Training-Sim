using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SyringeInOut : MonoBehaviour
{
    public InputActionReference syringeIn;
    public InputActionReference syringeOut;
    public GameObject syringe;

    public GameObject plunger;
    void Start()
    {

    }
    void FixedUpdate()
    {
        if (syringe.activeSelf)
        {
            float syringeValueUp = syringeIn.action.ReadValue<float>();
            float syringeValueDown = syringeOut.action.ReadValue<float>();
            Vector3 plungerPosition = plunger.transform.localPosition;
            plungerPosition.y += syringeValueUp / 50;
            plungerPosition.y -= syringeValueDown / 50;
            plunger.transform.localPosition = plungerPosition;
        }
    }
}

