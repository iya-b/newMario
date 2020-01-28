using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum GameState { Play, Pause }

public class GameController : MonoBehaviour
{
    private GameState state;
    static private GameController _instance;
    private int score;
    float dragonHitScore;
    float dragonKillScore;
    public static GameController Instance
    {
        get
        {
            return _instance;
        }
    }
    private void Awake()
    {
        _instance = this;
        state = GameState.Play;
    }
    public void Hit(IDestructable victim)
    {
        if (victim.GetType() == typeof(Dragon))
        {
            if (victim.Health > 0)
            {
                score += 10;
            }
            else
            {
                score += 50;
            }
            Debug.Log("Dragon hit.Current score " + score);
        }
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
