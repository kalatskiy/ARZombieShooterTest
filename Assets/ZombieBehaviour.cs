using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZombieBehaviour : MonoBehaviour
{
    float speed = 0.5f;
    Animator _animator;
    Vector3 targetPosition;
    public float distance;
    private HpBarScript _hpBar;
    public bool isMoving = true;
    public bool isAttack = false;
    UIManager _ui;
    private float _zombieDamage = 10;    
    private const int _scorePrice = 10;
    int _currentScore;
    float _attackCoolDown;



    void Start()
    {
        _ui = GameObject.Find("Canvas").GetComponent<UIManager>();
        _hpBar = GameObject.Find("Healthbar").GetComponent<HpBarScript>();
        targetPosition = Camera.main.transform.localPosition;
        _animator = GetComponent<Animator>();
        if (isMoving)
        {
            _animator.Play("walking");
        }        
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            Movement();
        }

        if (isAttack)
        {
            isMoving = false;
            PlayerDamage();
        }
    }
    void Movement()
    {
        if (isMoving)
        {
            Quaternion targetRotation = Quaternion.LookRotation(targetPosition - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, speed * Time.deltaTime);
            targetPosition = Camera.main.transform.localPosition;
            //targetPosition = new Vector3(targetPosition.x, 0, targetPosition.z);
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(targetPosition.x,transform.position.y ,targetPosition.z), speed * Time.deltaTime);
            distance = Vector3.Distance(transform.position, targetPosition);
            Debug.DrawLine(transform.position, targetPosition, Color.red);
            if (distance <= 2f)
            {
                isMoving = false;
                isAttack = true;
                PlayerDamage();
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
            _ui.Score(_scorePrice);
            _animator.Play("zombie_dying");
            Destroy(this.gameObject, 3f);
            Destroy(other.gameObject);
            isMoving = false;
        }
    }
    void PlayerDamage()
    {
        if(Time.time > _attackCoolDown)
        {
            _hpBar.Damage(_zombieDamage);
            _attackCoolDown = Time.time + 3f;
        }        
    }
}
