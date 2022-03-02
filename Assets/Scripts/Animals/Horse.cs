using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Horse : Animal, IAnimal
{
    private Renderer _rend;
    private Animator _anim;

    protected override void Start()
    {
        base.Start();
        _rend = GetComponentInChildren<Renderer>();
        _anim = GetComponent<Animator>();
    }

    public void IncorrectFoodFed()
    {
        Run();
    }

    void Run()
    {
        _speed *= 2;
        _rend.material.color = Color.red;
        _anim.SetFloat("Speed_f", 1);
    }
}
