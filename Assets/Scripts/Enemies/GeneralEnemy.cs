using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralEnemy : MonoBehaviour
{
    // Start is called before the first frame update

    private int life;


    void Start()
    {
        life = 2;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision);
        if (collision.tag.Equals("Bullet"))
        {
            life--;
            if (life <= 0)
            {
                Destroy(this.gameObject);
            }
            Destroy(collision.gameObject);
            //UIController.instance.reduceEnemies();
        }
    }

}
