using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Cinematic : MonoBehaviour
{
    public GameObject captainDiego;
    public GameObject hernanCortes;

    public TMP_Text dialogueText;

    private int dialogueIndex = 0;
    private string[] dialogues = {
        "Año 1519. El Imperio Mexica se encuentra en su apogeo, dominando vastas regiones de Mesoamérica bajo el gobierno del Tlatoani Moctezuma.",
        "Después de desembarcar en las costas de Veracruz, Hernán Cortés y sus hombres avanzan, buscando la manera de asegurar alianzas estratégicas.",
        "Hernán Cortés: \"Capitán Diego, debemos movernos rápido. La tierra es rica, pero sus habitantes son numerosos y poderosos.\"",
        "Capitán Diego: \"Sí, señor. Los hombres están inquietos. Cuentan historias sobre un gran imperio lleno de tesoros y peligros. ¿Cómo procederemos?\"",
        "Hernán Cortés: \"Nuestra prioridad es encontrar aliados entre los pueblos que sufren bajo el yugo mexica. Sus resentimientos serán nuestra fuerza en esta conquista.\"",
        "Hernán Cortés: \"Capitán Diego, creo que será mejor que me adentre solo. Necesito explorar estas tierras y conocer a los posibles aliados por mí mismo. No tardaré.\""

    };

    // Start is called before the first frame update
    void Start()
    {
        dialogueText.text = dialogues[dialogueIndex];
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            dialogueIndex++;
            if (dialogueIndex < dialogues.Length)
            {
                dialogueText.text = dialogues[dialogueIndex];
            }
            else
            {
                LoadNextScene();
            }
        }
    }

    void LoadNextScene()
    {
        // Lógica para cargar la siguiente escena (nivel)
        SceneManager.LoadScene("Nivel 1");
    }
}
