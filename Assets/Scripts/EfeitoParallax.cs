using UnityEngine;
using UnityEngine.UI;
/*
======================================
Classe: Efeito de Parallax:
Analista: Marcos Felix
Data: 27-03-2021
Game: Balão
======================================

*/
public class EfeitoParallax : MonoBehaviour
{
    [SerializeField] private Image fundo;
    [SerializeField] private float velocidade;

   
    private void Update()
    {
        MoveFundo();
    }

    public void MoveFundo()
    {  // Parte comentada: Ativa o parallax com o input do teclado.
       // transform.position = new Vector3(transform.position.x - velocidade * Time.deltaTime  * Input.GetAxisRaw("Horizontal"), 0, 0);
          transform.position = new Vector3(transform.position.x - velocidade * Time.deltaTime * 1,0,0) ;
     

        if(transform.localPosition.x >= fundo.preferredWidth)
        {
            transform.localPosition = new Vector3(transform.localPosition.x - fundo.preferredWidth * 2, 0, 0);            
        } else if(transform.localPosition.x <= -fundo.preferredWidth)
        {
            transform.localPosition = new Vector3(transform.localPosition.x + fundo.preferredWidth * 2, 0, 0);
        }
    }
}
