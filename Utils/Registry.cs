using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
    public class Registry
    {
        public string Read(string keyName)
        {
            string subKey = "SOFTWARE\\THESIS";

            RegistryKey sk = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(subKey);
            if (sk == null)
                return null;
            else
                return sk.GetValue(keyName.ToUpper()).ToString();
        }

        /// <summary>
        /// This C# code writes a key to the windows registry.
        /// </summary>
        /// <param name="keyName">
        /// <param name="value">
        public void Write(string keyName, string value)
        {
            string subKey = "SOFTWARE\\THESIS";

            RegistryKey sk1 = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(subKey);
            sk1.SetValue(keyName.ToUpper(), value);
        }
    }
}
