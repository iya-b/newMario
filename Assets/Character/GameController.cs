using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum GameState { Play, Pause }

public class GameController : MonoBehaviour
{
    private GameState state;
    static private GameController _instance;
    private int score;
    int dragonHitScore;
    int dragonKillScore;
    [SerializeField]
    float maxHealth;
    public static GameController Instance
    {
        get
        {
            return _instance;
        }
    }
    public float MaxHealth
    {
        get
        {
            return maxHealth;
        }
        set
        {
            maxHealth = value;
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
            {
                HUD.Instance.HealthBar.value = victim.Health;
            }
            if (victim.Health > 0)
            {
                Score += dragonHitScore;
            }
            else
            {
                Score  += dragonKillScore;
            }
            Debug.Log("Dragon hit.Current score " + score);
        }
    }
    private int Score
    {
        get
        {
            return score;
        }
        set
        {

            if (value != score)
            {
                score = value;
                HUD.Instance.SetScore(score.ToString());
            }

        }
    }


    void Start()
    {
        HUD.Instance.HealthBar.maxValue = maxHealth;

        HUD.Instance.HealthBar.value = maxHealth;

        HUD.Instance.SetScore(Score.ToString());

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
