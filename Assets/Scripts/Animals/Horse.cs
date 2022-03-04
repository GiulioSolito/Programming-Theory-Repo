using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Horse : Animal, IAnimal // INHERITANCE
{
    private Renderer _rend;
    private Animator _anim;

    protected override void Start() // POLYMORPHISM
    {
        base.Start();
        _rend = GetComponentInChildren<Renderer>();
        _anim = GetComponent<Animator>();
    }

    public void IncorrectFoodFed() // POLYMORPHISM
    {
        Run();
    }

    void Run()  // ABSTRACTION
    {
        _speed *= 2;
        _rend.material.color = Color.red;
        _anim.SetFloat("Speed_f", 1);
    }
}
