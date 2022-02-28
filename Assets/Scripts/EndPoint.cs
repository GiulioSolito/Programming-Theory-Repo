using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("End Point Reached");
        Player.Instance.DamagePlayer();
        Destroy(other.gameObject);
    }
}
