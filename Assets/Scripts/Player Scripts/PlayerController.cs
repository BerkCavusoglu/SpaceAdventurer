using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float min_Y, max_Y;
    public GameObject player_Bullet;
    public Transform attack_Point;
    private bool canAttack;
    public AudioSource laserAudio;
    public AudioSource explosionSound;
    public GameObject gameOverText;
    public GameObject Restart;
    public GameObject ExitButton;
    public GameObject explosionEffect;
    public Button fireButton; // Butonu ekledik

    private float upmovement = 0f;

    private float nextAttackTime = 0f;
    private float attackRate = 1.5f; // Her saldýrý arasýndaki süre (saniye cinsinden)

    void Start()
    {
        fireButton.onClick.AddListener(StartFiring); // Butonun týklanma durumunu dinliyoruz
        fireButton.onClick.AddListener(StopFiring); // Butonun býrakýlma durumunu dinliyoruz
    }

    void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        float moveInput = Input.GetAxisRaw("Vertical");
        Vector3 temp = transform.position;
        temp.y += (moveInput + upmovement) * speed * Time.deltaTime;
        temp.y = Mathf.Clamp(temp.y, min_Y, max_Y);
        transform.position = temp;
    }

    void StartFiring()
    {
        canAttack = true; // Butona basýldýðýnda ateþ etme izni ver
        if (Time.time >= nextAttackTime)
        {
            Attack();
            nextAttackTime = Time.time + 1f / attackRate; // Bir sonraki saldýrýnýn zamanýný ayarla
        }
        StartCoroutine(AttackRoutine());
    }

    IEnumerator AttackRoutine()
    {
        while (canAttack)
        {
            if (Time.time >= nextAttackTime)
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate; // Bir sonraki saldýrýnýn zamanýný ayarla
            }
            yield return null;
        }
    }

    void Attack()
    {
        Instantiate(player_Bullet, attack_Point.position, Quaternion.identity);
        laserAudio.Play();
    }

    void StopFiring()
    {
        canAttack = false; // Butondan çekildiðinde ateþ etmeyi durdur
    }

    public void Up()
    {
        upmovement = 1f;
    }

    public void Down()
    {
        upmovement = -1f;
    }

    public void Stop()
    {
        upmovement = 0f;
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Bullet" || target.tag == "Enemy1" || target.tag == "Enemy2" || target.tag == "Enemy3" || target.tag == "Enemy4")
        {
            explosionSound.Play();
            Instantiate(explosionEffect, transform.position, Quaternion.identity);
            StartCoroutine(PauseGameForSeconds(2f));
        }
    }

    IEnumerator PauseGameForSeconds(float pauseTime)
    {
        yield return new WaitForSecondsRealtime(pauseTime);
        Time.timeScale = 0f;
        explosionSound.Play();
        Destroy(gameObject);
        gameOverText.SetActive(true);
        Restart.SetActive(true);
        ExitButton.SetActive(true);
    }

    public void EnableAttackButton()
    {
        fireButton.interactable = true;
    }
}