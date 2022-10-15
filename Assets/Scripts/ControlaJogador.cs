using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/*
======================================
Classe: controle do Jogador:
Analista: Marcos Felix
Data: 27-03-2021
Game: Balão
======================================

*/
public class ControlaJogador : MonoBehaviour {
	bool inicio;
	bool fim;
	Rigidbody2D CorpoJogador;
	Vector2 forcaImpulso = new Vector2(0,300f);
	public Text TextoScore;
	GameObject Comportamento;
	int pontuacao;

	
	void Start () {
		Comportamento = GameObject.FindGameObjectWithTag ("MainCamera");
		CorpoJogador = GetComponent<Rigidbody2D>();
	
	}
	
	void Update () {
		if (!fim) {

			if (Input.GetButtonDown ("Fire1")) {
				if (!inicio) {
					inicio = true;
					CorpoJogador.isKinematic = false;

					TextoScore.text = pontuacao.ToString();
					TextoScore.fontSize = 74;
					Comportamento.SendMessage ("comecou");
				}	
				CorpoJogador.velocity = new Vector2 (0,0);
				CorpoJogador.AddForce(forcaImpulso);

				Vector3 posicaoFelpudo = this.transform.position + new Vector3 (0,1,0);
			
			}
			float alturaplayerEmpixel = Camera.main.WorldToScreenPoint (transform.position).y;
			if (alturaplayerEmpixel > Screen.height || alturaplayerEmpixel <0) {
				
				GetComponent<Collider2D> ().enabled = false;
				GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
				GetComponent<Rigidbody2D> ().AddForce (new Vector2 (-100,0));
				GetComponent<Rigidbody2D> ().AddTorque (100f);
				GetComponent<SpriteRenderer> ().color = new Color (9.0f,0.35f,0.35f);
				FimdoJogo ();

			}
	
		}
		}

	void OnCollisionEnter2D() {

		if (!fim) {
			fim = true;
			GetComponent<Collider2D> ().enabled = false;
			GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
			GetComponent<Rigidbody2D> ().AddForce (new Vector2 (-300,0));
			GetComponent<Rigidbody2D> ().AddTorque (300f);
			GetComponent<SpriteRenderer> ().color = new Color (1.0f,0.35f,0.35f);
			FimdoJogo ();
		}

	}
	

	void MarcaPonto() {

		pontuacao++;
		TextoScore.text = pontuacao.ToString();

	}

	void FimdoJogo() {
		Comportamento.SendMessage ("acabou");
       
       
		Invoke ("RecarregarCena",2);
	}
	void RecarregarCena() {
        SceneManager.LoadScene("Balao");
				Comportamento.SendMessage("exibirpanel");

	}
	   
}
