using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class MainScenaryControl : MonoBehaviour
{
    public TextMeshProUGUI numberText;
    public int contador = 1;
    public bool estadoDeEmpresa;
    public float probabilidadEstado1 = 100f;

    void Start()
    {
        EstadoOutput();

    }

    public void EstadoOutput()
    {
        bool estado = DeterminarEstado();

        if(estado)
        {
            Debug.Log("Subida");
        }
        else
        {
            Debug.Log("Bajada");
        }
    }
  

  
    public void CambiarEstadoEmpresa(){
        contador++;
        numberText.text = contador + "";
  
        if(contador <3){
            contador = contador + 1;

        }else{
            contador =1;
        }
        
        //Debug.Log("Contador: "+ contador);

        EstadoOutput();

        
    }

    private bool DeterminarEstado(){
        float randomNum = Random.Range (0f, 100f);
        
            
        return randomNum < probabilidadEstado1;
    }
   

    

}
