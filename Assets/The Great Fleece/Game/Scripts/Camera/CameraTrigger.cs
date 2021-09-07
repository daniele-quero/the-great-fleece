using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrigger : MonoBehaviour
{
    public Transform cameraProgressionAngle;
    public GameObject camera;
    [SerializeField]
    private int id;

    private void OnTriggerEnter(Collider other)
    {
        if ("Player".Equals(other.tag))
        {
            Debug.Log("player entered " + id);
            camera.transform.position = cameraProgressionAngle.position;
            camera.transform.rotation = cameraProgressionAngle.rotation;
        }
    }
}
