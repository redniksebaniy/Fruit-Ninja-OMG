using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SpawnField : MonoBehaviour
{
    [SerializeField]
    [Range(0, 1)]
    float spawnChance;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.Lerp(Color.red, Color.green, spawnChance);
        Gizmos.DrawCube(transform.position, transform.localScale);
    }
}
