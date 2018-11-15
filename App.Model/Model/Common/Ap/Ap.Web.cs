using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App.Model
{
    public enum WebUrlE
    {
        Unknown = 0,
        UrlAdminTournamentEdit = 1,
        UrlAdminTournamentList = 2,
        UrlAdminTournamentMatch = 3,
        UrlAdminTournamentTeam = 4,
        UrlAdminTieBreakMatchDetail = 5,
        UrlAdminTournamentWantinList = 6,
        UrlPublicTournamentUserView = 7,
        UrlSignIn = 8,
        UrlAdminDefault = 9,
        UrlDefault = 10
    }

    public partial class Ap
    {
        #region Urls

        static string urlPublicTournamentUserView = "/Web/Page/Public/viewer/Tournament/TournamentUserView.aspx";
        static string urlAdminTournamentEdit = "/Web/Page/Admin/Editor/Tournament.aspx";
        static string urlAdminTournamentList = "/Web/Page/Admin/List/Tournament.aspx";
        static string urlDefault = "/Default.aspx";
        static string urlSignIn = "/Web/Page/Account/SignIn.aspx";
        static string urlAdminDefault = "/Web/Page/Admin/Default.aspx";
      
        public static string GetUrl(WebUrlE FormsNameE)
        {
            switch (FormsNameE)
            {
                case WebUrlE.Unknown:
                    break;
                case WebUrlE.UrlAdminTournamentEdit:
                    return urlAdminTournamentEdit;
                case WebUrlE.UrlAdminTournamentList:
                    return urlAdminTournamentList;
                case WebUrlE.UrlAdminTournamentMatch:
                    break;
                case WebUrlE.UrlAdminTournamentTeam:
                    break;
                case WebUrlE.UrlAdminTieBreakMatchDetail:
                    break;
                case WebUrlE.UrlAdminTournamentWantinList:
                    break;
                case WebUrlE.UrlPublicTournamentUserView:
                    return urlPublicTournamentUserView;
                case WebUrlE.UrlSignIn:
                    return urlSignIn;
                case WebUrlE.UrlAdminDefault:
                    return urlAdminDefault;

                default:
                    break;

            }
            return urlDefault;
        }
        #endregion
    }
}
