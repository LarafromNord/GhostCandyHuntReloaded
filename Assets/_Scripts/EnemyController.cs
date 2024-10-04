using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Rigidbody2D enemyrb;

    // Start is called before the first frame update
    void Start()
    {
        enemyrb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Time.deltaTime * 1.75f, 0, 0);
    }
}
