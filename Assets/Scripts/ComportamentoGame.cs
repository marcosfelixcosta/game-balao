using UnityEngine;
using System.Collections;
/*
======================================
Classe: Comportamento do Game:
Analista: Marcos Felix
Data: 27-03-2021
Game: Balão
======================================

*/
public class ComportamentoGame : MonoBehaviour {
	public GameObject inimigo;
	public GameObject panelplay;
	public AudioClip gato;
    AudioSource Audio;

    void Start(){

        Audio = GetComponent<AudioSource>();
				//gato = GetComponent<AudioSource>();
    }

	void CriaInimigo() {

		float alturaaleatoria = 10.0f * Random.value - 4;
		GameObject novoInimigo = Instantiate (inimigo);
		novoInimigo.transform.position = new Vector2 (15.0f, alturaaleatoria);

	}

	void comecou() {
		panelplay.SetActive(false);
		InvokeRepeating ("CriaInimigo", 0.0f, 1.5f);

	}

	void acabou() {
			CancelInvoke ("CriaInimigo");
        //Audio.Stop();
				Audio.PlayOneShot(gato);

	}

	void exibirpanel() {
			panelplay.SetActive(true);
	}
}
