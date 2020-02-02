using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public GameObject[] prefab;
    public Vector3 PositionOffset = new Vector3(0, 0, 100);

    private void OnTriggerEnter(Collider other)
    {
        Vector3 position = this.transform.parent.position;
        Vector3 newPosition = position + PositionOffset;

        int num = Mathf.RoundToInt(Random.Range(0f,prefab.Length-1f));

        Debug.Log(num);

        Instantiate(prefab[num], newPosition, Quaternion.identity);
    }
}
