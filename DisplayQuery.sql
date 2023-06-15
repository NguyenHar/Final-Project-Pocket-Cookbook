/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) [primary_key_id]
      ,[id]
      ,[offset]
      ,[number]
      ,[totalResults]
  FROM [Cookbook].[dbo].[Meals]

/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) [primary_key_id]
      ,[id]
      ,[title]
      ,[image]
      ,[imageType]
      ,[Meal]
  FROM [Cookbook].[dbo].[Results]

