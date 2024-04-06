using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR; // Required for InputDevice
using UnityEngine.XR.Interaction.Toolkit; // Required for XRController

public class BedController : MonoBehaviour
{
    public GameObject objectToMove; // The GameObject to move
    public float yOffset = 0.01f; // The amount to move the GameObject by
    public XRController controller; // The controller to check for button presses

    // Update is called once per frame
    void Update()
    {
        CheckForInput();
    }

    void CheckForInput()
    {
        InputDevice device = controller.inputDevice;

        // Check if the Oculus B button is pressed (Oculus controller mapping)
        if (device.TryGetFeatureValue(CommonUsages.secondaryButton, out bool secondaryButtonValue) && secondaryButtonValue)
        {
            MoveObjectDown();
        }
        // Check if the Oculus A button is pressed (Oculus controller mapping)
        else if (device.TryGetFeatureValue(CommonUsages.primaryButton, out bool primaryButtonValue) && primaryButtonValue)
        {
            MoveObjectUp();
        }
    }

    void MoveObjectUp()
    {
        Vector3 newPosition = objectToMove.transform.position;
        newPosition.y += yOffset;
        objectToMove.transform.position = newPosition;
    }

    void MoveObjectDown()
    {
        Vector3 newPosition = objectToMove.transform.position;
        newPosition.y -= yOffset;
        objectToMove.transform.position = newPosition;
    }
}
