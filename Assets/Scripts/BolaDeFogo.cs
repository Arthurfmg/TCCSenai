using UnityEngine;
using System.Collections;

public class BolaDeFogo : MonoBehaviour {
	private float posicaoY = 0f;

	// Use this for initialization
	void Start () {
		Destroy (gameObject,2f);
		GetComponent<Rigidbody2D>().AddForce(transform.up * 400f);
		posicaoY = transform.position.y;
	
	}
	
	// Update is called once per frame
	void Update () {
		if (posicaoY > transform.position.y) { //Descendo
			transform.eulerAngles = new Vector2(180, 0);
		}
		posicaoY = transform.position.y;
	
	}
}
