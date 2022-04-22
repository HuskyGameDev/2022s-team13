using System.Collections.Generic;
using UnityEngine;

public class Detection : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite newSprite;
    public Sprite oldSprite;
    public Collider2D objectCollider;
    public Collider2D anotherCollider;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "GameObject")
        {
            ChangeSprite();
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        spriteRenderer.sprite = oldSprite;
    }

    void ChangeSprite()
    {
        spriteRenderer.sprite = newSprite;
    }
}
