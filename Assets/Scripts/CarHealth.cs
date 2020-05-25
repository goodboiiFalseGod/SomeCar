using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public int health = 100;
    private int frameSkip = 60;
    private int frame = 0;
    public int GameDifficulty = 1;

    public int Health { 
        get { return health; }
        set { health = value; UIController.instance.ShowHealth(value); }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        frame++;

        if (frame >= (frameSkip / (GameDifficulty * 0.6f)))
        {
            frame = 0;

            Health -= 1;
            if(Health <= 0)
            {
                tag = "DeadCar";
                Debug.Log(Health);
            }
        }
    }
}
