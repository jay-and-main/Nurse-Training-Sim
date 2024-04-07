using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SyringeLogic : MonoBehaviour
{
    public Material opaqueMaterial;
    public Material transparentMaterial;
    public MeshRenderer skinMeshRenderer;
    public bool isTransparent = false;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        SetMaterial();
        
    }

    private void SetMaterial()
    {
        if (skinMeshRenderer != null)
        {
            Material[] materials = skinMeshRenderer.materials;
            materials[0] = isTransparent ? transparentMaterial : opaqueMaterial;
            skinMeshRenderer.materials = materials;
        }
    }
}
