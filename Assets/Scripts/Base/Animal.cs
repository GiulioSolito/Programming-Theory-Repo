using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Animal : MonoBehaviour
{
    [SerializeField] protected float _speed = 4f;
    [SerializeField] private int _hitsNeededToSatisfy = 1;
    [SerializeField] private GameObject[] _favoriteFoods;
    [SerializeField] private FoodType _currentFavoriteFood;
    public FoodType CurrentFavoriteFood
    {
        get { return _currentFavoriteFood; }
        private set { _currentFavoriteFood = value; }
    }

    [SerializeField] private float _timeToChangeFood = 3f;

    protected virtual void Start()
    {
        _currentFavoriteFood = _favoriteFoods[Random.Range(0, _favoriteFoods.Length)].GetComponent<Food>().FoodType;
        StartCoroutine(ChangeFavoriteFood());
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    protected virtual void Move() // ABSTRACTION
    {
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
    }

    IEnumerator ChangeFavoriteFood()
    {
        while (true)
        {
            _timeToChangeFood = Random.Range(3f, 5f);
            yield return new WaitForSeconds(_timeToChangeFood);
            _currentFavoriteFood = _favoriteFoods[Random.Range(0, _favoriteFoods.Length)].GetComponent<Food>().FoodType;
        }
    }

    public void FeedAnimal()
    {
        _hitsNeededToSatisfy--;

        if (_hitsNeededToSatisfy <= 0)
        {
            Destroy(gameObject);
        }
    }
}
