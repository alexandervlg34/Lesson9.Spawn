using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float lifetime = 5f;
    [SerializeField] private float speed = 10f;
    [SerializeField] private Transform spawn;



    private void OnEnable()
    {
        this.StartCoroutine("LifeRoutine");
    }

    private void OnDisable()
    {
        this.StopCoroutine("LifeRoutine");
    }

    private IEnumerator LifeRoutine()
    {
        yield return new WaitForSeconds(lifetime);

        this.Deactivate();
    }

    private void Deactivate()
    {
        this.gameObject.SetActive(false);
    }

    private void Update()
    {
        Move();
    }

    public void Move()
    {
        gameObject.GetComponent<Rigidbody>().velocity = spawn.forward * speed;
    }

}
