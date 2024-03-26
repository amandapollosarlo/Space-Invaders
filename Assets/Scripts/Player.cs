using UnityEngine;

public class Player : MonoBehaviour
{
    public Projectile laserPrefab;
    public float speed = 5.0f;
    private bool _laserActive;

    public int maxLives = 3;
    private int currentLives;

    private GameManager gameManager;

    private void Start()
    {
        currentLives = maxLives;
        gameManager = FindObjectOfType<GameManager>(); // Assuming GameManager is a singleton
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            this.transform.position += Vector3.left * this.speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            this.transform.position += Vector3.right * this.speed * Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        if (!_laserActive)
        {
            Projectile projectile = Instantiate(this.laserPrefab, this.transform.position, Quaternion.identity);
            projectile.destroyed += () => { _laserActive = false; };
            _laserActive = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("EnemyProjectile"))
        {
            TakeDamage();
        }
    }

    private void TakeDamage()
    {
        currentLives--;
        if (currentLives <= 0)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        // Implement your game over logic here
        Debug.Log("Game Over");
    }
}