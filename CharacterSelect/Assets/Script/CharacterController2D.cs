/*
                                     IMPORTANT
   -------------------------------------------------------------------------------------
   This code was open source and provided by Brackeys YouTube Channel. 
   We have edited the code in this file. The original can be found in the link below.

   link to original code: https://github.com/Brackeys/2D-Character-Controller/blob/master/CharacterController2D.cs
*/

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

public class CharacterController2D : MonoBehaviour
{
    [SerializeField] private float m_JumpForce1 = 400f;                          // Amount of force added when the player jumps.
    [SerializeField] private float m_JumpForce2 = 600f;
    [SerializeField] private float m_JumpForce3 = 900f;
    [Range(0, 1)] [SerializeField] private float m_CrouchSpeed = .36f;          // Amount of maxSpeed applied to crouching movement. 1 = 100%
    [Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;  // How much to smooth out the movement
    [SerializeField] private bool m_AirControl = false;                         // Whether or not a player can steer while jumping;
    [SerializeField] private LayerMask m_WhatIsGround;                          // A mask determining what is ground to the character
    [SerializeField] private Transform m_GroundCheck;                           // A position marking where to check if the player is grounded.
    [SerializeField] private Transform m_CeilingCheck;                          // A position marking where to check for ceilings
    [SerializeField] private Collider2D m_CrouchDisableCollider;                // A collider that will be disabled when crouching

    const float k_GroundedRadius = .2f; // Radius of the overlap circle to determine if grounded
    private bool m_Grounded;            // Whether or not the player is grounded.
    const float k_CeilingRadius = .2f; // Radius of the overlap circle to determine if the player can stand up
    private Rigidbody2D m_Rigidbody2D;
    private bool m_FacingRight = true;  // For determining which way the player is currently facing.
    private Vector3 m_Velocity = Vector3.zero;

    public Image heart1;
    public Image heart2;
    public Image heart3;
    public int health = 3;
    public GameObject rec;

    [Header("Events")]
    [Space]

    public UnityEvent OnLandEvent;

    [System.Serializable]
    public class BoolEvent : UnityEvent<bool> { }
    
    public BoolEvent OnCrouchEvent;
    private bool m_wasCrouching = false;

    private void Awake()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();

        if (OnLandEvent == null)
            OnLandEvent = new UnityEvent();

        if (OnCrouchEvent == null)
            OnCrouchEvent = new BoolEvent();
    }

    private void Start()
    {
        
    }

    void OnCollisionEnter2D(Collision2D touched)//determines which buttons are pressed
    {

        if (touched.gameObject.tag == "Obstacle1") //health up/down
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

    private void FixedUpdate()
    {
        bool wasGrounded = m_Grounded;
        m_Grounded = false;

        // The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
        // This can be done using layers instead but Sample Assets will not overwrite your project settings.
        Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                m_Grounded = true;
                if (!wasGrounded)
                    OnLandEvent.Invoke();
            }
        }
    }


    public void Move(float move, float jump)
    {

        //only control the player if grounded or airControl is turned on
        if (m_Grounded || m_AirControl)
        {
        

            // Move the character by finding the target velocity
            Vector3 targetVelocity = new Vector2(move * 10f, m_Rigidbody2D.velocity.y);
            // And then smoothing it out and applying it to the character
            m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);

            // If the input is moving the player right and the player is facing left...
            if (move > 0 && !m_FacingRight)
            {
                // ... flip the player.
                Flip();
            }
            // Otherwise if the input is moving the player left and the player is facing right...
            else if (move < 0 && m_FacingRight)
            {
                // ... flip the player.
                Flip();
            }
        }
        // If the player should jump...
        if (m_Grounded && jump==1f)
        {
            // Add a vertical force to the player.
            m_Grounded = false;
            m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce1));
        }
        else if (m_Grounded && jump==2f)
        {
            // Add a vertical force to the player.
            m_Grounded = false;
            m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce2));
        }
        else if (m_Grounded && jump == 3f)
        {
            // Add a vertical force to the player.
            m_Grounded = false;
            m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce3));
        }
    }


    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        m_FacingRight = !m_FacingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}