using UnityEngine;

public class GetCamRot : MonoBehaviour
{
    public float _camRotZ;

    private void Update()
    {
        _camRotZ = transform.localEulerAngles.z;

        if (_camRotZ > 180)
            _camRotZ = _camRotZ - 360;
    }
}