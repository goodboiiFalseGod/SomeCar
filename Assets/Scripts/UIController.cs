using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public int Score = 0;
    public Text Ulose;
    public Text ScoreUI;
    public Text CarHealth;

    public static UIController instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        Ulose.text = "";
    }

    // Update is called once per frame
    /*void Update()
    {   
        foreach (VictimHealth victimHealth in FindObjectsOfType<VictimHealth>())
        {
            if (victimHealth.tag == "Dead")
            {
                Score += 10;
                ScoreUI.text = "Score: " + Score.ToString();

                foreach (CarHealth carHealth in FindObjectsOfType<CarHealth>())
                {
                    carHealth.health += 20;
                    if (carHealth.health > 100)
                    {
                        carHealth.health = 100;
                    }
                    carHealth.GameDifficulty += 1;
                }

                victimHealth.tag = "Alive";
            }
        }
    }

    private void FixedUpdate()
    {
        foreach (CarHealth carHealth in FindObjectsOfType<CarHealth>())
        {
            //CarHealth.text = carHealth.health.ToString();

            if (carHealth.tag == "DeadCar")
            {
                Ulose.text = "You Lose";
            }
        }
    }*/

    public void ShowHealth(int hp)
    {
        CarHealth.text = hp.ToString();
    }
}
