using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public enum FoodType { SANDWICH, ENERGY_CAN, PIZZA, APPLE, STEAK, CARROT };
    [SerializeField] private FoodType _foodType;

    [SerializeField] private float _rotateSpeed = 50f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, _rotateSpeed * Time.deltaTime, 0);
    }
}
