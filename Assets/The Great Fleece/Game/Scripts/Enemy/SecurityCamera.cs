using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecurityCamera : MonoBehaviour
{
    [SerializeField]
    private MeshRenderer _cameraConeMesh;

    [SerializeField]
    private Material _alertConeMaterial;

    public void FreezeCameraOnDarren()
    {
        GetComponent<AlertController>().AlertAnimation();
        _cameraConeMesh.material = _alertConeMaterial;
    }

}
