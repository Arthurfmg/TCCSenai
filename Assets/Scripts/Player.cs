using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float velocidade;
	public float forcaPulo;
	private bool estaNoChao;
	public Transform chaoVerificador;
	public Transform spritePlayer;
	private Animator animator;

	// Use this for initialization
	void Start () {
		animator = spritePlayer.GetComponent<Animator> ();
	
	}
	
	// Update is called once per frame
	void Update () {
		Movimentacao();
	}

	void Movimentacao() {
		if (Input.GetAxisRaw("Horizontal") > 0 ) {
			transform.Translate (Vector2.right * velocidade * Time.deltaTime);
			transform.eulerAngles = new Vector2(0, 0);
		} 	

		if (Input.GetAxisRaw("Horizontal") < 0 ) {
			transform.Translate (Vector2.right * velocidade * Time.deltaTime);
			transform.eulerAngles = new Vector2(0, 180);
		}

		if (Input.GetButtonDown("Jump") && estaNoChao) {
			GetComponent<Rigidbody2D>().AddForce(transform.up * forcaPulo);
		}

		estaNoChao = Physics2D.Linecast(transform.position, chaoVerificador.position, 1 << LayerMask.NameToLayer("Piso"));
		animator.SetBool ("Chao", estaNoChao);

		animator.SetFloat("Movimento", Mathf.Abs (Input.GetAxisRaw ("Horizontal")));

	}
}
