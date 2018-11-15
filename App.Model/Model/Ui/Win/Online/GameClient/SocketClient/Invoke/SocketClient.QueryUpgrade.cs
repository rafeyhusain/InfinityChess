// (c) Copyright RafeySoft, Karachi Pakistan. http://rafeysoft.com
// This source is subject to following License:
// http://rafeysoft.com/Web/Page/ItemEdit.aspx?sid=29&lid=4&cid=23&iid=2143
// Please write to info@rafeysoft.com for more information
// All other rights reserved.
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Xml;
using App.Model.Db;
using System.Net.Sockets;
using System.Net;
using System.Collections;
using System.Threading;

namespace App.Model
{
    public partial class SocketClient
    {
        public static void QueryUpgrade()
        {
            Kv kv = new Kv();
            kv.Set("MethodName", (int)MethodNameE.QueryUpgrade);
            kv.Set("VersionNo", String.Empty);
            kv.Set("PatchUrl", String.Empty);
            SocketClient.Instance.InvokeAsync(kv.DataTable);
        }
    }
}
