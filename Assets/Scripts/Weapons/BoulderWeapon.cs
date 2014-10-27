using UnityEngine;
using System.Collections;

public class BoulderWeapon : MonoBehaviour {
	private float unit = 2.5f;
	private float speed = 20.0f;
	private float currentCooldown = 0.0f;
	private float cooldown = 3.0f;

	void Start() {
	}

	void OnGUI () {
		Event e = Event.current;
		if (e.isKey) {
			// fire boulder weapon
			if(e.keyCode == KeyCode.F && currentCooldown <= 0.0f) {
				currentCooldown = cooldown;
				Vector3 fwd = Camera.main.transform.TransformDirection(Vector3.forward) * unit;
				Vector3 offset = transform.position + fwd + 2*Vector3.down;
				GameObject boulder = (GameObject)Instantiate(Grid.boulderPrefab, offset, transform.rotation);
				Rigidbody rb = boulder.AddComponent<Rigidbody>();
				rb.mass = 1.0f;
				rb.AddForce(fwd * speed, ForceMode.Impulse);
				audio.Play();
				Destroy (boulder, 120);
			}
		}
		
	}
	
	void Update() {
		if(currentCooldown > 0.0f) {
			currentCooldown -= 0.1f;
		}
		if(currentCooldown < 0.0f) {
			currentCooldown = 0.0f;
		}
	}
}
