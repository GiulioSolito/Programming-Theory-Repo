using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stag : Animal, IAnimal // INHERITANCE
{
    private Renderer _rend;
    private Animator _anim;

    private bool _isChargingPlayer = false;
    private bool _canDamagePlayer = false;

    protected override void Start() // POLYMORPHISM
    {
        base.Start();
        _rend = GetComponentInChildren<Renderer>();
        _anim = GetComponent<Animator>();
    }

    public void IncorrectFoodFed() // POLYMORPHISM
    {
        _isChargingPlayer = true;
        _canDamagePlayer = true;

        _speed *= 2f;
        _rend.material.color = Color.red;
        _anim.SetFloat("Speed_f", 1);
    }

    protected override void Move() // ABSTRACTION
    {
        base.Move();

        if (_isChargingPlayer)
        {
            transform.LookAt(GameObject.FindGameObjectWithTag("Player").transform);
            StartCoroutine(AttackPlayer());
        }        
    }

    IEnumerator AttackPlayer() // ABSTRACTION
    {
        float dist = Vector3.Distance(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position);

        if (dist <= 1 && _canDamagePlayer)
        {
            _canDamagePlayer = false;
            GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().DamagePlayer();
            Reset();
        }
        yield return new WaitForSeconds(3f);
        _canDamagePlayer = false;
        Reset();
    }

    void Reset() // ABSTRACTION
    {
        _isChargingPlayer = false;
        _anim.SetFloat("Speed_f", 0.5f);
        transform.LookAt(GameObject.Find("EndPoint").transform);
        _rend.material.color = Color.white;
        _speed = _originalSpeed;
    }
}
