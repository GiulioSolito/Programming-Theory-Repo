using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Horse : Animal, IAnimal
{
    public void IncorrectFoodFed()
    {
        Debug.Log("Nooooooo");
    }
}
