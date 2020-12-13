using UnityEngine;

public class SpeedController : MonoBehaviour
{
    public GetCamRot _cam;

    [Range(0, 10)] public float _speed;
    [Range(0, 90)] public float _limitRotation;
    [Range(0, 4)] public float _forwardRay, _upRay;
    public LayerMask _detect;

    [HideInInspector] public float _localSpeed;

    private Rigidbody _rgb;
    private Raycast3D _raycast3D;
    private bool _stopCar;

    private void Awake()
    {
        _rgb = GetComponent<Rigidbody>();
        _raycast3D = GetComponent<Raycast3D>();
    }
    private void Update()
    {
        //Car Rotation
        float carRot = Mathf.Clamp(-_cam._camRotZ * Time.deltaTime, -_limitRotation, _limitRotation);
        transform.Rotate(0, carRot * 5, 0);

        //Car Speed
        _localSpeed = (_stopCar) ? _localSpeed -= Time.deltaTime * 15 : _localSpeed += Time.deltaTime * 5;
        _localSpeed = Mathf.Clamp(_localSpeed, 0, _speed);

        //Car Detection
        Transform frontHit = _raycast3D.Ray3D(transform.position, transform.forward, _forwardRay, _detect, Color.green);
        Transform downHit = _raycast3D.Ray3D(transform.position, -transform.up, _upRay, _detect, Color.blue);
        _stopCar = (frontHit != null || downHit == null) ? true : false;
    }
    private void FixedUpdate()
    {
        if (!_stopCar)
            _rgb.velocity = transform.forward * _localSpeed;
    }
}