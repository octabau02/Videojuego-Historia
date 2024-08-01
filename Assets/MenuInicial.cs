using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuInicial : MonoBehaviour
{
   public void Jugar()
   {
    SceneManager.LoadScene("NivelesScene");
   }

   public void Salir(){
    Debug.Log("Salir...");
    Application.Quit();
   }

   public void creditos(){
      SceneManager.LoadScene("CreditsScene");
   }

   public void ayuda(){
      SceneManager.LoadScene("HowToPlayScene");
   }

   public void ajustes(){
      SceneManager.LoadScene("SettingsScene");
   }

   public void volver(){
      SceneManager.LoadScene("MenuScene");
   }
   public void nivel1(){
      SceneManager.LoadScene("Intro Cinematic");
   }
}

