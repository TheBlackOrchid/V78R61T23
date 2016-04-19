using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public Transform head;
	public float speed = 1;

	private Transform myTransform;
	private Rigidbody rb;
	private Vector3 moveVector;
	private bool moving = false;

	void OnEnable(){
		Cardboard.SDK.OnTrigger += TriggerPulled;
	}

	void OnDisable(){
		Cardboard.SDK.OnTrigger -= TriggerPulled;
	}

	void Start()
	{
		myTransform = transform;
		rb = GetComponent<Rigidbody> ();
	}

	void Update()
	{
		if (moving) {
			moveVector = (head.forward - Vector3.up * head.forward.y).normalized * speed;
			//Debug.DrawRay (head.position, moveVector * 10);
		}
	}

	void FixedUpdate()
	{
		if (moving)
		{
			rb.MovePosition (myTransform.position + (moveVector * Time.fixedDeltaTime));
		}
	}

	void TriggerPulled() {
		//Debug.Log("The trigger was pulled!");
		moving = !moving;
	}

}
