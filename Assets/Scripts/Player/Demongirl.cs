using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Demongirl : MonoBehaviour
{
    // Start is called before the first frame update

    private float moveSpeed = 2f;
    private Animator _anim;
    private bool direction = false;

    [SerializeField]
    private GameObject FireBall;

    void Start()
    {
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        KeyboardAction();
    }

    private void KeyboardAction()
    {
        var movementX = Input.GetAxis("Horizontal");
        var movementY = Input.GetAxis("Vertical");

        if (movementX > 0)
        {
            Vector3 temp = transform.localScale;
            temp.x = 1f;
            transform.localScale = temp;
            direction = true;
            _anim.Play("Run");
        }
        else if (movementX < 0)
        {
            Vector3 temp = transform.localScale;
            temp.x = -1f;
            transform.localScale = temp;
            direction = false;
            _anim.Play("Run");
        }
        if (movementY < 0 || movementY > 0)
        {
            _anim.Play("Run");
        }

        if (movementX == 0 && movementY == 0)
        {
            Vector3 temp = transform.localScale;
            temp.x = direction ? -1f : 1f;
            transform.localScale = temp;
            _anim.Play("Idle");
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            invockeFireball(direction);
        }

        transform.position += new Vector3(movementX, movementY, 0) * Time.deltaTime * moveSpeed;

    }

    public void invockeFireball(bool direction)
    {
        GameObject new_vaccine;
        var position = new Vector2(this.transform.position.x, this.transform.position.y);
        if (direction)
        {
            position.x = this.transform.position.x + 0.01f;
            new_vaccine = Instantiate(FireBall, position, Quaternion.identity);
            Rigidbody2D bodyBullet = new_vaccine.AddComponent<Rigidbody2D>();
            bodyBullet.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY;
            bodyBullet.AddForce(new Vector2(10, 0), ForceMode2D.Impulse);
        }
        else
        {
            position.x = this.transform.position.x - 0.01f;
            new_vaccine = Instantiate(FireBall, position, Quaternion.identity);
            Rigidbody2D bodyBullet = new_vaccine.AddComponent<Rigidbody2D>();
            bodyBullet.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY;
            bodyBullet.AddForce(new Vector2(-10, 0), ForceMode2D.Impulse);
        }
    }


}
