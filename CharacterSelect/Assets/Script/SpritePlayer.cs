using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SpritePlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public Image bar;
    public Image heart1;
    public Image heart2;
    public Image heart3;
    public GameObject rec;
    public float speed;
    public int health = 3;
    float m_JumpForce1 = 15f;
    float m_JumpForce2 = 20f;
    float m_JumpForce3 = 30f;
    public Rigidbody2D m_Rigidbody2D;
    public float power = 0;
    public float fillAmount;

    [SerializeField]
    private Color full;
    [SerializeField]
    private Color low;
    [SerializeField]
    private Color mid;


    // Update is called once per frame
    void OnCollisionEnter2D(Collision2D touched)//determines which buttons are pressed
    {

        if (touched.gameObject.tag == "obstacle")
        {
            health -= 1;
            if (health == 2)
            {
                heart3.color = Color.clear;
                //Destroy(heart3);
            }
            else if (health == 1)
            {
                heart2.color = Color.clear;
                //Destroy(heart2);
            }

        }
        if (touched.gameObject.tag == "healthRec")
        {
            Destroy(rec);
            if (health == 2)
            {
                heart3.color = Color.red;
                health += 1;
            }
            else if (health <= 1)
            {
                heart2.color = Color.red;
                health += 1;
            }

        }
    }
    private void Start()
    {
        bar.fillAmount = 1f;
    }
    void Update()
    {

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            power += .1f;
            bar.fillAmount = power / 15f;
            fillAmount = power / 15f;
            if (fillAmount < .33f)
            {
                bar.color = low;
            }
            else if (fillAmount > .33f && fillAmount < .66f)
            {
                bar.color = mid;
            }
            else if (fillAmount > .66f)
            {
                bar.color = full;
            }
            //bar.color = Color.Lerp(low, full, fillAmount);
        }
        else
        {
            //float moveHorizontal = Input.GetAxis("Horizontal");
            //Vector3 movement = new Vector3(moveHorizontal, 0.0f, 0.0f);
            if (power > 0 && power < 5)
            {
                Vector3 jumpMovement = new Vector3(0.0f, 1.0f, 0.0f);
                m_Rigidbody2D.velocity = jumpMovement * m_JumpForce1;

            }
            else if (power > 5 && power < 10)
            {
                Vector3 jumpMovement = new Vector3(0.0f, 1.0f, 0.0f);
                m_Rigidbody2D.velocity = jumpMovement * m_JumpForce2;
            }
            else if (power > 10)
            {
                Vector3 jumpMovement = new Vector3(0.0f, 1.0f, 0.0f);
                m_Rigidbody2D.velocity = jumpMovement * m_JumpForce3;
            }


            power = 0;
        }

        /* private void Flip()
         {
             // Switch the way the player is labelled as facing.
             m_FacingRight = !m_FacingRight;

             // Multiply the player's x local scale by -1.
             Vector3 theScale = transform.localScale;
             theScale.x *= -1;
             transform.localScale = theScale;
         }*/
    }
}
