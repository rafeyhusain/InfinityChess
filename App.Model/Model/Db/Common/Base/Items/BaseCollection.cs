// (c) Copyright RafeySoft, Karachi Pakistan. http://rafeysoft.com
// This source is subject to following License:
// http://rafeysoft.com/Web/Page/ItemEdit.aspx?sid=29&lid=4&cid=23&iid=2143
// Please write to info@rafeysoft.com for more information
// All other rights reserved.

using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;
using System.Data;
using System.Data.SqlClient;

namespace App.Model
{
    public class BaseCollection : BaseItems<BaseItem, BaseCollection>
    {
        #region Constructor
        public BaseCollection()
        {

        }

        public BaseCollection(DataTable table)
            : base(table)
        {

        }

        public BaseCollection(string xsdPath, string xmlPath)
            : base(xsdPath, xmlPath)
        {
        }

        public BaseCollection(string sql)
            : base(sql)
        {
        }

        #endregion

    }
}
