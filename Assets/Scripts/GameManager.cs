using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    /*
    private int Puntaje = 0;
    private int Vidas = 2;
    private int Zombies = 0;
    private int VidaZombie = 2;
    private int RespawnVida =2;
    private int VidaGanada = 0;
    // Start is called before the first frame update
    
    public void GanarPuntos() {
        Puntaje +=1;
    }
    public void PerderPuntos() {
        Puntaje -=1;
    }

    public void MatarZombie() {
        Zombies +=1;
    }

    public void PerderVidas() {
        if(Vidas > 0)
            Vidas -= 1;
    }

    public void PerderVidasZombie() {
        if(VidaZombie > 0)
            VidaZombie -= 1;
    }

    public void GanarVidasZombie() {
        if(VidaZombie == 0)
            VidaZombie+=2;
    }

    public int GetPuntaje() {
        return Puntaje;
    }

    public int GetVidas() {
        return Vidas;
    }
    public int GetVidaZombie() {
        return VidaZombie;
    }

    public int GetVidaZombieGanada() {
        return VidaZombie;
    }

    public int GetZombies() {
        return Zombies;
    }

    public int GetRespawn() {
        return RespawnVida;
    }

    */
    GameData gameData = new GameData();
    GameRepository gameRepository;
    Text MonedasText;
    Text vidaText;
    void Start() {
        
        gameRepository = GetComponent<GameRepository>();

        //gameRepository.SaveData(gameData);

        MonedasText = GameObject.Find("/Canvas/MonedasText").GetComponent<Text>();
        vidaText = GameObject.Find("/Canvas/VidaText").GetComponent<Text>();

        gameData = gameRepository.GetSavedData();

        LoadScreenTexts();
    }

    void LoadScreenTexts() {
        MonedasText.text = $"Monedas: {gameData.Score}";
        vidaText.text = $"Vidas: {gameData.Vidas}";
    }

    public void GanarMoneda() {
        gameData.Score++;
        gameRepository.SaveData(gameData);
        LoadScreenTexts();
    }

    public void GuardarPartida1(){
        gameRepository.SaveData(gameData);
    }

    public void CambiarScena(){
        int valorMoneda = gameData.Score;
        //Debug.Log(valorMoneda);

        if (SceneManager.GetActiveScene().name == "Scene1"){
            if(valorMoneda >= 10){
            SceneManager.LoadScene("Scene3");
        }
        }
        
        if (SceneManager.GetActiveScene().name == "Scene3")
            {
            // Realizar alguna acción específica para la escena "NuevaEscena"
                Debug.Log("Estás en la escena NuevaEscena");
                if(valorMoneda >= 20){
                    SceneManager.LoadScene("Scene4");
                }
                //EliminarData();
            }
            
        
    }


    /*public void EliminarData()
    {
        gameRepository.DeleteData();
        Debug.Log("Se eliminó la data guardada");
    }
    */
    public void RegresarMain(){
        SceneManager.LoadScene("SceneMain");
    }
    /*
    public List<string> GetSkills() {
        return gameData.Skills;
    }
    */
}
