using UnityEngine;
using System.Collections;
/*
======================================
Classe: Desctroi particula:
Analista: Marcos Felix
Data: 27-03-2021
Game: Balão
======================================
*/
public class DestroiParticula : MonoBehaviour {

	void Start () {

		Invoke("ApagaObjeto", 1.5f);
	
	}	

	void Update () {
		
	
	}

	void ApagaObjeto(){

		Destroy (this.gameObject);
	}
}
