using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public GameObject prefab;
    public Vector3 PositionOffset = new Vector3(0, 0, 100);

    private void OnTriggerExit(Collider other)
    {
        Vector3 position = this.transform.parent.position;
        Vector3 newPosition = position + PositionOffset;
        Instantiate(prefab, newPosition, Quaternion.identity);
    }
}
