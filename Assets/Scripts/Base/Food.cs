using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public enum FoodType { SANDWICH, ENERGY_CAN, PIZZA, APPLE, STEAK, CARROT };
    [SerializeField] private FoodType _foodType;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Animal"))
        {
            //TODO: Kill animal and add score
            Destroy(gameObject);
        }
    }
}
