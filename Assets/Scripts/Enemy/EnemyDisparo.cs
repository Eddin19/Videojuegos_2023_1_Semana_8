using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDisparo : MonoBehaviour
{
    private int disparos = 0;
    private int maximo = 2;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bala")
        {
            Debug.Log("Colision de bala1");
            disparos++;
            Debug.Log(disparos);
            if (disparos >= maximo)
            {
                Destroy(this.gameObject);
            }
        }

    }
}
