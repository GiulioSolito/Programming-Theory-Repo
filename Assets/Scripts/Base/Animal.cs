using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Animal : MonoBehaviour
{
    [SerializeField] protected float _speed = 4f;

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    protected virtual void Move() // ABSTRACTION
    {
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
    }
}
