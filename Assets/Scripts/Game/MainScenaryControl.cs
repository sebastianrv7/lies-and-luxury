using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MainScenaryControl : MonoBehaviour
{
    
    public int contador = 1;
    public bool estadoDeEmpresa;
    public float probabilidadEvento = 0.5f;

    void start()
    {
        float na = Random.value;
        estadoDeEmpresa = (probabilidadEvento >=0.5);

        Debug.Log("Evento activo al inicio"+ estadoDeEmpresa);
            
    }

    public void CambiarEstadoEmpresa(){


    }

    
    public void CambiaTiempo(){
        if(contador <3){
            contador++;

        }else{
            contador =1;
        }
        
        Debug.Log("Contador: "+ contador);
    }
  

    

}
