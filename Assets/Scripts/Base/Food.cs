using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FoodType { SANDWICH, ENERGY_CAN, PIZZA, APPLE, STEAK, CARROT };
public class Food : MonoBehaviour
{
    [SerializeField] private FoodType _foodType;
    public FoodType FoodType
    {
        get { return _foodType; }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Animal"))
        {
            //TODO: Kill animal and add score
            if (other.GetComponent<Animal>().CurrentFavoriteFood == _foodType)
            {
                Debug.Log("Correct Food!");
                other.GetComponent<Animal>().FeedAnimal();
                Player.Instance.AddScore(10);
            }
            else
            {
                Debug.Log("Incorrect Food!");
                Player.Instance.DamagePlayer();
            }
            Destroy(gameObject);
        }
    }
}
