using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public float speed;
    public float stop;
    public float retreatDistance;
    public float shotTime;
    public float StartShots;

    public GameObject projectile;
    private bool isFacingRight = true;
    private Transform Target;
    private Vector2 trgt;

    // Start is called before the first frame update
    void Start()
    {
        Target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        shotTime = StartShots;
        trgt = new Vector2(Target.position.x, Target.position.y);
    }
    void Update()
    {
        if (Vector2.Distance(transform.position, Target.position) > stop)
        {
            transform.position = Vector2.MoveTowards(transform.position, Target.position, speed * Time.deltaTime);
            //Flip();
            
        }
        else if (Vector2.Distance(transform.position, Target.position) < stop && Vector2.Distance(transform.position, Target.position) > retreatDistance)
        {
            transform.position = this.transform.position;
        }
        else if (Vector2.Distance(transform.position, Target.position) < retreatDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, Target.position, -speed * Time.deltaTime);
            //Flip();
        }

        if(transform.position.x == trgt.x && transform.position.y == trgt.y)
        {
            DestroyProjectile();
        }

        if (shotTime <= 0)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            Debug.Log("Fired");
            shotTime = StartShots;
           
        }
        else
        {
            shotTime -= Time.deltaTime; 
        }
    }
    private void Flip()
    {
        Vector3 temp = transform.localScale;
        temp.x *= -1;
        transform.localScale = temp;

        isFacingRight = !isFacingRight;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            DestroyProjectile();
        }

    }
    public void DestroyProjectile()
    {
        Destroy(gameObject);
    }

}
