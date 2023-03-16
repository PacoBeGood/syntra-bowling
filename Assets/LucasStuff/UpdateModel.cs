using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateModel : MonoBehaviour
{
    [Tooltip("List of all linked .fbx-files")]
    [SerializeField] List<GameObject> models;
    //[Tooltip("Object to change its Mesh and Material from")]
    //[SerializeField] GameObject targetObject;
    [Space]
    [Tooltip("List of all linked GameObjects")]
    [SerializeField] List<GameObject> objects;
    public void ChangeModel(float id = 0)
    {
        GetComponent<MeshFilter>().mesh = models[(int)id].GetComponent<MeshFilter>().sharedMesh;
        GetComponent<MeshRenderer>().material = models[(int)id].GetComponent<Renderer>().sharedMaterial;
    }
    public void ChangeObject(float id = 0)
    {
        foreach(GameObject o in objects) o.SetActive(false);

        objects[(int)id].SetActive(true);
    }
}
