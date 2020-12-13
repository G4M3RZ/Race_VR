using UnityEngine;

public class SetCam : MonoBehaviour
{
    [Range(0,10)]
    public float _distance;
    private Transform _headController, _cam, _player;
    private Vector3 headPos;

    private void Start()
    {
        _headController = transform.GetChild(0).transform;
        _cam = _headController.GetChild(0).transform;
        _player = transform.GetChild(1).transform;

        headPos = _cam.localPosition;
        _cam.localPosition = new Vector3(headPos.x, headPos.y, -_distance);
    }
    private void Update()
    {
        _cam.localPosition = new Vector3(headPos.x, headPos.y, -_distance);

        Vector3 _getRot = _player.eulerAngles;
        _headController.rotation = Quaternion.Lerp(_headController.localRotation, Quaternion.Euler(_getRot), Time.deltaTime * 5);

        _headController.position = _player.position;
    }
}