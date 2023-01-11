using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject _fire;

    void OnCollisionEnter(Collision collision)
    {
        if(gameObject.tag == collision.gameObject.tag)
        {
            return;
        }
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Floor")
        {
            if (collision.gameObject.tag == "Enemy")
            {
                GameManager.AddCell1(1);
                Destroy(collision.gameObject, 0.2f);
                GameObject fire = Instantiate(_fire, this.transform.position, transform.rotation);
                Destroy(this.gameObject, 0.1f);
                Destroy(fire, 0.3f);

            }
            if (collision.gameObject.tag == "Floor")
            {
                GameObject fire = Instantiate(_fire, this.transform.position, transform.rotation);
                Destroy(this.gameObject, 0.1f);
                Destroy(fire, 0.3f);
            }
        }
    }
}
