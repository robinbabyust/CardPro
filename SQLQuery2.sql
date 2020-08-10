USE [DbCardPro]
GO

INSERT INTO [dbo].[Bank]
           ([Name],[Country])
     VALUES ('Barclays' ,'United Kingdom')

	 INSERT INTO [dbo].[Bank]
           ([Name],[Country])
     VALUES ('HSBCs' ,'United Kingdom')

	 INSERT INTO [dbo].[Bank]
           ([Name],[Country])
     VALUES ('Lloyds' ,'United Kingdom')

	 INSERT INTO [dbo].[Bank]
           ([Name],[Country])
     VALUES ('Vanquis' ,'United Kingdom')


	 
INSERT INTO [dbo].[CardType]
           ([BankId] ,[Name] ,[Category] ,[CreditLimit] ,[CashLimit] ,[Image])
     VALUES
           (1,'Barclay arrival plus' ,'Barclaycard',10000,7000,'https://storyv.com/wp-content/uploads/2018/11/barclaycard-us-credit-card.jpg')
INSERT INTO [dbo].[CardType]
           ([BankId] ,[Name] ,[Category] ,[CreditLimit] ,[CashLimit] ,[Image])
     VALUES
           (4,'Vanquis luma' ,'Vanquiscard',5000,2000,'https://ddialhyn49dxu.cloudfront.net/cards/vanquis-purple-large.png')

INSERT INTO [dbo].[Criteria]
           ([CardTypeId] ,[MinimumIncome] ,[MinimumAge])
     VALUES
           (1 ,30000, 18)

INSERT INTO [dbo].[Criteria]
           ([CardTypeId] ,[MinimumIncome] ,[MinimumAge])
     VALUES
           (2 ,1, 18)
GO


