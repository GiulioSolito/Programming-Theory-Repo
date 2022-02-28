using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] private float _rotateSpeed = 50f;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(0, _rotateSpeed * Time.deltaTime, 0);
    }
}
