using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SyringeCollide : MonoBehaviour
{

    public bool isSyringeDone = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "SnapZone3")
        {
            isSyringeDone = true;
        }
    }
}
