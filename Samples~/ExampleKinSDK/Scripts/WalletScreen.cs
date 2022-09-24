using System;
using Solana.Unity.Rpc.Types;
using TMPro;
using UnityEngine;

public class WalletScreen : MonoBehaviour
{
    public TextMeshProUGUI txtPublicKey;
    public TextMeshProUGUI txtBalance;
    public TextMeshProUGUI txtHistory;
    public TextMeshProUGUI txtTokenAccountDesc;
    public TMP_InputField txtDestination;
    public TMP_InputField txtAmount;
    public TMP_Dropdown tokenAccountsDropDown;
    public GameObject loading;

    private void OnEnable()
    {
        if (GameController.Keypair != null)
        {
            txtPublicKey.text = GameController.Keypair.PublicKey;
        }
        UpdateBalance();
        GetTokenAccounts();
    }

    public async void UpdateBalance()
    {
        if(GameController.Keypair == null) return;
        var balance = await GameController.KineticSdk.GetBalance( account: GameController.Keypair.PublicKey );
        txtBalance.gameObject.transform.parent.gameObject.SetActive(true);
        txtBalance.text = (float.Parse(balance.Balance) / Math.Pow(10, 5)).ToString("0.00") + " KIN";
    }
    
    public async void GetTokenAccounts()
    {
        if(GameController.Keypair == null) return;
        var accounts = await GameController.KineticSdk.GetTokenAccounts( account: GameController.Keypair.PublicKey );
        if(accounts.Count == 0) return;
        tokenAccountsDropDown.gameObject.SetActive(true);
        txtTokenAccountDesc.gameObject.SetActive(true);
        tokenAccountsDropDown.options.Clear();
        foreach (var acc in accounts)
        {
            tokenAccountsDropDown.options.Add(new TMP_Dropdown.OptionData(acc));
        }
    }

    public async void GetHistory()
    {
        if(GameController.Keypair == null) return;
        var history =  await GameController.KineticSdk.GetHistory( account: GameController.Keypair.PublicKey );
        txtHistory.text = "";
        foreach (var h in history)
        {
            txtHistory.text += h.ToJson();
        }
    }
    
    public async void RequestAirdrop()
    {
        if(GameController.Keypair == null) return;
        loading.SetActive(true);
        try
        {
            await GameController.KineticSdk.RequestAirdrop(
                account: GameController.Keypair.PublicKey,
                amount: "1000"
            );
            UpdateBalance();
        }
        catch (Exception e)
        {
            
            Debug.LogException(e);
        }

        loading.SetActive(false);
    }

    public async void MakeTransfer()
    {
        if(GameController.Keypair == null) return;
        loading.SetActive(true);
        try
        {
            await GameController.KineticSdk.MakeTransfer(
                amount: txtAmount.text,
                destination: txtDestination.text,
                owner: GameController.Keypair,
                commitment: Commitment.Finalized,
                senderCreate: true
            );
            txtDestination.transform.parent.parent.gameObject.SetActive(false);
            UpdateBalance();
        }
        catch (Exception e)
        {
            
            txtDestination.text = " - Invalid destination - ";
            Debug.LogException(e);
        }
        loading.SetActive(false);

    }

}
