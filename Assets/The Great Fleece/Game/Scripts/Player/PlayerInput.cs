using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField]
    private PlayerMovement _pm;

    void Update()
    {
        if (Input.GetMouseButton(0))
            _pm.Move(ClickedPosition());
    }

    public Vector3 ClickedPosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        Physics.Raycast(ray, out hit);

        //DebugObjectOnTarget(hit.point);
        return hit.point;
    }

    private void DebugObjectOnTarget(Vector3 pos)
    {
        GameObject.CreatePrimitive(PrimitiveType.Sphere).transform.position = pos;
    }
}
