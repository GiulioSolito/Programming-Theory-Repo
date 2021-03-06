using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FoodType { SANDWICH, ENERGY_CAN, PIZZA, APPLE, STEAK, CARROT };
public class Food : MonoBehaviour
{
    [SerializeField] private FoodType _foodType;
    public FoodType FoodType // ENCAPSULATION
    {
        get { return _foodType; }
    }

    [SerializeField] private bool _canDamageAnimal = false;
    public bool CanDamageAnimal // ENCAPSULATION
    {
        get { return _canDamageAnimal; }
        set { _canDamageAnimal = value; }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Animal") || other.CompareTag("Doe") || other.CompareTag("Fox") && _canDamageAnimal)
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
                if (other.GetComponent<IAnimal>() != null)
                {
                    other.GetComponent<IAnimal>().IncorrectFoodFed();
                }
                Player.Instance.DamagePlayer();                
            }
            Destroy(gameObject);
        }
    }
}
