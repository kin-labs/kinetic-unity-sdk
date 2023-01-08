```
Custom Fork which replaces RestSharp package with UnityWebRequests to make it Unity-oriented and compatible with all Unity platforms, specially WebGL.  
RestSharp does not work in WebGL.
```

---
title: Unity SDK
layout: layout-index
eleventyNavigation:
key: Unity SDK
order: 19
---
# Unity SDK

## Get Started or Add to an Existing Project

Getting started with Kin is incredibly straightforward. Just follow the steps below to start transacting with Kin in your App.


#### Installation

* Open [Unity Package Manager](https://docs.unity3d.com/Manual/upm-ui.html) window.
* Click the add **+** button in the status bar.
* The options for adding packages appear.
* Select Add package from git URL from the add menu. A text box and an Add button appear.
* Enter the `https://github.com/kin-labs/kinetic-unity-sdk.git` Git URL in the text box and click Add.
* Once the package is installed, in the Package Manager inspector you will have Samples. Click on Import
* You may also install a specific package version by using the URL with the specified version.
    * `https://github.com/kin-labs/kinetic-unity-sdk#X.Y.X`
    * Please note that the version `X.Y.Z` stated here is to be replaced with the version you would like to get.
    * You can find all the available releases [here](https://github.com/kin-labs/kinetic-unity-sdk/releases).
    * The latest available release version is [![Last Release](https://img.shields.io/github/v/release/kin-labs/kinetic-unity-sdk)](https://github.com/kin-labs/kinetic-unity-sdk/releases/latest)
* You will find a sample App in `Samples/Kinetic SDK/0.1.0/Kinetic SDK example/ExampleKinSDK/scenes/KinSampleScene.unity````
```

#### Instantiate the Kinetic Client

The Kinetic Client will give you access to all the methods you need to work with Kin on the blockchain.

We recommend starting with Devnet before moving on to Mainnet.

```
    sdk = await KineticSdk.Setup(
      new KineticSdkConfig(
        index:1,
        endpoint: "https://sandbox.kinetic.host/",
        environment: KineticSdkEndpoint.Devnet,
      )
    );
```
Don't have an App Index? Register your App on our Developer Portal so you can get your App Index that allows you to transact with our SDKs and earn via the KRE.

<div class='navIcons'>
  <a href='/essentials/kre-app-registration/'><div class='navIcon'>
    <img class='navIcon-icon invert' alt='Developer' src='../essentials/images/address-card-solid.svg'>
    <span class='navIcon-text'>Register Your App</span>
  </div></a>
</div>

#### Create Account
You can create accounts from existing mnemonics or secret keys. In this case we'll generate a mnemonic and use that to create the keypair we use for creating the account on the blockchain.
```
    var mnemonic = Keypair.GenerateMnemonic();
    var keypair = Keypair.FromMnemonic(mnemonic);
    await sdk.CreateAccount(keypair);
```
#### Check Balance
```
    var balance = await sdk.GetBalance(keypair.PublicKey);
```
#### Airdrop Funds (devnet)
```
    await sdk.RequestAirdrop( account: keypair.PublicKey, amount: "1000" );
```
#### Transfer Kin
```
    await sdk.MakeTransfer(
      amount: "5000",
      destination: "BQJi5K2s4SDDbed1ArpXjb6n7yVUfM34ym9a179MAqVo",
      owner: keypair,
      type: TransactionType.P2P // Can be Unknown, None, Earn, Spend or P2P
    );
```

#### Get Transaction Details
```
    await sdk.GetTransaction(signature: transactionSignature);
```

#### Get Account History
```
    await sdk.GetHistory(account: keypair.PublicKey);
```

### Webhooks
In [Kinetic Manager](/developers/kinetic-manager/), you can configure your App to use the following webhooks:
#### Events Webhook
This webhook can be used to receive information about completed transactions.
<br/>E.g. In a node express server:
```
app.use('/events', async (req, res) => {
  const event = req.body
  // DO STUFF WITH THE EVENT DATA
  res.sendStatus(200);
});
```

#### Verify Webhook
This webhook can be used to verify transactions.
<br/>E.g. In a node express server return a `200` status code to approve the transaction:
```
app.use('/verify', async (req, res) => {
  const transaction = req.body
  // CHECK THAT YOU WANT THIS TRANSACTION TO PROCEED
  // e.g.
  if (transaction.amount < 1000000) {
    res.sendStatus(200);
  }
  res.sendStatus(400);
});
```

#### Examples
For examples of how to create your own server for handling webhooks, see:
- [Node SDK Demo](https://github.com/kin-starters/kin-demo-node-sdk)
- [Python SDK Demo](https://github.com/kin-starters/kin-demo-python-sdk)


## Demos and Starter Kits
Created to help get you up and running as quickly as possible, these projects can be a great reference point when you get stuck or even a starter for your own project. Happy coding!

### [TODO SDK Demo](https://github.com/kin-starters/kin-demo-python-sdk)
TODO DESCRIPTION.


## Ready for Production?
If your App is ready for production, this is the place for you!

<div class='navIcons'>
  <a href='/developers/production/'><div class='navIcon'>
    <img class='navIcon-icon invert' alt='production' src='./images/coins-solid.svg'>
    <span class='navIcon-text'>Production</span>
  </div></a>
</div>

## Earn Kin via the KRE
<div class='navIcons'>
  <a href='/essentials/kin-rewards-engine/'><div class='navIcon'>
    <img class='navIcon-icon invert' alt='Developer' src='../essentials/images/money-bill-trend-up-solid.svg'>
    <span class='navIcon-text'>Kin Rewards Engine</span>
  </div></a>
</div>

## Contribute
Want to contribute to the Kin Python SDK?
<div class='navIcons'>
  <a href='https://github.com/kinecosystem/kin-python' target='_blank'><div class='navIcon'>
    <img class='navIcon-icon invert' alt='Kinetic' src='./images/github-brands.svg'>
    <span class='navIcon-text'>Kinetic Python SDK</span>
  </div></a>
</div>




## What If I Get Stuck?

Fortunately, we have an amazing developer community on our Developer Discord server. Join today!

<div class='navIcons'>
<a href='/essentials/getting-help/'><div class='navIcon'>
    <img class='navIcon-icon invert' alt='Getting Help' src='../essentials/images/circle-question-regular.svg'>
    <span class='navIcon-text'>Getting Help</span>
  </div></a>
  <a href='https://discord.com/invite/kdRyUNmHDn' target='_blank'><div class='navIcon'>
    <img class='navIcon-icon invert' alt='Discord' src='../essentials/images/discord-brands.svg'>
    <span class='navIcon-text'>Developer Discord</span>
  </div></a>
</div>



## Developer Best Practices

Once you're ready to code, have a quick look at our [Developer Best Practices](/essentials/best-practices/) where we cover some useful topics that you'll want to keep in mind as you build out your Kin application.

<div class='navIcons'>
  <a href='/essentials/best-practices/'><div class='navIcon'>
    <img class='navIcon-icon invert' alt='Best Practices' src='../essentials/images/rainbow-solid.svg'>
    <span class='navIcon-text'>Best Practices</span>
  </div></a>
</div>

***
**Was this page helpful?**<br/>
If you'd like to tell us how we can make these docs better, let us know here:

<div class='navIcons'>
  <a href='https://forms.gle/qhjcDJR59v8RJsaY7' target='_blank'><div class='navIcon'>
    <img class='navIcon-icon invert' alt='Developer' src='../essentials/images/comment-dots-solid.svg'>
    <span class='navIcon-text'>Feedback</span>
  </div></a>
</div>
