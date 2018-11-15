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

    public class Moves : BaseItems<Move, Moves>
    {
        #region Data Members
        public Game Game = null;
        public Notations Notation = null;

        #region Columns
        public const string Id = "Id";
        public const string Pid = "Pid";
        public const string White = "W";
        public const string No = "No";
        public const string Pce = "P";
        public const string FromSquare = "F";
        public const string ToSquare = "T";
        public const string MoveFlags = "Mf";
        public const string MoveTime = "Mt";
        public const string MoveTimeWhite = "Mw";
        public const string MoveTimeBlack = "Mb";
        public const string CapturedPce = "Cp";
        public const string Fen = "Fen";
        public const string Eval = "E";
        public const string ExpectedMove = "Em";
        public const string Comments = "Cm";
        #endregion

        #region Flags
        /*
         * WARNING: Sort Flags alphabatically to avoid duplicates
         */

        public const string Mated = "#";
        public const string InCheck = "+";

        public const string Book = "B";

        public const string LongCastling = "C";
        public const string ShortCastling = "c";

        public const string AmbigousMove = "D";

        public const string AmbigousMoveColumn = "E";
        public const string EnpassantCapture = "e";

        public const string AmbigousMoveRow = "F";

        public const string AmbigousMoveRowToCol = "H";
        public const string Human = "h";

        public const string VariationInsert = "I";

        public const string VariationNewMainLine = "L";

        public const string BlackMainLine = "M";
        public const string MainMove = "m"; // for book

        public const string Engine = "N";

        public const string VariationOverwrite = "O";

        public const string Promotion = "P";

        public const string IsValidMove = "Q";

        public const string StaleMated = "S";

        public const string TempMove = "T";
        public const string NotInTournament = "t"; // for book

        public const string Variation = "V";
        public const string BlackVariation = "v";

        public const string Capture = "x";

        #endregion

        #endregion

        #region Ctor

        public Moves()
        {
            DataTable = GetMovesTable();
        }

        public Moves(Game game)
        {
            Game = game;
            DataTable = GetMovesTable();
        }

        public Moves(Notations notation)
        {
            this.Notation = notation;
            DataTable = GetMovesTable();
        }

        public Moves(DataTable table)
        {
            this.DataTable = table;
        }

        public Moves(string movesDataTable)
        {
            DataTable = GetMovesTable();

            UData.LoadDataTable(DataTable, movesDataTable);
        }
        #endregion

        #region Properties
        public override string PrimaryKey
        {
            [DebuggerStepThrough]
            get { return Moves.Id; }
        }

        public int MoveCount
        {
            [DebuggerStepThrough]
            get
            {
                return DataTable.Rows.Count;
            }
        }

        #endregion

        #region Methods

        public Move GetById(int id)
        {
            return Get(id, "=", "");
        }

        private Move Get(int id, string op, string sort)
        {
            try
            {
                DataRow[] rows = base.DataTable.Select(Id + op + UStr.Quote(id), Id + " " + sort);
                if (rows.Length > 0)
                {
                    Move m = new Move(rows[0]);
                    m.Game = this.Game;
                    return m;
                }
            }
            catch
            {

            }
            return null;
        }

        #endregion

        #region Helpers
        /**********************************************
        *   Description Column name in Moves
        *   pce = piece
        *   mvx = move action = "x","0-0","0-0-0","PR-Q(promote to Queen)","PR-xQ(promote to Queen and capture)"
        *   mvchk = move check = "+" , "#"
        *   mvdr = move duration
        *   wmt = white move time
        *   bmt = black move time
        *   cp = captured piece
        /**********************************************/

        public static DataTable GetMovesTable()
        {
            DataSet ds = new DataSet();

            DataTable table = ds.Tables.Add("M");

            table.Columns.Add(new DataColumn(Moves.Id, typeof(int)));
            table.Columns.Add(new DataColumn(Moves.Pid, typeof(int)));
            table.Columns.Add(new DataColumn(Moves.White, typeof(int)));
            table.Columns.Add(new DataColumn(Moves.No, typeof(int)));
            table.Columns.Add(new DataColumn(Moves.Pce, typeof(string)));
            table.Columns.Add(new DataColumn(Moves.FromSquare, typeof(string)));
            table.Columns.Add(new DataColumn(Moves.ToSquare, typeof(string)));
            table.Columns.Add(new DataColumn(Moves.MoveFlags, typeof(string)));
            table.Columns.Add(new DataColumn(Moves.MoveTime, typeof(long)));
            table.Columns.Add(new DataColumn(Moves.MoveTimeWhite, typeof(long)));
            table.Columns.Add(new DataColumn(Moves.MoveTimeBlack, typeof(long)));
            table.Columns.Add(new DataColumn(Moves.CapturedPce, typeof(string)));
            table.Columns.Add(new DataColumn(Moves.Fen, typeof(string)));
            table.Columns.Add(new DataColumn(Moves.Eval, typeof(string)));
            table.Columns.Add(new DataColumn(Moves.ExpectedMove, typeof(string)));
            table.Columns.Add(new DataColumn(Moves.Comments, typeof(string)));

            return table;

        }

        public static bool HasVariation(DataTable moves)
        {
            if (moves.Select(Moves.MoveFlags + " like '%V'").Length > 0)
                return true;
            else
                return false;
        }

        public DataTable GetChildLine(int id)
        {
            DataView dv = new DataView(DataTable, Moves.Pid + "=" + id, "", DataViewRowState.CurrentRows | DataViewRowState.Deleted);

            DataTable table = new DataTable("Lines");

            table.Columns.Add(new DataColumn("Id", typeof(int)));
            table.Columns.Add(new DataColumn("Line", typeof(string)));

            int c = 65; //A
            int i = 0;

            foreach (DataRowView rv in dv)
            {
                Move m = new Move(rv.Row);
                m.Game = this.Game;

                DataRow row = table.NewRow();

                string s = m.Notation;

                if (m.IsBlack && !s.Contains("..."))
                {
                    s = m.MoveNo + "..." + m.Notation;
                }
                
                row["Id"] = m.Id;
                row["Line"] = Convert.ToChar(c++) + (i == 0 ? "" : i.ToString()) + ") " + s;// +" " + GetLineStr(m.Id);

                if (c == 91) //Z
                {
                    c = 65;
                    i++;
                }

                table.Rows.Add(row);
            }

            return table;
        }

        private string GetLineStr(int id)
        {
            DataView dv = new DataView(DataTable, Moves.Pid + "=" + id, "", DataViewRowState.CurrentRows | DataViewRowState.Deleted);

            if (dv.Count == 0)
            {
                return "";
            }

            Move m = new Move(dv[0].Row);
            m.Game = this.Game;

            return m.Notation + " " + GetLineStr(m.Id);
        }

        public Moves GetChildren(Move m)
        {
            if (m == null)
            {
                return null;
            }

            DataView dv = new DataView(DataTable, Moves.Pid + "=" + m.Id, "Id ASC", DataViewRowState.CurrentRows | DataViewRowState.Deleted);

            return new Moves(dv.ToTable("M"));
        }

        public Moves GetParents(Move m)
        {
            Moves parents = null;

            if (m == null)
            {
                return null;
            }

            Move parent = this.GetById(m.Pid);

            if (parent == null)
            {
                return null;
            }
            else
            {
                parents = new Moves(this.DataTable.Clone());

                parents.Add(parent);

                Moves parentx = GetParents(parent);

                if (parentx != null)
                {
                    parents.Import(parentx);
                }
            }

            return parents;
        }

        public string GetParentsStr(Move m)
        {
            string moves = "";

            if (m == null)
            {
                return moves;
            }

            if (m.Pid == -1)
            {
                return m.MoveString;
            }

            moves += m.MoveString;

            Move parent = this.GetById(m.Pid);

            moves = GetParentsStr(parent) + " " + moves;

            return moves.Trim();
        }

        public void DeleteRows(Move m)
        {
            int j = GetRowIndex(m.Pid);

            for (int i = DataTable.Rows.Count - 1; i > j; i--)
            {
                DataTable.Rows[i].Delete();
            }

            DataTable.AcceptChanges();
        }

        public void DeleteAllRows()
        {
            for (int i = DataTable.Rows.Count - 1; i > -1; i--)
            {
                DataTable.Rows[i].Delete();
            }

            DataTable.AcceptChanges();
        }

        public bool DeleteChilds(Move m)
        {
            Moves moves = GetChildren(m);

            if (moves == null || moves.Count == 0)
            {
                return false;
            }

            for (int i = 0; i < moves.Count; i++)
            {
                Move mov = moves[i];
                DeleteChilds(mov);
                DeleteRows(mov);
            }
            return true;
        }

        public int GetRowIndex(int id)
        {
            DataRow[] rows = this.DataTable.Select("Id=" + id);
            if (rows.Length > 0)
            {
                return DataTable.Rows.IndexOf(rows[0]);
            }

            return DataTable.Rows.Count;
        }

        public Moves GetLine(Move m)
        {
            Move last = GetLastLineMove(m);

            Moves moves = GetParents(last);

            if (moves != null)
            {
                moves.Add(last);
            }

            return moves;
        }

        private Move GetLastLineMove(Move m)
        {
            Moves moves = GetChildren(m);

            if (moves.Count == 0)
            {
                return m;
            }

            return GetLastLineMove(moves[0]);
        }

        public Moves GetLineFrom(Move m)
        {
            if (m == null)
            {
                return null;
            }

            Moves moves = GetChildren(m);

            Moves childs = null;

            if (moves.Count == 0)
            {
                return childs;
            }

            Move child = null;

            for (int i = 0; i < moves.Count; i++)
            {
                if (moves[i].Flags.IsVariationNewMainLine)
                {
                    child = moves[i];
                }
            }

            if (child == null)
            {
                child = moves[0];
            }

            childs = new Moves(this.DataTable.Clone());

            childs.Add(child);

            Moves childsx = GetLineFrom(child);

            if (childsx != null)
            {
                childs.Import(childsx);
            }

            return childs;
        }


        #endregion

        #region Datatable Row
        public DataRow NewRow()
        {
            DataRow row = DataTable.NewRow();

            DataTable.Rows.Add(row);

            return row;
        }

        public void Import(Move move)
        {
            DataTable.ImportRow(move.DataRow);
        }

        public void Import(Moves moves)
        {
            for (int i = 0; i < moves.Count; i++)
            {
                Import(moves[i]);
            }
        }
        #endregion

        #region Next/Prev
        public Move Next(int id)
        {
            return Get(id, ">", "Asc");
        }

        public Move Prev(int id)
        {
            return Get(id, "<", "Desc");
        }

        public Move Next(Move move)
        {
            if (move == null)
            {
                return null;
            }

            Moves children = GetChildren(move);

            if (children.Count == 0)
            {
                return move;
            }
            else
            {
                return children[0];
            }
        }

        public Move Prev(Move move)
        {
            if (move == null)
            {
                return null;
            }

            Move m = Game.Moves.GetById(move.Pid);

            if (m == null)
            {
                return move;
            }
            else
            {
                return m;
            }
        }
        #endregion

        #region Truncate
        public void TruncateAfter(int moveID)
        {
            DataTable.DefaultView.RowFilter = Moves.Id + "<=" + moveID;

            DataTable = DataTable.DefaultView.ToTable(DataTable.TableName);
        }
        #endregion

        #region Indexer
        public new Move this[int index]
        {
            get
            {
                Move m = base[index];

                m.MoveComments = new MoveComments(m);

                return m;
            }
            set
            {
                base[index] = value;
            }
        }

        #endregion
    }
}
