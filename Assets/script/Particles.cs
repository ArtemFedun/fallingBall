using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particles : MonoBehaviour
{
    public ParticleSystem par; 
    public string a = "Ground"; 

    private bool grounded = false;
    private GameObject spriteObj; // Оголосили змінну без ініціалізації

    void Start()
    {
        // Створюємо об’єкт один раз при старті
        spriteObj = new GameObject("MySprite");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(a))
        {
            if (!grounded)
            {
                grounded = true;

                if (par != null)
                {
                    par.transform.position = collision.contacts[0].point;
                    par.Play();

                    // Додаємо SpriteRenderer до існуючого spriteObj
                    SpriteRenderer renderer = spriteObj.GetComponent<SpriteRenderer>();
                    if (renderer == null) // Перевіряємо, чи немає ще компонента
                    {
                        renderer = spriteObj.AddComponent<SpriteRenderer>();
                    }

                    Sprite sprite = Resources.Load<Sprite>("pngkey.com-graffiti-splatter-png-8213267");
                    renderer.sprite = sprite;
                    spriteObj.transform.position = new Vector3(0, 0, 0);
                }
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag(a))
        {
            grounded = false;
        }
    }
}
