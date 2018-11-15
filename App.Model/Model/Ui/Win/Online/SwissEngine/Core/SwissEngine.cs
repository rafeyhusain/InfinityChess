using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Data;
using System.Data.Common;
using twinfeats.pairings;

namespace twinfeats.pairings
{
    public class SwissEngine
    {
        public static void CreateRound(int tournamentID)
        { 

            SqlConnection cn = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=InfiChess;Data Source=ARSALANATA\\SQLEXPRESS");
            SqlCommand cmd = new SqlCommand("select * from Tournament where tournamentid = 265", cn);
            cmd.CommandType = CommandType.Text;
            DataSet ds = new DataSet();

            SqlDataAdapter adp = new SqlDataAdapter();
            adp.SelectCommand = cmd;
            adp.Fill(ds);

            SqlCommand cmdUser = new SqlCommand("GetTournamentRegisteredUsers", cn);
            cmdUser.CommandType = CommandType.StoredProcedure;
            cmdUser.Parameters.Add("@TournamentID", SqlDbType.Int, 4).Value = tournamentID;

            DataSet dsuser = new DataSet();

            SqlDataAdapter adpUser = new SqlDataAdapter();

            adpUser.SelectCommand = cmdUser;

            adpUser.Fill(dsuser);


            //dataGridView1.DataSource = dsuser.Tables[0];

           // txtName.Text = ds.Tables[0].Rows[0]["Name"].ToString();

            //currentTournament = new Tournament();
            //currentTournament.Name = txtName.Text;
            //t.NumSections = 1;
            //t.NumRatedSections = 1;

            TournamentSection ts = new TournamentSection();
            ts.Name = "1st";
            ts.ByePoints = 1;
            ts.Marked = true;
            ts.NumRounds = 3;

            foreach (DataRow dr in dsuser.Tables[0].Rows)
            {
                Player p = new Player();
                p.FullName = dr["UserName"].ToString();
                p.QuickRating = Convert.ToInt32(dr["Rating"].ToString());
                p.MemberNumber = dr["No"].ToString();
                p.Team = "";
                ts.addPlayer(p);
            }

            //Card c = new Card(p);

            Engine e = new Engine();



        }
    }
}