using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    [SerializeField] private GameObject menuPausa;
    private bool juegoPausado = false;

    private void Update(){
        if(Input.GetKeyDown(KeyCode.Escape)){
            if (juegoPausado){
                Reanudar();
            }
            else
            {
                Pausar();
            }
        }
    }

    public void Pausar(){
        juegoPausado = true;
        Time.timeScale = 0f;
        menuPausa.SetActive(true);
    }

    public void Reanudar(){
        juegoPausado = false;
        Time.timeScale = 1f;
        menuPausa.SetActive(false);
    }
    public void MenuPrincipal(){
        SceneManager.LoadScene("MenuScene");
    }
    public void Reiniciar(){
        juegoPausado = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


}
