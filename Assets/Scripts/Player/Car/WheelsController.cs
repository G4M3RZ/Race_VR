using System.Collections.Generic;
using UnityEngine;

public class WheelsController : MonoBehaviour
{
    [Range(0, 90)] public float _wheelLimit;

    public GetCamRot _cam;
    public List<Transform> _wheels;
    private List<Transform> _wheelSons;
    private SpeedController _speed;

    private void Awake()
    {
        _wheelSons = new List<Transform>();

        for (int i = 0; i < _wheels.Count; i++)
            _wheelSons.Add(_wheels[i].GetChild(0));

        _speed = GetComponent<SpeedController>();
    }
    private void Update()
    {
        for (int i = 0; i < _wheels.Count; i++)
        {
            Vector3 wheelRot = _wheels[i].transform.localEulerAngles;
            float wheelLimit = Mathf.Clamp(_cam._camRotZ, -_wheelLimit, _wheelLimit);

            wheelRot.y = (i < 2) ? 0 - wheelLimit : 0;
            _wheels[i].transform.localEulerAngles = wheelRot;

            float rotation = (i == 0 || i == 2) ? -_speed._localSpeed : _speed._localSpeed;
            _wheelSons[i].Rotate(rotation, 0, 0);
        }
    }
}