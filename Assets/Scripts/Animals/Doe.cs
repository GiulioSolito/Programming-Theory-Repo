using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doe : Animal, IAnimal
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
        foreach (GameObject doe in GameObject.FindGameObjectsWithTag("Doe"))
        {
            Doe d = doe.GetComponent<Doe>();
            d._speed *= 2f;
            d._rend.material.color = Color.red;
            d._anim.SetFloat("Speed_f", 1);
            d.transform.Rotate(0, -60, 0);
            Destroy(d.gameObject, 4f);
        }
    }
}
