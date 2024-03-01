using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CustomExtensions;
using UnityEngine.SceneManagement;

public class GameBehavior : MonoBehaviour, IManager
{
    
    private string _state;
    public string State
    {
        get { return _state;}
        set { _state = value;}
    }
    void Start()
    {
        Initialize();
    }

    public void Initialize()
     {
        _state = "Manager intialized..";
        _state.FancyDebug();
        Debug.Log(_state);
    }

    public bool showWinScreen = false;
    public bool showLossScreen = false;

    public string labelText = "Collect all 4 items and win your freedom!";
    

    public int maxItems = 4;
    private int _itemsCollected = 0;

    public int Items
    {
        get { return _itemsCollected; }

        set { _itemsCollected = value;
            Debug.LogFormat("Items: {0}", _itemsCollected);

            if(_itemsCollected >= maxItems)
            {
                labelText = "You've found all the items!";
                showWinScreen = true;
                Time.timeScale = 0f;
            }
            else
            {
                labelText = "Item found, only " + (maxItems - _itemsCollected) + " more to go!";
            }
        }
    }

    private int _playerHP = 100;
    public int HP
    {
        get { return _playerHP; }
        set { _playerHP = value;

            if(_playerHP <= 0)
            {
                labelText = "You want another life with that?";
                showLossScreen = true;
                Time.timeScale = 0;
            }
            else
            {
                labelText = "Ouch... that's got to hurt.";
            }
        }
    }

    public int maxPower = 105;
    private int _shieldPower = 0;
    public int Shield
    {
        get{ return _shieldPower; }
        set { _shieldPower = value;
            Debug.LogFormat("Shield: {0}", _shieldPower);
            
            if(_shieldPower >= maxPower)
            {
                labelText = "You are charged!";
            }
            else
            {
                labelText = "Charged!";
            }
        }
    }
        

    public int maxAmmo = 20;
    private int _ammoTaken = 0;
    public int Ammo
    {
        get{ return _ammoTaken; }
        set { _ammoTaken = value;
            Debug.LogFormat("Shield: {0}", _ammoTaken);
            
            if(_ammoTaken >= maxAmmo)
            {
                labelText = "Tons of Ammo!";
            }
            else
            {
                labelText = "Ammo!";
            }
        }
    }
        
    void RestartLevel()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1.0f;
    }
    void OnGUI()
    {
        GUI.Box(new Rect(20, 20, 150, 25), "Player Health:" + _playerHP);
        GUI.Box(new Rect(20, 50, 150, 25), "Shield Power: " + _shieldPower);
        GUI.Box(new Rect(20, 80, 150, 25), "Ammo Taken: " + _ammoTaken);
        GUI.Box(new Rect(20, 110, 150, 25), "Items Collected: " + _itemsCollected);

        GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height - 50, 300, 50), labelText);

        if(showWinScreen)
        {
            if(GUI.Button(new Rect(Screen.width/2 - 100, Screen.height/2 - 50, 200, 100), "YOU WON!"))
            {
                SceneManager.LoadScene(0);
                Time.timeScale = 1.0f;
                Utilities.RestartLevel(0);
            }
        }


        if(showLossScreen)
        {
            if(GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 50, 200, 100), "You lose..."))
            {
                SceneManager.LoadScene(0);
                Time.timeScale = 1.0f;
                Utilities.RestartLevel(0);
            }
        }

    }
}
