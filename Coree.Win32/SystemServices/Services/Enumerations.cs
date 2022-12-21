﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Coree.Win32.SystemServices
{
    internal partial class Services
    {
        internal class Enumerations
        {
            [Flags]
            internal enum ACCESS_MASK : uint
            {
                DELETE = 0x00010000,
                READ_CONTROL = 0x00020000,
                WRITE_DAC = 0x00040000,
                WRITE_OWNER = 0x00080000,
                SYNCHRONIZE = 0x00100000,

                STANDARD_RIGHTS_REQUIRED = 0x000F0000,

                STANDARD_RIGHTS_READ = 0x00020000,
                STANDARD_RIGHTS_WRITE = 0x00020000,
                STANDARD_RIGHTS_EXECUTE = 0x00020000,

                STANDARD_RIGHTS_ALL = 0x001F0000,

                SPECIFIC_RIGHTS_ALL = 0x0000FFFF,

                ACCESS_SYSTEM_SECURITY = 0x01000000,

                MAXIMUM_ALLOWED = 0x02000000,

                GENERIC_READ = 0x80000000,
                GENERIC_WRITE = 0x40000000,
                GENERIC_EXECUTE = 0x20000000,
                GENERIC_ALL = 0x10000000,

                DESKTOP_READOBJECTS = 0x00000001,
                DESKTOP_CREATEWINDOW = 0x00000002,
                DESKTOP_CREATEMENU = 0x00000004,
                DESKTOP_HOOKCONTROL = 0x00000008,
                DESKTOP_JOURNALRECORD = 0x00000010,
                DESKTOP_JOURNALPLAYBACK = 0x00000020,
                DESKTOP_ENUMERATE = 0x00000040,
                DESKTOP_WRITEOBJECTS = 0x00000080,
                DESKTOP_SWITCHDESKTOP = 0x00000100,

                WINSTA_ENUMDESKTOPS = 0x00000001,
                WINSTA_READATTRIBUTES = 0x00000002,
                WINSTA_ACCESSCLIPBOARD = 0x00000004,
                WINSTA_CREATEDESKTOP = 0x00000008,
                WINSTA_WRITEATTRIBUTES = 0x00000010,
                WINSTA_ACCESSGLOBALATOMS = 0x00000020,
                WINSTA_EXITWINDOWS = 0x00000040,
                WINSTA_ENUMERATE = 0x00000100,
                WINSTA_READSCREEN = 0x00000200,

                WINSTA_ALL_ACCESS = 0x0000037F
            }

            [Flags]
            public enum SCM_ACCESS : uint
            {
                /// <summary>
                /// Required to connect to the service control manager.
                /// </summary>
                SC_MANAGER_CONNECT = 0x00001,

                /// <summary>
                /// Required to call the CreateService function to create a service
                /// object and add it to the database.
                /// </summary>
                SC_MANAGER_CREATE_SERVICE = 0x00002,

                /// <summary>
                /// Required to call the EnumServicesStatusEx function to list the
                /// services that are in the database.
                /// </summary>
                SC_MANAGER_ENUMERATE_SERVICE = 0x00004,

                /// <summary>
                /// Required to call the LockServiceDatabase function to acquire a
                /// lock on the database.
                /// </summary>
                SC_MANAGER_LOCK = 0x00008,

                /// <summary>
                /// Required to call the QueryServiceLockStatus function to retrieve
                /// the lock status information for the database.
                /// </summary>
                SC_MANAGER_QUERY_LOCK_STATUS = 0x00010,

                /// <summary>
                /// Required to call the NotifyBootConfigStatus function.
                /// </summary>
                SC_MANAGER_MODIFY_BOOT_CONFIG = 0x00020,

                /// <summary>
                /// Includes STANDARD_RIGHTS_REQUIRED, in addition to all access
                /// rights in this table.
                /// </summary>
                SC_MANAGER_ALL_ACCESS = ACCESS_MASK.STANDARD_RIGHTS_REQUIRED |
                    SC_MANAGER_CONNECT |
                    SC_MANAGER_CREATE_SERVICE |
                    SC_MANAGER_ENUMERATE_SERVICE |
                    SC_MANAGER_LOCK |
                    SC_MANAGER_QUERY_LOCK_STATUS |
                    SC_MANAGER_MODIFY_BOOT_CONFIG,

                GENERIC_READ = ACCESS_MASK.STANDARD_RIGHTS_READ |
                    SC_MANAGER_ENUMERATE_SERVICE |
                    SC_MANAGER_QUERY_LOCK_STATUS,

                GENERIC_WRITE = ACCESS_MASK.STANDARD_RIGHTS_WRITE |
                    SC_MANAGER_CREATE_SERVICE |
                    SC_MANAGER_MODIFY_BOOT_CONFIG,

                GENERIC_EXECUTE = ACCESS_MASK.STANDARD_RIGHTS_EXECUTE |
                    SC_MANAGER_CONNECT | SC_MANAGER_LOCK,

                GENERIC_ALL = SC_MANAGER_ALL_ACCESS,
            }

        }
    }
}
