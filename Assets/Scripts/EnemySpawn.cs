using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    private float RotateSpeed = 5f;
    private float Radius = 18f;

    private Vector2 _centre;
    private float _angle;
    [SerializeField]
    private GameObject[] spawnlar;

    private void Start()
    {
        _centre = transform.position;
    }

    private void Update()
    {
        _angle += RotateSpeed * Time.deltaTime;

        var offset = new Vector2(Mathf.Sin(_angle), Mathf.Cos(_angle)) * Radius;
        spawnlar[0].transform.position = _centre + offset;
    }
}
