using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCube : MonoBehaviour
{
    private Transform _transform;

    private void Awake()
    {
        _transform = GetComponent<Transform>();
    }
    private void Update()
    {
        Vector2 Vector = new Vector2(_transform.position.x + 0.1f * Time.deltaTime, _transform.position.y);

        _transform.position = Vector;
    }
    private void FixedUpdate()
    {
    //    Vector2 Vector = new Vector2(_transform.position.x + 0.01f, _transform.position.y);
      //  _transform.position = Vector;
    }
}
