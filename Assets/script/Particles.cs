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

                    spriteObj.transform.position = collision.contacts[0].point;
                    spriteObj.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                    spriteObj.transform.rotation = Quaternion.Euler(90f, 0f, 0f); 

                    // Встановлюємо спрайт
                    SpriteRenderer renderer = spriteObj.GetComponent<SpriteRenderer>();
                    if (renderer == null)
                    {
                        renderer = spriteObj.AddComponent<SpriteRenderer>();
                    }
                    Sprite sprite = Resources.Load<Sprite>("pngkey.com-holi-colour-splash-png-321924");
                    renderer.sprite = sprite;

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
