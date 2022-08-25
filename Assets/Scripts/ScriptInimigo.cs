using UnityEngine;
using System.Collections;
/*
======================================
Classe: Script Inimigo:
Analista: Marcos Felix
Data: 27-03-2021
Game: Balão
======================================

*/
public class ScriptInimigo : MonoBehaviour {
	GameObject Jogador;
	bool marcarPonto;

	void Start () {
		GetComponent<Rigidbody2D> ().velocity = new Vector2 (-4,0);
		Jogador = GameObject.FindGameObjectWithTag ("Player");
	}

	void Update () {
		if (transform.position.x < -20) {
			Destroy (this.gameObject);

		} else {

			if (transform.position.x < Jogador.transform.position.x) {

				if (!marcarPonto) {
					marcarPonto = true;
					GetComponent<Rigidbody2D> ().velocity = new Vector2 (-7.5f, 5.0f);
					GetComponent<Rigidbody2D> ().isKinematic = false;
					Jogador.SendMessage ("MarcaPonto");
				}
			}
		}
		}
	}

