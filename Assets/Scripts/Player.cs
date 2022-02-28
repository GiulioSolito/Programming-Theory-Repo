using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;

    [SerializeField] private float _xMin, _xMax, _zMin, _zMax;

    private float _horInput;
    private float _verInput;

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move() // ABSTRACTION
    {
        _horInput = Input.GetAxis("Horizontal");
        _verInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.right * _horInput * _speed * Time.deltaTime);
        transform.Translate(Vector3.forward * _verInput * _speed * Time.deltaTime);

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, _xMin, _xMax), transform.position.y,
                                         Mathf.Clamp(transform.position.z, _zMin, _zMax));
    }
}
