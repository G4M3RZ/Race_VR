using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildRoadMap : MonoBehaviour
{
    public List<GameObject> _typeOfRoad;

    [Range(1, 4)] public List<int> _roadSection;
    [Range(1, 20)] public List<int> _roadLenth;

    Transform parent;
    private void Awake()
    {
        parent = transform.GetChild(0);
        StartCoroutine(BuildingRoadMap());
    }
    IEnumerator BuildingRoadMap()
    {
        for (int i = 0; i < _roadSection.Count; i++)
        {
            int num = _roadSection[i] - 1;
            int lenth = _roadLenth[i];

            for (int e = 1; e <= lenth; e++)
            {
                GameObject instance = Instantiate(_typeOfRoad[num], parent);
                instance.transform.parent = transform.GetChild(num);
                parent = instance.transform.GetChild(instance.transform.childCount - 1);

                yield return new WaitForSeconds(0.1f);
            }
        }
    }
}