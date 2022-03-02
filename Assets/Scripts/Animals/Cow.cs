using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cow : Animal, IAnimal
{
    private Renderer _rend;
    private Animator _anim;

    private bool _isRunningCrazy = false;

    protected override void Start()
    {
        base.Start();
        _rend = GetComponentInChildren<Renderer>();
        _anim = GetComponent<Animator>();
    }

    public void IncorrectFoodFed()
    {
        _speed *= 2f;
        _rend.material.color = Color.red;
        _anim.SetFloat("Speed_f", 1);
        StartCoroutine(RunCrazy());
    }

    IEnumerator RunCrazy()
    {
        _isRunningCrazy = true;

        StartCoroutine(Reset());

        while (_isRunningCrazy)
        {
            transform.Rotate(0, Random.Range(30, 130), 0);
            yield return new WaitForSeconds(1f);
        }       
    }

    IEnumerator Reset()
    {
        yield return new WaitForSeconds(6f);
        _isRunningCrazy = false;
        _anim.SetFloat("Speed_f", 0.5f);
        transform.LookAt(GameObject.Find("EndPoint").transform);
        _rend.material.color = Color.white;
        _speed = _originalSpeed;
    }
}
