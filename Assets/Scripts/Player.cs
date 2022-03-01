using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoSingleton<Player>
{
    [SerializeField] private float _speed = 10f;
    [SerializeField] private int _lives = 3;
    public int Lives
    {
        get { return _lives; }
        private set { _lives = value; }
    }

    [SerializeField] private int _score = 0;
    public int Score 
    {
        get { return _score; }
        private set { _score = value; }
    }

    [SerializeField] private GameObject _projectile;
    public GameObject Projectile
    {
        get { return _projectile; }
        set { _projectile = value; }
    }
    [SerializeField] private float _fireRate = 0.15f;
    private float _canFire = 0f;

    [SerializeField] private float _xMin, _xMax, _zMin, _zMax;

    private float _horInput;
    private float _verInput;

    // Update is called once per frame
    void Update()
    {
        Move();

        if (Input.GetButtonDown("Fire1") && Time.time > _canFire)
        {
            Shoot();
        }
        Debug.Log(Time.time);
    }

    void Move() // ABSTRACTION
    {
        _horInput = Input.GetAxis("Horizontal");
        _verInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.right * _horInput * _speed * Time.deltaTime);
        transform.Translate(Vector3.forward * _verInput * _speed * Time.deltaTime);

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, _xMin, _xMax), transform.position.y,
                                         Mathf.Clamp(transform.position.z, _zMin, _zMax));
    }

    void Shoot() // ABSTRACTION
    {
        _canFire = Time.time + _fireRate;

        GameObject go = Instantiate(_projectile, transform.position, _projectile.transform.rotation);
        go.GetComponent<Rotate>().enabled = false;
        go.GetComponent<MoveForward>().enabled = true;
        go.GetComponent<Food>().CanDamageAnimal = true;
    }

    public void AddScore(int amount)
    {
        Score += amount;
    }

    public void DamagePlayer()
    {
        Lives--;

        if (Lives <= 0)
        {
            Debug.Log("Player has died!");
            Lives = 0;
            SpawnManager.Instance.IsSpawning = false;
            SpawnManager.Instance.StopAllCoroutines();
        }
    }
}
