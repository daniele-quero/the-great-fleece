using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField]
    private PlayerMovement _pm;

    [SerializeField]
    private TossCoin _tc;

    void Update()
    {
        if (Input.GetMouseButton(0))
            _pm.Move(ClickedPosition());

        if (Input.GetMouseButtonDown(1))
            _tc.TossCoinAt(ClickedPosition());
    }

    public Vector3 ClickedPosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        Physics.Raycast(ray, out hit);
        return hit.point;
    }

}
