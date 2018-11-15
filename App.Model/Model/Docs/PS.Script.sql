ALTER TABLE KeyValue
ALTER COLUMN [Value] ntext NULL

insert into KeyValue values('ServerMaintainceDateTime',null
,null,1,null,null,null)
GO
sp_RENAME BlockedIPs, BlockedIP
GO
ALTER TABLE [user]
ADD BanMachineKey ntext NULL 

GO

ALTER TABLE [TournamentUser]
ADD UserId2 INT NULL DEFAULT 1

GO

ALTER TABLE [TournamentMatch]
ADD StatusId INT NULL DEFAULT 1

GO

ALTER TABLE [TournamentTeam]
ADD StatusId INT NULL DEFAULT 1

GO

ALTER TABLE [TournamentWantinUser]
ADD StatusId INT NULL DEFAULT 1

GO

ALTER TABLE Tournament
ADD		NoOfGamesPerRound int null, 
		NoOfTieBreaks int null, 
		SuddenDeathWhiteMin int null, 
		SuddenDeathWhiteSec int null, 
		SuddenDeathBlackMin int null,
		SuddenDeathBlackSec int null,
		TieBreakMin int  NULL,
		TieBreakSec int  NULL 

CREATE TABLE [dbo].[TournamentMatchType](
[TournamentMatchTypeID] [int] IDENTITY(1,1) NOT NULL,
[Name] [nvarchar](600) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Description] [ntext] COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[CreatedBy] [int] NULL,
[DateCreated] [datetime] NULL,
[ModifiedBy] [int] NULL,
[DateModified] [datetime] NULL,
CONSTRAINT [PK_TournamentMatchType] PRIMARY KEY CLUSTERED
(
[TournamentMatchTypeID] ASC
)WITH (PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

ALTER TABLE [dbo].[TournamentMatchType] WITH CHECK ADD CONSTRAINT [FK_TournamentMatchType_User] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[User] ([UserID])
GO
ALTER TABLE [dbo].[TournamentMatchType] CHECK CONSTRAINT [FK_TournamentMatchType_User]
GO
ALTER TABLE [dbo].[TournamentMatchType] WITH CHECK ADD CONSTRAINT [FK_TournamentMatchType_User1] FOREIGN KEY([ModifiedBy])
REFERENCES [dbo].[User] ([UserID])
GO
ALTER TABLE [dbo].[TournamentMatchType] CHECK CONSTRAINT [FK_TournamentMatchType_User1]
GO


CREATE TABLE [dbo].[TournamentRound](
[TournamentRoundID] [int] IDENTITY(1,1) NOT NULL,
[TournamentID] [int] NULL,
[Round] [int] NULL,
[WinUserID] [int] NULL,
[LoseUserID] [int] NULL,
[StatusID] [int] NULL,
[CreatedBy] [int] NULL,
[DateCreated] [datetime] NULL,
[ModifiedBy] [int] NULL,
[DateModified] [datetime] NULL,
CONSTRAINT [PK_TournamentRound] PRIMARY KEY CLUSTERED
(
[TournamentRoundID] ASC
)WITH (PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[TournamentRound] WITH CHECK ADD CONSTRAINT [FK_TournamentRound_Status] FOREIGN KEY([StatusID])
REFERENCES [dbo].[Status] ([StatusID])
GO
ALTER TABLE [dbo].[TournamentRound] CHECK CONSTRAINT [FK_TournamentRound_Status]
GO
ALTER TABLE [dbo].[TournamentRound] WITH CHECK ADD CONSTRAINT [FK_TournamentRound_Tournament] FOREIGN KEY([TournamentID])
REFERENCES [dbo].[Tournament] ([TournamentID])
GO
ALTER TABLE [dbo].[TournamentRound] CHECK CONSTRAINT [FK_TournamentRound_Tournament]
GO
ALTER TABLE [dbo].[TournamentRound] WITH CHECK ADD CONSTRAINT [FK_TournamentRound_User] FOREIGN KEY([WinUserID])
REFERENCES [dbo].[User] ([UserID])
GO
ALTER TABLE [dbo].[TournamentRound] CHECK CONSTRAINT [FK_TournamentRound_User]
GO
ALTER TABLE [dbo].[TournamentRound] WITH CHECK ADD CONSTRAINT [FK_TournamentRound_User1] FOREIGN KEY([LoseUserID])
REFERENCES [dbo].[User] ([UserID])
GO
ALTER TABLE [dbo].[TournamentRound] CHECK CONSTRAINT [FK_TournamentRound_User1]
GO
ALTER TABLE [dbo].[TournamentRound] WITH CHECK ADD CONSTRAINT [FK_TournamentRound_User2] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[User] ([UserID])
GO
ALTER TABLE [dbo].[TournamentRound] CHECK CONSTRAINT [FK_TournamentRound_User2]
GO
ALTER TABLE [dbo].[TournamentRound] WITH CHECK ADD CONSTRAINT [FK_TournamentRound_User3] FOREIGN KEY([ModifiedBy])
REFERENCES [dbo].[User] ([UserID])
GO
ALTER TABLE [dbo].[TournamentRound] CHECK CONSTRAINT [FK_TournamentRound_User3]

GO

INSERT INTO [TournamentMatchType] ([Name]) VALUES ('Normal')
INSERT INTO [TournamentMatchType] ([Name]) VALUES ('Tie break')
INSERT INTO [TournamentMatchType] ([Name]) VALUES ('Sudden Death')

GO

ALTER TABLE TournamentMatch
add TournamentMatchTypeID int  NOT NULL DEFAULT 1 
GO

ALTER TABLE [dbo].[TournamentMatch]  WITH CHECK ADD  CONSTRAINT [FK_TournamentMatch_TournamentMatchType] FOREIGN KEY([TournamentMatchTypeID])
REFERENCES [dbo].[TournamentMatchType] ([TournamentMatchTypeID])

GO
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

GO
/****** Object:  StoredProcedure [dbo].[GetChallengesByRoomID]    Script Date: 10/14/2010 14:21:41 ******/
DROP PROCEDURE [dbo].[GetChallengesByRoomID]
GO
/****** Object:  StoredProcedure [dbo].[ApData]    Script Date: 10/14/2010 14:21:41 ******/
DROP PROCEDURE [dbo].[ApData]
GO
/****** Object:  StoredProcedure [dbo].[GetTournamentMatchByTournamentID]    Script Date: 10/14/2010 14:21:41 ******/
DROP PROCEDURE [dbo].[GetTournamentMatchByTournamentID]
GO
/****** Object:  StoredProcedure [dbo].[GetuserMessages]    Script Date: 10/14/2010 14:21:41 ******/
DROP PROCEDURE [dbo].[GetuserMessages]
GO
/****** Object:  StoredProcedure [dbo].[GetTournamentMatchByTournamentUserID]    Script Date: 10/14/2010 14:21:41 ******/
--DROP PROCEDURE [dbo].[GetTournamentMatchByTournamentUserID]
GO
/****** Object:  StoredProcedure [dbo].[UpdateAllChallengesByID]    Script Date: 10/14/2010 14:21:41 ******/
DROP PROCEDURE [dbo].[UpdateAllChallengesByID]
GO
/****** Object:  UserDefinedFunction [dbo].[GetInternetID]    Script Date: 10/14/2010 14:21:42 ******/
DROP FUNCTION [dbo].[GetInternetID]
GO
/****** Object:  StoredProcedure [dbo].[GetAllRoomsWithNullTournament]    Script Date: 10/14/2010 14:21:41 ******/
DROP PROCEDURE [dbo].[GetAllRoomsWithNullTournament]
GO
/****** Object:  StoredProcedure [dbo].[GetAllRoomsWithRelationship]    Script Date: 10/14/2010 14:21:41 ******/
DROP PROCEDURE [dbo].[GetAllRoomsWithRelationship]
GO
/****** Object:  StoredProcedure [dbo].[AddAccessCode]    Script Date: 10/14/2010 14:21:41 ******/
DROP PROCEDURE [dbo].[AddAccessCode]
GO
/****** Object:  StoredProcedure [dbo].[GetTournamentUsersByRound]    Script Date: 10/14/2010 14:21:41 ******/
--DROP PROCEDURE [dbo].[GetTournamentUsersByRound]
GO
/****** Object:  StoredProcedure [dbo].[GetHighestRankingPlayerGame]    Script Date: 10/14/2010 14:21:41 ******/
DROP PROCEDURE [dbo].[GetHighestRankingPlayerGame]
GO
/****** Object:  StoredProcedure [dbo].[GetGamesByRoomID]    Script Date: 10/14/2010 14:21:41 ******/
DROP PROCEDURE [dbo].[GetGamesByRoomID]
GO
/****** Object:  StoredProcedure [dbo].[GetGamesByUserID]    Script Date: 10/14/2010 14:21:41 ******/
DROP PROCEDURE [dbo].[GetGamesByUserID]
GO
/****** Object:  StoredProcedure [dbo].[GetRankInfo]    Script Date: 10/14/2010 14:21:41 ******/
DROP PROCEDURE [dbo].[GetRankInfo]
GO
/****** Object:  StoredProcedure [dbo].[GetTopRatingByGameType]    Script Date: 10/14/2010 14:21:41 ******/
DROP PROCEDURE [dbo].[GetTopRatingByGameType]
GO
/****** Object:  StoredProcedure [dbo].[GetTournamentCmbData]    Script Date: 10/14/2010 14:21:41 ******/
DROP PROCEDURE [dbo].[GetTournamentCmbData]
GO
/****** Object:  StoredProcedure [dbo].[GetUsersByRoomID]    Script Date: 10/14/2010 14:21:41 ******/
DROP PROCEDURE [dbo].[GetUsersByRoomID]
GO
/****** Object:  StoredProcedure [dbo].[LoginUser]    Script Date: 10/14/2010 14:21:41 ******/
DROP PROCEDURE [dbo].[LoginUser]
GO
/****** Object:  StoredProcedure [dbo].[GetUserInfoByUserID]    Script Date: 10/14/2010 14:21:41 ******/
DROP PROCEDURE [dbo].[GetUserInfoByUserID]
GO
/****** Object:  StoredProcedure [dbo].[CreateServerStatistics]    Script Date: 10/14/2010 14:21:41 ******/
DROP PROCEDURE [dbo].[CreateServerStatistics]
GO
/****** Object:  StoredProcedure [dbo].[CreateTournamentRegisterUser]    Script Date: 10/14/2010 14:21:41 ******/
DROP PROCEDURE [dbo].[CreateTournamentRegisterUser]
GO
/****** Object:  StoredProcedure [dbo].[GetTournamentRegisteredUsers]    Script Date: 10/14/2010 14:21:41 ******/
DROP PROCEDURE [dbo].[GetTournamentRegisteredUsers]
GO
/****** Object:  StoredProcedure [dbo].[GetGameByGameID]    Script Date: 10/14/2010 14:21:41 ******/
DROP PROCEDURE [dbo].[GetGameByGameID]
GO
/****** Object:  StoredProcedure [dbo].[GetLastInprogressGame]    Script Date: 10/14/2010 14:21:41 ******/
DROP PROCEDURE [dbo].[GetLastInprogressGame]
GO
/****** Object:  StoredProcedure [dbo].[GetGameByChallengeID]    Script Date: 10/14/2010 14:21:41 ******/
DROP PROCEDURE [dbo].[GetGameByChallengeID]
GO
/****** Object:  StoredProcedure [dbo].[GetGameData]    Script Date: 10/14/2010 14:21:41 ******/
DROP PROCEDURE [dbo].[GetGameData]
GO
/****** Object:  StoredProcedure [dbo].[GetAllGamesByTournamentID]    Script Date: 10/14/2010 14:21:41 ******/
--DROP PROCEDURE [dbo].[GetAllGamesByTournamentID]
GO
/****** Object:  StoredProcedure [dbo].[UpdateTournamentMatchWithUser]    Script Date: 10/14/2010 14:21:41 ******/
--DROP PROCEDURE [dbo].[UpdateTournamentMatchWithUser]
GO
/****** Object:  StoredProcedure [dbo].[UpdateTournamentUserEloBefore]    Script Date: 10/14/2010 14:21:41 ******/
DROP PROCEDURE [dbo].[UpdateTournamentUserEloBefore]
GO
/****** Object:  UserDefinedFunction [dbo].[GetRankByUserID]    Script Date: 10/14/2010 14:21:42 ******/
--DROP FUNCTION [dbo].[GetRankByUserID]
GO
/****** Object:  StoredProcedure [dbo].[_init]    Script Date: 10/14/2010 14:21:41 ******/
DROP PROCEDURE [dbo].[_init]
GO
/****** Object:  StoredProcedure [dbo].[GetAllTournament]    Script Date: 10/14/2010 14:21:41 ******/
DROP PROCEDURE [dbo].[GetAllTournament]
GO
/****** Object:  StoredProcedure [dbo].[GetSchTournamentWantinUsers]    Script Date: 10/14/2010 14:21:41 ******/
--DROP PROCEDURE [dbo].[GetSchTournamentWantinUsers]
GO
/****** Object:  StoredProcedure [dbo].[GetKnockoutResultByTournamentID]    Script Date: 10/14/2010 14:21:41 ******/
DROP PROCEDURE [dbo].[GetKnockoutResultByTournamentID]
GO
/****** Object:  StoredProcedure [dbo].[GetSchTournamentResultByTournamentID]    Script Date: 10/14/2010 14:21:41 ******/
--DROP PROCEDURE [dbo].[GetSchTournamentResultByTournamentID]
GO
/****** Object:  StoredProcedure [dbo].[GetTournamentUsers]    Script Date: 10/14/2010 14:21:41 ******/
DROP PROCEDURE [dbo].[GetTournamentUsers]
GO
/****** Object:  StoredProcedure [dbo].[GetTournamentWantinUsers]    Script Date: 10/14/2010 14:21:41 ******/
DROP PROCEDURE [dbo].[GetTournamentWantinUsers]
GO
/****** Object:  StoredProcedure [dbo].[GetTournamentResultByTournamentID]    Script Date: 10/14/2010 14:21:41 ******/
DROP PROCEDURE [dbo].[GetTournamentResultByTournamentID]
GO
/****** Object:  StoredProcedure [dbo].[GetServerStatistics]    Script Date: 10/14/2010 14:21:41 ******/
DROP PROCEDURE [dbo].[GetServerStatistics]
GO
/****** Object:  StoredProcedure [dbo].[DeleteTournamentMatchByUserID]    Script Date: 10/14/2010 14:21:41 ******/
DROP PROCEDURE [dbo].[DeleteTournamentMatchByUserID]
GO
/****** Object:  StoredProcedure [dbo].[UpdateTournamentChallengeStatus]    Script Date: 10/14/2010 14:21:41 ******/
DROP PROCEDURE [dbo].[UpdateTournamentChallengeStatus]
GO
/****** Object:  UserDefinedFunction [dbo].[GetUserEloAfter]    Script Date: 10/14/2010 14:21:42 ******/
DROP FUNCTION [dbo].[GetUserEloAfter]
GO
/****** Object:  StoredProcedure [dbo].[UpdateTournamentMatchStatus]    Script Date: 10/14/2010 14:21:41 ******/
DROP PROCEDURE [dbo].[UpdateTournamentMatchStatus]
GO
/****** Object:  StoredProcedure [dbo].[GetUsersInfoByIds]    Script Date: 10/14/2010 14:21:41 ******/
DROP PROCEDURE [dbo].[GetUsersInfoByIds]
GO
/****** Object:  UserDefinedFunction [dbo].[GetUserEloBefore]    Script Date: 10/14/2010 14:21:42 ******/
DROP FUNCTION [dbo].[GetUserEloBefore]
GO
/****** Object:  StoredProcedure [dbo].[UpdateTournamentUserStatus]    Script Date: 10/14/2010 14:21:41 ******/
DROP PROCEDURE [dbo].[UpdateTournamentUserStatus]
GO
/****** Object:  UserDefinedFunction [dbo].[GetName]    Script Date: 10/14/2010 14:21:42 ******/
--DROP FUNCTION [dbo].[GetName]
GO
/****** Object:  StoredProcedure [dbo].[UpdateTournamentUsersEloAfterByTournamentID]    Script Date: 10/14/2010 14:21:41 ******/
DROP PROCEDURE [dbo].[UpdateTournamentUsersEloAfterByTournamentID]
GO
/****** Object:  StoredProcedure [dbo].[UpdateTournamentWantinUserStatus]    Script Date: 10/14/2010 14:21:41 ******/
DROP PROCEDURE [dbo].[UpdateTournamentWantinUserStatus]
GO
/****** Object:  StoredProcedure [dbo].[UpdateWantinUserStatusByUserID]    Script Date: 10/14/2010 14:21:41 ******/
DROP PROCEDURE [dbo].[UpdateWantinUserStatusByUserID]
GO
/****** Object:  StoredProcedure [dbo].[UpdateGameStatusWithTournamentMatchID]    Script Date: 10/14/2010 14:21:41 ******/
--DROP PROCEDURE [dbo].[UpdateGameStatusWithTournamentMatchID]
GO
/****** Object:  StoredProcedure [dbo].[GetUsersGameRating]    Script Date: 10/14/2010 14:21:41 ******/
--DROP PROCEDURE [dbo].[GetUsersGameRating]
GO
/****** Object:  StoredProcedure [dbo].[UpdateTournamentTeamStatus]    Script Date: 10/14/2010 14:21:41 ******/
--DROP PROCEDURE [dbo].[UpdateTournamentTeamStatus]
GO
/****** Object:  StoredProcedure [dbo].[UpdateTournamentUserStatusByTeamID]    Script Date: 10/14/2010 14:21:41 ******/
--DROP PROCEDURE [dbo].[UpdateTournamentUserStatusByTeamID]
GO
/****** Object:  UserDefinedFunction [dbo].[CheckBanUser]    Script Date: 10/14/2010 14:21:42 ******/
DROP FUNCTION [dbo].[CheckBanUser]
GO
/****** Object:  StoredProcedure [dbo].[CreateTournamentMatch]    Script Date: 10/14/2010 14:21:41 ******/
DROP PROCEDURE [dbo].[CreateTournamentMatch]
GO
/****** Object:  StoredProcedure [dbo].[CreateTournamentMatch]    Script Date: 10/14/2010 14:21:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CreateTournamentMatch]

@TournamentID int,
@WhiteUserID int,
@BlackUserID int,
@MatchStartDate datetime,
@MatchStartTime datetime,
@TournamentMatchStatusID int,
@CreatedBy int,
@DateCreated datetime,
@EloWhiteBefore int,
@EloBlackBefore int

as

INSERT INTO TournamentMatch 
(
	TournamentID,
	WhiteUserID,
	BlackUserID,
	MatchStartDate,
	MatchStartTime,
	TournamentMatchStatusID,
	EloWhiteBefore,
	EloBlackBefore,	
	CreatedBy,
	DateCreated	
)
VALUES
(
	@TournamentID,
	@WhiteUserID,
	@BlackUserID,
	@MatchStartDate,
	@MatchStartTime,
	@TournamentMatchStatusID,
	@EloWhiteBefore,
	@EloBlackBefore,
	@CreatedBy,
	@DateCreated
)
GO
/****** Object:  UserDefinedFunction [dbo].[CheckBanUser]    Script Date: 10/14/2010 14:21:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Arsalan
-- Create date: 11 June 2010
-- Description:	Check Ban User
-- =============================================
CREATE FUNCTION [dbo].[CheckBanUser] 
(	
	@UserID int
)
RETURNS int
AS
BEGIN
	
declare @BanStartDate datetime
declare @BanStartTime datetime
declare @BanEndDate datetime
declare @BanEndTime datetime
declare @StatusID int
declare @BanEndDateTime datetime

set @BanStartDate = ''
set @BanStartTime = ''
set @BanEndDate = ''
set @BanEndTime = ''
set @BanEndDateTime = ''
set @StatusID = 0

	DECLARE @Result int

	Select @StatusID = StatusID, @BanEndDate = BanEndDate, @BanEndTime = BanEndTime
					From	[User]
					Where   UserId = @UserID 

	if @StatusID = 5 AND @BanEndDate is null
	begin
		set @Result = -5
	end
	else
	begin
		Set @BanEndDateTime = Convert(DateTime, convert(varchar, @BanEndDate, 23) + ' ' + 
												convert(varchar, @BanEndTime, 24))
		if GetDate() <= @BanEndDateTime 
		begin
			set @Result = 0
		end
		else
		begin			
			set @Result = -1
		end
	end
	
	RETURN @Result

END
GO
/****** Object:  StoredProcedure [dbo].[UpdateTournamentUserStatusByTeamID]    Script Date: 10/14/2010 14:21:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[UpdateTournamentUserStatusByTeamID]

@TeamIDs varchar(200),
@TournamentID int,
@ModifiedBy int,
@DateModified datetime,
@StatusID int

AS

declare @sql varchar(4000)

set @sql = ''

set @sql = 'UPDATE TournamentUser 
	SET 		
		ModifiedBy = ' + convert(varchar, @ModifiedBy) +', 
		DateModified = ''' + convert(varchar, @DateModified) + ''',
		StatusID = ' + convert(varchar, @StatusID) + '
	WHERE 
		TournamentID = ' + convert(varchar, @TournamentID) +' AND (''' +		
		@TeamIDs + ''' = ''0'' OR TeamID in (' + @TeamIDs + '))'


print @sql
exec (@sql)
--
--
--
GO
/****** Object:  StoredProcedure [dbo].[UpdateTournamentTeamStatus]    Script Date: 10/14/2010 14:21:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[UpdateTournamentTeamStatus]

@TournamentID int,
@StatusID int,
@ModifiedBy int,
@DateModified datetime


AS

declare @sql varchar(4000)

set @sql = ''

set @sql = 'UPDATE TournamentTeam 
	SET 		
		ModifiedBy = ' + convert(varchar, @ModifiedBy) +', 
		DateModified = ''' + convert(varchar, @DateModified) + ''',
		StatusID = ' + convert(varchar, @StatusID) + '
	WHERE 
		TournamentID = ' + convert(varchar, @TournamentID) 



print @sql
exec (@sql)
--
--
--
--[UpdateTournamentUserStatusByTeamID] ''
GO
/****** Object:  StoredProcedure [dbo].[GetUsersGameRating]    Script Date: 10/14/2010 14:21:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[GetUsersGameRating]
@ChessTypeID int,
@GameTypeID int,
@UserIDs varchar(200)

as

declare @sql varchar(4000)

set @sql = ''

set @sql = 'SELECT * FROM UserGameType WHERE ChessTypeID = ' + convert(varchar, @ChessTypeID) +' AND 
			GameTypeID = ' + convert(varchar, @ChessTypeID) + ' AND UserID IN (' +@UserIDs +')'

print @sql

exec (@sql)
GO
/****** Object:  StoredProcedure [dbo].[UpdateGameStatusWithTournamentMatchID]    Script Date: 10/14/2010 14:21:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- create by arsalan ata for online client
-- use for online client
CREATE procedure [dbo].[UpdateGameStatusWithTournamentMatchID]

@GameIDs varchar(4000),
@GameResultID int,
@ModifiedBy int,
@DateModified datetime

AS

declare @sql varchar(4000)

set @sql = ''

set @sql = 'UPDATE Game
	SET 
		GameResultID = ' + convert(varchar, @GameResultID) +', 
		ModifiedBy = ' + convert(varchar, @ModifiedBy) +', 
		DateModified = ''' + convert(varchar, @DateModified) + ''' 
	WHERE 			
		GameID in (' +@GameIDs +')'

print @sql

exec (@sql)
GO
/****** Object:  StoredProcedure [dbo].[UpdateWantinUserStatusByUserID]    Script Date: 10/14/2010 14:21:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- create by arsalan ata for online client
-- use for online client
CREATE procedure [dbo].[UpdateWantinUserStatusByUserID]

@UserIDs varchar(4000),
@TournamentID int,
@TournamentUserStatusID int,
@ModifiedBy int,
@DateModified datetime

AS

declare @sql varchar(4000)

set @sql = ''

set @sql = 'update TournamentWantinUser 
	SET 
		TournamentUserStatusID = ' + convert(varchar, @TournamentUserStatusID) +', 
		ModifiedBy = ' + convert(varchar, @ModifiedBy) +', 
		DateModified = ''' + convert(varchar, @DateModified) + ''' 
	WHERE 	
		TournamentID = ' + convert(varchar, @TournamentID) +' and 
		UserID in (' +@UserIDs +')'

--print @sql

exec (@sql)
GO
/****** Object:  StoredProcedure [dbo].[UpdateTournamentWantinUserStatus]    Script Date: 10/14/2010 14:21:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[UpdateTournamentWantinUserStatus]


/*
@TournamentWantinIDs varchar(200),
@TournamentUserStatusID int,
@ModifiedBy int,
@DateModified datetime

AS

declare @sql varchar(4000)

set @sql = ''

set @sql = 'update TournamentWantinUser 
	SET 
		TournamentUserStatusID = ' + convert(varchar, @TournamentUserStatusID) +', 
		ModifiedBy = ' + convert(varchar, @ModifiedBy) +', 
		DateModified = ''' + convert(varchar, @DateModified) + ''' 
	WHERE 	
		TournamentWantinUserID in (' +@TournamentWantinIDs +')'

--print @sql

exec (@sql)
*/

@TeamIDs varchar(200) = '',
@TournamentID int,
@TournamentUserStatusID int,
@StatusID int,
@ModifiedBy int,
@DateModified datetime

AS

declare @sql varchar(4000)

set @sql = ''

set @sql = 'update TournamentWantinUser 
	SET 
		TournamentUserStatusID = ' + convert(varchar, @TournamentUserStatusID) +', 
		ModifiedBy = ' + convert(varchar, @ModifiedBy) +', 
		DateModified = ''' + convert(varchar, @DateModified) + ''',
		StatusID = ''' + convert(varchar, @StatusID) + '''
	WHERE 	
		TournamentID = ' + convert(varchar, @TournamentID) +' and (''' +		
		@TeamIDs + ''' = ''0'' OR TeamID in (' + @TeamIDs + '))'

print @sql

exec (@sql)

--[UpdateTournamentWantinUserStatus] '31, 32', 454, 2, 4, 1, '2010-10-13 10:53:33.627'
GO
/****** Object:  StoredProcedure [dbo].[UpdateTournamentUsersEloAfterByTournamentID]    Script Date: 10/14/2010 14:21:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Ubaid
-- Create date: 18-03-2010
-- Description:	Update tournament users EloAfter by tournament id
-- =============================================
CREATE PROCEDURE [dbo].[UpdateTournamentUsersEloAfterByTournamentID] 
	-- Add the parameters for the stored procedure here
	@Wu int , 
	@Bu int ,
	@EloW int,
	@EloB int,
	@TournamentID int
AS


Update TournamentUser
set EloAfter = @EloW
where UserID = @Wu and TournamentID = @TournamentID

Update TournamentUser
set EloAfter = @EloB
where UserID = @Bu and TournamentID = @TournamentID
GO
/****** Object:  UserDefinedFunction [dbo].[GetName]    Script Date: 10/14/2010 14:21:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Arsalan
-- Create date: 24 Sep, 2010
-- Description:	
-- =============================================
CREATE FUNCTION [dbo].[GetName] 
(
	-- Add the parameters for the function here
	@UserName1 varchar(100),
	@UserName2 varchar(100)
)
RETURNS varchar(100)
AS
BEGIN
	-- Declare the return variable here
	DECLARE @Result varchar(100)

	-- Add the T-SQL statements to compute the return value here
	set @Result = @UserName1
	if @UserName2 <> ''
		begin
			SELECT @Result = @UserName2 + ' (' +@UserName1 + ')'
		end
	-- Return the result of the function
	RETURN @Result

END
GO
/****** Object:  StoredProcedure [dbo].[UpdateTournamentUserStatus]    Script Date: 10/14/2010 14:21:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[UpdateTournamentUserStatus]

@UserIDs varchar(200),
@TournamentID int,
@ModifiedBy int,
@DateModified datetime,
@StatusID int

AS

declare @sql varchar(4000)

set @sql = ''

set @sql = 'UPDATE TournamentUser 
	SET 		
		ModifiedBy = ' + convert(varchar, @ModifiedBy) +', 
		DateModified = ''' + convert(varchar, @DateModified) + ''',
		StatusID = ' + convert(varchar, @StatusID) + '
	WHERE 
		TournamentID = ' + convert(varchar, @TournamentID) +'
	AND 
		UserID in (' +@UserIDs +')'


print @sql
exec (@sql)
GO
/****** Object:  UserDefinedFunction [dbo].[GetUserEloBefore]    Script Date: 10/14/2010 14:21:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [dbo].[GetUserEloBefore] 
(
	-- Add the parameters for the function here
	@id int ,
	@tid int
)
RETURNS int 
AS
BEGIN
	
declare @ResultVar int

set @ResultVar= ( SELECT   top(1)  

case when WhiteUserID = @id then EloWhiteBefore  when BlackUserID = @id then EloBlackBefore end


FROM       dbo.TournamentMatch
where TournamentID = @tid and (WhiteUserID = @id or BlackUserID = @id)
order by MatchStartDate,MatchStartTime,TournamentMatchID)



	RETURN @ResultVar

END
GO
/****** Object:  StoredProcedure [dbo].[GetUsersInfoByIds]    Script Date: 10/14/2010 14:21:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		IMRAN HASHMAT
-- Create date: 26 MARCH 2010
-- Description:	Get users by csv ids 
-- =============================================
CREATE PROCEDURE [dbo].[GetUsersInfoByIds] 
	@UserIds VARCHAR(MAX)
AS
BEGIN
		DECLARE @query VARCHAR(MAX)
		

		SET @query = 'SELECT U.UserID, U.UserName, US.Name AS [Status], 
		(SELECT EloRating FROM UserGameType WHERE ChessTypeID = 1 AND GameTypeID = 1 AND UserID = U.UserID) AS BulletElo,
		(SELECT EloRating FROM UserGameType WHERE ChessTypeID = 1 AND GameTypeID = 2 AND UserID = U.UserID) AS BlitzElo,
		(SELECT EloRating FROM UserGameType WHERE ChessTypeID = 1 AND GameTypeID = 3 AND UserID = U.UserID) AS RapidElo,
		(SELECT EloRating FROM UserGameType WHERE ChessTypeID = 1 AND GameTypeID = 4 AND UserID = U.UserID) AS LongElo,
		FT.Name AS FIDETitle, IT.Name AS ICCFTitle, U.CountryID, R.Name AS [Rank], S.Name AS Scocial, 
		(SELECT Name FROM Engine WHERE EngineID = U.EngineID) AS Engine, CT.Name CountryName
		FROM [User] U 
		INNER JOIN UserStatus US ON U.UserStatusID = US.UserStatusID 
		INNER JOIN [Status] ST ON U.StatusID = ST.StatusID 
		INNER JOIN [Rank] R ON U.HumanRankID = R.RankID 
		LEFT JOIN Country CT ON U.CountryID = CT.CountryID 
		LEFT JOIN FideTitle FT ON U.FideTitleID = FT.FideTitleID 
		LEFT JOIN IccfTitle IT ON U.IccfTitleID = IT.IccfTitleID 
		LEFT JOIN Social S ON U.SocialID = S.SocialID 
		WHERE U.UserID IN (' + @UserIds + ') AND U.UserStatusID <> 4'
		--print @query
		EXEC (@query)
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateTournamentMatchStatus]    Script Date: 10/14/2010 14:21:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[UpdateTournamentMatchStatus]

@TournamentMatchIDs varchar(200),
@TournamentMatchStatusID int,
@GameResultID int,
@ModifiedBy int

AS

declare @sql varchar(4000)

set @sql = ''

set @sql = 'UPDATE TournamentMatch
	SET 		
		ModifiedBy = ' + convert(varchar, @ModifiedBy) +', 
		DateModified = ''' + convert(varchar, getdate()) + ''',
		TournamentMatchStatusID = ' + convert(varchar, @TournamentMatchStatusID) + ',
		GameResultID = ' + convert(varchar, @GameResultID) + '
	WHERE 	
		TournamentMatchID in (' +@TournamentMatchIDs +')'


print @sql
exec (@sql)
GO
/****** Object:  UserDefinedFunction [dbo].[GetUserEloAfter]    Script Date: 10/14/2010 14:21:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
Create FUNCTION [dbo].[GetUserEloAfter] 
(
	-- Add the parameters for the function here
	@id int ,
	@tid int
)
RETURNS int 
AS
BEGIN
	
declare @ResultVar int

set @ResultVar= (SELECT   top(1) 
case when WhiteUserID = @id then EloWhiteAfter  when BlackUserID = @id then EloBlackAfter end 


FROM       dbo.TournamentMatch
where TournamentID = @tid and (WhiteUserID = @id or BlackUserID = @id)
order by MatchStartDate,MatchStartTime,TournamentMatchID desc
)



	RETURN @ResultVar

END
GO
/****** Object:  StoredProcedure [dbo].[UpdateTournamentChallengeStatus]    Script Date: 10/14/2010 14:21:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[UpdateTournamentChallengeStatus]

@TournamentMatchIDs varchar(200),
@StatusID int,
@ModifiedBy int

AS

declare @sql varchar(4000)

set @sql = ''

set @sql = 'UPDATE Challenge
	SET 		
		ModifiedBy = ' + convert(varchar, @ModifiedBy) +', 
		DateModified = ''' + convert(varchar, getdate()) + ''',
		StatusID = ' + convert(varchar, @StatusID) + '
	WHERE 	
		TournamentMatchID in (' +@TournamentMatchIDs +')'


print @sql
exec (@sql)
GO
/****** Object:  StoredProcedure [dbo].[DeleteTournamentMatchByUserID]    Script Date: 10/14/2010 14:21:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Created by Arsalan ata on 06 March 2010
CREATE procedure [dbo].[DeleteTournamentMatchByUserID]

@TournamentUserIDs varchar(200),
@TournamentID int,
@TournamentMatchStatusID int
AS

declare @sql varchar(4000)

set @sql = ''

set @sql = 'DELETE TournamentMatch
		where (whiteuserid in( ' + convert(varchar, @TournamentUserIDs) +') or
		blackuserid in ('+ @TournamentUserIDs + '))
		and tournamentid = ' + convert(varchar, @TournamentID) + '
		and tournamentmatchstatusid in (' + convert(varchar, @TournamentMatchStatusID) +')'


print @sql
exec (@sql)
GO
/****** Object:  StoredProcedure [dbo].[GetServerStatistics]    Script Date: 10/14/2010 14:21:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Muiz
-- Create date: 27 May
-- Description:	get server information
-- =============================================

CREATE PROCEDURE [dbo].[GetServerStatistics]
	
AS
select * from serverstatistics where serverstatisticsid = 
(select max(serverstatisticsid) from serverstatistics)
GO
/****** Object:  StoredProcedure [dbo].[GetTournamentResultByTournamentID]    Script Date: 10/14/2010 14:21:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Ubaid-ur-Rehman
-- Create date: 10 march 10
-- Description:	Tournament Result
-- GetTournamentResultByTournamentID 0
-- =============================================
CREATE PROCEDURE [dbo].[GetTournamentResultByTournamentID] 
	-- Add the parameters for the stored procedure here
	@TournamentID int = 0

AS

SELECT   ROW_NUMBER()over (order by TournamentPoints desc) as Rank,
		[User].UserID,UserName,EloBefore,EloAfter,TournamentPoints, 
isnull([user].CountryID,244) as CountryID,
c.Name CountryName,

isnull(TournamentUser.UserID2, 0) UserID2,
UserName2 = isnull((select UserName from [user] where UserID = TournamentUser.UserID2),'')

FROM         dbo.TournamentUser INNER JOIN
                      dbo.[User] ON dbo.TournamentUser.UserID = dbo.[User].UserID
left join country c on c.countryid = [User].countryid
where      TournamentID =@TournamentID
and TournamentUser.StatusID <> 4
order by TournamentPoints desc

SELECT     TournamentID,ROW_NUMBER()over (order by TournamentMatchID) as CNo, 
			WhiteUserID, BlackUserID, GameResultID,[Round],
(select max([Round]) from  dbo.TournamentMatch where TournamentID = @TournamentID)as NoR

FROM       dbo.TournamentMatch

where      TournamentID =@TournamentID
and TournamentMatch.StatusID <> 4


SELECT   ROW_NUMBER()over (order by teamid) as Rank, 
sum(tournamentpoints) Rating

FROM         dbo.TournamentUser INNER JOIN
                      dbo.[User] ON dbo.TournamentUser.UserID = dbo.[User].UserID
where      TournamentID = @TournamentID 
and TournamentUser.StatusID <> 4
group by TeamID 
order by sum(tournamentpoints) desc

select u.username, sum(tournamentpoints) points, tu.tournamentid, u.userid 
from tournamentuser tu 
inner join [user] u on u.userid = tu.userid
where tu.tournamentid = @TournamentID
and tu.StatusID <> 4
group by u.username, tu.tournamentid, u.userid
order by sum(tournamentpoints) desc
GO
/****** Object:  StoredProcedure [dbo].[GetTournamentWantinUsers]    Script Date: 10/14/2010 14:21:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[GetTournamentWantinUsers]

@TournamentID int
as

declare @GametypeID int
declare @ChessTypeId int
set @GametypeID = 0
set @ChessTypeId = 0

select @GametypeID = GameTypeID, @ChessTypeId = ChessTypeId from Tournament where tournamentid = @TournamentID

select * from (
select 
u.UserID,
u.UserName,
twu.TournamentID,
u.FirstName,
u.LastName,
isnull(c.Name,'') Country,
isnull(U.CountryID, '')  Flag,
R.Name AS [Rank], 
R.RankID as RankID,
S.Name AS Scocial, 
U.StatusID,
tus.Name TournamentUserStatusName,
twu.TournamentUserStatusID,
Rating = isnull((select elorating 
		from usergametype gt 
		where userid = u.userid 
		and gametypeID = @GametypeID 
		and chessTypeId = @ChessTypeId), 0),

FT.Name AS FIDETitle, IT.Name AS ICCFTitle, 
twu.TournamentWantinUserID TournamentWantinUserID,
twu.ModifiedBy,
twu.DateModified,
@GametypeID GameTypeID, 
@ChessTypeId ChessTypeId,
twu.TeamID,
TeamName = ''
from 
TournamentWantinUser twu inner join Tournament t on t.TournamentID = twu.TournamentID
inner join TournamentUserStatus tus on tus.TournamentUserStatusID = twu.TournamentUserStatusID
inner join [User] u on u.userid = twu.userid
INNER JOIN [Rank] R ON U.HumanRankID = R.RankID 
LEFT JOIN FideTitle FT ON U.FideTitleID = FT.FideTitleID 
LEFT JOIN IccfTitle IT ON U.IccfTitleID = IT.IccfTitleID 
LEFT JOIN Social S ON U.SocialID = S.SocialID 
left JOIN Country c on c.CountryID = U.CountryID
where twu.TournamentID = @TournamentID
and twu.StatusID <> 4
) tbl where teamname is not null
GO
/****** Object:  StoredProcedure [dbo].[GetTournamentUsers]    Script Date: 10/14/2010 14:21:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*
[GetTournamentUsers] 187, 0, 4
*/

CREATE procedure [dbo].[GetTournamentUsers]

@TournamentID int,
@TeamID int = 0,
@UserStatusID int = 0
AS

declare @GametypeID int
declare @ChessTypeId int
set @GametypeID = 0
set @ChessTypeId = 0

select @GametypeID = GameTypeID, @ChessTypeId = ChessTypeId from Tournament where tournamentid = @TournamentID


select 
U.UserID, 
U.UserName, 
U.FirstName,
U.LastName,
Rating = (select elorating 
		from usergametype gt 
		where userid = u.userid 
		and gametypeID = @GametypeID 
		and chessTypeId = @ChessTypeId),
isnull(c.Name,'') Country,

case 
	isnull(U.CountryID, '')
	when 0 then 244	
	else
		isnull(U.CountryID, '')
	end as Flag,
R.Name AS [Rank], 
S.Name AS Scocial, 

0 TournamentUserStatusID,
--'' TournamentUserStatusName,
0 TournamentUserID,
u.statusid,
@GametypeID GametypeID,
@ChessTypeId ChessTypeId
from [user] U 
left join country c on c.countryid = u.countryid
INNER JOIN [Rank] R ON U.HumanRankID = R.RankID 
LEFT JOIN Social S ON U.SocialID = S.SocialID 

where 
	userid not in
	(
		select tu.userid from tournament t 
		inner join 
			tournamentuser tu 		
		on t.tournamentid=tu.tournamentid 
		where 
			(t.tournamentid = @TournamentID )
		and
			(@TeamID = 0 or tu.TeamID = @TeamID)	
		and (tu.StatusID = 1)		
	)
and
	userid
	not in 
		(
			select isnull(tu.userid2, 0) from tournament t 
			inner join 
			tournamentuser tu 		
			on t.tournamentid=tu.tournamentid 
			where 
			(t.tournamentid = @TournamentID )
			and
			(@TeamID = 0 or tu.TeamID = @TeamID)	
			and (tu.StatusID = 1)	
		)
	
and u.statusid <> 2 
and (@UserStatusID = 0 or u.userstatusid <> @UserStatusID)

and u.UserID not in (select userid from [user] where username like 'Guest%')
GO
/****** Object:  StoredProcedure [dbo].[GetSchTournamentResultByTournamentID]    Script Date: 10/14/2010 14:21:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Ubaid-ur-Rehman
-- Create date: 10 march 10
-- Description:	Tournament Result
-- GetTournamentResultByTournamentID 0
-- =============================================
CREATE PROCEDURE [dbo].[GetSchTournamentResultByTournamentID]
	-- Add the parameters for the stored procedure here
	@TournamentID int = 0

AS

SELECT   ROW_NUMBER()over (order by TournamentPoints desc) as Rank,
		[User].UserID,UserName,EloBefore,EloAfter,TournamentPoints, 
isnull([user].CountryID,244) as CountryID,
c.Name CountryName,
tournamentuser.TeamID,
TeamName = (select teamname from team where teamid = tournamentuser.teamid),
isnull(TournamentUser.UserID2, 0) UserID2,
UserName2 = 
	isnull((select UserName from [user] where UserID = TournamentUser.UserID2),'')

FROM         dbo.TournamentUser INNER JOIN
                      dbo.[User] ON dbo.TournamentUser.UserID = dbo.[User].UserID
inner join TournamentTeam tt on tt.TeamID = TournamentUser.TeamID
and tt.TournamentID = @TournamentID
left join country c on c.countryid = [User].countryid
where TournamentUser.TournamentID = @TournamentID
and TournamentUser.StatusID <> 4
and tt.StatusID <> 4
order by TournamentPoints desc



SELECT     TournamentID,ROW_NUMBER()over (order by TournamentMatchID) as CNo, 
			WhiteUserID, BlackUserID, GameResultID,[Round],
(select max([Round]) from  dbo.TournamentMatch where TournamentID =@TournamentID)as NoR

FROM       dbo.TournamentMatch
where      TournamentID = @TournamentID
and TournamentMatch.StatusID <> 4

SELECT   ROW_NUMBER()over (order by TournamentUser.teamid) as Rank, 
sum(tournamentpoints) Rating,  
TournamentUser.TeamID, TeamName = (select teamname from team where teamid = tournamentuser.teamid)

FROM         dbo.TournamentUser INNER JOIN
                      dbo.[User] ON dbo.TournamentUser.UserID = dbo.[User].UserID
inner join TournamentTeam tt on tt.TeamID = TournamentUser.TeamID
and tt.TournamentID = @TournamentID
where      TournamentUser.TournamentID = @TournamentID 

and TournamentUser.StatusID <> 4
group by TournamentUser.TeamID 
order by sum(tournamentpoints) desc



select u.username, '( ' +t.TeamName + ' )' TeamName, sum(tournamentpoints) points, 
t.teamid, tu.tournamentid, u.userid 
from tournamentuser tu 
inner join [user] u on u.userid = tu.userid
inner join team t on t.teamid = tu.teamid
inner join TournamentTeam tt on tt.TeamID = t.TeamID
and tt.tournamentid = @TournamentID
and tu.TournamentID = @TournamentID
and tt.StatusID <> 4
and tu.StatusID <> 4
group by u.username, tu.tournamentid, u.userid, t.teamid, t.TeamName
order by sum(tournamentpoints) desc
GO
/****** Object:  StoredProcedure [dbo].[GetKnockoutResultByTournamentID]    Script Date: 10/14/2010 14:21:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--[GetKnockoutResultByTournamentID] 202
CREATE PROCEDURE [dbo].[GetKnockoutResultByTournamentID] 
	-- Add the parameters for the stored procedure here
	@TournamentID int = 0
AS

/*
select 
* 


from 
(
	SELECT     [Round],whiteUser.[UserName] as White,blackUser.[UserName] as Black,Display as Result,

	WhiteUserName2 = dbo.GetName(whiteUser.[UserName], 
							isnull((select u2.username from [user] u inner join tournamentuser tu on tu.UserID = u.UserID 
							inner join [user] u2 on u2.UserID = tu.UserID2
							where tournamentId = @TournamentID  and u.userid = dbo.TournamentMatch.WhiteUserID), '')),

	BlackUserName2 = dbo.GetName(blackUser.[UserName],
							isnull((select u2.username from [user] u inner join tournamentuser tu on tu.UserID = u.UserID 
							inner join [user] u2 on u2.UserID = tu.UserID2
							where tournamentId = @TournamentID  and u.userid = dbo.TournamentMatch.BlackUserID), ''))

	FROM       dbo.TournamentMatch
	Inner Join dbo.[User] as whiteUser On dbo.TournamentMatch.WhiteUserID = whiteUser.UserId
	Inner Join dbo.[User] as blackUser On dbo.TournamentMatch.BlackUserID = blackUser.UserId
	Inner Join dbo.GameResult on dbo.TournamentMatch.GameResultID = dbo.GameResult.GameResultID
where      TournamentID = @TournamentID
) tbl
*/


---- Get Preliminary Round(Round=0) Results.

---------- Preliminary Round Started ----------
SELECT     [Round],
CASE substring(dbo.GameResult.Display, 0, 4)
		 -- if WhiteWin, then BlackUser is 'Lose'
         WHEN '1-0' THEN 
			dbo.GetName(blackUser.[UserName],
							isnull((select u2.username from [user] u inner join tournamentuser tu on tu.UserID = u.UserID 
							inner join [user] u2 on u2.UserID = tu.UserID2
							where tournamentId = @TournamentID  and u.userid = dbo.TournamentMatch.BlackUserID), ''))			
		 -- else WhiteUser is 'Lose'
         ELSE 		
			dbo.GetName(whiteUser.[UserName],
							isnull((select u2.username from [user] u inner join tournamentuser tu on tu.UserID = u.UserID 
							inner join [user] u2 on u2.UserID = tu.UserID2
							where tournamentId = @TournamentID  and u.userid = dbo.TournamentMatch.WhiteUserID), ''))			
end as Lose,
CASE substring(dbo.GameResult.Display, 0, 4)
		 -- if WhiteWin, then WhiteUser is 'Win'
         WHEN '1-0' THEN 			
			dbo.GetName(whiteUser.[UserName],
							isnull((select u2.username from [user] u inner join tournamentuser tu on tu.UserID = u.UserID 
							inner join [user] u2 on u2.UserID = tu.UserID2
							where tournamentId = @TournamentID  and u.userid = dbo.TournamentMatch.WhiteUserID), ''))
		 -- else BlackUser is 'Win'
         ELSE 					
			dbo.GetName(blackUser.[UserName],
							isnull((select u2.username from [user] u inner join tournamentuser tu on tu.UserID = u.UserID 
							inner join [user] u2 on u2.UserID = tu.UserID2
							where tournamentId = @TournamentID  and u.userid = dbo.TournamentMatch.BlackUserID), ''))
end as Win,
'0-1' as Result	

	FROM       dbo.TournamentMatch
	Inner Join dbo.[User] as whiteUser On dbo.TournamentMatch.WhiteUserID = whiteUser.UserId
	Inner Join dbo.[User] as blackUser On dbo.TournamentMatch.BlackUserID = blackUser.UserId
	Inner Join dbo.GameResult on dbo.TournamentMatch.GameResultID = dbo.GameResult.GameResultID
where      TournamentID = @TournamentID 
and TournamentMatch.GameResultID in (2,3,7,8,9,10) -- either white-win or Black-win
and TournamentMatch.Round = 0 
and TournamentMatch.StatusID <> 4
---------- Preliminary Round Finished ----------

Union -- union both(Preliminary-Round and Tournament-Rounds) results

---- Get Tournament's Rounds(Round > 0) Results.

---------- Tournament's Rounds Started ----------
select tr.Round,dbo.GetName(loser.[UserName],
							isnull((select u2.username from [user] u inner join tournamentuser tu on tu.UserID = u.UserID 
							inner join [user] u2 on u2.UserID = tu.UserID2
							where tournamentId = @TournamentID  and u.userid = tr.LoseUserID), ''))
 as Lose, dbo.GetName(winner.[UserName],
							isnull((select u2.username from [user] u inner join tournamentuser tu on tu.UserID = u.UserID 
							inner join [user] u2 on u2.UserID = tu.UserID2
							where tournamentId = @TournamentID  and u.userid = tr.WinUserID), ''))
as Win, '0-1' as Result	

from TournamentRound tr
Inner Join dbo.[User] as winner On tr.WinUserID = winner.UserId
Inner Join dbo.[User] as loser On tr.LoseUserID = loser.UserId
where tr.TournamentId = @TournamentID
and tr.StatusID <> 4
---------- Tournament's Rounds Finished ----------
GO
/****** Object:  StoredProcedure [dbo].[GetSchTournamentWantinUsers]    Script Date: 10/14/2010 14:21:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[GetSchTournamentWantinUsers]

@TournamentID int
as

declare @GametypeID int
declare @ChessTypeId int
set @GametypeID = 0
set @ChessTypeId = 0

select @GametypeID = GameTypeID, @ChessTypeId = ChessTypeId from Tournament where tournamentid = @TournamentID

select * from (
select 
u.UserID,
u.UserName,
twu.TournamentID,
u.FirstName,
u.LastName,
isnull(c.Name,'') Country,
isnull(U.CountryID, '')  Flag,
R.Name AS [Rank], 
R.RankID as RankID,
S.Name AS Scocial, 
U.StatusID,
tus.Name TournamentUserStatusName,
twu.TournamentUserStatusID,
Rating = isnull((select elorating 
		from usergametype gt 
		where userid = u.userid 
		and gametypeID = @GametypeID 
		and chessTypeId = @ChessTypeId), 0),

FT.Name AS FIDETitle, IT.Name AS ICCFTitle, 
twu.TournamentWantinUserID TournamentWantinUserID,
twu.ModifiedBy,
twu.DateModified,
@GametypeID GameTypeID, 
@ChessTypeId ChessTypeId,
twu.TeamID,
TeamName = (select TeamName from Team t inner join TournamentTeam tt On tt.TeamID = t.TeamID where tt.TeamID = twu.TeamID and tt.TournamentID = @TournamentID and tt.StatusID <> 4)
from 
TournamentWantinUser twu inner join Tournament t on t.TournamentID = twu.TournamentID
inner join TournamentUserStatus tus on tus.TournamentUserStatusID = twu.TournamentUserStatusID
inner join [User] u on u.userid = twu.userid
INNER JOIN [Rank] R ON U.HumanRankID = R.RankID 
LEFT JOIN FideTitle FT ON U.FideTitleID = FT.FideTitleID 
LEFT JOIN IccfTitle IT ON U.IccfTitleID = IT.IccfTitleID 
LEFT JOIN Social S ON U.SocialID = S.SocialID 
left JOIN Country c on c.CountryID = U.CountryID
where twu.TournamentID = @TournamentID
and twu.StatusID <> 4
) tbl where teamname is not null
GO
/****** Object:  StoredProcedure [dbo].[GetAllTournament]    Script Date: 10/14/2010 14:21:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[GetAllTournament]
@TournamentStatusID int
as
if @TournamentStatusID = 1
	begin
		select * from (
		select 
		RegistrationStartDateTime = convert( datetime, convert(varchar, registrationstartdate, 101) + ' ' +
		convert(varchar, registrationstartTime, 114)),
		RegistrationEndDateTime = convert( datetime, convert(varchar, RegistrationEndDate, 101) + ' ' +
		convert(varchar, RegistrationEndTime, 114)), 
		*,
		TD = (select username from [user] where userid = t.createdby),
		TournamentStatus = (select [Name] from TournamentStatus where TournamentStatusId = t.TournamentStatusId)
		 from tournament t		
		where 
		t.registrationstartdate is not null
		) tbl
		where 
		TournamentStatusID = @TournamentStatusID
		--and 
		--RegistrationEndDateTime >= getdate()
		and statusid = 1
		Order by DateCreated DESC
	end
else
	begin		
		select 
		*,TD = (select username from [user] where userid = t.createdby),
		TournamentStatus = (select [Name] from TournamentStatus where TournamentStatusId = t.TournamentStatusId)

		 from tournament t
		where 
		t.TournamentStatusID = @TournamentStatusID		
		--and t.statusid = @TournamentStatusID
		Order by DateCreated DESC
	end
GO
/****** Object:  StoredProcedure [dbo].[_init]    Script Date: 10/14/2010 14:21:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[_init]
	@Dummy INT
AS
	TRUNCATE TABLE [Log]

	delete from [UserAccessCode]; DBCC CHECKIDENT ([UserAccessCode], RESEED, 0);
	delete from [AccessCode]; DBCC CHECKIDENT ([AccessCode], RESEED, 0);
	delete from [BlockedIPs]; DBCC CHECKIDENT ([BlockedIPs], RESEED, 0);
	delete from [Event]; DBCC CHECKIDENT ([Event], RESEED, 0);	
	delete from [UserFormula]; DBCC CHECKIDENT ([UserFormula], RESEED, 0);
	delete from [OrderDetail]; DBCC CHECKIDENT ([OrderDetail], RESEED, 0);
	delete from [Order]; DBCC CHECKIDENT ([Order], RESEED, 0);
	delete from [Performance]; DBCC CHECKIDENT ([Performance], RESEED, 0);
	delete from [UserVoucher]; DBCC CHECKIDENT ([UserVoucher], RESEED, 0);

	DELETE FROM [UserFini] 
	DBCC CHECKIDENT ([UserFini], RESEED, 0)
	
	delete from [Game] 
	DBCC CHECKIDENT ([Game], RESEED, 0)

	delete from Challenge 
	DBCC CHECKIDENT (Challenge, RESEED, 0)

	delete from TournamentMatch 
	DBCC CHECKIDENT (TournamentMatch, RESEED, 0)

	delete from TournamentWantinUser 
	DBCC CHECKIDENT (TournamentWantinUser, RESEED, 0)

	delete from TournamentUser 
	DBCC CHECKIDENT (TournamentUser, RESEED, 0)
	
	delete from TournamentTeam 
	DBCC CHECKIDENT (TournamentTeam, RESEED, 0)

	delete from Team 
	DBCC CHECKIDENT (Team, RESEED, 0)

	delete from Tournament 
	DBCC CHECKIDENT (Tournament, RESEED, 0)

	delete from UserGameType 
	DBCC CHECKIDENT (UserGameType, RESEED, 0)

	delete from [ServerEventLog] 
	DBCC CHECKIDENT ([ServerEventLog], RESEED, 0)

	delete from [Event] 
	DBCC CHECKIDENT ([Event], RESEED, 0)

	delete from [News] 
	DBCC CHECKIDENT ([News], RESEED, 0)

	delete from [UserAccessCode]
	DBCC CHECKIDENT ([UserAccessCode], RESEED, 0)

	delete from [UserMessage]
	DBCC CHECKIDENT ([UserMessage], RESEED, 0)
	
	delete from [RegisteredUser]
	DBCC CHECKIDENT ([RegisteredUser], RESEED, 0)

	UPDATE [Room] SET TournamentID = NULL, CreatedBy = 1, ModifiedBy = 1

	UPDATE [User] SET EngineID = 1, RoomID = 3, UserStatusID = 4 -- WHERE UserID IN (1,2)
	
	DELETE FROM [Room] WHERE RoomID > 15
	DBCC CHECKIDENT ([Room], RESEED, 15)

	DELETE FROM [Engine] WHERE EngineID > 1
	DBCC CHECKIDENT ([Engine], RESEED, 1)

	UPDATE [User] SET HumanRankID = 1, EngineRankID = 1, CentaurRankID = 1, CorrespondenceRankID = 1
	WHERE UserID > 16

	--DELETE FROM [UserRole] WHERE UserID > 2
	--DBCC CHECKIDENT ([UserRole], RESEED, 2)
	
	--DELETE FROM [User] WHERE UserID > 2
	--DBCC CHECKIDENT ([User], RESEED, 2)

	--UPDATE [User] SET [FirstName]='admin', [UserName]='admin', [Password]='iU/gkPRskOINaz36XOwLDg==' where UserID = 1
GO
/****** Object:  UserDefinedFunction [dbo].[GetRankByUserID]    Script Date: 10/14/2010 14:21:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Arsalan Ata
-- Create date: 01/09/2010
-- Description:	To calculate rank of a user
-- =============================================
CREATE FUNCTION [dbo].[GetRankByUserID] 
(
	-- Add the parameters for the function here
	@TournamentID int,
	@UserID int
)
RETURNS varchar(20)
AS
BEGIN
	
	DECLARE @Result varchar(20)	
	declare @ChessTypeID int
	set @ChessTypeID = 1

	select @ChessTypeID = ChessTypeID from tournament where tournamentid = @TournamentID

	if (@ChessTypeID = 1)
	begin
	select @Result = r.Name from [user] u inner join rank r on u.HumanRankID = r.RankID where UserID = @UserID
	end
	else if (@ChessTypeID = 2)
	begin
	select @Result = r.Name from [user] u inner join rank r on u.HumanRankID = r.RankID where UserID = @UserID
	end
	else if (@ChessTypeID = 3)
	begin
	select @Result = r.Name from [user] u inner join rank r on u.HumanRankID = r.RankID where UserID = @UserID
	end
	else if (@ChessTypeID = 4)
	begin
	select @Result = r.Name from [user] u inner join rank r on u.HumanRankID = r.RankID where UserID = @UserID
	end



	-- Return the result of the function
	RETURN @Result

END
GO
/****** Object:  StoredProcedure [dbo].[UpdateTournamentUserEloBefore]    Script Date: 10/14/2010 14:21:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[UpdateTournamentUserEloBefore]

@TournamentID int,
@UserID int,
@ModifedBy int
AS

declare @GametypeID int
declare @ChessTypeId int
declare @EloBefore int
set @GametypeID = 0
set @ChessTypeId = 0
set @EloBefore = 0


select @GametypeID = GameTypeID, @ChessTypeId = ChessTypeId from Tournament where tournamentid = @TournamentID


select @EloBefore = elorating from usergametype gt where userid = @UserID and gametypeID = @GametypeID and chessTypeId = @ChessTypeId

if isnull(@EloBefore, 0) = 0
begin
set @EloBefore =
	case @ChessTypeId 
		when 1 then 1500
	else
		2200
	end
end

update TournamentUser set EloBefore = @EloBefore, ModifiedBy = @ModifedBy, DateModified = getdate() 
where TournamentID = @TournamentID
and UserID = @UserID
GO
/****** Object:  StoredProcedure [dbo].[UpdateTournamentMatchWithUser]    Script Date: 10/14/2010 14:21:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[UpdateTournamentMatchWithUser]

@TournamentID int,
@UserID int,
@UserID2 int,
@ModifiedBy int,
@QueryType int

AS

Declare @EloBefore int
Select @EloBefore = EloBefore from TournamentUser where TournamentID = @TournamentID and @UserID2 = @UserID2


if @QueryType = 0
	begin

		
		update TournamentMatch Set WhiteUserID = @UserID2, 
				EloWhiteBefore = @EloBefore
				WHERE TournamentID = @TournamentID
				and WhiteUserID = @UserID
				and TournamentMatchStatusID = 1
	end
else if @QueryType = 1
	begin	
		update TournamentMatch Set BlackUserID = @UserID2, 
				EloBlackBefore = @EloBefore
				WHERE TournamentID = @TournamentID
				and BlackUserID = @UserID
				and TournamentMatchStatusID = 1
	end
else
	begin		
		
		DECLARE @GametypeID int
		DECLARE @ChessTypeId int
		DECLARE @EloRating int

		SET @GametypeID = 0
		SET @ChessTypeId = 0
		SET @EloRating = 0

		SELECT @GametypeID = GameTypeID, @ChessTypeId = ChessTypeId from Tournament where TournamentID = @TournamentID

		SELECT @EloRating = EloRating FROM usergametype gt WHERE userid = @UserID2 and GameTypeID = @GametypeID and chessTypeId = @ChessTypeId

		IF ISNULL(@EloRating, 0) = 0
		BEGIN
				if @ChessTypeId = 1	
					begin
						set @EloRating = 1500
					end
				else
					begin
						set @EloRating = 2200
					end
				
		END	

		SET @EloRating = @EloRating

		UPDATE TournamentUser set UserID2 = @UserID2, Elobefore = @EloRating
		WHERE UserID = @UserID AND TournamentID = @TournamentID
		
	end
GO
/****** Object:  StoredProcedure [dbo].[GetAllGamesByTournamentID]    Script Date: 10/14/2010 14:21:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Arsalan Ata
-- Create date: 08-09-2010
-- Description:	Get All Games By Tournament ID
-- =============================================
CREATE PROCEDURE [dbo].[GetAllGamesByTournamentID] 

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
/****** Object:  StoredProcedure [dbo].[GetGameData]    Script Date: 10/14/2010 14:21:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetGameData] 
	@ChallengeID int,
    @OpponentUserID int,
	@opponentChessTypeID int,
	@isNewGame bit
AS
	declare @ChallengerUserID int
	declare @GameTypeID int
	declare @ChessTypeID int
	declare @ColorID int
	declare @TournamentMatchId int
	declare @TournamentId int
	declare @Count int
	declare @ChallengeStatusID int
	declare @StatusID int

	-- 1. Obtain Challenge DataTable
	select @ChallengerUserID=ChallengerUserID, @GameTypeID=GameTypeID,@ChessTypeID = ChessTypeID,
	@TournamentMatchId=TournamentMatchId, @ChallengeStatusID=ChallengeStatusID, @StatusID = StatusID
	from [Challenge] where ChallengeID = @ChallengeID

	Select @TournamentId = TournamentId From TournamentMatch
	Where TournamentMatchId = @TournamentMatchId


	select top 1
	@ColorID = case when @ChallengerUserID = WhiteUserId then 3 else 2 end
	from game
	where (WhiteUserId = @ChallengerUserID or BlackUserId = @ChallengerUserID) and tournamentMatchId is null
	order by GameID desc

	SELECT     ChallengeID, ChallengerUserID, OpponentUserID, TournamentMatchID, RoomID, GameTypeID, ChessTypeID, ChallengeStatusID, 
			   case when ColorID = 1 then isnull(@ColorID,2) else ColorID end as ColorID, 
			   ChallengeTypeID, StatusID, IsRated, WithClock, IsChallengerSendsGame, TimeMin, TimeMax, GainPerMoveMin,  GainPerMoveMax, Description, DateCreated, ModifiedBy, 
			   DateModified, CreatedBy
	FROM       dbo.Challenge
	where	   ChallengeID = @ChallengeID

	--Check if user already in playing or has gone or kibitze game
	SELECT @Count = COUNT(*) FROM [User] WHERE UserID in (@ChallengerUserID, @OpponentUserID) 
	AND UserStatusID NOT IN (2,4) -- Means UserStatus should not be Playing, Gone or Kibitzer
	
	--IF(@ChallengeStatusID = 1 AND @StatusID = 1 AND (@Count > 1 OR @isNewGame = 1 OR @TournamentMatchId IS NOT NULL))
	IF(@isNewGame = 1 OR (@ChallengeStatusID = 1 AND @StatusID = 1 AND (@Count > 1 OR @TournamentMatchId IS NOT NULL)))
	BEGIN
	
		-- 2. Obtain User DataTable
		select * from [User] where UserID in (@ChallengerUserID, @OpponentUserID)
		
		-- 3. Obtain UserGameType DataTable
		SELECT     UserGameTypeID, UserID, GameTypeID, ChessTypeID,'' as Description, NoOfGames, EloRating, StoredMatches, CreatedBy, DateCreated, ModifiedBy, 
				   DateModified
		FROM       dbo.UserGameType 
		where      UserID = @ChallengerUserID AND GameTypeID = @GameTypeID and ChessTypeID=@ChessTypeID
		union
		SELECT     UserGameTypeID, UserID, GameTypeID, ChessTypeID,'' as Description, NoOfGames, EloRating, StoredMatches, CreatedBy, DateCreated, ModifiedBy, 
				   DateModified
		FROM       dbo.UserGameType
		where	   UserID = @OpponentUserID AND GameTypeID = @GameTypeID and ChessTypeID=@opponentChessTypeID

		-- 4. Obtain UserEngine DataTable
		SELECT      dbo.Engine.*
		FROM         dbo.[User] INNER JOIN
						  dbo.Engine ON dbo.[User].EngineID = dbo.Engine.EngineID
		where UserID in (@ChallengerUserID, @OpponentUserID) 



		-- 5. Tournament Match

		Select * from TournamentMatch
		Where TournamentMatchId = @TournamentMatchId


		-- 6. Tournament 

		Select * from Tournament
		Where TournamentId = @TournamentId
	
	END
GO
/****** Object:  StoredProcedure [dbo].[GetGameByChallengeID]    Script Date: 10/14/2010 14:21:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Ubaid
-- Create date: 11-02-2010
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[GetGameByChallengeID] 
	-- Add the parameters for the stored procedure here
	@ChallengeID int,
    @OpponentUserID int
As	

--Data Members
--**********************************************************************************************
declare @ChallengerUserID int
declare @OpponentUserID1 int
declare @TournamentMatchId int
declare @TournamentId int

select @ChallengerUserID=ChallengerUserID, @OpponentUserID1=OpponentUserID from [Challenge] where ChallengeID = @ChallengeID

-- 1. Obtain Challenge DataTable
select 
		  @ChallengeID as ChallengeID
		, @ChallengerUserID as ChallengerUserID
		, @OpponentUserID1 as OpponentUserID

--************************************************************************************************ 
if @OpponentUserID = @ChallengerUserID
	begin 
		select @ChallengerUserID=@OpponentUserID1 
	end

Select  @TournamentMatchId = TournamentMatchId From Game
WHERE ChallengeID=@ChallengeID and (ModifiedBy <> @OpponentUserID or ModifiedBy is null)

Select @TournamentId = TournamentId From TournamentMatch
Where TournamentMatchId = @TournamentMatchId
--************************************************************************************************ 


-- 2. Obtain Game DataTable
SELECT * FROM Game 
WHERE ChallengeID=@ChallengeID and (ModifiedBy <> @OpponentUserID or ModifiedBy is null)

-- 3. Obtain User DataTable
SELECT     UserID, UserName , Password, Email, FirstName, LastName, RoomID, UserStatusID, HumanRankID, EngineRankID, CentaurRankID, 
                      CorrespondenceRankID, CountryID, NearestCityID, DateLastLogin, GenderID, DateOfBirth, EngineID, PersonalNotes, PasswordHint, Url, FideTitleID, 
                      IccfTitleID, SocialID, StatusID, BanStartDate, BanStartTime, BanEndDate, BanEndTime, CreatedBy, DateCreated, ModifiedBy, DateModified, 
                      Internet
FROM         dbo.[User]
where UserID in (@ChallengerUserID, @OpponentUserID)

-- 4. Obtain UserEngine DataTable
SELECT       dbo.Engine.*
FROM         dbo.[User] INNER JOIN
                  dbo.Engine ON dbo.[User].EngineID = dbo.Engine.EngineID
where UserID in (@ChallengerUserID, @OpponentUserID) 


-- 5. Tournament Match

Select * from TournamentMatch
Where TournamentMatchId = @TournamentMatchId


-- 6. Tournament 
Select * from Tournament
Where TournamentId = @TournamentId
GO
/****** Object:  StoredProcedure [dbo].[GetLastInprogressGame]    Script Date: 10/14/2010 14:21:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Ubaid
-- Create date: 11 may
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[GetLastInprogressGame] 
	
	@UserId int 
	
AS
declare @ChallengeID int
declare @WhiteUserId int
declare @BlackUserId int
declare @GameID int
declare @TournamentMatchId int
declare @TournamentId int


Select Top(1) @GameID=GameID,@WhiteUserId= WhiteUserId ,@BlackUserId=BlackUserId ,@TournamentMatchId=TournamentMatchId from Game
Where (WhiteUserId = @UserId or BlackUserId = @UserId) and GameResultId = 1
order by GameId desc

Select @TournamentId = TournamentId From TournamentMatch
Where TournamentMatchId = @TournamentMatchId

SELECT     @ChallengeID = ChallengeID
FROM       Game WHERE GameID=@GameID 
--************************************************************************************************ 

-- 1. Obtain Challenge DataTable
SELECT ChallengeID, ChallengerUserID, OpponentUserID FROM Challenge WHERE ChallengeID = @ChallengeID

-- 2
SELECT * FROM Game 
WHERE GameID=@GameID

-- 3. Obtain User DataTable
SELECT    *
FROM         dbo.[User]
where UserID in (@WhiteUserId, @BlackUserId)

-- 4. Obtain UserEngine DataTable
SELECT       dbo.Engine.*
FROM         dbo.[User] INNER JOIN
                  dbo.Engine ON dbo.[User].EngineID = dbo.Engine.EngineID
where UserID in (@WhiteUserId, @BlackUserId) 


-- 5. Tournament Match
Select * from TournamentMatch
Where TournamentMatchId = @TournamentMatchId


-- 6. Tournament 
Select * from Tournament
Where TournamentId = @TournamentId
GO
/****** Object:  StoredProcedure [dbo].[GetGameByGameID]    Script Date: 10/14/2010 14:21:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Ubaid
-- Create date: 11-02-2010
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[GetGameByGameID] 
	-- Add the parameters for the stored procedure here
	@GameID int
As	

--Data Members
--**********************************************************************************************
declare @ChallengeID int
declare @WhiteUserId int
declare @BlackUserId int
declare @TournamentMatchId int
declare @TournamentId int

Select @WhiteUserId= WhiteUserId ,@BlackUserId=BlackUserId ,@TournamentMatchId=TournamentMatchId 
from Game
Where GameID=@GameID 

Select @TournamentId = TournamentId From TournamentMatch
Where TournamentMatchId = @TournamentMatchId

SELECT     @ChallengeID = ChallengeID
FROM       Game WHERE GameID=@GameID 
--************************************************************************************************ 

-- 1. Obtain Challenge DataTable
SELECT ChallengeID, ChallengerUserID, OpponentUserID FROM Challenge WHERE ChallengeID = @ChallengeID

-- 2
SELECT * FROM Game 
WHERE GameID=@GameID 

-- 3. Obtain User DataTable
SELECT    *
FROM         dbo.[User]
where UserID in (@WhiteUserId, @BlackUserId)

-- 4. Obtain UserEngine DataTable
SELECT       dbo.Engine.*
FROM         dbo.[User] INNER JOIN
                  dbo.Engine ON dbo.[User].EngineID = dbo.Engine.EngineID
where UserID in (@WhiteUserId, @BlackUserId) 


-- 5. Tournament Match

Select * from TournamentMatch
Where TournamentMatchId = @TournamentMatchId


-- 6. Tournament 

Select * from Tournament
Where TournamentId = @TournamentId
GO
/****** Object:  StoredProcedure [dbo].[GetTournamentRegisteredUsers]    Script Date: 10/14/2010 14:21:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[GetTournamentRegisteredUsers] 

@TournamentID int = 0,
@TeamID int = 0

AS
declare @GametypeID int
declare @ChessTypeId int
set @GametypeID = 0
set @ChessTypeId = 0

SELECT @GametypeID = GameTypeID, @ChessTypeId = ChessTypeId FROM Tournament WHERE tournamentid = @TournamentID


select ROW_NUMBER() OVER (ORDER BY Rating DESC) AS 'No', * from (
SELECT 
	U.UserID, 
	U.UserName, 
	US.Name AS [Status],
	
Rating = --isnull((SELECT elorating 
		--FROM usergametype gt 
		--WHERE userid = u.userid 
		--and gametypeID = @GametypeID 
		--and chessTypeId = @ChessTypeId), 0),
		EloBefore,
FT.Name AS FIDETitle, IT.Name AS ICCFTitle, 

tu.TournamentUserID,
tu.TournamentID,
U.FirstName,
U.LastName,
isnull(c.Name,'') Country,
isnull(U.CountryID, '')  Flag,
R.Name AS [Rank], 
S.Name AS Scocial, 
U.StatusID,
tu.StatusID TournamentUserStatusID,
tu.TeamID,
isnull(tu.UserID2, 0) UserID2,
UserName2 = (select UserName from [user] where UserID = tu.UserID2)
FROM [User] U 
inner join TournamentUser tu on tu.userid = u.UserID 
left JOIN UserStatus US ON U.UserStatusID = US.UserStatusID 
INNER JOIN [Status] ST ON U.StatusID = ST.StatusID 
INNER JOIN [Rank] R ON U.HumanRankID = R.RankID 
LEFT JOIN FideTitle FT ON U.FideTitleID = FT.FideTitleID 
LEFT JOIN IccfTitle IT ON U.IccfTitleID = IT.IccfTitleID 
LEFT JOIN Social S ON U.SocialID = S.SocialID 
left JOIN Country c on c.CountryID = U.CountryID
where 
tu.TournamentID = @TournamentID
and (@TeamID = 0 or tu.TeamID = @TeamID)
and isnull(tu.StatusID, 0) <> 4     --' 4 status is for delete
) tbl

--order by Rating desc
GO
/****** Object:  StoredProcedure [dbo].[CreateTournamentRegisterUser]    Script Date: 10/14/2010 14:21:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--[CreateTournamentRegisterUser] 14, 2, 1, 1, '2010-02-20 10:34:00.000'
--select * from tournamentuser

CREATE procedure [dbo].[CreateTournamentRegisterUser]

	@TournamentID int,  
	@UserID int, 
	@StatusID int,	
	@TeamID int,
	@EloBefore int,
	@CreatedBy int, 
	@DateCreated datetime	

as

declare @TournamentUserId int
set @TournamentUserId = 0

select @TournamentUserId = TournamentUserId from TournamentUser 
	where 
		tournamentid = @TournamentID 
		AND 
		UserID = @UserID

declare @GametypeID int
declare @ChessTypeId int
declare @EloRating int

set @GametypeID = 0
set @ChessTypeId = 0
set @EloRating = 0

select @GametypeID = GameTypeID, @ChessTypeId = ChessTypeId from Tournament where tournamentid = @TournamentID

select @EloRating = EloRating from usergametype gt where userid = @UserID and gametypeID = @GametypeID and chessTypeId = @ChessTypeId


if @TeamID = 0
	BEGIN
		SELECT @TeamID = TeamID FROM TournamentWantinUser WHERE UserID = @UserID AND TournamentID = @TournamentID
	END



if isnull(@EloRating, 0) = 0
begin
		if @ChessTypeId = 1	
			begin
				set @EloRating = 1500
			end
		else
			begin
				set @EloRating = 2200
			end
		
end	

set @EloBefore = @EloRating


if @TournamentUserId > 0
begin
	update TournamentUser set 
	TeamID = @TeamID,
	StatusID = @StatusID,
	ModifiedBy = @CreatedBy,
	DateModified = getDate()
	where TournamentUserId = @TournamentUserId
end
else
begin
insert into TournamentUser 
(
	TournamentID, 
	UserID,
	StatusID,
	TeamID,
	EloBefore,
	CreatedBy, 
	DateCreated
) 
values (

	@TournamentID, 
	@UserID,
	@StatusID,	
	@TeamID,
	@EloBefore,
	@CreatedBy, 
	@DateCreated
)
end
GO
/****** Object:  StoredProcedure [dbo].[CreateServerStatistics]    Script Date: 10/14/2010 14:21:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[CreateServerStatistics]

AS

BEGIN 

declare @TotalGames int
declare @Tournaments int
declare @RegisteredUsers int 
declare @Visitors int 
declare @GamePlayed int 
declare @UpTimeDays datetime 
declare @PriviousDay datetime
declare @upTime datetime
declare @Peakuser int
declare @val1  int
declare @val2 nvarchar(50)
  
select  @Peakuser = ServerEventID,@val2 =  description  from servereventlog where servereventlogid = (select max(servereventlogid) from servereventlog)

if @Peakuser = 2 
begin
set  @Peakuser = convert(int ,@val2)
end
else
begin
set @Peakuser = 0
end

select  @upTime = DateCreated
from servereventlog where servereventlogid = (select max(servereventlogid) from servereventlog)

select @TotalGames =  count(*) from game
select @Tournaments = count(*) from tournament
select @RegisteredUsers = count(*) from [user] where humanrankid != 7

select @Visitors = count(*) from [user] 
where datelastlogin between  @upTime and getdate() and humanrankid = 7 

select @GamePlayed = count(*) from game 
where datecreated between @upTime and getdate() 


 
insert into serverstatistics
select serverip,serverport,1.0 
,datediff(day,datecreated,getdate()) 
,getdate() , @Visitors ,@GamePlayed , @Peakuser, @Tournaments,@RegisteredUsers,@TotalGames,1,getdate(),' ' ,' '
FROM servereventlog where servereventlogid = 
(select max(servereventlogid) from servereventlog)


END
GO
/****** Object:  StoredProcedure [dbo].[GetUserInfoByUserID]    Script Date: 10/14/2010 14:21:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ==================================================================
-- Author:		IMRAN HASHMAT
-- Create date: 03/03/2010
-- Description:	SP for Get Games for View Rating of User
-- ==================================================================
CREATE PROCEDURE [dbo].[GetUserInfoByUserID]
	@UserID INT = 0,
	@UserName varchar(50) = ''
AS
BEGIN
	SELECT 
	U.UserID, U.UserName, U.Password, U.Email, U.FirstName, U.LastName, U.RoomID, U.UserStatusID, U.HumanRankID, 
	U.EngineRankID, U.CentaurRankID, U.CorrespondenceRankID, ISNULL(U.CountryID, 244) AS CountryID, U.NearestCityID, 
	U.DateLastLogin, U.GenderID, U.DateOfBirth, U.EngineID, U.PersonalNotes, U.PasswordHint, U.Url, U.FideTitleID, 
	U.IccfTitleID, U.SocialID, 	U.StatusID, U.BanStartDate, U.BanStartTime, U.BanEndDate, U.BanEndTime, U.CreatedBy, 
	U.DateCreated, U.ModifiedBy, U.DateModified, U.Internet,
	R.Name AS Rank, ISNULL(C.Name,'') AS Country, NC.Name AS NearestCity, 
	FT.Name AS FIDETitle, IT.Name AS ICCFTitle FROM [User] U
	INNER JOIN [Rank] R ON R.RankID = U.HumanRankID 
	INNER JOIN [NearestCity] NC ON NC.NearestCityID = U.NearestCityID 
	LEFT JOIN [Country] C ON C.CountryID = U.CountryID 
	LEFT JOIN FideTitle FT ON U.FideTitleID = FT.FideTitleID 
	LEFT JOIN IccfTitle IT ON U.IccfTitleID = IT.IccfTitleID 
	WHERE 
	((@UserId = 0 ) or (U.UserID = @UserId)) and
	((@UserName = '') or (U.UserName = @UserName))
	
END
GO
/****** Object:  StoredProcedure [dbo].[LoginUser]    Script Date: 10/14/2010 14:21:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Ubaid
-- Create date: 23 apr
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[LoginUser] 
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
/****** Object:  StoredProcedure [dbo].[GetUsersByRoomID]    Script Date: 10/14/2010 14:21:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetUsersByRoomID]
	@RoomID int
AS

SELECT U.UserID, U.UserName, US.Name AS [Status], 
(SELECT EloRating FROM UserGameType WHERE ChessTypeID = 1 AND GameTypeID = 1 AND UserID = U.UserID) AS BulletElo,
(SELECT EloRating FROM UserGameType WHERE ChessTypeID = 1 AND GameTypeID = 2 AND UserID = U.UserID) AS BlitzElo,
(SELECT EloRating FROM UserGameType WHERE ChessTypeID = 1 AND GameTypeID = 3 AND UserID = U.UserID) AS RapidElo,
(SELECT EloRating FROM UserGameType WHERE ChessTypeID = 1 AND GameTypeID = 4 AND UserID = U.UserID) AS LongElo,
FT.Name AS FIDETitle, IT.Name AS ICCFTitle, U.CountryID, R.Name AS [Rank], S.Name AS Scocial, 
(SELECT Name FROM Engine WHERE EngineID = U.EngineID) AS Engine
FROM [User] U 
INNER JOIN UserStatus US ON U.UserStatusID = US.UserStatusID 
INNER JOIN [Status] ST ON U.StatusID = ST.StatusID 
INNER JOIN [Rank] R ON U.HumanRankID = R.RankID 
LEFT JOIN FideTitle FT ON U.FideTitleID = FT.FideTitleID 
LEFT JOIN IccfTitle IT ON U.IccfTitleID = IT.IccfTitleID 
LEFT JOIN Social S ON U.SocialID = S.SocialID 
WHERE 
(@RoomId=0 or RoomId=ISNULL(@RoomID,RoomId)) AND
 U.UserStatusID <> 4
ORDER BY DateLastLogin DESC
GO
/****** Object:  StoredProcedure [dbo].[GetTournamentCmbData]    Script Date: 10/14/2010 14:21:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[GetTournamentCmbData]

as

select *from tournamenttype
select * from chesstype
GO
/****** Object:  StoredProcedure [dbo].[GetTopRatingByGameType]    Script Date: 10/14/2010 14:21:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[GetTopRatingByGameType]

@ChessTypeID int,
@GameTypeID int

as

select top 100 ROW_NUMBER() OVER (ORDER BY ugt.elorating desc) RowNumber, * from usergametype ugt inner join [user] u on ugt.userid = u.userid
where ugt.GameTypeID = @GameTypeID and ugt.ChessTypeID = @ChessTypeID
GO
/****** Object:  StoredProcedure [dbo].[GetRankInfo]    Script Date: 10/14/2010 14:21:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[GetRankInfo]

@UserID int

as
declare @RankID int
declare @Rank char(10) 
Declare @NextRank varchar(15)
declare @NoOfGames int
declare @LoginDays int
declare @RequiredGames int 

select @Rank = r.[name],@RankID = humanrankid,
@LoginDays =  datediff(day,u.DateCreated ,getdate())
 from Rank r inner join [user] u on r.rankid = u.humanrankid 
	where u.userid = @UserID and rankid <> 7
select @NextRank = Name from rank where rankid = @RankID+1
select @NoOfGames = noofgames from usergametype where  userid = @UserID and gametypeid = 1 and chesstypeid = 1 

if @NoOfGames is null 
begin
set @NoOfGames = 12
end
else if @NoOfGames < 12
begin
set @NoOfGames = 12- @NoOfGames
end
else if @NoOfGames < 120
begin
set @NoOfGames = 120- @NoOfGames
end
else if @NoOfGames < 1000
begin
set @NoOfGames = 1000- @NoOfGames
end
else if @NoOfGames < 1500
begin
set @NoOfGames = 1500- @NoOfGames
end
else if @NoOfGames < 2000
begin
set @NoOfGames = 2000- @NoOfGames
end
if @RankID  = 6
begin
set @NextRank = 'no next Rank '
end

select @Rank as rank , @NextRank as nextRank, @LoginDays as loginDays, @NoOfGames as requiredGame
GO
/****** Object:  StoredProcedure [dbo].[GetGamesByUserID]    Script Date: 10/14/2010 14:21:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ==================================================================
-- Author:		IMRAN HASHMAT
-- Create date: 03/03/2010
-- Description:	SP for Get Games for View Rating of User
-- ==================================================================
CREATE PROCEDURE [dbo].[GetGamesByUserID]
	@UserID INT
AS
BEGIN

	DECLARE @UserName VARCHAR(50)
	SELECT @UserName = UserName FROM [User] WHERE UserID = @UserID
	
	SELECT 
	G.*, 
	(SELECT UserName FROM [User] WHERE UserID = WhiteUserID) AS WhiteUserName,
	(SELECT UserName FROM [User] WHERE UserID = BlackUserID) AS BlackUserName,
	(SELECT CountryID FROM [User] WHERE UserID = WhiteUserID) AS WhiteUserCountry,
	(SELECT CountryID FROM [User] WHERE UserID = BlackUserID) AS BlackUserCountry,
	
	CASE 
		WHEN WhiteUserID = @UserID THEN 
		ISNULL((SELECT EloRating FROM UserGameType WHERE UserID = @UserID 
		AND GameTypeID = G.GameTypeID AND ChessTypeID = G.WhiteChessTypeID),0)
	ELSE
		ISNULL((SELECT EloRating FROM UserGameType WHERE UserID = @UserID 
		AND GameTypeID = G.GameTypeID AND ChessTypeID = G.BlackChessTypeID),0)
	END AS EloRating,
	
	GR.Display As Name,
		
	CASE WHEN WhiteUserID = @UserID THEN 
		ISNULL((SELECT TOP 1 RowNum FROM (SELECT ROW_NUMBER() 
		OVER(ORDER BY EloRating DESC) RowNum, * FROM UserGameType 
		WHERE ChessTypeID=G.WhiteChessTypeID AND GameTypeID=G.GameTypeID) Tbl WHERE UserID = @UserID),0)
	ELSE
		ISNULL((SELECT TOP 1 RowNum FROM (SELECT ROW_NUMBER() OVER(ORDER BY EloRating DESC) RowNum, * 
		FROM UserGameType 
		WHERE ChessTypeID=G.BlackChessTypeID AND GameTypeID=G.GameTypeID) Tbl WHERE UserID = @UserID),0)
	END AS Position,
			
	CASE WHEN WhiteUserID = @UserID THEN 
		G.WhiteChessTypeID
	ELSE
		G.BlackChessTypeID
	END	AS ChessTypeID,
	
	CASE WHEN WhiteUserID = @UserID THEN 
		(SELECT COUNT (*) FROM UserGameType WHERE 
		ChessTypeID=G.WhiteChessTypeID AND GameTypeID=G.GameTypeID)
	ELSE
		(SELECT COUNT (*) FROM UserGameType WHERE 
		ChessTypeID=G.BlackChessTypeID AND GameTypeID=G.GameTypeID)
	END	AS TotalPlayers,
	
	UserID = @UserID,
	UserName = @UserName
	
	FROM Game G
	INNER JOIN GameResult GR ON G.GameResultID = GR.GameResultID
	WHERE (WhiteUserID = @UserId OR BlackUserID = @UserID)
	AND G.IsRated = 1
	AND (G.GameResultID = 2 OR G.GameResultID = 3 OR G.GameResultID = 4)
	END
GO
/****** Object:  StoredProcedure [dbo].[GetGamesByRoomID]    Script Date: 10/14/2010 14:21:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetGamesByRoomID]
	@RoomID int
AS
	
Select G.GameID, G.GameTypeID, WhiteUserID, 
(SELECT UserName From [User] U WHERE U.UserID = G.WhiteUserID) AS WhiteUserName, G.EloWhiteBefore, 
BlackUserID, (SELECT UserName From [User] U WHERE U.UserID = G.BlackUserID) AS BlackUserName, G.EloBlackBefore, GR.Name AS Result,
(CONVERT(VARCHAR(100), ISNULL(G.TimeMin,0)) + 'm + ' + 	CONVERT(VARCHAR(100),ISNULL(G.GainPerMoveMin,0)) + 's') AS TimeControl,
--ISNULL((CONVERT(VARCHAR(20), G.StartDate, 8)),'') G.StartTime,
CONVERT(VARCHAR, G.StartDate, 8) AS StartTime, 
G.StartDate, G.IsRated FROM Game G INNER JOIN GameResult GR ON G.GameResultID = GR.GameResultID WHERE RoomId=@RoomID
AND G.GameResultID = 1
GO
/****** Object:  StoredProcedure [dbo].[GetHighestRankingPlayerGame]    Script Date: 10/14/2010 14:21:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[GetHighestRankingPlayerGame]
@UserID int
as

declare @EloWhite int
declare @EloBlack int

set @EloWhite = 0
set @EloBlack = 0

select top 1 @EloWhite = max(EloWhiteBefore) from game
where gameresultid = 1
group by EloWhiteBefore
order by EloWhiteBefore desc

select top 1 @EloBlack = max(EloBlackBefore) from game
where gameresultid = 1
group by EloBlackBefore
order by EloBlackBefore desc

if @EloWhite >= @EloBlack
begin
select * from game where gameresultid = 1 and gametypeid = 2 and (EloWhiteBefore = @EloWhite)
and (WhiteUserId <> @UserID and BlackUserId <> @UserID)
end
else
begin
select * from game where (gameresultid = 1 and gametypeid = 2 and EloBlackBefore = @EloBlack)
and (WhiteUserId <> @UserID and BlackUserId <> @UserID)
end
GO
/****** Object:  StoredProcedure [dbo].[GetTournamentUsersByRound]    Script Date: 10/14/2010 14:21:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetTournamentUsersByRound]
	@TournamentID int,
	@Round int
AS
BEGIN

	select tu.* from TournamentUser tu 
		where tu.TournamentId = @TournamentID and tu.UserId in
		(
			select WhiteUserId from TournamentMatch where TournamentId = @TournamentID and Round = @Round and StatusID <> 4
				union
			select BlackUserId from TournamentMatch where TournamentId = @TournamentID and Round = @Round and StatusID <> 4
		) 
		and tu.StatusID <> 4

END
GO
/****** Object:  StoredProcedure [dbo].[AddAccessCode]    Script Date: 10/14/2010 14:21:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Ubaid Lodhi
-- Create date: 21 apr
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[AddAccessCode] 
	-- Add the parameters for the stored procedure here
	@UserID int,
	@Code varchar(150) 
AS

declare @AccessCodeID int
declare @UserAccessCodeID int

Select @AccessCodeID=AccessCodeID from AccessCode where Code = @Code

if(@AccessCodeID is null)
	begin
		insert into AccessCode (Code,IsBlock) values(@Code,'False')
		Select @AccessCodeID=AccessCodeID from AccessCode where Code = @Code
	end

Select @UserAccessCodeID=UserAccessCodeID from UserAccessCode where UserID = @UserID and AccessCodeID = @AccessCodeID
if(@UserAccessCodeID is null)
	begin
		insert into UserAccessCode (UserID,AccessCodeID) values(@UserID,@AccessCodeID)
	end
GO
/****** Object:  StoredProcedure [dbo].[GetAllRoomsWithRelationship]    Script Date: 10/14/2010 14:21:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[GetAllRoomsWithRelationship]
as

select 
	r2.RoomID, 
	r2.parentid ParentID, 
	ParentAndChild = 
		case r2.parentid when r2.parentid then r1.name +' > ' +r2.name
			else r2.name
		end ,
	r2.IsGuestAllow,
	r2.CanTakeBackMove,
	r2.StatusID,Status.Name AS Status
	from 
	(select * from room) r1  
	right join room r2 on r1.roomid = r2.parentid 
	inner JOIN Status ON r2.StatusID = Status.StatusID
	where r2.statusid <> 4
GO
/****** Object:  StoredProcedure [dbo].[GetAllRoomsWithNullTournament]    Script Date: 10/14/2010 14:21:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[GetAllRoomsWithNullTournament]
as

select -1 RoomID, NULL ParentID, NULL TournamentID, '(No Parent Room)' ParentAndChild, 0 IsGuestAllow,0 CanTakeBackMove,0 StatusID
union all
select 
	r2.RoomID, 
	r2.parentid ParentID, r2.TournamentID,
	ParentAndChild = 
		case r2.parentid when r2.parentid then r1.name +' > ' +r2.name
			else r2.name 
		end  ,
	r2.IsGuestAllow,
	r2.CanTakeBackMove,
	r2.StatusID 
	from 
	(select * from room) r1  
	right join room r2 on r1.roomid = r2.parentid 
	where r2.statusid <> 4 and r2.tournamentid is null
Order By ParentAndChild
GO
/****** Object:  UserDefinedFunction [dbo].[GetInternetID]    Script Date: 10/14/2010 14:21:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Ubaid lodhi
-- Create date: 
-- Description:	
-- =============================================
-- Updated by arsalan ata on 14 September 2010

CREATE FUNCTION [dbo].[GetInternetID] 
(
	-- Add the parameters for the function here
	@p1 numeric(9,2),
	@p2 bit
)
RETURNS varchar(50)
AS
BEGIN

DECLARE @Result varchar(50)

if(@p2 = 1)
	begin	
		Select @Result = InternetID from Internet 
			Where @p1 between MinValue and Maxvalue
	end
else
	begin
		Select @Result = [Name] from Internet 
		Where @p1 between MinValue and Maxvalue
	end


RETURN @Result

END
GO
/****** Object:  StoredProcedure [dbo].[UpdateAllChallengesByID]    Script Date: 10/14/2010 14:21:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Ubaid Lodhi
-- Create date: 08-02-2010
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[UpdateAllChallengesByID] 
	-- Add the parameters for the stored procedure here
	@ChallengeID int,
    @CurrentUserID int,
	@ChallengerUserID int

AS

Update challenge 
set 
ChallengeStatusID = 2,
OpponentUserID = @CurrentUserID				
Where ChallengeID = @ChallengeID

Update challenge set 
ChallengeStatusID = 3,
StatusID = 4
Where ChallengeID <> @ChallengeID and ChallengeStatusID = 1 and (ChallengerUserID = @CurrentUserID or OpponentUserId = @CurrentUserID)

Update challenge set 
ChallengeStatusID = 3,
StatusID = 4
Where ChallengeID <> @ChallengeID and ChallengeStatusID = 1 and (ChallengerUserID = @ChallengerUserID or OpponentUserId = @ChallengerUserID)

Update [User]
set UserStatusID = 2
Where UserID in (@CurrentUserID,@ChallengerUserID)
GO
/****** Object:  StoredProcedure [dbo].[GetTournamentMatchByTournamentUserID]    Script Date: 10/14/2010 14:21:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[GetTournamentMatchByTournamentUserID] 

@TournamentID int,
@UserID int

as
declare @UserID2 int
set @UserID2 = 0;
select @UserID2 = UserID2 from tournamentuser where tournamentid = @TournamentID and userid = @UserID

select * from tournamentmatch where tournamentid = @TournamentID and (whiteuserid = @UserID2 or blackuserid = @UserID2) and TournamentMatchStatusID <> 1
GO
/****** Object:  StoredProcedure [dbo].[GetuserMessages]    Script Date: 10/14/2010 14:21:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ============================================== --
-- Author:		IMRAN HASHMAT
-- Create date: 17 MARCH 2010
-- Description:	Get all messages (email) of  user
-- ============================================== --
CREATE PROCEDURE [dbo].[GetuserMessages]
	@UserID int
AS
BEGIN
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
/****** Object:  StoredProcedure [dbo].[GetTournamentMatchByTournamentID]    Script Date: 10/14/2010 14:21:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetTournamentMatchByTournamentID]

@TournamentID int

as

declare @GametypeID int
declare @ChessTypeId int
set @GametypeID = 0
set @ChessTypeId = 0

select @GametypeID = GameTypeID, @ChessTypeId = ChessTypeId from Tournament where tournamentid = @TournamentID


select *,
GameResult = case 				
				when GameResultID = 1 then 'In progress'
				when GameResultID = 2 then '1-0'
				when GameResultID = 3 then '0-1'
				when GameResultID = 6 then '6'
				when GameResultID = 7 then '0-1 (by arbiter decision)'
				when GameResultID = 8 then '1-0 (by arbiter decision)'
				when GameResultID = 4 then '1/2-1/2'
				when GameResultID = 9 then '1-0 (Forced white win)'
				when GameResultID = 10 then '0-1 (Forced black win)'
				when GameResultID = 11 then '1/2-1/2 (Forced draw)'			
				else ''
			end,

InternetW = isnull(dbo.[GetInternetID](UserInternetW,	1), -1),
InternetB = isnull(dbo.[GetInternetID](UserInternetB,	1), -1),

isnull(dbo.GetInternetID(UserInternetW, 0) +' '+convert(varchar,UserInternetW)+'s', -1) as InternetTooltipW,
isnull(dbo.GetInternetID(UserInternetB, 0) +' '+convert(varchar,UserInternetB)+'s' , -1) as InternetTooltipB


from (
select 
	tm.TournamentMatchID,
	tm.TournamentID,
	tm.WhiteUserID,
	tm.BlackUserID,
	tm.MatchStartDate,
	tm.MatchStartTime,
	tm.TournamentMatchStatusID,
	tm.CreatedBy,
	tm.DateCreated,
	tm.Round Round,
	Player1 = (select username from [user] u where u.userid = tm.WhiteUserID),
	Player2 = (select username from [user] u where u.userid = tm.BlackUserID),
	TournamentMatchStatus = 		(select [name] from TournamentMatchStatus tms 
				where tms.TournamentMatchStatusID = tm.TournamentMatchStatusID),
	WRating = isnull((select elorating from usergametype gt where userid = tm.WhiteUserID 
						and gametypeID = @GametypeID and ChessTypeID=@ChessTypeId), 
						(CASE WHEN @ChessTypeId = 1 THEN 1500 ELSE 2200 END)),
	BRating = isnull((select elorating from usergametype gt where userid = tm.BlackUserID 
						and gametypeID = @GametypeID and ChessTypeID=@ChessTypeId),
						(CASE WHEN @ChessTypeId = 1 THEN 1500 ELSE 2200 END)),
	WRank = (select r.name from rank r inner join [user] u on r.rankid = u.humanrankid 
														where u.userid = tm.WhiteUserID),
	BRank = (select r.name from rank r inner join [user] u on r.rankid = u.humanrankid
														where u.userid = tm.BlackUserID),
	t.RoomID,
	RoomName = (select Name from room r where r.roomid = t.RoomID),
	tm.TimeMin as TimeControlMin,
    tm.TimeSec as TimeControlSec,
	--t.TimeControlMin,
    --t.TimeControlSec,

	GameResultID,
--	GameResultID = (select top 1 GameResultID from 
--                      dbo.Game where tm.TournamentMatchID = dbo.Game.TournamentMatchID
--					order by gameid asc	),
	t.TournamentTypeID,	
	isnull(ParentMatchID, 0) ParentMatchID,
	
	UserInternetW = (select internet from [user] where userid = tm.WhiteUserID and UserStatusID <> 4),
	UserInternetB = (select internet from [user] where userid = tm.BlackUserID  and UserStatusID <> 4),
	
	WhiteUserName2 = isnull((select u2.username from [user] u inner join tournamentuser tu on tu.UserID = u.UserID 
						inner join [user] u2 on u2.UserID = tu.UserID2
						where tournamentId = @TournamentID  and u.userid = tm.WhiteUserID), ''),

	BlackUserName2 = isnull((select u2.username from [user] u inner join tournamentuser tu on tu.UserID = u.UserID 
						inner join [user] u2 on u2.UserID = tu.UserID2
						where tournamentId = @TournamentID  and u.userid = tm.BlackUserID), ''),

	TeamW = (select t.teamname from tournamentuser tu inner join team t on t.teamid = tu.teamid where tu.userid = tm.WhiteUserID and tu.TournamentID = tm.TournamentID),
	TeamB = (select t.teamname from tournamentuser tu inner join team t on t.teamid = tu.teamid where tu.userid = tm.BlackUserID and tu.TournamentID = tm.TournamentID)
				
	from TournamentMatch tm 
	inner join Tournament t on t.TournamentID = tm.TournamentID		
		  
where t.tournamentid = @TournamentID
and tm.StatusID not in (3, 4)
) tbl
order by TournamentMatchID
--and tm.ParentMatchID is null
GO
/****** Object:  StoredProcedure [dbo].[ApData]    Script Date: 10/14/2010 14:21:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ========================================================================================== --
-- Author:		IMRAN HASHMAT
-- Create date: 17 MARCH 2010
-- Description:	Get all data for application like users, games room count etc
-- ========================================================================================== --
CREATE PROCEDURE [dbo].[ApData]
	@UserID int,
	@RoomID int
AS
BEGIN
	
Declare @TournamentID int, @TournamentTypeID int, @RoomParentID int
set @TournamentID = 0
set @TournamentTypeID = 0
SET @RoomParentID = 0
	SELECT @RoomParentID = ParentID FROM Room WHERE RoomID = @RoomID
	--Room
	SELECT RoomID, ParentID, Name, ISNULL(TournamentID,0) TournamentID, 
			IsGuestAllow, 
			CanTakeBackMove, ISNULL(Description,'') Description, ISNULL(Html,'') Html ,
			ISNULL(IsUrlBit,0 ) IsUrlBit, StatusID
			, CreatedBy, DateCreated, ModifiedBy, DateModified 
			
	FROM [Room] 
			WHERE RoomID=@RoomID
	
	--Room Users
	IF(@RoomID = 8 OR @RoomID = 9 OR @RoomID = 10 OR @RoomID = 11 OR @RoomID = 12 OR @RoomParentID = 12)
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
		U.UserStatusID, U.IsPause, U.IsIdle,
		
		TeamName = isnull((select top 1 t.teamname from tournamentuser tu inner join team t on t.teamid = tu.teamid 
								where tu.UserID = U.UserID and tu.TournamentID = @TournamentID), ''),
		isnull(@TournamentID, 0) TournamentID, isnull(@TournamentTypeID, 0) TournamentTypeID


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

		
		select @TournamentID = TournamentID, @TournamentTypeID = TournamentTypeID from tournament where RoomID = @RoomID
		and TournamentTypeID = 4 and TournamentStatusID <> 3

		SELECT U.UserID,UserName, US.Name AS [Status], 
		(SELECT EloRating FROM UserGameType WHERE ChessTypeID = 1 AND GameTypeID = 1 AND UserID = U.UserID) AS BulletElo,
		(SELECT EloRating FROM UserGameType WHERE ChessTypeID = 1 AND GameTypeID = 2 AND UserID = U.UserID) AS BlitzElo,
		(SELECT EloRating FROM UserGameType WHERE ChessTypeID = 1 AND GameTypeID = 3 AND UserID = U.UserID) AS RapidElo,
		(SELECT EloRating FROM UserGameType WHERE ChessTypeID = 1 AND GameTypeID = 4 AND UserID = U.UserID) AS LongElo,
		FT.Name AS FIDETitle, IT.Name AS ICCFTitle, U.CountryID, R.Name AS [Rank], S.Name AS Scocial, 
		(SELECT Name FROM Engine WHERE EngineID = U.EngineID) AS Engine,
		(SELECT MAX(GameID) FROM Game WHERE GameResultID = 1 AND RoomID = @RoomID AND(WhiteUserID = U.UserID OR BlackUserID = U.UserID)) AS GameID,
		dbo.GetInternetID(U.Internet,1)as Internet,dbo.GetInternetID(U.Internet,0)+' '+convert(varchar,U.Internet)+'s' as InternetTooltip, CT.Name CountryName,
		U.UserStatusID, U.IsPause, U.IsIdle,
		
		TeamName = isnull((select top 1 t.teamname from tournamentuser tu inner join team t on t.teamid = tu.teamid 
								where tu.UserID = U.UserID and tu.TournamentID = @TournamentID), ''),
		isnull(@TournamentID, 0) TournamentID, isnull(@TournamentTypeID, 0) TournamentTypeID


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

-- Get Tournament Rooms
select RoomID, isnull(ParentID, -1) ParentID, Name, isnull(TournamentID, -1) TournamentID, StatusID, Description, Html from room 
where ParentID IN (7, 12)
 AND StatusID = 1
GO
/****** Object:  StoredProcedure [dbo].[GetChallengesByRoomID]    Script Date: 10/14/2010 14:21:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetChallengesByRoomID]
	@RoomID int,
	@UserID int
AS
BEGIN
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

END
GO
