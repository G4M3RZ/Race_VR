using System.Collections;
using UnityEngine;

public class Restart : MonoBehaviour
{
    [Range(0,1)] public float _rayDistance;
    public LayerMask _cPDetect, _spawnDetect;
    private Transform _checkpoint;

    private Raycast3D _raycast3D;
    private bool _tp;

    private void Awake()
    {
        _raycast3D = GetComponent<Raycast3D>();
    }
    private void Update()
    {
        Vector3 pos = transform.position;

        Transform checkpoint = _raycast3D.Ray3D(pos, -transform.up, _rayDistance, _cPDetect, Color.black);
        if (checkpoint != null) _checkpoint = checkpoint;

        Transform spawnDetect = _raycast3D.Ray3D(pos, -transform.up, 10f, _spawnDetect, Color.white);
        Teleport(spawnDetect);
    }
    void Teleport(Transform detect)
    {
        if(_checkpoint != null && !_tp && detect == null)
        {
            StartCoroutine(Respawn());
            _tp = true;
        }
    }
    IEnumerator Respawn()
    {
        yield return new WaitForSeconds(1f);

        transform.position = _checkpoint.position + new Vector3(-6.2f, 0.5f, 0);
        transform.rotation = _checkpoint.rotation;
        _tp = false;
    }
}