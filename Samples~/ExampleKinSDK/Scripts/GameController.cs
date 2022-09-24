using System;
using Kinetic.Sdk;
using Kinetic.Sdk.Configurations;
using Solana.Unity.Rpc.Types;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public string endpoint = "https://sandbox.kinetic.host/";
    public static Keypair Keypair { get; private set; }
    public static KineticSdk KineticSdk { get; private set; }

    public GameObject canvasLogin;
    public GameObject canvasWallet;
    
     

    // Start is called before the first frame update
    async void Awake()
    {
        KineticSdk = await KineticSdk.Setup(
            new KineticSdkConfig(
                index:1,
                endpoint: endpoint, 
                environment: KineticSdkEndpoint.Devnet,
                logger: new Logger(Debug.unityLogger.logHandler)
            )
        );
    }
    

    public async void CreateNewAccount()
    {
        Keypair = Keypair.Random();
        await KineticSdk.CreateAccount(Keypair, commitment: Commitment.Finalized);
        canvasWallet.SetActive(true);
        canvasLogin.SetActive(false);
    }
    
    public void Login()
    {
        var keyOrMnemonics = GameObject.Find("TxtKeyOrMnemonics").GetComponentInChildren<TextMeshProUGUI>().text;
        keyOrMnemonics = keyOrMnemonics.Trim().Replace("\u200B", "");
        try
        {
            Keypair = Keypair.FromMnemonic(keyOrMnemonics);
        }
        catch (NotSupportedException)
        {
            Keypair = Keypair.FromSecretKey(keyOrMnemonics);
            Keypair.FromSecretKey(keyOrMnemonics);
        }
    }
    
}