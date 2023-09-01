using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Bank : MonoBehaviour
{
    [SerializeField] int startingBalance;


    [SerializeField] int currentBalance;
    public int CurrentBalance { get { return currentBalance; } }


    [SerializeField] private TextMeshProUGUI displayBalance;

    private void Awake()
    {
        currentBalance = startingBalance;
        UpdateDisplay();
    }

    public void Deposit(int amount)
    {
        currentBalance += Mathf.Abs(amount);
        UpdateDisplay();

    }

    public void Withdraw(int amount)
    {
        currentBalance -= Mathf.Abs(amount);

        if (currentBalance < 0)
        {
            ReloadScene();
            //Lose the game
        }
        UpdateDisplay();
    }


    private void UpdateDisplay()
    {
        displayBalance.text = "Gold: " + currentBalance;
    }
    private void ReloadScene()
    {
        //Reload the active scene.
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
