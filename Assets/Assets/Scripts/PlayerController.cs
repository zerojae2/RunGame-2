using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Animator anim;
    [SerializeField] private Collider2D[] collider;

    private bool isJump = false;
    private bool isSlide = false;
    private bool isTop = false;
    private bool isGameOver = true;
    private bool isShot = true;

    private bool isJumpClick = false;
    private bool isSlideClick = false;

    public float jumpHeight = 0;
    public float jumpSpeed = 0;

    Vector2 startPostion;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        startPostion = transform.position;
    }

    private void Update()
    {      
        PlayerJump();
        PlayerSlide();
    }

    public void PlayerJump() 
    {
        if (isJumpClick && GameManager.instance.isPlay)
        {
            isJump = true;
            isGameOver = false;
            anim.SetBool("Jump", isJump);
        }
        else if (transform.position.y <= startPostion.y)
        {
            isJump = false;
            isTop = false;
            isGameOver = true;
            anim.SetBool("Jump", isJump);
            transform.position = startPostion;
        }

        if (isJump)
        {
            if (transform.position.y <= jumpHeight - 0.1f && !isTop)
            {
                transform.position = Vector2.Lerp(transform.position, new Vector2(transform.position.x, jumpHeight), jumpSpeed * Time.deltaTime);
            }
            else
            {
                isTop = true;
            }
            if (transform.position.y > startPostion.y && isTop)
            {
                transform.position = Vector2.MoveTowards(transform.position, startPostion, jumpSpeed * Time.deltaTime);
            }
        }
    }

    private void PlayerSlide()
    {
        if (isSlideClick && GameManager.instance.isPlay) 
        {
            isSlide = true;
            isGameOver = false;
            anim.SetBool("Slide", isSlide);
            collider[0].enabled = false;
            collider[1].enabled = true;
        }
        else if (transform.position.y <= startPostion.y)
        {
            isSlide = false;
            isGameOver = true;
            anim.SetBool("Slide", isSlide);
            collider[0].enabled = true;
            collider[1].enabled = false;
            transform.position = startPostion;
        }

        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Mob"))
        {
            Destroy(collision.gameObject);
            isGameOver = false;
            GameManager.instance.GameOver();
            anim.SetBool("GameOver", true);
            SceneManager.LoadScene("GameOverScene");
            DataManager.Instance.FinishGame();
        }
        if (collision.CompareTag("Coin")) 
        {
            Destroy(collision.gameObject);
            DataManager.Instance.score += 500;
            GameManager.instance.gameSpeed += 1f;
        }
    }

    public void JumpClickDown() 
    {
        isJumpClick = true;
    }
    public void JumpClickUp() 
    {
        isJumpClick = false;
    }
    public void SlideClickDown() 
    {
        isSlideClick = true;
    }
    public void SlideClickUp() 
    {
        isSlideClick = false;
    }
}
