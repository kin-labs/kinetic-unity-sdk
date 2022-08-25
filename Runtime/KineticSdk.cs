using System;
using IO.Swagger.Api;
using UnityEngine;

// ReSharper disable once CheckNamespace

namespace Kinetic.Sdk
{

    /// <summary>
    /// The KineticSdk is the main entry point and handles communication with the Kinetic API
    /// </summary>
    public class KineticSdk
    {
        
        public static void Init()
        {
            var apiInstance = new ConfigApi();
            var result = apiInstance.Config();
            Debug.Log(result);
            throw new NotImplementedException();
        }
        
        public static void Setup()
        {
            throw new NotImplementedException();
        }
        
    }
}