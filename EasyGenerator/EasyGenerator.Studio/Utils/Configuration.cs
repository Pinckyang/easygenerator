/*
 * Copyright ?2005-2006 Danilo Mendez <danilo.mendez@kontac.net>
 * Adolfo Socorro <ajs@esolutionspr.com>
 * www.kontac.net 
 * All rights reserved.
 * Released under both BSD license and Lesser GPL library license.
 * Whenever there is any discrepancy between the two licenses,
 * the BSD license will take precedence.
 */

using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;

namespace EasyGenerator.Studio.Utils
{

    public sealed class Configuration
    {
        private static int GetInt32(string keyName, int defaultValue)
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\EasyGenerator");
            if (key != null)
            {
                object value = key.GetValue(keyName);
                key.Close();
                if (value != null)
                {
                    return (int)value;
                }
            }
            return defaultValue;
        }

        private static string GetString(string keyName, string defaultValue)
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\EasyGenerator");
            if (key != null)
            {
                object value = key.GetValue(keyName);
                key.Close();
                if (value != null)
                {
                    return (string)value;
                }
            }
            return defaultValue;
        }

        public static string OutputPath
        {
            get
            {
                return Configuration.GetString("OutputPath", Environment.CurrentDirectory);
            }
            set
            {
                RegistryKey key = null;
                try
                {
                    key = Registry.CurrentUser.OpenSubKey(@"Software\EasyGenerator", true);
                    if (key != null)
                    {
                        key.SetValue("OutputPath", value);
                    }
                }
                catch
                {
                    return;
                }
                finally
                {
                    if (key != null)
                    {
                        key.Close();
                    }
                }
            }
        }
    }
}
