using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    static private HUD _instance;
    [SerializeField]
    Slider healthBar;

    [SerializeField]
    Text scoreLabel;
    public static HUD Instance
    {
        get
        {
            return _instance;
        }
    }
    
    public Slider HealthBar
    {
        get
        {
            return healthBar ;
        }
        set
        {
            healthBar = value;
        }
    }
    private void Awake()
    {
        _instance = this;
    }
    public void SetScore(string scoreValue)
    {
        scoreLabel.text = scoreValue;
    }
   
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
