using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;
    public float rotationSpeed = 25.0f;
    public Material[] materials;    // an array to hold the materials
    public float switchInterval = 3.0f;    // how often to switch the material
    private int currentMaterialIndex = 0;    // the index of the current material in the array
    private new Renderer renderer;    // the renderer of the object that this script is attached to

    void Start()
    {
        renderer = GetComponent<Renderer>();    // get the renderer component of the object
        InvokeRepeating("SwitchMaterial", switchInterval, switchInterval);    // start repeating the SwitchMaterial function with the specified interval

        CubeMod();
    }

    void Update()
    {
        CubeRotation();
    }
    // Gives cube rotation
    void CubeRotation()
    {
        transform.Rotate(rotationSpeed * Time.deltaTime, 0.0f, 0.0f);
    }

    //Modifies cube scale, material, and color
    void CubeMod()
    {

        transform.position = new Vector3(3, 4, 1);
        transform.localScale = Vector3.one * 1.3f;

        Material material = Renderer.material;

        material.color = new Color(0.5f, 1.0f, 0.3f, 0.4f);
    }
    void SwitchMaterial()
    {
        currentMaterialIndex++;    // increment the index
        if (currentMaterialIndex >= materials.Length)    // if the index exceeds the length of the array, wrap around to the first material
        {
            currentMaterialIndex = 0;
        }
        renderer.material = materials[currentMaterialIndex];    // set the material to the one at the current index
    }
}


