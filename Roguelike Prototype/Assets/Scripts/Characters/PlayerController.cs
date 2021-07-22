
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Weapon weapon;

    Rigidbody2D myRigidBody;
    Health health;

    Vector2 movement;
    float timeSinceShoot;

    private void Awake()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        myRigidBody.MovePosition((Vector2)transform.position + movement * speed * Time.fixedDeltaTime);
        health = GetComponent<Health>();

    }

    void Update()
    {
        timeSinceShoot += Time.deltaTime;
        movement = GetMovementInput();

        if (Input.GetMouseButton(0) && timeSinceShoot > (1 / weapon.GetFireRate()))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            weapon.Shoot(mousePos - (Vector2)transform.position);
            timeSinceShoot = 0;
        }
    }

    public void SetWeapon(Weapon weapon)
    {
        this.weapon = weapon;
    }


    private Vector2 GetMovementInput()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        return new Vector2(x, y);
    }
}
