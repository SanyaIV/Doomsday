using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public float damage = 25f;
	public float speed = 3f;

	public LayerMask layerMask;
	public Vector3 playerDistance;
	public float playerDistanceX;
	public float playerDistanceY;
	public float EnemyPlayerPosition;
	public BoxCollider2D[] myColliders;
    public AudioClip hitSound;
    public AudioClip dieSound;

	Transform Player;
	Rigidbody2D myBody;
	Transform myTrans;
	float myWidth, myHeight;
	public Vector2 myVel; 
	
	void Start () {
		myTrans = this.transform;
		myBody = this.GetComponent<Rigidbody2D>();
		SpriteRenderer mySprite = this.GetComponent<SpriteRenderer>();
		myWidth = mySprite.bounds.extents.x;
		myHeight = mySprite.bounds.extents.y;

		Player = GameObject.FindWithTag ("Player").transform;

		myColliders = gameObject.GetComponents<BoxCollider2D>();
        transform.localScale += new Vector3(3f, 3f, 0);
    }

	void FixedUpdate() {

        // Se om det är mark under eller blockad framför
        Vector2 lineCastPos = myTrans.position.toVector2() - myTrans.right.toVector2() * myWidth * 3f + Vector2.up * myHeight * 3f;
        Debug.DrawLine(lineCastPos, lineCastPos + Vector2.down);
        bool isGrounded = Physics2D.Linecast(lineCastPos, lineCastPos + Vector2.down, layerMask);
        Debug.DrawLine(lineCastPos, lineCastPos - myTrans.right.toVector2() * .2f);
        bool isBlocked = Physics2D.Linecast(lineCastPos, lineCastPos - myTrans.right.toVector2() * .2f, layerMask);

        // om det inte är mark eller blockad så vänd
        if (!isGrounded || isBlocked) {
			Vector3 currRot = myTrans.eulerAngles;
			currRot.y += 180;
			myTrans.eulerAngles = currRot;
		}
			
		playerDistance = GameObject.FindWithTag("Player").transform.position - transform.position;
		playerDistanceX = Mathf.Abs (playerDistance.x);
		playerDistanceY = Mathf.Abs (playerDistance.y);
		if (playerDistanceX <= 4 && playerDistanceY <= 1f) {
			EnemyPlayerPosition = Player.position.x - myTrans.position.x;
			if (EnemyPlayerPosition < 0) {
				Vector3 currRot = myTrans.eulerAngles;
				currRot.y = 360;
				myTrans.eulerAngles = currRot;
				myVel = myBody.velocity;
				myVel.x = -myTrans.right.x * speed / 2;
				myBody.velocity = myVel;
			} else if (EnemyPlayerPosition > 0) {
				Vector3 currRot = myTrans.eulerAngles;
				currRot.y = 180;
				myTrans.eulerAngles = currRot;
				myVel = myBody.velocity;
				myVel.x = -myTrans.right.x * speed / 2;
				myBody.velocity = myVel;
			}
		} else {
			myVel = myBody.velocity;
			myVel.x = -myTrans.right.x * speed / 2;
			myBody.velocity = myVel;
		}	


	}

	void OnTriggerStay2D(Collider2D other) {
		if(other.CompareTag("Player")){
			// Kolliderguyar detta objekt med spelaren bör denna göra via Harm(float) funktionen som finns i spelarens PlayerVariables script.
			other.GetComponent<PlayerVariables> ().Harm (34f);
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if(other.CompareTag("Player")){
			var force = other.transform.position - transform.position;
			force.Normalize();
			other.GetComponent<PlatformInputs>().rigidBody.velocity = new Vector2(7f * force.x, 7f);

			other.GetComponent<PlayerVariables> ().Harm (34f);
		}
        if (other.CompareTag("Projectile"))
        {
            GetComponentInChildren<KillEnemy>().health--;
            SoundManager.instance.RandomizeSfx(hitSound);
            if (GetComponentInChildren<KillEnemy>().health <= 0)
            {
                GameObject.FindWithTag("SlimeEjac").GetComponent<InstantiateSlime>().killed++;
                StartCoroutine(Die());
            }
        }
	}

	public IEnumerator Die(){
        SoundManager.instance.RandomizeSfx(dieSound);
        //GetComponent<BoxCollider2D>().enabled = false;
        foreach (BoxCollider2D bc in myColliders) bc.enabled=false;
        GetComponentInChildren<KillEnemy>().Die();
        //GetComponentInParent<EnemyParentCounter> ().enemies++;
        enabled = false;
		GetComponent<Rigidbody2D>().AddForce(new Vector2(2f,13f),ForceMode2D.Impulse);
		transform.localScale = new Vector3(transform.localScale.x, -transform.localScale.y, transform.localScale.z);
		
		// Denna funktion stänger av diverse funktioner för att få fienden se levande ut när den dör (...) men objektet tas bort direkt när man träffar det. Kan vi lägga in en paus? 2 sekunder verkade fungera bra.
		yield return new WaitForSeconds(2);
		Destroy (gameObject);
		//gameObject.SetActive(false);
	}
}
