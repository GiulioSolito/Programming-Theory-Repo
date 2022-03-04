using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Animal : MonoBehaviour
{
    [SerializeField] protected float _speed = 4f; 
    protected float _originalSpeed;
    [SerializeField] private int _hitsNeededToSatisfy = 1;
    [SerializeField] private GameObject[] _favoriteFoods;
    [SerializeField] private FoodType _currentFavoriteFood;
    public FoodType CurrentFavoriteFood // ENCAPSULATION
    {
        get { return _currentFavoriteFood; }
        private set { _currentFavoriteFood = value; }
    }

    private int _foodIndex;
    [SerializeField] private float _timeToChangeFood = 3f;
    [SerializeField] private Transform _foodDisplayParent;
    private GameObject _displayFood;

    protected virtual void Start()
    {
        _originalSpeed = _speed;
        _foodIndex = Random.Range(0, _favoriteFoods.Length);
        _currentFavoriteFood = _favoriteFoods[_foodIndex].GetComponent<Food>().FoodType;
        SetFoodDisplay();
        
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

    IEnumerator ChangeFavoriteFood() // ABSTRACTION
    {
        while (true)
        {
            _timeToChangeFood = Random.Range(3f, 5f);
            yield return new WaitForSeconds(_timeToChangeFood);
            _foodIndex = Random.Range(0, _favoriteFoods.Length);
            _currentFavoriteFood = _favoriteFoods[_foodIndex].GetComponent<Food>().FoodType;
            Destroy(_displayFood);
            SetFoodDisplay();
        }
    }

    void SetFoodDisplay() // ABSTRACTION
    {
        _displayFood = Instantiate(_favoriteFoods[_foodIndex], _foodDisplayParent.position, Quaternion.Euler(new Vector3(0,0,0)));
        _displayFood.transform.SetParent(_foodDisplayParent);
        _displayFood.GetComponent<Collider>().enabled = false;
    }

    public void FeedAnimal() // ABSTRACTION
    {
        _hitsNeededToSatisfy--;

        if (_hitsNeededToSatisfy <= 0)
        {
            Destroy(gameObject);
        }
    }
}
