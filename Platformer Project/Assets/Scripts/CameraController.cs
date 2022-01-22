using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    private Vector3 pos;
    public float z_coord = -5f;

    // Update is called once per frame
    void Awake()
    {
        if (!player)
        {
            player = FindObjectOfType<Hero>().transform;

        }
    }
    void Update()
    {
        pos = player.position;
        pos.z = z_coord;
        transform.position = Vector3.Lerp(transform.position, pos, Time.deltaTime);
    }
}
