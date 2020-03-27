using System;
using UnityEngine;
using Debug = System.Diagnostics.Debug;

public class MeshDeformerInput : MonoBehaviour
{
    public float force = 10f;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            HandleInput();
        }
    }

    private void HandleInput()
    {
        Debug.Assert(Camera.main != null, "Camera.main != null");
        Ray inputRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(inputRay, out hit))
        {
            MeshDeformer deformer = hit.collider.GetComponent<MeshDeformer>();
            if (deformer) {
                Vector3 point = hit.point;
                deformer.AddDeformingForce(point, force);
            }
        }
    }
}