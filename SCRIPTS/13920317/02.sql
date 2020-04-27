USE [andicator];
GO
SET ANSI_NULLS ON;
GO
SET QUOTED_IDENTIFIER ON;
GO
ALTER TABLE [dbo].[LETTERITEMSPERMISSION] ADD [SEPERATE_CHANING] tinyint NULL
GO

SELECT     LETTERSUBJECT, INPUTREGISTERNUMBER, SUMMARY, INSURANCETYPEID, INSURANCENUMBER, INSURANCEDATE, LETTERSTATEID, 
                      COMPANYID, REFERENCEUSERID, RECIEVEDLETTERNUMBER, RECIEVEDLETTERDATE, ARCHIVE, FINALCONFIRM, USERID, BTNSEARCH, 
                      BTNLETTERSTATE, BTNUSERSREPLIES, ID, REFERTOMASTER, SHOWREFFRENCES, ALARMSTARTDATE, BTN_AGENT, BTN_DELETE, FASTACTION, 
                      DO_CHANING_TO_RECIEVE, DO_CHANING_TO_SEND,SEPERATE_CHANING 
FROM         dbo.LETTERITEMSPERMISSION