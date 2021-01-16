using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    private float RotateSpeed = 5f;
    private float Radius = 18f;

    public CreateEnemy deneme;

    private Vector2 _centre;
    private float _angle;
    [SerializeField]
    private GameObject[] spawnlar;

    private void Start()
    {
        _centre = transform.position;
        StartCoroutine(OyuncuyaBak());
    }

    private void Update()
    {
        _angle += RotateSpeed * Time.deltaTime;

        var offset = new Vector2(Mathf.Sin(_angle), Mathf.Cos(_angle)) * Radius;
        spawnlar[0].transform.position = _centre + offset;
    }


        private IEnumerator OyuncuyaBak()
    {
        ObjectPool.DusmanSpawn(deneme,new Vector2(spawnlar[0].transform.position.x,spawnlar[0].transform.position.y));
        yield return new WaitForSeconds(5f);
        StartCoroutine(OyuncuyaBak());
    }
}
