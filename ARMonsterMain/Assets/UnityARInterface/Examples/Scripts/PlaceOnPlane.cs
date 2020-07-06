using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityARInterface;
using UnityEngine.EventSystems;

public class PlaceOnPlane : ARBase
{
    [SerializeField]
    private Transform m_ObjectToPlace;

    void Update ()
    {
        if (Input.GetMouseButton(0) && !EventSystem.current.IsPointerOverGameObject(0))
        {
            var camera = GetCamera();

            Ray ray = camera.ScreenPointToRay(Input.mousePosition);

			int layerMask = 1 << LayerMask.NameToLayer("ARGameObject"); // Planes are in layer ARGameObject

            RaycastHit rayHit;
            if (Physics.Raycast(ray, out rayHit, float.MaxValue, layerMask))
                m_ObjectToPlace.transform.position = rayHit.point;
        }
    }
}
