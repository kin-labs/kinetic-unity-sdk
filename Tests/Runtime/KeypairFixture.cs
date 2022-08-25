// ReSharper disable once CheckNamespace

namespace Kinetic.Sdk.Tests
{

    public static class KeypairFixture
    {
        public const string TestSecretKey =
            "4j3PbCCYvcAz1FbKGs7fBoQ5cd8piWCsQm5k6wNnTTzEtE6aM8JZ2AJaaJTjZJgGk9LywyonNHcVopHAwrMqh6kr";

        public const string TestPublicKey = "5ZWj7a1f8tWkjBESHKgrLmXshuXxqeY9SYcfbshpAqPG";

        public static readonly byte[] TestSecretByteArray =
        {
            186, 78, 68, 54, 63, 205, 1, 141, 2, 89, 45, 80, 77, 168, 215, 120, 56, 57, 72, 222, 50, 140, 31, 236,
            254, 35, 208, 163, 138, 186, 225, 18, 67, 194, 241, 235, 28, 5, 209, 235, 248, 58, 150, 42, 218, 71, 43,
            177, 183, 62, 55, 96, 216, 41, 59, 146, 121, 132, 223, 24, 39, 109, 3, 163,
        };

        public const string TestMnemonic12 =
            "pill tomorrow foster begin walnut borrow virtual kick shift mutual shoe scatter";

        public const string TestMnemonic24 =
            "grab amused tattoo cruise industry corn welcome wealth tilt erupt gauge ankle remove toast journey heavy unit vibrant zoo blood notice jealous gesture cargo";

        public const string TestMnemonic24SecretKey =
            "RkXUT99dpuSPP33w3X6tTx8KTDJMs1ce3tjeHWm2GSTKau7qFDN5BFMEeGToMGcEDunXuBpozxWAnr6uir8JVMD";

        public const string TestMnemonic24PublicKey = "36hssW7DqagnHyC3dPjD59kjiUnYWrYd8hXeQ3zZ5kUK";

        public static readonly Keypair[] TestMnemonic12Set =
        {
            new("5F86TNSTre3CYwZd1wELsGQGhqG2HkN3d8zxhbyBSnzm",
                "cWNhG6WhR4q6X5v8d65x6UgVR4buQJFkpKVvKiFDbbbZnoxpTJZLoCkCLZXpCYKc1QgyXYbhQpACYN8VKgS5xxq",
                TestMnemonic12),
            new("AWjbG5SH5VEay5ksZbGHHgJhYRhM1rsN5Z538cfFvs4a",
                "CnJAJFfB8PkLPAGVfc7Pc9J2cWaCAiN65j44DFDP8ub7R1jN1XRkgT7FFBdBy9pUB33UmdAskuB5ZLPspH6U9jL",
                TestMnemonic12),
            new("TdFkuCzMB6ikLWbhxXkHT8ZZFdqD7LrD5QbuRYQCp18",
                "5ZKRCfEZpp5gchtkJTFJpPJQcbjR4M99L2mYRRcAWdXCE4Gfvd7CwdZgvDHcMeMTyGBLKiVEoqQ7etnGy3JnXtwc",
                TestMnemonic12),
            new("C7xHnBLteo5QZwc1Dzgu2aMvPVd5FwsX44cH6DMMszPz",
                "4mKLiQGyBvp9BGoF1FUtvLTLc2v9UormC6Aqva7eM2nTFnMUWj5KaTCSELUMyp4otJ253oZnJHApjUFV6CB7rQ7i",
                TestMnemonic12),
            new("7QJUf8m94wnSrukK7HQsbBZ2V4NVQQUuvZ5wdux9a5Lu",
                "4YudKZdE1MHpFJuXjKZGDERJ8Zh4e3wY3RmPw7csm3dmDTsd1iKtoyFuSYA6kmEzDTmLT8Dz68NUQNoe3jYQZexZ",
                TestMnemonic12),
            new("GkeNvLEAznNwPV47rXahTuYtqqCpzFs1g3gb2jq7x8Kd",
                "4MqYS4wyuxJsR48yvCy4jULnqAFxLscsUVW3eMoHzBPSNKyAX8rXtkEg3TQkgznN1G6iNfJHTf3mPhrvFh7bhyKR",
                TestMnemonic12),
            new("8T1j8WyQc726rByayWTz1tZZwMV2A6U1C4Ase2FxHgib",
                "Bb8z3xU7NmUxoX716NoZBUWXK8bciXJdZnknbgsUjaFm8S1zaFGipzYQTT2bf8x3xk79VjhP6KrfevwTEMZSZ6F",
                TestMnemonic12),
            new("CV2sNJvxqdHRQW2pejnGjLMqWXBy61jnx3uExxZ7n3CW",
                "5sJkm11xJgsztEHgPGNMRwVzBHwhJtf6kNaH9MBCwW6JiTe5aBDDy142JuM48rmbhuVVRmfgx9QDRYKbRRN9xvyp",
                TestMnemonic12),
            new("32e2ughnjjJ9MxuBb7JystX81Mh52qNfm8Kh9nMPXYtM",
                "5PwFc5bJ2cxMe8zeQRZzyL1Md3KAxh4pBVbv4Myo9m6HaPEnYvT7SDmYY8tuvXuHy1JZYN86L5pNnG9J6LfGxcLD",
                TestMnemonic12),
            new("36herGLdWaFZ9raFLeXBLE43t1oMwgd4yoUAAKaSTHKR",
                "ByHWNEnSCyoz3LzqnV9xRoKMKEWW9thGXEUp5XCP863ymhk7zhd54j8svVxgrKPDa9yboLbdobQMEuX7s4X4SsV",
                TestMnemonic12),
        };

        public static readonly Keypair[] TestMnemonic24Set =
        {
            new("6pFBagvvyvBHuCkbMAiPTLn42nnHXrHC2zwWSdZ1NtVn",
                "WTqijcBccatWsAA6WJzaqgNzJVdARiBHceL5DQG15RbZCNn9jeoEjwMyKRiQqsPvLKGhgkQMoUgo2ybbZmStU3r",
                TestMnemonic24),
            new("Foo948ttNuYa8SsfHX78BVyPVA7P7MsV8u43ZeQ1RBxm",
                "TcauP27RkmyhH2AsVaPh5rCofCN4xCoB1h5MgUT6eRoJ7GiVPDBqtW1dAmh9CNcHSqCVnoEFUbRhfApM6oLrUDF",
                TestMnemonic24),
            new("3ySWEh9mvVUpzMYYcqEv7VeAQp7ueGFAjUg1G9DBTjD5",
                "48wHgpEEb1f14kcYAyskTmUY9WnzLXuGUi1qmGiZr89uEmNo8g3uDNsk4aNjMaAfrE4oew7tk7VXWtUj8jWZGdbR",
                TestMnemonic24),
            new("HyMtaWzweBgpmgDf2dn8RhsM1c9m48VPQFjV6DAkHxbv",
                "46HfvZCsmSCnS9akRqULDci7313KQGk7Ndv7PXejTa4rnEtH7PnGMUo5jxkJwMJjifFxHyfJSkYcziEBqJqGPQYL",
                TestMnemonic24),
            new("5SZcAkce1YHt5D4ANfxQGBo1fRcjn7jbCaUGgaBPz8or",
                "3Gr9wYRLhz9LLhkSTYy1TsXyUbDcsfhVUxpDxDrHSjdY2J1tNBQWRZ4qdFvbH5AiMJCvq9qhxZc6j1RinPXMWDMa",
                TestMnemonic24),
            new("77VRnnzwRTeQLDpNDfMh8DrDkzbAtcuKncZyWN49oegG",
                "vrMzreRiV8Abz2WxqZhgh2Hmg5Mnc65QD3P1tr5Y7a296d7Y4FrUBppGCUAz2qCa6iNVUjygZu4SMiRDmW59Vbe",
                TestMnemonic24),
            new("GRwsvJC92A9UB4eEcpzuxPqsuBdKRjd731uGp6BLbPJv",
                "4ZPFuK3dS189sJFXdTiVRXeVA7ZV4LPgUUgXJwx7WVWMVCpafG3L1D2j1Z4dSJzamyYruHCSYWrwP6s8HhGLTYS2",
                TestMnemonic24),
            new("piCoBHqPoK4dhg84g1NajB6vdJX785G3wT2rExaQ6Q3",
                "3iUkSFmpVM4rZUsMJqGH1ajY3tWxG9A64agQwaPCZ1m5Yc3V8JacEPnAu3oDdhxTARHnpXKBBVcDJhv9cR2JDvd9",
                TestMnemonic24),
            new("6EeiyS9X6222PeUzpKA32jc3ZEkpTKms3qNZEmySm1DS",
                "8BJqbw31Zmn7887LtFtevmmGaUm5BNUvMB1tsnLdzCv5TFPTodYDCsKCFovHoL1BSZwGxbixDZoWwszLpSyYKXv",
                TestMnemonic24),
            new("DhW8bCabXWMJYg99rtZyy2XWax8J5wfLh8kmkpDxbR8G",
                "3P4zpjXuBtxH8hMguo8k68Nz3mDYRto3CaMkSm55TtPZzinRYg76uyvy2CBimcegBRThH92H9MzffYShJB62W8ya",
                TestMnemonic24),
        };
    }
}