using System;
using App.Model;
using System.Collections.Generic;
using System.Data;
using System.Text;
using InfinityChess;
using System.Windows.Forms;
using ChessLibrary;
using System.Diagnostics;

namespace App.Model
{
    public partial class Notations
    {

        #region Ctor

        public static DataTable GetNotationDataTable()
        {
            DataTable table = new DataTable("ND");

            table.Columns.Add(new DataColumn(Notations.Id, typeof(int)));
            table.Columns.Add(new DataColumn(Notations.R, typeof(int)));
            table.Columns.Add(new DataColumn(Notations.C, typeof(int)));

            return table;
        }
        #endregion

        #region Method
        public void AddNotationData(Move m)
        {
            DataRow row = NotationData.NewRow();
            int r = GetR(m.Flags.VariationType, m.Pid);
            int c = GetC(m.Flags.VariationType, m.Pid);

            if (AddNewNotationViewRow(m))
            {
                r = LastNotationViewRowIndex;
          
                if (IsPrevMoveMainLine(m))
                {
                    c = 0;
                }
            }

            row["Id"] = m.Id;
            row["R"] = r;
            row["C"] = c;

            NotationData.Rows.Add(row);
        }

        #endregion

        #region Helpers

        public int GetR(VariationTypeE type, int id)
        {
            if (this.Game.Flags.IsFirtMove)
            {
                return 0;
            }

            NotationDataRow nd = GetNotationDataRow(id);

            if (nd == null)
            {
                return 0;
            }

            switch (type)
            {
                case VariationTypeE.Variation:
                    return LastNotationViewRowIndex;
                case VariationTypeE.MainLine:
                case VariationTypeE.Insert:
                case VariationTypeE.Overwrite:
                default:
                    if (nd.C == Notations.MaxColumnIndex)
                    {
                        return nd.R + 1;
                    }

                    return nd.R;
            }
        }

        public int GetC(VariationTypeE type, int id)
        {
            if (this.Game.Flags.IsFirtMove)
            {
                return 0;
            }

            NotationDataRow nd = GetNotationDataRow(id);

            if (nd == null)
            {
                return 0;
            }


            switch (type)
            {
                case VariationTypeE.Variation:
                    return 1;
                case VariationTypeE.MainLine:
                case VariationTypeE.Insert:
                case VariationTypeE.Overwrite:
                default:
                    if (nd.C == Notations.MaxColumnIndex)
                    {
                        return 0;
                    }

                    return nd.C + 1;
            }
        }

        public int GetId(int r, int c)
        {
            NotationDataRow nd = GetNotationDataRow(r, c);

            if (nd == null)
            {
                return -1;
            }

            return nd.Id;
        }

        public int GetC(int id)
        {
            NotationDataRow nd = GetNotationDataRow(id);

            if (nd == null)
            {
                return -1;
            }

            return nd.C;
        }

        public int GetR(int id)
        {
            NotationDataRow nv = GetNotationDataRow(id);

            if (nv == null)
            {
                return -1;
            }

            return nv.R;
        }

        public NotationDataRow GetNotationDataRow(int r, int c)
        {
            try
            {
                DataRow[] rows = this.NotationData.Select("R=" + r + " AND " + "C=" + c);
                if (rows.Length > 0)
                    return new NotationDataRow(rows[0]);
            }
            catch
            {
            }

            return null;
        }

        public int GetNotationDataRowIndex(int id)
        {
            NotationDataRow nd = GetNotationDataRow(id);

            return NotationData.Rows.IndexOf(nd.DataRow);
        }

        public NotationDataRow GetNotationDataRow(int id)
        {
            try
            {
                DataRow[] rows = this.NotationData.Select("Id=" + id);
                if (rows.Length > 0)
                {
                    return new NotationDataRow(rows[0]);
                }
            }
            catch
            {
            }

            return null;
        }

        #endregion
    }
}
