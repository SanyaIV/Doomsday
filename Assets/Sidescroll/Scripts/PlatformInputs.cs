using UnityEngine;
using System.Collections;

public class PlatformInputs : MonoBehaviour {

    public Rigidbody2D rigidBody;
    public GameObject WalkSound;
	public float speed = 10f;
	public float jumpHeight = 11f;
    public float jetStream = 40f;
    public bool jetpack;
    public bool weapon;
	public LayerMask PlayerLayer;
    public int pubfacing;
    public AudioClip moveSound;
    public AudioClip jumpSound;
    public AudioClip jetSound;
    public AudioClip shootSound;


    private Transform groundCheck;
	private bool grounded = false;

	private Animator anim;
	public float horizontalDirection;
    private float horizontalDirection2 = 1;

	void Start () {
		rigidBody = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
		groundCheck = transform.Find("GroundCheck");
        jetpack = false;
        weapon = false;
    }

	void Update () {
        horizontalDirection = Input.GetAxis("Horizontal"); // Det finns en klass som heter Input, den har en funktion som heter GetAxis - Det finns också en string som heter Horizontal som GetAxis tar.
		grounded = Physics2D.OverlapPoint(groundCheck.position);

        if (grounded && horizontalDirection != 0 && GetComponent<PlayerVariables>().deWalk == false)
        {
            //WalkSound.SetActive(true);
            GetComponentInChildren<AudioSource>().enabled = true;
            //GetComponent<PlayerVariables>().deWalk = false;
        }
        else if (horizontalDirection == 0 || !grounded || GetComponent<PlayerVariables>().deWalk == true)
        {
            //WalkSound.SetActive(false);
            GetComponentInChildren<AudioSource>().enabled = false;
            //GetComponent<PlayerVariables>().deWalk = true;
        }

		// Vi bör hoppa när vi använder Space-knappen. Detta ska vi bara göra när vi är grounded. Dvs, byt ut "false" i if-satsen nedan mot någonting som letar efter en typ av GetKeyDown under Input-klassen. 
		//Pil upp = hoppa om den inte används till något annat.
		if(grounded && Input.GetKeyDown("space") && !jetpack || grounded && Input.GetKeyDown("joystick button 0") && !jetpack){
			rigidBody.velocity += new Vector2(rigidBody.velocity.x, jumpHeight);
            SoundManager.instance.RandomizeSfx(jumpSound);
        } else if (jetpack && Input.GetKey("space") || jetpack && Input.GetKey("joystick button 0"))
        {
            rigidBody.velocity += new Vector2(rigidBody.velocity.x * 0.0000005f, jetStream * Time.deltaTime);
            rigidBody.velocity = new Vector2(200f * Time.deltaTime * horizontalDirection2, rigidBody.velocity.y);
        }
        if (jetpack && Input.GetKeyDown("space") || jetpack && Input.GetKeyDown("joystick button 0"))
        {
            SoundManager.instance.PlaySingleJet(jetSound);
        }else if (jetpack && Input.GetKeyUp("space") || jetpack && Input.GetKeyUp("joystick button 0"))
        {
            SoundManager.instance.jetPackSource.Stop();
        }
        
        if(weapon && Input.GetKeyDown(KeyCode.LeftControl) || weapon && Input.GetKeyDown(KeyCode.RightControl))
        {
            GetComponentInChildren<WeaponTrans>().Shoot();
            SoundManager.instance.RandomizeSfx(shootSound);
        }

		anim.SetFloat("Speed", Mathf.Abs(horizontalDirection));
        anim.SetBool("Grounded", grounded);
        anim.SetBool("Jetpack", jetpack);

        if (horizontalDirection > 0)
        {
            Flip(1);
            pubfacing = 1;

        }
        else if (horizontalDirection < 0)
        {
            Flip(-1);
            pubfacing = -1;
        }

		// Vi borde förflytta spelaren via funktionen Translate som finns under dess transform. Här bör horizontalDirection, speed och Time.deltaTime användas

		transform.Translate (Vector3.right * horizontalDirection * speed * Time.deltaTime, Camera.main.transform);
	}

	void Flip (int facingRight) {
		//GetComponent<SpriteRenderer>().flipX = facingRight;
		Vector3 myScale = transform.localScale;
		myScale.x = facingRight; // Vrider sig inte karaktären efter det vi har skickat med till Flip-funktionen?
		transform.localScale = myScale;
        horizontalDirection2 = facingRight;
	}

    public void PlayOpa (int PlayOpaReturn)
    {
        Color PlayerOpacity = GetComponent<SpriteRenderer>().color;

        if (PlayOpaReturn == 1)
        {
            //speed = 0f;
            PlayerOpacity.a = 0f;
            GetComponent<SpriteRenderer>().color = PlayerOpacity;
        } else if (PlayOpaReturn == 2)
        {
            //speed = 10f;
            PlayerOpacity.a = 1f;
            GetComponent<SpriteRenderer>().color = PlayerOpacity;
        }
    }

}
