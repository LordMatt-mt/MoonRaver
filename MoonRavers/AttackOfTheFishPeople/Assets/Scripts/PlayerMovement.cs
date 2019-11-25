using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {

    public CharacterController character;
    public Animator an;
    public WeaponScript gun;
    public float speed;
	public float jumpForce;
	public float gravity;
	private Vector3 movePlayer;
	private bool isGrounded;
	public float slide = 6f;
	private Vector3 hitVector;
    public int CrystalCount = 0;
    public Text Crystalcollect;
    public float damage = 10f;
	public float maxHealth = 100f;
    public float currentHealth;
	public Image healthBar;
    public Image bloodHUD;
    private Color tempAlpha;
	private bool playerAlive = true;
    public Canvas levelComplete;
    private float horizontal;
    private float vertical;

    void Awake()
    {
        character = GetComponent<CharacterController>();
        //Cursor.visible = false;
      
    }

    // Use this for initialization
    void Start()
    {
        currentHealth = maxHealth;
        //Cursor.visible = false;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
		
		healthBar.fillAmount = currentHealth/100f;
        

        if (character.isGrounded == true) 
		{

            if (Input.GetKey(KeyCode.LeftShift))
            {
                horizontal = speed * 2 * Input.GetAxis("Horizontal");
                vertical = speed * 2 * Input.GetAxis("Vertical");
            }
            else
            {
                horizontal = speed * Input.GetAxis("Horizontal");
                vertical = speed * Input.GetAxis("Vertical");
            }

            movePlayer = new Vector3 (horizontal, 0, vertical);
			movePlayer = transform.TransformDirection(movePlayer);
		

			if(Input.GetKey(KeyCode.Space))
			{
				
				movePlayer.y = jumpForce;
			}

		}

        movePlayer.y = movePlayer.y - (gravity * Time.deltaTime);

        character.Move(movePlayer * Time.deltaTime);


        if (isGrounded == false) 
		{
			movePlayer.x = (1f - hitVector.y) * hitVector.x * slide;
			movePlayer.z = (1f - hitVector.y) * hitVector.z * slide;
		}

		isGrounded = Vector3.Angle (Vector3.up, hitVector) <= character.slopeLimit;


      
    }

	private void OnControllerColliderHit(ControllerColliderHit hit)
	{
        hitVector = hit.normal;
	}

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Crystal")
        {
            CrystalCount += 1;
            Crystalcollect.text = "Crystals: " + CrystalCount;
            col.gameObject.SetActive(false);
        }

        if(col.tag == "crytal 2")
        {
            CrystalCount += 1;
            Crystalcollect.text = "Crystals: " + CrystalCount;
            col.gameObject.SetActive(false);
            if(CrystalCount == 11)
            {
                levelComplete.gameObject.SetActive(true);
                Cursor.visible = true;
              
            }
        }

        if (col.tag == "Ammo")
        {
            if (!gun.fullyLoaded)
            {
                gun.AddAmmo(30);
                col.gameObject.SetActive(false);
			    gun.noAmmo.gameObject.SetActive (false);
            }
        }

        if (col.tag == "Health")
        {
            if (currentHealth < maxHealth)
            {
                currentHealth = currentHealth + 50;
                bloodHUD.color = new Color(bloodHUD.color.r, bloodHUD.color.g, bloodHUD.color.b, 1 - 0.01f*currentHealth);
                col.gameObject.SetActive(false);
                if (currentHealth > maxHealth) currentHealth = maxHealth;
            }
            
        }

        if(col.gameObject.tag == "NextLevel")
        {
            levelComplete.gameObject.SetActive(true);
            Cursor.visible = true;
            character.enabled = false;
        }
    }

	private void OnCollisionEnter(Collision bullet)
	{
		if (bullet.gameObject.tag == "Bullet") 
		{
			
			currentHealth = currentHealth - damage;
            bloodHUD.color = new Color(bloodHUD.color.r, bloodHUD.color.g, bloodHUD.color.b, 1 - 0.01f * currentHealth);

        }
	}

    private void OnTriggerStay(Collider col)
    {
        if(col.tag == "Door" && CrystalCount == 10)
        {
            an.SetTrigger("OpenDoor");
            print("Door Opened");
        }
    }

    

}
