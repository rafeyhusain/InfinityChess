
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Arsalan Ata
-- Create date: 08-09-2010
-- Description:	Get All Games By Tournament ID
-- =============================================
alter PROCEDURE GetAllGamesByTournamentID 

	@TournamentID int
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select tm.TournamentMatchID, * from Tournament t
		inner join TournamentMatch tm 
		on t.tournamentid = tm.tournamentid 
		inner join Game g on
		g.TournamentMatchID = tm.TournamentMatchID
		where t.TournamentID = @TournamentID

END
GO


set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

-- ========================================================================================== --
-- Author:		IMRAN HASHMAT
-- Create date: 17 MARCH 2010
-- Description:	Get all data for application like users, games room count etc
-- ========================================================================================== --
ALTER PROCEDURE [dbo].[ApData]
	@UserID int,
	@RoomID int
AS
BEGIN
	
	--Room
	SELECT RoomID, ParentID, Name, ISNULL(TournamentID,0) TournamentID, 
			IsGuestAllow, 
			CanTakeBackMove, ISNULL(Description,'') Description, ISNULL(Html,'') Html ,
			ISNULL(IsUrlBit,0 ) IsUrlBit, StatusID
			, CreatedBy, DateCreated, ModifiedBy, DateModified 
			
	FROM [Room] 
			WHERE RoomID=@RoomID
	
	--Room Users
	IF(@RoomID = 8 OR @RoomID = 9 OR @RoomID = 10 OR @RoomID = 11 OR @RoomID = 12)
	BEGIN
		SELECT U.UserID,UserName, US.Name AS [Status], 
		(SELECT EloRating FROM UserGameType WHERE ChessTypeID = 2 AND GameTypeID = 1 AND UserID = U.UserID) AS BulletElo,
		(SELECT EloRating FROM UserGameType WHERE ChessTypeID = 2 AND GameTypeID = 2 AND UserID = U.UserID) AS BlitzElo,
		(SELECT EloRating FROM UserGameType WHERE ChessTypeID = 2 AND GameTypeID = 3 AND UserID = U.UserID) AS RapidElo,
		(SELECT EloRating FROM UserGameType WHERE ChessTypeID = 2 AND GameTypeID = 4 AND UserID = U.UserID) AS LongElo,
		FT.Name AS FIDETitle, IT.Name AS ICCFTitle, U.CountryID, R.Name AS [Rank], S.Name AS Scocial, 
		(SELECT Name FROM Engine WHERE EngineID = U.EngineID) AS Engine,
		(SELECT MAX(GameID) FROM Game WHERE GameResultID = 1 AND RoomID = @RoomID AND(WhiteUserID = U.UserID OR BlackUserID = U.UserID)) AS GameID,
		dbo.GetInternetID(U.Internet,1)as Internet,dbo.GetInternetID(U.Internet,0)+' '+convert(varchar,U.Internet)+'s' as InternetTooltip, CT.Name CountryName,
		U.UserStatusID, U.IsPause, U.IsIdle
		FROM [User] U 
		INNER JOIN UserStatus US ON U.UserStatusID = US.UserStatusID 
		INNER JOIN [Status] ST ON U.StatusID = ST.StatusID 
		INNER JOIN [Rank] R ON U.HumanRankID = R.RankID 
		LEFT JOIN Country CT ON U.CountryID = CT.CountryID 
		LEFT JOIN FideTitle FT ON U.FideTitleID = FT.FideTitleID 
		LEFT JOIN IccfTitle IT ON U.IccfTitleID = IT.IccfTitleID 
		LEFT JOIN Social S ON U.SocialID = S.SocialID 
		WHERE (@RoomId=0 or RoomId=ISNULL(@RoomID,RoomId)) AND U.UserStatusID <> 4
		ORDER BY DateLastLogin DESC
	END
	ELSE
	BEGIN
		SELECT U.UserID,UserName, US.Name AS [Status], 
		(SELECT EloRating FROM UserGameType WHERE ChessTypeID = 1 AND GameTypeID = 1 AND UserID = U.UserID) AS BulletElo,
		(SELECT EloRating FROM UserGameType WHERE ChessTypeID = 1 AND GameTypeID = 2 AND UserID = U.UserID) AS BlitzElo,
		(SELECT EloRating FROM UserGameType WHERE ChessTypeID = 1 AND GameTypeID = 3 AND UserID = U.UserID) AS RapidElo,
		(SELECT EloRating FROM UserGameType WHERE ChessTypeID = 1 AND GameTypeID = 4 AND UserID = U.UserID) AS LongElo,
		FT.Name AS FIDETitle, IT.Name AS ICCFTitle, U.CountryID, R.Name AS [Rank], S.Name AS Scocial, 
		(SELECT Name FROM Engine WHERE EngineID = U.EngineID) AS Engine,
		(SELECT MAX(GameID) FROM Game WHERE GameResultID = 1 AND RoomID = @RoomID AND(WhiteUserID = U.UserID OR BlackUserID = U.UserID)) AS GameID,
		dbo.GetInternetID(U.Internet,1)as Internet,dbo.GetInternetID(U.Internet,0)+' '+convert(varchar,U.Internet)+'s' as InternetTooltip, CT.Name CountryName,
		U.UserStatusID, U.IsPause, U.IsIdle
		FROM [User] U 
		INNER JOIN UserStatus US ON U.UserStatusID = US.UserStatusID 
		INNER JOIN [Status] ST ON U.StatusID = ST.StatusID 
		INNER JOIN [Rank] R ON U.HumanRankID = R.RankID 
		LEFT JOIN Country CT ON U.CountryID = CT.CountryID 
		LEFT JOIN FideTitle FT ON U.FideTitleID = FT.FideTitleID 
		LEFT JOIN IccfTitle IT ON U.IccfTitleID = IT.IccfTitleID 
		LEFT JOIN Social S ON U.SocialID = S.SocialID 
		WHERE (@RoomId=0 or RoomId=ISNULL(@RoomID,RoomId)) AND U.UserStatusID <> 4
		ORDER BY DateLastLogin DESC
	END
	
	--Room Games
	Select G.GameID, G.GameTypeID, WhiteUserID, 
	(SELECT UserName From [User] U WHERE U.UserID = G.WhiteUserID) AS WhiteUserName, G.EloWhiteBefore, 	BlackUserID, 
	(SELECT UserName From [User] U WHERE U.UserID = G.BlackUserID) AS BlackUserName, G.EloBlackBefore, GR.Display AS Result,
	(CONVERT(VARCHAR(100), ISNULL(G.TimeMin,0)) + ''' + ' + 	CONVERT(VARCHAR(100),ISNULL(G.GainPerMoveMin,0)) + '"') AS TimeControl,
	CONVERT(VARCHAR, G.StartDate, 0) AS StartTime, 
	G.StartDate, G.IsRated, G.ChallengeID FROM Game G 
	INNER JOIN GameResult GR ON G.GameResultID = GR.GameResultID 
	WHERE RoomId=@RoomID AND G.DateCreated > (GETDATE()-1) AND G.GameResultID NOT IN (5,6)
	ORDER BY G.GameID DESC
	
	--Room Challenges

	SELECT ChallengeID, ChallengeStatusID, ChallengerUserID,(SELECT UserName FROM [User] WHERE UserID = ChallengerUserID) AS ChallengerName, 
	ISNULL((SELECT EloRating FROM UserGameType WHERE UserID = ChallengerUserID AND GameTypeID = Ch.GameTypeID AND ChessTypeID = Ch.ChessTypeID),0) AS ChallengerElo, 
	ISNULL(OpponentUserID,0) AS OpponentUserID, ISNULL((SELECT UserName FROM [User] WHERE UserID = OpponentUserID),'To All') AS OpponentName, 
	ISNULL((SELECT EloRating FROM UserGameType WHERE UserID = OpponentUserID AND GameTypeID = Ch.GameTypeID AND ChessTypeID = Ch.ChessTypeID),0) AS OpponentElo, 
	Ch.IsRated AS Condition, Co.Name AS Color, 
	CASE WHEN WithClock = 0 THEN 'No Clock'
	ELSE
	(CONVERT(VARCHAR(100), ISNULL(Ch.TimeMin,0)) + ''' + ' + CONVERT(VARCHAR(100),ISNULL(Ch.GainPerMoveMin,0)) + '"') --AS Clock,
	END AS Clock,
	Ch.ChallengeTypeID AS [Type],
	ISNULL(dbo.GetInternetID((SELECT Internet FROM [User] WHERE UserID = ChallengerUserID),1),1) AS InternetC,
	ISNULL(dbo.GetInternetID((SELECT Internet FROM [User] WHERE UserID = ChallengerUserID),0)+' '+convert(varchar,(SELECT Internet FROM [User] WHERE UserID = ChallengerUserID))+'s','') as InternetTooltipC,
	ISNULL(dbo.GetInternetID((SELECT Internet FROM [User] WHERE UserID = OpponentUserID),1),1) as InternetO,
	ISNULL(dbo.GetInternetID((SELECT Internet FROM [User] WHERE UserID = OpponentUserID),0)+' '+convert(varchar,(SELECT Internet FROM [User] WHERE UserID = OpponentUserID))+'s','') as InternetTooltipO,
	Ch.ChessTypeID, ISNULL(Ch.TimeMin,0) AS GameTime, Ch.TimeMax, Ch.GainPerMoveMin,  Ch.GainPerMoveMax,
	(SELECT HumanRankID FROM [User] WHERE UserID = ChallengerUserID) AS ChallengerRankID,
	CASE WHEN OpponentUserID = 0 THEN 1 
	ELSE
	(SELECT HumanRankID FROM [User] WHERE UserID = OpponentUserID)
	END AS OpponentRankID, ISNULL(IsChallengerSendsGame, 0) AS IsChallengerSendsGame,
	ISNULL(TournamentMatchID, 0) AS TournamentMatchID
	FROM Challenge Ch
	INNER JOIN Color Co ON Ch.ColorID = Co.ColorID
	WHERE RoomId=@RoomID
	AND ChallengeStatusID <> 2 AND Ch.StatusID = 1
	AND (ChallengerUserID = @UserID OR OpponentUserID = @UserID OR OpponentUserID = 0 OR OpponentUserID IS NULL)
	
	--Room Users Count
	SELECT RoomID, COUNT(*) AS UsersCount FROM [User] WHERE UserStatusID <> 4 AND StatusID = 1 GROUP BY ROOMID

	SELECT COUNT(*) LoggedinUser FROM [User] WHERE UserStatusId <> 4 AND StatusID = 1 
	AND RoomID IN (SELECT RoomID FROM Room WHERE StatusID = 1)
	
	--UserMessages
	SELECT  UserMessageID, ISNULL(Subject,'') AS Subject, ISNULL(Text,'') AS Text, EmailTime, 
		UserIDFrom, (SELECT UserName FROM [User] WHERE UserID = UserIDFrom) AS [From],
		UserIDTo, (SELECT UserName FROM [User] WHERE UserID = UserIDTo) AS [To],
		Size, StatusIDFrom, StatusIDTo, CreatedBy, DateCreated, ModifiedBy, DateModified
	FROM	UserMessage
	WHERE (UserIDFrom = @UserID OR UserIDTo = @UserID)
	ORDER BY EmailTime DESC

END
GO
-- Get Tournament Rooms
select RoomID, isnull(ParentID, -1) ParentID, Name, isnull(TournamentID, -1) TournamentID, StatusID, Description, Html from room 

/*

update by muiz on 2010-09-28 14:44:41.810
*/


ALTER TABLE KeyValue
 ALTER COLUMN [Value] ntext NULL

insert into KeyValue values('ServerMaintainceDateTime',null
,null,1,null,null,null)

Go
sp_RENAME BlockedIPs, BlockedIP;
Go

ALTER TABLE [user]
ADD BanMachineKey ntext NULL 

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Ubaid
-- Create date: 23 apr
-- Description:	
-- =============================================
ALTER PROCEDURE [dbo].[LoginUser] 
	-- Add the parameters for the stored procedure here
	@UserName nvarchar(100),
	@Password nvarchar(100),
	@Code nvarchar(150),
	@IpAddress nvarchar(50),
	@MachineKey nvarchar(100)

As
declare @Count int
declare @Count2 int
declare @StatusID int 
declare @UserID int
declare @UserRole int

declare @BanStartDateTime datetime
declare @BanEndDateTime datetime

set @StatusID =0
set @UserID =0 
set @UserRole =0 

set @BanStartDateTime = ''
set @BanEndDateTime = ''

Select @Count = count(*) from BlockedIp where IpAddress = @IpAddress
Select @Count2 = count(*) from BlockedMachines where MachineKey = @MachineKey

if(@Count >0) -- check ip is block
	begin
		select -6 as MsgId
		set @UserID =-1
	end
else if(@Count2 >0) -- check machine is block
	begin
		select -100 as MsgId
		set @UserID =-1
	end
else if(@UserName = 'Guest') -- check guest
	begin
		SELECT       @UserID=dbo.[User].UserID,@StatusID=dbo.[User].StatusID
		FROM         dbo.UserAccessCode INNER JOIN
                     dbo.AccessCode ON dbo.UserAccessCode.AccessCodeID = dbo.AccessCode.AccessCodeID INNER JOIN
                     dbo.[User] ON dbo.UserAccessCode.UserID = dbo.[User].UserID
		Where	     dbo.AccessCode.Code = @Code and Password = @Password
	end
else  -- check valid user
	begin
		select @UserID=UserID,@StatusID=StatusID 
		from [User] 
		where LOWER(UserName)=LOWER(@UserName) AND Password=@Password
	end


if(@UserID = 0)
	begin
		Select  -7 as MsgId
	end
else if(@UserID > 0)
	begin
		SELECT   @UserRole=count(*)
		FROM     dbo.UserRole
		Where    UserId = @UserID

		if(@UserRole = 0)
			begin
				Select -8 as MsgId
			end
		else
			begin
				Select	@StatusID = (StatusID * -1),
				@BanStartDateTime = Convert(DateTime, convert(varchar, BanStartDate, 23) 
								+ ' ' + convert(varchar, BanStartTime, 24)),
				
				@BanEndDateTime = Convert(DateTime, convert(varchar, BanEndDate, 23) 
								+ ' ' + convert(varchar, BanEndTime, 24))

				From	[User]
				Where   UserId = @UserID 

				if @StatusID = -5
				begin					
					 set @StatusID = dbo.CheckBanUser(@UserID)
					if @StatusID = -1          -- ban time expires and update ban status
					begin
						update [User] set StatusID = 1,
								BanStartDate = NULL, BanStartTime = NULL, 
								BanEndDate = NULL, BanEndTime = NULL
								where UserID = @UserID
						--select (-1) as MsgId
					end						
				end

				select @StatusID MsgId, 
						@BanStartDateTime BanEndDateTime, 
						@BanEndDateTime BanEndDateTime
				
				Select	*
				From	[User]
				Where   UserId = @UserID 

				SELECT RoleID 
				FROM UserRole 
				WHERE UserID = @UserID
			end
end
GO

SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO




