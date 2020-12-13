using UnityEngine;

public class Raycast3D : MonoBehaviour
{
    public Transform Ray3D(Vector3 initPos, Vector3 direction, float rayDistance, LayerMask layer, Color rayColor)
    {
        Ray ray = new Ray(initPos, direction);
        Debug.DrawLine(ray.origin, ray.origin + ray.direction * rayDistance, rayColor);

        RaycastHit hitInfo;
        Transform obj = (Physics.Raycast(ray, out hitInfo, rayDistance, layer)) ? hitInfo.collider.transform : null;

        return obj;
    }
}