using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgScript : MonoBehaviour
{
    public Transform CircleTransform;
    private Transform _transform;
    private Vector3 _offset;
    private void Awake()
    {
        _transform = GetComponent<Transform>();
    }

    private void Start()
    {
        _offset = _transform.position;
    }
    // Update is called once per frame
    private void FixedUpdate()
    {
        _transform.position = new Vector3(CircleTransform.position.x+_offset.x, _transform.position.y,0) ;
    }
}
