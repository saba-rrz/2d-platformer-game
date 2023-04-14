using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterDatabase characterDB;
    public SpriteRenderer artworkSprite;
    private int selectedOption = 0;
    public float horizantal;
    private float Speed = 8f;
    private bool isFacingTheRightWay = true;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;


     void Start()
    {
        if (!PlayerPrefs.HasKey("SelectedOption"))
        {
            selectedOption = 0;
        }
        else
        {
            Load();
        }
        UpdateCharacter(selectedOption);
    }

    // Update is called once per frame
    void Update()
    {
        horizantal = Input.GetAxis("Horizontal");
        flip();
        
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizantal * Speed, rb.velocity.y);
    }
    private void flip()
    {
        if(isFacingTheRightWay && horizantal < 0f || isFacingTheRightWay && horizantal > 0f)
        {
            isFacingTheRightWay = !isFacingTheRightWay;
            Vector3 localScale = transform.localScale;
            localScale.x *=  -1f;
            transform.localScale = localScale;
        }
    }
    private void UpdateCharacter(int selectedOption)
    {
        CHARACTER charatcer =
        characterDB.GetCHARACTER(selectedOption);
        artworkSprite.sprite = charatcer.characterSprite;


    }
    private void Load()
    {
        selectedOption = PlayerPrefs.GetInt("SelectedOption");
    }
}
