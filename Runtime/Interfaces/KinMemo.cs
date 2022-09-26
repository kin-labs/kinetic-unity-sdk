using System;
using System.Linq;

// ReSharper disable once CheckNamespace

namespace Kinetic.Sdk.Interfaces
{
    /// <summary>
    /// The KineticSdk is the main entry point and handles communication with the Kinetic API
    /// </summary>
    public class KinMemo
    {
        public byte[] Buffer { get; }
        private const byte MagicByte = 1;

        private KinMemo(byte[] buffer)
        {
            Buffer = buffer;
        }

        public static KinMemo CreateKinMemo(
            decimal? appIndex, string memo = null, TransactionType type = TransactionType.None)
        {
            var data = new byte[29];
            if (memo != null)
            {
                data = Convert.FromBase64String(memo);
            }
            return New(1, (int)type, (int)appIndex.GetValueOrDefault(0), data);
        }

        private static KinMemo New(int version, int type, int appIndex, byte[] fk)
        {
            if (fk.Length > 29) {
                throw new Exception("invalid foreign key length");
            }
            if (version > 7) {
                throw new Exception("invalid version");
            }
            if (type == -1) {
                throw new Exception("cannot use unknown transaction type");
            }
            var b = new int[32];
            // encode magic byte + version
            b[0] = MagicByte;
            b[0] += version << 2;
            // encode transaction type
            b[0] += (type & 0x7) << 5;
            b[1] = (type & 0x18) >> 3;
            // encode AppIndex
            b[1] += (appIndex & 0x3f) << 2;
            b[2] = (appIndex & 0x3fc0) >> 6;
            b[3] = (appIndex & 0xc000) >> 14;
            if (fk.Length <= 0) return null;
            b[3] |= (fk[0] & 0x3f) << 2;
            // insert the rest of the fk. since each loop references fk[n] and fk[n+1], the upper bound is offset by 3 instead of 4.
            for (var i = 4; i < 3 + fk.Length; i++) {
                // apply last 2-bits of current byte
                // apply first 6-bits of next byte
                b[i] = (fk[i - 4] >> 6) & 0x3;
                b[i] |= (fk[i - 3] & 0x3f) << 2;
            }
            // if the foreign key is less than 29 bytes, the last 2 bits of the FK can be included in the memo
            if (fk.Length < 29) {
                b[fk.Length + 3] = (fk[^1] >> 6) & 0x3;
            }
            return new KinMemo(b.Select(i => (byte)i).ToArray());
        }
    }
}