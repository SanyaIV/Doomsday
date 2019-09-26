using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class PlayerVariables : MonoBehaviour {

	public float health = 100f;

	[HideInInspector]
	public int coins = 0;
	
	public float damageTimer = 1f;

    private Animator anim;
    private Slider healthSlider;
	private Text coinUI;
	private Vector3 startPos;
	public Rigidbody2D myBody;
    public bool deWalk = false;
    private bool deaded = false;
    public AudioClip dieSound;
    public AudioClip hitSound;


    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    void Start ()
    {
        anim = GetComponent<Animator>();
        GetComponent<PlatformInputs>().PlayOpa(1);
        GetComponent<PlatformInputs>().enabled = false;
        startPos = transform.position;
        Cursor.visible = true;
    }

	void Update () {
        
        // damageTimer bör öka med tiden som gått från senaste uppdate-loopen. Tiden räknas ut genom att addera Time.deltaTime;
        damageTimer += Time.deltaTime;
		if (damageTimer > 10) damageTimer = 1;

        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            healthSlider.value = Mathf.Lerp(healthSlider.value, health, Time.deltaTime);
            if (!GetComponent<PlatformInputs>().jetpack)
            {
                coinUI.text = coins + "/4";
            }else
            {
                coinUI.text = "";
            }
        }

        anim.SetBool("DeWalk", deWalk);
    }

	public void Harm(float dmg){
		
		// Om damageTimer är större än en sekund bör vi sänka health med damage. Vi bör även sätta damageTimer till 0f för att nollställa timern.
		if (damageTimer > 1) {
			health -= dmg;
			dmg = 0f;
			damageTimer = 0f;
            SoundManager.instance.RandomizeSfx(hitSound);
        }
		// Om health är mindre än 1f så bör vi starta funktionen Die(). Det kan bara göras med StartCoroutine eftersom Die() är en IEnumerator.
		if (health < 1) {
            if (!deaded)
            {
                StartCoroutine("Die");
            }
		}
	}

	IEnumerator Die() {
        deaded = true;
        SoundManager.instance.RandomizeSfx(dieSound);
        GetComponent<Collider2D>().enabled = false;
		GetComponent<PlatformInputs>().enabled = false;
		GetComponent<Rigidbody2D>().AddForce(new Vector2(1f,5f),ForceMode2D.Impulse);
		transform.localScale = new Vector3(transform.localScale.x, -1f, 1f);
        SoundManager.instance.jetPackSource.Stop();
		
		yield return new WaitForSeconds(2f);

		// SceneManager.LoadScene(0); // Load some scene
		// Eller kalla på Respawn-funktionen vi har gjort? 
		Respawn();
	}

	public void Respawn () {
		// Här nollställer vi ett gäng med variabler för att få spelaren att börja om spelet istället för att helst starta om scenen. 
		coins = 0;
        GetComponent<PlatformInputs>().jetpack = false;
        health = 100f;
        deaded = false;

        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            //GameObject.Find("Slime Ejaculator").GetComponent<InstantiateSlime>().Respawn();
            GetComponentInChildren<WeaponTrans>().WeaponOpa(1);
            GetComponent<PlatformInputs>().weapon = false;
            
            SceneManager.LoadScene(1);
            gameObject.transform.position = startPos;

            GetComponent<Collider2D>().enabled = true;
            GetComponent<PlatformInputs>().enabled = true;
            transform.localScale = new Vector3(transform.localScale.x, 1f, 1f);
        }

        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            SceneManager.LoadScene(2);
            gameObject.transform.position = startPos;

            GetComponent<Collider2D>().enabled = true;
            GetComponent<PlatformInputs>().enabled = true;
            transform.localScale = new Vector3(transform.localScale.x, 1f, 1f);
            GameObject.FindWithTag("MainCamera").GetComponent<CameraFollow>().boss = false;
        }

        /* Sätt position, som finns under detta gameObjects transform, till Vector3n startPos.
        gameObject.transform.position = startPos;

		GetComponent<Collider2D>().enabled = true;
		GetComponent<PlatformInputs>().enabled = true;
		transform.localScale = new Vector3(transform.localScale.x, 1f, 1f); */
	}

    public void DoStartPos ()
    {
        transform.position = startPos;
    }

    public void HUDUI ()
    {
        healthSlider = GameObject.Find("HealthSliderUI").GetComponent<Slider>();
        coinUI = GameObject.Find("CoinTextUI").GetComponent<Text>();
    }

}
