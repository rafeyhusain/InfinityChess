// (c) Copyright RafeySoft, Karachi Pakistan. http://rafeysoft.com
// This source is subject to following License:
// http://rafeysoft.com/Web/Page/ItemEdit.aspx?sid=29&lid=4&cid=23&iid=2143
// Please write to info@rafeysoft.com for more information
// All other rights reserved.

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace App.Model
{
    // MessageForm.Confirm = Confirm
    // MessageForm.Show = Info
    // MessageForm.Error = Error

    #region MsgE

    public enum MsgE
    {
        Active = 1,
        Disabled = 2,
        Inactive = 3,
        Deleted = 4,
        Ban = 5,
        BlockIp = 6,
        WrongIdPassowrd = 7,
        NoRoles = 8,
        Resign = 9,
        Abort = 10,
        DrawAsked = 11,
        DrawDecline = 12,
        ErrorInvalidFileFormat = 13,
        InfoKickUser = 14,
        InfoSelectEngineForWhite = 15,
        InfoNotationError = 16,
        InfoMated = 17,
        InfoSelectNotation = 18,
        InfoEngineLoaded = 19,
        InfoEngineExsist = 20,
        InfoPlay = 21,
        ConfirmResetSetting = 22,
        ErrorEnterPassword = 23,
        ErrorPasswordLimit = 24,
        ErrorPasswordMismatch = 25,
        InfoCommingShortly = 26,
        ErrorEmptyOldPassword = 27,
        ErrorWrongOldPassword = 28,
        InfoUpdatePassword = 29,
        ErrorUpdatePassword = 30,
        ErrorSpacing = 31,
        ErrorServerConnection = 32,
        ErrorEmptyIdPassword = 33,
        InfoUploadEngine = 34,
        InfoCheckEmail = 35,
        ErrorChallangeYourself = 36,
        ErrorInvalidURL = 37,
        ErrorInvalidEmail = 38,
        InfoUserUpdate = 39,
        ErrorEnterUser = 40,
        ErrorUciEngine = 41,
        ErrorUserExsist = 42,
        InfoLoginRule = 43,
        ErrorImageRange = 44,
        ErrorLoginIdRange = 45,
        InfoSelectEngineForBlack = 46,
        ErrorEngineActive = 47,
        ConfirmLoadDefaultPanes = 48,
        InfoCopyPosition = 49,
        InfoPastePosition = 50,
        InfoNewPosition = 51,
        InfoKingStalem = 52,
        ConfirmSaveChanges = 53,
        ConfirmAbortGame = 54,
        ConfirmResignGame = 55,
        ErrorBaned = 56,
        ConfirmPlay = 57,
        InfoNewGameOffer = 58,
        InfoBlockedUser = 59,
        ConfirmAccessMenubar = 60,
        ConfirmLogOff = 61,
        ConfirmStoreNormalView = 62,
        InfoRating = 63,
        InfoBaned = 64,
        InfoProfile = 65,
        ConfirmBanUser = 66,
        ErrorMessage = 67,
        ConfirmKickUser = 68,
        ConfirmBlockIp = 69,
        ChallengePauseUser = 70,
        InfoKibitz = 71,
        ErrorRoomChange = 72,
        ErrorViewUserPicture = 73,
        ErrorViewGuestPicture = 74,
        ErrorViewUserRating = 75,
        ErrorViewGuestRating = 76,
        ErrorBannedForever = 77,
        ErrorGuestAcceptChallenge = 78,
        ErrorUserNotExist = 79,
        InfoEmailSend = 80,
        ConfirmEmailDelete = 81,
        InfoAvChatRequested = 82,
        ErrorAvChatDenied = 83,
        ErrorAvChatBusy = 84,
        ErrorAvChatNoUserFound = 85,
        InfoNoAvService = 86,
        ConfirmClosedAllWindow = 87,
        ErrorAvNoCamera = 88,
        ErrorAvNoPlayer = 89,
        ErrorUpgradeInProgress = 90,
        InfoUpgradeNotRequired = 91,
        InfoUpgradeAvailable = 92,
        InfoUpgradeDownloaded = 93,
        AlreadyLogin = 94,
        CreditCardValid = 95,
        CardAlreadyCheckedout = 96,
        VoucherInvalid = 97,
        ErrorNoPatch = 98,
        ConfirmBlockMachine = 99,
        InfoBlockMachine = 100,
        ConfirmFlashInstall = 101,
        InfoFlashUrl = 102,
        ErrorBlockMachine = 103,
        ConfirmRestartSchedular = 104,
        ErrorBanReason = 105,
        ErrorDatabaseLoadLastGameFailed = 106,
        ErrorInvalidUciEngine = 107,
        ConfirmTournamentWantinRequest = 108,
        ErrorTournamentWantinRequest = 109,
        ConfirmTournamentSaved = 110,
        ErrorTournamentInprogressUpdate = 111,
        ErrorTournamentName = 112,
        ConfirmTournamentStarted = 113,
        ConfirmTournamentFinished = 114,
        ConfirmTournamentMatchSaved = 115,
        ConfirmTournamentMatchesSaved = 116,
        ErrorTournamentMultipleRounds = 117,
        ErrorValidPrice = 118,
        ErrorTournamentStartReminding = 119,
        ErrorTournamentNextRoundStarted = 120,
        ErrorTournamentNextTournamentStarts = 121,
        InfoSelectDatabaseFileForE2E = 122,
        ErrorTournamentUserExist = 123,
        ErrorBeforePlayFini = 124,
        ErrorRoundStarts = 125,
        ErrorMatchStarts = 126,
        ErrorTournamentStartDate = 127,
        ErrorTournamentStartTime = 128,
        ErrorTournamentEndDate = 129,
        ErrorTournamentEndTime = 130,
        ConfirmFiniAccountUpdated = 131,
        InfoBanRemove = 132,
        ErrorFiniNotExist = 133,
        InfoGameNotFoundForTournamentMatch = 134,
        InfoUpdateTeamStatus = 137,
        ConfirmItemDelete = 138,
        ErrorNoSelection = 139,
        ConfirmItemTask = 140,
        InfoNewsUpdate = 141,
        ConversionCompleted = 142,
        ConversionCancelled = 143,
        ErrorWhiteAndBlackBye = 144,
        InfoUpdateRoom = 145,
        ErrorTieBreakMatchStart = 146,
        ErrorEmptyRoomTitle = 147,
        ErrorEmptyNewsTitle = 148,
        ErrorEmptyTeamTitle = 149,
        InfoSaveTeam = 150,
        InfoSaveRoom = 151,
        InfoSaveNews = 152,
        ImportCancelled = 153,
        InfoBanUser = 155,
        ErrorTournamentTypeChange = 156,
        ErrorSelectCheckBox = 157,
        InfoClearLogs = 158,
        SearchingCompleted = 159,
        SearchingCancelled = 160,
        ErrorServerMaintainceMode = 161,
        ErrorTournamentUserStatus = 162,
        InfoBestBiltzGameToKibitz = 163,
        InfoUnBlockedIPs = 164,
        InfoRestartTournamentMatch = 165,
        ConfirmRestartTournamentMatch = 166,
        ErrorReplacePlayerSelection = 167,
        InfoRescheduleTournament = 168,
        InfoSaveBlockedIP = 169,
        ErrorRescheduleTournament = 170,
        ConfirmRescheduleTournament = 171,
        ResetMatchAsked = 172,
        ResetMatchDecline = 173,
        InfoTournamentAnnounce = 174,
        InfoAdminRevoked = 175,
        InfoMakeAdmin = 176,
        ErrorRestartGameTime = 177,
        ErrorTournamentPlayerReplaceUser = 178,
        InfoRestartTournamentGame = 179,
        ConfirmRestartTournamentGame = 180,
        InfoUserLeftRoom = 181,
        InfoUserEnteredRoom = 182,
        ErrorTournamentMultipleMatchSelection = 183,
        InfoResetTournamentGame = 184,
        ErrorTournamentMatchNotInprogress = 185,
        ErrorTournamentMatchRestart = 186,
        InfoTournamentMatchStarted = 187,
        ErrorTournamentTeamCount = 188,
        InfoTournamentMatchRestartRequest = 189,
        InfoTournamentMatchRequestDecline = 190,
        ErrorTournamentMatchStartRequest = 191,
        ErrorTournamentChessTypeChange = 192,
        ErrorMultipleItemsNotAllowed = 193,
        ErrorTournamentMatchNotInStatus = 194,
        ConfirmPatchSizeDownload = 195
    }

    #endregion

    public class Msg
    {
        #region GetMsg

        public static string GetMsg(MsgE msgId, params object[] vals)
        {
            string text = GetMsg(msgId);

            int i = 1;
            foreach (object val in vals)
            {
                text = text.Replace("@p" + i.ToString(), val.ToString());
                i++;
            }

            return text;
        }

        public static string GetMsg(MsgE msgId)
        {
            switch (msgId)
            {
                case MsgE.Disabled:
                    return "Account Disabled";
                case MsgE.Inactive:
                    return "Account Inactive";
                case MsgE.Deleted:
                    return "Account Deleted";
                case MsgE.Ban:
                    return "'@p1' @p2";
                case MsgE.BlockIp:
                    return "Your Ip is blocked";
                case MsgE.WrongIdPassowrd:
                    return "Invalid User Name or Password";
                case MsgE.NoRoles:
                    return "Can not sign in, not assigned any role.";
                case MsgE.Resign:
                    return "'@p1' Resign";
                case MsgE.Abort:
                    return "'@p1' Abort game";
                case MsgE.DrawAsked:
                    return "Opponent Draw, Accept Offer";
                case MsgE.DrawDecline:
                    return "Opponent Rejected Draw Offer";
                case MsgE.ErrorInvalidFileFormat:
                    return "Invalid file format. Please provide valid database file.";
                case MsgE.InfoKickUser:
                    return "'@p1' has been kicked off by Administrator";
                case MsgE.InfoSelectEngineForWhite:
                    return "please select engine for White player.";
                case MsgE.InfoNotationError:
                    return "Double Notation Error";
                case MsgE.InfoMated:
                    TestDebugger.Instance.WriteInfo("============ MATED =====================");
                    return "Mated.";
                case MsgE.InfoSelectNotation:
                    return "Please select notation.";
                case MsgE.InfoEngineLoaded:
                    return "Engine Loaded Successfully";
                case MsgE.InfoEngineExsist:
                    return "Engine Already Exsist";
                case MsgE.InfoPlay:
                    return "can't draw, please play.";
                case MsgE.ConfirmResetSetting:
                    return "Reset all settings";
                case MsgE.ErrorEnterPassword:
                    return "Please enter Password";
                case MsgE.ErrorPasswordLimit:
                    return "Password should be atleast 5 characters";
                case MsgE.ErrorPasswordMismatch:
                    return "Password Mismatch";
                case MsgE.InfoCommingShortly:
                    return "Coming Shortly";
                case MsgE.ErrorEmptyOldPassword:
                    return "Please enter old Password";
                case MsgE.ErrorWrongOldPassword:
                    return "Old Password Incorrect";
                case MsgE.InfoUpdatePassword:
                    return "Password updated successfully";
                case MsgE.ErrorUpdatePassword:
                    return "Password not updated successfully";
                case MsgE.ErrorSpacing:
                    return "Space not allowed";
                case MsgE.ErrorServerConnection:
                    return "Unable to connect to server, please try again later";
                case MsgE.ErrorEmptyIdPassword:
                    return "Please enter LoginId and Password";
                case MsgE.InfoUploadEngine:
                    return "Please upload your engine";
                case MsgE.InfoCheckEmail:
                    return "Please check your email address, Email has been sent on your email address.";
                case MsgE.ErrorChallangeYourself:
                    return "Cannot challenge yourself";
                case MsgE.ErrorInvalidURL:
                    return "Invalid URL";
                case MsgE.ErrorInvalidEmail:
                    return "Invalid Email Address";
                case MsgE.InfoUserUpdate:
                    return "User updated sucessfully";
                case MsgE.ErrorEnterUser:
                    return "Please enter username";
                case MsgE.ErrorUciEngine:
                    return "Can not create UCI engine, either engine already exists or loaded.";
                case MsgE.ErrorUserExsist:
                    return "Username already exist";
                case MsgE.InfoLoginRule:
                    return "Start with alphabet and only  a-z|A-Z|0-9|.|_  are allowed";
                case MsgE.ErrorImageRange:
                    return "Image size not more than 200Kb";
                case MsgE.ErrorLoginIdRange:
                    return "LoginId should be atleast 3 characters";
                case MsgE.InfoSelectEngineForBlack:
                    return "please select engine for Black player.";
                case MsgE.ErrorEngineActive:
                    return "Engine @p1 can not be inactive, it is use as default engine";
                case MsgE.ConfirmLoadDefaultPanes:
                    return "Do you want to load default panes?";
                case MsgE.InfoCopyPosition:
                    return "Copy : @p1";
                case MsgE.InfoPastePosition:
                    return "Paste : @p1";
                case MsgE.InfoNewPosition:
                    return "New positions : @p1";
                case MsgE.InfoKingStalem:
                    return "Stalem.";
                case MsgE.ConfirmSaveChanges:
                    return "Are you want to save the changes?";
                case MsgE.ConfirmAbortGame:
                    return "Abort this game";
                case MsgE.ConfirmResignGame:
                    return "Resign this game";
                case MsgE.ErrorBaned:
                    return "You have been banned by the Administrator";
                case MsgE.ConfirmPlay:
                    return "Do you want to play another game.";
                case MsgE.InfoNewGameOffer:
                    return "Opponent Rejected New Game Offer";
                case MsgE.InfoBlockedUser:
                    return "You are Blocked by administrator";
                case MsgE.ConfirmAccessMenubar:
                    return "Press Ctrl + Alt + M to access menubar";
                case MsgE.ConfirmLogOff:
                    return "Are you sure you want to logoff?";
                case MsgE.ConfirmStoreNormalView:
                    return "To store normal view, press Ctrl + Alt + F";
                case MsgE.InfoRating:
                    return "'@p1' has no Rating.";
                case MsgE.InfoBaned:
                    return "You are banned from @p1 to @p2 by administrator";
                case MsgE.InfoProfile:
                    return "'@p1' has no profile";
                case MsgE.ConfirmBanUser:
                    return "Are you sure you want to ban '@p1'?";
                case MsgE.ErrorMessage:
                    return "Error: @p1";
                case MsgE.ConfirmKickUser:
                    return "Are you sure you want to kick off '@p1'?";
                case MsgE.ConfirmBlockIp:
                    return "Are you sure you want to block IP of '@p1'?";
                case MsgE.ChallengePauseUser:
                    return "'@p1' is paused you can not challenge";
                case MsgE.InfoKibitz:
                    return "No match currently running";
                case MsgE.ErrorRoomChange:
                    //return "Please close all game windows";
                    return "Please close game window";
                case MsgE.ErrorViewUserPicture:
                    return "Guest can not view picture";
                case MsgE.ErrorViewUserRating:
                    return "Guest can not view rating";
                case MsgE.ErrorViewGuestPicture:
                    return "Guest does not have a picture";
                case MsgE.ErrorViewGuestRating:
                    return "Guest does not have rating";
                case MsgE.ErrorBannedForever:
                    return "'@p1' banned forever";
                case MsgE.ErrorGuestAcceptChallenge:
                    return "Guest can not accept rated challenge";
                case MsgE.ErrorUserNotExist:
                    return "'@p1' not exist";
                case MsgE.InfoEmailSend:
                    return "Email has been send successfully";
                case MsgE.ConfirmEmailDelete:
                    return "Are you sure you want to delete email?";
                case MsgE.InfoAvChatRequested:
                    return "Do you want to @p1 chat with '@p2'?";
                case MsgE.ErrorAvChatBusy:
                    return "'@p1' is busy and already in chat with another user";
                case MsgE.ErrorAvChatDenied:
                    return "'@p1' refused chat inivitation.";
                case MsgE.InfoNoAvService:
                    return "Service is not available right now.";
                case MsgE.ConfirmClosedAllWindow:
                    return "You are already logged in from other place, Are you sure you want to log off from there?";
                case MsgE.ErrorAvNoCamera:
                    return "Camera is not present or not properly installed.";
                case MsgE.ErrorAvNoPlayer:
                    return "Flash player 8 or higher is required.";
                case MsgE.ErrorUpgradeInProgress:
                    return "Upgrade is already in progress.";
                case MsgE.InfoUpgradeNotRequired:
                    return "Your program is up to date.";
                case MsgE.InfoUpgradeAvailable:
                    return "Update is available. Are you sure you want to download?";
                case MsgE.InfoUpgradeDownloaded:
                    return "Update is downloaded successfully and will be installed when you exit application.";
                case MsgE.AlreadyLogin:
                    return "User '@p1' already logged in.";
                case MsgE.CardAlreadyCheckedout:
                    return "Your card is already checked out.";
                case MsgE.CreditCardValid:
                    return "Your card has been successfully checked in";
                case MsgE.VoucherInvalid:
                    return "You voucher no. is not valid, Please try again";
                case MsgE.ErrorNoPatch:
                    return "Installation package could not be found.";
                case MsgE.ConfirmBlockMachine:
                    return "Are you sure you want to block machine of '@p1'?";
                case MsgE.InfoBlockMachine:
                    return "Your machine is blocked.";
                case MsgE.ConfirmFlashInstall:
                    return "Flash Player 8 or higher is required. Do you want to install it?";
                case MsgE.InfoFlashUrl:
                    return @"http://www.adobe.com/go/getflash";
                case MsgE.ErrorBlockMachine:
                    return "Machine cannot be blocked.";
                case MsgE.ConfirmRestartSchedular:
                    return "Are you sure you want to restart schedular?";
                case MsgE.ErrorBanReason:
                    return "Please specify ban reason.";
                case MsgE.ErrorDatabaseLoadLastGameFailed:
                    return "Load last game from database failed.";
                case MsgE.ErrorInvalidUciEngine:
                    return "Engine: could not load";
                case MsgE.ConfirmTournamentWantinRequest:
                    return "Your wantin request sent to admin for tournament '@p1'.";
                case MsgE.ErrorTournamentWantinRequest:
                    return "You can not send wantin request. Please select team.";
                case MsgE.ConfirmTournamentSaved:
                    return "'@p1' saved successfully.";
                case MsgE.ErrorTournamentInprogressUpdate:
                    return "Tournament is in progress so it can not be updated.";
                case MsgE.ErrorTournamentName:
                    return "Please enter tournament title.";
                case MsgE.ConfirmTournamentStarted:
                    return "'@p1' started successfully.";
                case MsgE.ConfirmTournamentFinished:
                    return "'@p1' finished successfully.";
                case MsgE.ConfirmTournamentMatchSaved:
                    return "'@p1' created successfully";
                case MsgE.ConfirmTournamentMatchesSaved:
                    return "'@p1' updated successfully";
                case MsgE.ErrorTournamentMultipleRounds:
                    return "Multiple rounds can not be started simultaneously.";
                case MsgE.ErrorValidPrice:
                    return "Please enter valid amount in prize '@p1'.";
                case MsgE.ErrorTournamentStartReminding:
                    return "Tournament is scheduled, please start the tournament first in tournament detail form.";
                case MsgE.ErrorTournamentNextRoundStarted:
                    return "Next round can not be created due to few matches result is pending";
                case MsgE.ErrorTournamentNextTournamentStarts:
                    return "You can not start this tournament as another tournament '@p1' is in progress. Please contact tournament director ' @p2'";
                case MsgE.InfoSelectDatabaseFileForE2E:
                    return "Please select target database file.";
                case MsgE.ErrorTournamentUserExist:
                    return "Tournament '@p1' can not be started, please select at least @p2 players to start Tournament";
                case MsgE.ErrorBeforePlayFini:
                    return "Rank must be Knight or greater to play for fini.";
                case MsgE.ErrorRoundStarts:
                    return "Round can not be started due to inprogress matches.";
                case MsgE.ErrorMatchStarts:
                    return "Matches can not be started due to pending results.";
                case MsgE.ErrorTournamentStartDate:
                    return "Start date should be in 'mm/dd/yyyy' format.";
                case MsgE.ErrorTournamentStartTime:
                    return "Start time should be in 'hh:mm AM/PM' format.";
                case MsgE.ErrorTournamentEndDate:
                    return "End date should be in 'mm/dd/yyyy' format.";
                case MsgE.ErrorTournamentEndTime:
                    return "End time should be in 'hh:mm AM/PM' format.";
                case MsgE.ConfirmFiniAccountUpdated:
                    return "Your request has been submitted. An email is sent to your specified email address";
                case MsgE.InfoBanRemove:
                    return "Ban removed successfully";
                case MsgE.ErrorFiniNotExist:
                    return "Player '@p1' has no enough fini to play.";
                case MsgE.InfoGameNotFoundForTournamentMatch:
                    return "Game information is not available for selected tournament match.";
                case MsgE.InfoUpdateTeamStatus:
                    return "Team status updated successfully";
                case MsgE.ConfirmItemDelete:
                    return "Are you sure, you want to delete @p1 ? ";
                case MsgE.ConfirmItemTask:
                    return "Are you sure, you want to @p1 @p2 ? ";
                case MsgE.ErrorNoSelection:
                    return "No @p1 is selected.";
                case MsgE.InfoNewsUpdate:
                    return "News status updated successfully";
                case MsgE.ConversionCompleted:
                    return "Conversion completed successfully";
                case MsgE.ConversionCancelled:
                    return "Conversion cancelled on user request";
                case MsgE.ErrorWhiteAndBlackBye:
                    return "Please select White and Black player";
                case MsgE.InfoUpdateRoom:
                    return "Room status updated successfully";
                case MsgE.ErrorTieBreakMatchStart:
                    return "Please select valid match for playing";
                case MsgE.ErrorEmptyRoomTitle:
                    return "Please enter room title";
                case MsgE.ErrorEmptyTeamTitle:
                    return "Please enter team title";
                case MsgE.ErrorEmptyNewsTitle:
                    return "Please enter news title";
                case MsgE.InfoSaveTeam:
                    return "Team saved successfully";
                case MsgE.InfoSaveRoom:
                    return "Room saved successfully";
                case MsgE.InfoSaveNews:
                    return "News saved successfully";
                case MsgE.ImportCancelled:
                    return "Import cancelled on user request";
                case MsgE.InfoBanUser:
                    return "User banned successfully";
                case MsgE.ErrorTournamentTypeChange:
                    return "Tournament type can not be updated, please create new tournament.";
                case MsgE.ErrorSelectCheckBox:
                    return "Please check at least one checkbox";
                case MsgE.InfoClearLogs:
                    return "logs cleared successfully";
                case MsgE.SearchingCompleted:
                    return "Searching completed successfully";
                case MsgE.SearchingCancelled:
                    return "Searching cancelled successfully";
                case MsgE.ErrorServerMaintainceMode:
                    return "Server is in maintaince mode. Please try again later after @p1 (Server Time)";
                case MsgE.ErrorTournamentUserStatus:
                    return "Some Matches can not be started. Players is not available in tournament room.";
                case MsgE.InfoBestBiltzGameToKibitz:
                    return "No Best Biltz game currently running";
                case MsgE.InfoUnBlockedIPs:
                    return "Ips unblocked successfully";
                case MsgE.InfoRestartTournamentMatch:
                    return "Match restarted by tournament director";
                case MsgE.ConfirmRestartTournamentMatch:
                    return "Are you sure you want to restart match?";
                case MsgE.ErrorReplacePlayerSelection:
                    return "Select only one player to replace.";
                case MsgE.ConfirmRescheduleTournament:
                    return "'@p1' rescheduled successfully.";
                case MsgE.InfoSaveBlockedIP:
                    return "IP blocked successfully";
                case MsgE.ErrorRescheduleTournament:
                    return "Only inprogress tournament will be reschedule";
                case MsgE.InfoRescheduleTournament:
                    return "Tournament rescheduled by tournament director";
                case MsgE.ResetMatchAsked:
                    return "Opponent accept reset match offer";
                case MsgE.ResetMatchDecline:
                    return "Opponent reject reset match offer";
                case MsgE.InfoTournamentAnnounce:
                    return "Tournament '@p1' going to be scheduling, you are invited to join this tournament.";
                case MsgE.InfoAdminRevoked:
                    return "Admin revoked.";
                case MsgE.InfoMakeAdmin:
                    return "Admin created.";
                case MsgE.ErrorRestartGameTime:
                    return "Game time can not be exceeded to tournament match time.";
                case MsgE.ErrorTournamentPlayerReplaceUser:
                    return "Tournament player can not be replaced.";
                case MsgE.InfoRestartTournamentGame:
                    return "Select Move to restart match.";
                case MsgE.ConfirmRestartTournamentGame:
                    return "Are you agree to restart match with these moves and time. If Yes, Press 'Ok' or 'Cancel' to resume.";
                case MsgE.InfoUserLeftRoom:
                    return "'@p1' has left room '@p2'";
                case MsgE.InfoUserEnteredRoom:
                    return "'@p1' has entered in room '@p2'";
                case MsgE.ErrorTournamentMultipleMatchSelection:
                    return "Please select one match to restart match with setup.";
                case MsgE.InfoResetTournamentGame:
                    return "Tournament Match is restarted with setup";
                case MsgE.ErrorTournamentMatchNotInprogress:
                    return "Tournament match is not in progress";
                case MsgE.ErrorTournamentMatchRestart:
                    return "Please select tournament matches to restart.";
                case MsgE.InfoTournamentMatchStarted:
                    return "Tournament match restarted.";
                case MsgE.ErrorTournamentTeamCount:
                    return "The no. of Players in team are not equal.";
                case MsgE.InfoTournamentMatchRestartRequest:
                    return "Restart Match Request Sent.";
                case MsgE.InfoTournamentMatchRequestDecline:
                    return "Opponent has decline restart match offer";
                case MsgE.ErrorTournamentMatchStartRequest:
                    return "Please select tournament matches to start.";
                case MsgE.ErrorTournamentChessTypeChange:
                    return "Tournament Chess Type can not be updated.";
                case MsgE.ErrorMultipleItemsNotAllowed:
                    return "This operation could only perform on single item, please select one item.";     
                case MsgE.ErrorTournamentMatchNotInStatus:
                    return "Tournament match is not '@p1'.";
                case MsgE.ConfirmPatchSizeDownload:
                    return "Upgrade size is @p1, while new setup size is @p2. Are you sure you want to download the upgrade?";
                default:
                    break;
            }
            return "";
        }

        #endregion
    }
}
