USE [PR_r0696944]
GO
/****** Object:  Schema [MyWeight]    Script Date: 05-Jan-21 19:09:08 ******/
CREATE SCHEMA [MyWeight]
GO
/****** Object:  Table [MyWeight].[Diary]    Script Date: 05-Jan-21 19:09:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [MyWeight].[Diary](
	[DiaryID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[Date] [datetime] NOT NULL,
 CONSTRAINT [PK_MyWeight.Diary] PRIMARY KEY CLUSTERED 
(
	[DiaryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [MyWeight].[DiaryTimeStamp]    Script Date: 05-Jan-21 19:09:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [MyWeight].[DiaryTimeStamp](
	[DiaryTimeStampID] [int] IDENTITY(1,1) NOT NULL,
	[DiaryID] [int] NOT NULL,
	[TimeStampID] [int] NOT NULL,
 CONSTRAINT [PK_MyWeight.DiaryTimeStamp] PRIMARY KEY CLUSTERED 
(
	[DiaryTimeStampID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [MyWeight].[DiaryTimeStampMeal]    Script Date: 05-Jan-21 19:09:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [MyWeight].[DiaryTimeStampMeal](
	[DiaryTimeStampMealID] [int] IDENTITY(1,1) NOT NULL,
	[DiaryTimeStampID] [int] NOT NULL,
	[MealID] [int] NOT NULL,
 CONSTRAINT [PK_MyWeight.DiaryTimeStampMeal] PRIMARY KEY CLUSTERED 
(
	[DiaryTimeStampMealID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [MyWeight].[Ingredient]    Script Date: 05-Jan-21 19:09:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [MyWeight].[Ingredient](
	[IngredientID] [int] IDENTITY(1,1) NOT NULL,
	[NutritionFactID] [int] NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[Brand] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_MyWeight.Ingredient] PRIMARY KEY CLUSTERED 
(
	[IngredientID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [MyWeight].[Meal]    Script Date: 05-Jan-21 19:09:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [MyWeight].[Meal](
	[MealID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_MyWeight.Meal] PRIMARY KEY CLUSTERED 
(
	[MealID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [MyWeight].[MealIngredient]    Script Date: 05-Jan-21 19:09:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [MyWeight].[MealIngredient](
	[MealIngredientID] [int] IDENTITY(1,1) NOT NULL,
	[MealID] [int] NOT NULL,
	[IngredientID] [int] NOT NULL,
 CONSTRAINT [PK_MyWeight.MealIngredient] PRIMARY KEY CLUSTERED 
(
	[MealIngredientID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [MyWeight].[MealRecipe]    Script Date: 05-Jan-21 19:09:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [MyWeight].[MealRecipe](
	[MealRecipeID] [int] IDENTITY(1,1) NOT NULL,
	[RecipeID] [int] NOT NULL,
	[MealID] [int] NOT NULL,
 CONSTRAINT [PK_MyWeight.MealRecipe] PRIMARY KEY CLUSTERED 
(
	[MealRecipeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [MyWeight].[NutritionFact]    Script Date: 05-Jan-21 19:09:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [MyWeight].[NutritionFact](
	[NutritionFactID] [int] IDENTITY(1,1) NOT NULL,
	[Unit] [nvarchar](20) NOT NULL,
	[Calories] [decimal](18, 2) NOT NULL,
	[Fat] [decimal](18, 2) NOT NULL,
	[Carbohydrates] [decimal](18, 2) NOT NULL,
	[Protein] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_MyWeight.NutritionFact] PRIMARY KEY CLUSTERED 
(
	[NutritionFactID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [MyWeight].[Recipe]    Script Date: 05-Jan-21 19:09:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [MyWeight].[Recipe](
	[RecipeID] [int] IDENTITY(1,1) NOT NULL,
	[RecipeCategoryID] [int] NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[Description] [nvarchar](255) NOT NULL,
	[Servings] [int] NOT NULL,
	[PrepTime] [int] NOT NULL,
	[CookTime] [int] NOT NULL,
 CONSTRAINT [PK_MyWeight.Recipe] PRIMARY KEY CLUSTERED 
(
	[RecipeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [MyWeight].[RecipeCategory]    Script Date: 05-Jan-21 19:09:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [MyWeight].[RecipeCategory](
	[RecipeCategoryID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_MyWeight.RecipeCategory] PRIMARY KEY CLUSTERED 
(
	[RecipeCategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [MyWeight].[RecipeDirections]    Script Date: 05-Jan-21 19:09:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [MyWeight].[RecipeDirections](
	[RecipeDirectionsID] [int] IDENTITY(1,1) NOT NULL,
	[RecipeID] [int] NOT NULL,
	[Description] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_MyWeight.RecipeDirections] PRIMARY KEY CLUSTERED 
(
	[RecipeDirectionsID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [MyWeight].[RecipeIngredient]    Script Date: 05-Jan-21 19:09:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [MyWeight].[RecipeIngredient](
	[RecipeIngredientID] [int] IDENTITY(1,1) NOT NULL,
	[RecipeID] [int] NOT NULL,
	[IngredientID] [int] NOT NULL,
	[Amount] [decimal](18, 2) NOT NULL,
	[Unit] [nvarchar](20) NULL,
 CONSTRAINT [PK_MyWeight.RecipeIngredient] PRIMARY KEY CLUSTERED 
(
	[RecipeIngredientID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [MyWeight].[Timestamp]    Script Date: 05-Jan-21 19:09:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [MyWeight].[Timestamp](
	[TimeStampID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](40) NOT NULL,
 CONSTRAINT [PK_MyWeight.Timestamp] PRIMARY KEY CLUSTERED 
(
	[TimeStampID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [MyWeight].[User]    Script Date: 05-Jan-21 19:09:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [MyWeight].[User](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](20) NOT NULL,
	[Password] [nvarchar](255) NOT NULL,
	[Weight] [decimal](18, 2) NOT NULL,
	[CurrentWeight] [decimal](18, 2) NOT NULL,
	[WantedWeight] [decimal](18, 2) NOT NULL,
	[CaloriesDayGoal] [int] NOT NULL,
 CONSTRAINT [PK_MyWeight.User] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [MyWeight].[Diary] ON 

INSERT [MyWeight].[Diary] ([DiaryID], [UserID], [Date]) VALUES (16, 1, CAST(N'2021-01-04T00:00:00.000' AS DateTime))
INSERT [MyWeight].[Diary] ([DiaryID], [UserID], [Date]) VALUES (17, 1, CAST(N'2021-01-03T00:00:00.000' AS DateTime))
INSERT [MyWeight].[Diary] ([DiaryID], [UserID], [Date]) VALUES (18, 1, CAST(N'2021-01-05T00:00:00.000' AS DateTime))
INSERT [MyWeight].[Diary] ([DiaryID], [UserID], [Date]) VALUES (19, 1, CAST(N'2020-12-31T00:00:00.000' AS DateTime))
INSERT [MyWeight].[Diary] ([DiaryID], [UserID], [Date]) VALUES (20, 1, CAST(N'2021-01-02T00:00:00.000' AS DateTime))
INSERT [MyWeight].[Diary] ([DiaryID], [UserID], [Date]) VALUES (21, 1, CAST(N'2021-01-01T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [MyWeight].[Diary] OFF
GO
SET IDENTITY_INSERT [MyWeight].[DiaryTimeStamp] ON 

INSERT [MyWeight].[DiaryTimeStamp] ([DiaryTimeStampID], [DiaryID], [TimeStampID]) VALUES (13, 16, 1)
INSERT [MyWeight].[DiaryTimeStamp] ([DiaryTimeStampID], [DiaryID], [TimeStampID]) VALUES (14, 16, 2)
INSERT [MyWeight].[DiaryTimeStamp] ([DiaryTimeStampID], [DiaryID], [TimeStampID]) VALUES (15, 16, 3)
INSERT [MyWeight].[DiaryTimeStamp] ([DiaryTimeStampID], [DiaryID], [TimeStampID]) VALUES (16, 16, 4)
INSERT [MyWeight].[DiaryTimeStamp] ([DiaryTimeStampID], [DiaryID], [TimeStampID]) VALUES (17, 17, 1)
INSERT [MyWeight].[DiaryTimeStamp] ([DiaryTimeStampID], [DiaryID], [TimeStampID]) VALUES (18, 17, 2)
INSERT [MyWeight].[DiaryTimeStamp] ([DiaryTimeStampID], [DiaryID], [TimeStampID]) VALUES (19, 17, 3)
INSERT [MyWeight].[DiaryTimeStamp] ([DiaryTimeStampID], [DiaryID], [TimeStampID]) VALUES (20, 17, 4)
INSERT [MyWeight].[DiaryTimeStamp] ([DiaryTimeStampID], [DiaryID], [TimeStampID]) VALUES (21, 18, 1)
INSERT [MyWeight].[DiaryTimeStamp] ([DiaryTimeStampID], [DiaryID], [TimeStampID]) VALUES (22, 18, 2)
INSERT [MyWeight].[DiaryTimeStamp] ([DiaryTimeStampID], [DiaryID], [TimeStampID]) VALUES (23, 18, 3)
INSERT [MyWeight].[DiaryTimeStamp] ([DiaryTimeStampID], [DiaryID], [TimeStampID]) VALUES (24, 18, 4)
INSERT [MyWeight].[DiaryTimeStamp] ([DiaryTimeStampID], [DiaryID], [TimeStampID]) VALUES (25, 19, 1)
INSERT [MyWeight].[DiaryTimeStamp] ([DiaryTimeStampID], [DiaryID], [TimeStampID]) VALUES (26, 19, 2)
INSERT [MyWeight].[DiaryTimeStamp] ([DiaryTimeStampID], [DiaryID], [TimeStampID]) VALUES (27, 19, 3)
INSERT [MyWeight].[DiaryTimeStamp] ([DiaryTimeStampID], [DiaryID], [TimeStampID]) VALUES (28, 19, 4)
INSERT [MyWeight].[DiaryTimeStamp] ([DiaryTimeStampID], [DiaryID], [TimeStampID]) VALUES (29, 20, 1)
INSERT [MyWeight].[DiaryTimeStamp] ([DiaryTimeStampID], [DiaryID], [TimeStampID]) VALUES (30, 20, 2)
INSERT [MyWeight].[DiaryTimeStamp] ([DiaryTimeStampID], [DiaryID], [TimeStampID]) VALUES (31, 20, 3)
INSERT [MyWeight].[DiaryTimeStamp] ([DiaryTimeStampID], [DiaryID], [TimeStampID]) VALUES (32, 20, 4)
INSERT [MyWeight].[DiaryTimeStamp] ([DiaryTimeStampID], [DiaryID], [TimeStampID]) VALUES (33, 21, 1)
INSERT [MyWeight].[DiaryTimeStamp] ([DiaryTimeStampID], [DiaryID], [TimeStampID]) VALUES (34, 21, 2)
INSERT [MyWeight].[DiaryTimeStamp] ([DiaryTimeStampID], [DiaryID], [TimeStampID]) VALUES (35, 21, 3)
INSERT [MyWeight].[DiaryTimeStamp] ([DiaryTimeStampID], [DiaryID], [TimeStampID]) VALUES (36, 21, 4)
SET IDENTITY_INSERT [MyWeight].[DiaryTimeStamp] OFF
GO
SET IDENTITY_INSERT [MyWeight].[DiaryTimeStampMeal] ON 

INSERT [MyWeight].[DiaryTimeStampMeal] ([DiaryTimeStampMealID], [DiaryTimeStampID], [MealID]) VALUES (11, 24, 11)
INSERT [MyWeight].[DiaryTimeStampMeal] ([DiaryTimeStampMealID], [DiaryTimeStampID], [MealID]) VALUES (12, 22, 12)
INSERT [MyWeight].[DiaryTimeStampMeal] ([DiaryTimeStampMealID], [DiaryTimeStampID], [MealID]) VALUES (13, 22, 13)
INSERT [MyWeight].[DiaryTimeStampMeal] ([DiaryTimeStampMealID], [DiaryTimeStampID], [MealID]) VALUES (14, 22, 14)
SET IDENTITY_INSERT [MyWeight].[DiaryTimeStampMeal] OFF
GO
SET IDENTITY_INSERT [MyWeight].[Ingredient] ON 

INSERT [MyWeight].[Ingredient] ([IngredientID], [NutritionFactID], [Name], [Brand]) VALUES (1, 1, N'Apple', N'Anonim')
INSERT [MyWeight].[Ingredient] ([IngredientID], [NutritionFactID], [Name], [Brand]) VALUES (2, 2, N'Volle Room', N'Melro')
INSERT [MyWeight].[Ingredient] ([IngredientID], [NutritionFactID], [Name], [Brand]) VALUES (4, 4, N'Ei', N'/')
INSERT [MyWeight].[Ingredient] ([IngredientID], [NutritionFactID], [Name], [Brand]) VALUES (5, 5, N'Halfvolle Melk', N'Inza')
INSERT [MyWeight].[Ingredient] ([IngredientID], [NutritionFactID], [Name], [Brand]) VALUES (6, 6, N'Zelfrijzende Bloem', N'Anco')
INSERT [MyWeight].[Ingredient] ([IngredientID], [NutritionFactID], [Name], [Brand]) VALUES (7, 7, N'Tomatenstukjes met Basilicum', N'Benito')
INSERT [MyWeight].[Ingredient] ([IngredientID], [NutritionFactID], [Name], [Brand]) VALUES (8, 8, N'Red Sweet Pepper', N'/')
INSERT [MyWeight].[Ingredient] ([IngredientID], [NutritionFactID], [Name], [Brand]) VALUES (9, 9, N'Ground Beef (Cooked)', N'/')
INSERT [MyWeight].[Ingredient] ([IngredientID], [NutritionFactID], [Name], [Brand]) VALUES (10, 10, N'Garlic', N'/')
INSERT [MyWeight].[Ingredient] ([IngredientID], [NutritionFactID], [Name], [Brand]) VALUES (11, 11, N'Onion', N'/')
INSERT [MyWeight].[Ingredient] ([IngredientID], [NutritionFactID], [Name], [Brand]) VALUES (12, 12, N'Super Chips Naturel', N'Lay''s')
INSERT [MyWeight].[Ingredient] ([IngredientID], [NutritionFactID], [Name], [Brand]) VALUES (14, 14, N'Yoghurt', N'Danone')
SET IDENTITY_INSERT [MyWeight].[Ingredient] OFF
GO
SET IDENTITY_INSERT [MyWeight].[Meal] ON 

INSERT [MyWeight].[Meal] ([MealID], [Name]) VALUES (11, N'Super Chips Naturel')
INSERT [MyWeight].[Meal] ([MealID], [Name]) VALUES (12, N'Ei')
INSERT [MyWeight].[Meal] ([MealID], [Name]) VALUES (13, N'Apple')
INSERT [MyWeight].[Meal] ([MealID], [Name]) VALUES (14, N'Yoghurt')
SET IDENTITY_INSERT [MyWeight].[Meal] OFF
GO
SET IDENTITY_INSERT [MyWeight].[MealIngredient] ON 

INSERT [MyWeight].[MealIngredient] ([MealIngredientID], [MealID], [IngredientID]) VALUES (4, 11, 12)
INSERT [MyWeight].[MealIngredient] ([MealIngredientID], [MealID], [IngredientID]) VALUES (5, 12, 4)
INSERT [MyWeight].[MealIngredient] ([MealIngredientID], [MealID], [IngredientID]) VALUES (6, 13, 1)
INSERT [MyWeight].[MealIngredient] ([MealIngredientID], [MealID], [IngredientID]) VALUES (7, 14, 14)
SET IDENTITY_INSERT [MyWeight].[MealIngredient] OFF
GO
SET IDENTITY_INSERT [MyWeight].[NutritionFact] ON 

INSERT [MyWeight].[NutritionFact] ([NutritionFactID], [Unit], [Calories], [Fat], [Carbohydrates], [Protein]) VALUES (1, N'Medium', CAST(72000.00 AS Decimal(18, 2)), CAST(0.23 AS Decimal(18, 2)), CAST(19.06 AS Decimal(18, 2)), CAST(0.36 AS Decimal(18, 2)))
INSERT [MyWeight].[NutritionFact] ([NutritionFactID], [Unit], [Calories], [Fat], [Carbohydrates], [Protein]) VALUES (2, N'100 mililiter(ml)', CAST(335000.00 AS Decimal(18, 2)), CAST(35.00 AS Decimal(18, 2)), CAST(3.10 AS Decimal(18, 2)), CAST(2.20 AS Decimal(18, 2)))
INSERT [MyWeight].[NutritionFact] ([NutritionFactID], [Unit], [Calories], [Fat], [Carbohydrates], [Protein]) VALUES (3, N'100 grams(g)', CAST(1.00 AS Decimal(18, 2)), CAST(1.00 AS Decimal(18, 2)), CAST(1.00 AS Decimal(18, 2)), CAST(1.00 AS Decimal(18, 2)))
INSERT [MyWeight].[NutritionFact] ([NutritionFactID], [Unit], [Calories], [Fat], [Carbohydrates], [Protein]) VALUES (4, N'1 Large', CAST(74000.00 AS Decimal(18, 2)), CAST(4.97 AS Decimal(18, 2)), CAST(0.38 AS Decimal(18, 2)), CAST(6.29 AS Decimal(18, 2)))
INSERT [MyWeight].[NutritionFact] ([NutritionFactID], [Unit], [Calories], [Fat], [Carbohydrates], [Protein]) VALUES (5, N'100 mililiter(ml)', CAST(65000.00 AS Decimal(18, 2)), CAST(3.60 AS Decimal(18, 2)), CAST(4.90 AS Decimal(18, 2)), CAST(3.20 AS Decimal(18, 2)))
INSERT [MyWeight].[NutritionFact] ([NutritionFactID], [Unit], [Calories], [Fat], [Carbohydrates], [Protein]) VALUES (6, N'100 grams(g)', CAST(340000.00 AS Decimal(18, 2)), CAST(1.10 AS Decimal(18, 2)), CAST(70.00 AS Decimal(18, 2)), CAST(10.00 AS Decimal(18, 2)))
INSERT [MyWeight].[NutritionFact] ([NutritionFactID], [Unit], [Calories], [Fat], [Carbohydrates], [Protein]) VALUES (7, N'200 g', CAST(46000.00 AS Decimal(18, 2)), CAST(0.20 AS Decimal(18, 2)), CAST(9.60 AS Decimal(18, 2)), CAST(2.00 AS Decimal(18, 2)))
INSERT [MyWeight].[NutritionFact] ([NutritionFactID], [Unit], [Calories], [Fat], [Carbohydrates], [Protein]) VALUES (8, N'2 medium', CAST(62000.00 AS Decimal(18, 2)), CAST(0.71 AS Decimal(18, 2)), CAST(14.35 AS Decimal(18, 2)), CAST(2.36 AS Decimal(18, 2)))
INSERT [MyWeight].[NutritionFact] ([NutritionFactID], [Unit], [Calories], [Fat], [Carbohydrates], [Protein]) VALUES (9, N'300 g', CAST(828000.00 AS Decimal(18, 2)), CAST(55.74 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(76.05 AS Decimal(18, 2)))
INSERT [MyWeight].[NutritionFact] ([NutritionFactID], [Unit], [Calories], [Fat], [Carbohydrates], [Protein]) VALUES (10, N'3 cloves', CAST(13000.00 AS Decimal(18, 2)), CAST(0.04 AS Decimal(18, 2)), CAST(2.98 AS Decimal(18, 2)), CAST(0.57 AS Decimal(18, 2)))
INSERT [MyWeight].[NutritionFact] ([NutritionFactID], [Unit], [Calories], [Fat], [Carbohydrates], [Protein]) VALUES (11, N'1 Medium', CAST(46000.00 AS Decimal(18, 2)), CAST(0.09 AS Decimal(18, 2)), CAST(11.12 AS Decimal(18, 2)), CAST(1.01 AS Decimal(18, 2)))
INSERT [MyWeight].[NutritionFact] ([NutritionFactID], [Unit], [Calories], [Fat], [Carbohydrates], [Protein]) VALUES (12, N'100 grams(g)', CAST(542000.00 AS Decimal(18, 2)), CAST(34.00 AS Decimal(18, 2)), CAST(52.00 AS Decimal(18, 2)), CAST(5.70 AS Decimal(18, 2)))
INSERT [MyWeight].[NutritionFact] ([NutritionFactID], [Unit], [Calories], [Fat], [Carbohydrates], [Protein]) VALUES (13, N'Medium', CAST(72000.00 AS Decimal(18, 2)), CAST(0.23 AS Decimal(18, 2)), CAST(19.06 AS Decimal(18, 2)), CAST(0.36 AS Decimal(18, 2)))
INSERT [MyWeight].[NutritionFact] ([NutritionFactID], [Unit], [Calories], [Fat], [Carbohydrates], [Protein]) VALUES (14, N'1 potje', CAST(84000.00 AS Decimal(18, 2)), CAST(1.30 AS Decimal(18, 2)), CAST(14.00 AS Decimal(18, 2)), CAST(4.30 AS Decimal(18, 2)))
SET IDENTITY_INSERT [MyWeight].[NutritionFact] OFF
GO
SET IDENTITY_INSERT [MyWeight].[Recipe] ON 

INSERT [MyWeight].[Recipe] ([RecipeID], [RecipeCategoryID], [Name], [Description], [Servings], [PrepTime], [CookTime]) VALUES (11, 7, N'Spaghettisaus', N'Simpele spaghettisaus', 6, 15, 30)
SET IDENTITY_INSERT [MyWeight].[Recipe] OFF
GO
SET IDENTITY_INSERT [MyWeight].[RecipeCategory] ON 

INSERT [MyWeight].[RecipeCategory] ([RecipeCategoryID], [Name]) VALUES (1, N'Appetizers')
INSERT [MyWeight].[RecipeCategory] ([RecipeCategoryID], [Name]) VALUES (2, N'Soups')
INSERT [MyWeight].[RecipeCategory] ([RecipeCategoryID], [Name]) VALUES (3, N'Main Dishes')
INSERT [MyWeight].[RecipeCategory] ([RecipeCategoryID], [Name]) VALUES (4, N'Side Dishes')
INSERT [MyWeight].[RecipeCategory] ([RecipeCategoryID], [Name]) VALUES (5, N'Breads & Baked Products')
INSERT [MyWeight].[RecipeCategory] ([RecipeCategoryID], [Name]) VALUES (6, N'Salads and Salad Dressings')
INSERT [MyWeight].[RecipeCategory] ([RecipeCategoryID], [Name]) VALUES (7, N'Sauces and Condiments')
INSERT [MyWeight].[RecipeCategory] ([RecipeCategoryID], [Name]) VALUES (8, N'Desserts')
INSERT [MyWeight].[RecipeCategory] ([RecipeCategoryID], [Name]) VALUES (9, N'Snacks')
INSERT [MyWeight].[RecipeCategory] ([RecipeCategoryID], [Name]) VALUES (10, N'Beverages')
INSERT [MyWeight].[RecipeCategory] ([RecipeCategoryID], [Name]) VALUES (11, N'Other')
INSERT [MyWeight].[RecipeCategory] ([RecipeCategoryID], [Name]) VALUES (12, N'Breakfast')
INSERT [MyWeight].[RecipeCategory] ([RecipeCategoryID], [Name]) VALUES (13, N'Lunch')
INSERT [MyWeight].[RecipeCategory] ([RecipeCategoryID], [Name]) VALUES (14, N'Dinner')
SET IDENTITY_INSERT [MyWeight].[RecipeCategory] OFF
GO
SET IDENTITY_INSERT [MyWeight].[RecipeDirections] ON 

INSERT [MyWeight].[RecipeDirections] ([RecipeDirectionsID], [RecipeID], [Description]) VALUES (4, 11, N'Groenten snijden')
INSERT [MyWeight].[RecipeDirections] ([RecipeDirectionsID], [RecipeID], [Description]) VALUES (5, 11, N'Olie in een diepe pan verwarmen')
INSERT [MyWeight].[RecipeDirections] ([RecipeDirectionsID], [RecipeID], [Description]) VALUES (6, 11, N'Groentjes fruiten in de hete olie')
INSERT [MyWeight].[RecipeDirections] ([RecipeDirectionsID], [RecipeID], [Description]) VALUES (7, 11, N'Rundergehakt meebakken')
INSERT [MyWeight].[RecipeDirections] ([RecipeDirectionsID], [RecipeID], [Description]) VALUES (8, 11, N'Tomaten met basilicum toevoegen')
INSERT [MyWeight].[RecipeDirections] ([RecipeDirectionsID], [RecipeID], [Description]) VALUES (9, 11, N'Minimum 20min laten pruttelen')
INSERT [MyWeight].[RecipeDirections] ([RecipeDirectionsID], [RecipeID], [Description]) VALUES (10, 11, N'Eventueel bijkruiden')
INSERT [MyWeight].[RecipeDirections] ([RecipeDirectionsID], [RecipeID], [Description]) VALUES (11, 11, N'Serveren op gekookte pasta')
SET IDENTITY_INSERT [MyWeight].[RecipeDirections] OFF
GO
SET IDENTITY_INSERT [MyWeight].[RecipeIngredient] ON 

INSERT [MyWeight].[RecipeIngredient] ([RecipeIngredientID], [RecipeID], [IngredientID], [Amount], [Unit]) VALUES (5, 11, 7, CAST(200.00 AS Decimal(18, 2)), N'g')
INSERT [MyWeight].[RecipeIngredient] ([RecipeIngredientID], [RecipeID], [IngredientID], [Amount], [Unit]) VALUES (6, 11, 8, CAST(2.00 AS Decimal(18, 2)), N'')
INSERT [MyWeight].[RecipeIngredient] ([RecipeIngredientID], [RecipeID], [IngredientID], [Amount], [Unit]) VALUES (7, 11, 9, CAST(300.00 AS Decimal(18, 2)), N'g')
INSERT [MyWeight].[RecipeIngredient] ([RecipeIngredientID], [RecipeID], [IngredientID], [Amount], [Unit]) VALUES (8, 11, 10, CAST(3.00 AS Decimal(18, 2)), N'cloves')
INSERT [MyWeight].[RecipeIngredient] ([RecipeIngredientID], [RecipeID], [IngredientID], [Amount], [Unit]) VALUES (9, 11, 11, CAST(1.00 AS Decimal(18, 2)), N'')
SET IDENTITY_INSERT [MyWeight].[RecipeIngredient] OFF
GO
SET IDENTITY_INSERT [MyWeight].[Timestamp] ON 

INSERT [MyWeight].[Timestamp] ([TimeStampID], [Name]) VALUES (1, N'Breakfast')
INSERT [MyWeight].[Timestamp] ([TimeStampID], [Name]) VALUES (2, N'Lunch')
INSERT [MyWeight].[Timestamp] ([TimeStampID], [Name]) VALUES (3, N'Dinner')
INSERT [MyWeight].[Timestamp] ([TimeStampID], [Name]) VALUES (4, N'Snacks/Other')
SET IDENTITY_INSERT [MyWeight].[Timestamp] OFF
GO
SET IDENTITY_INSERT [MyWeight].[User] ON 

INSERT [MyWeight].[User] ([UserID], [Username], [Password], [Weight], [CurrentWeight], [WantedWeight], [CaloriesDayGoal]) VALUES (1, N'robbe', N'AVUX1xBBGTsnUaykdXz9qmWhH1s7mL8NPRch4ZpM/6FUoS8qN3oaGs7WMDT0BgO36w==', CAST(63.00 AS Decimal(18, 2)), CAST(61.00 AS Decimal(18, 2)), CAST(57.00 AS Decimal(18, 2)), 2700)
SET IDENTITY_INSERT [MyWeight].[User] OFF
GO
ALTER TABLE [MyWeight].[Diary]  WITH CHECK ADD  CONSTRAINT [FK_MyWeight.Diary_MyWeight.User_UserID] FOREIGN KEY([UserID])
REFERENCES [MyWeight].[User] ([UserID])
ON DELETE CASCADE
GO
ALTER TABLE [MyWeight].[Diary] CHECK CONSTRAINT [FK_MyWeight.Diary_MyWeight.User_UserID]
GO
ALTER TABLE [MyWeight].[DiaryTimeStamp]  WITH CHECK ADD  CONSTRAINT [FK_MyWeight.DiaryTimeStamp_MyWeight.Diary_DiaryID] FOREIGN KEY([DiaryID])
REFERENCES [MyWeight].[Diary] ([DiaryID])
ON DELETE CASCADE
GO
ALTER TABLE [MyWeight].[DiaryTimeStamp] CHECK CONSTRAINT [FK_MyWeight.DiaryTimeStamp_MyWeight.Diary_DiaryID]
GO
ALTER TABLE [MyWeight].[DiaryTimeStamp]  WITH CHECK ADD  CONSTRAINT [FK_MyWeight.DiaryTimeStamp_MyWeight.Timestamp_TimeStampID] FOREIGN KEY([TimeStampID])
REFERENCES [MyWeight].[Timestamp] ([TimeStampID])
ON DELETE CASCADE
GO
ALTER TABLE [MyWeight].[DiaryTimeStamp] CHECK CONSTRAINT [FK_MyWeight.DiaryTimeStamp_MyWeight.Timestamp_TimeStampID]
GO
ALTER TABLE [MyWeight].[DiaryTimeStampMeal]  WITH CHECK ADD  CONSTRAINT [FK_MyWeight.DiaryTimeStampMeal_MyWeight.DiaryTimeStamp_DiaryTimeStampID] FOREIGN KEY([DiaryTimeStampID])
REFERENCES [MyWeight].[DiaryTimeStamp] ([DiaryTimeStampID])
ON DELETE CASCADE
GO
ALTER TABLE [MyWeight].[DiaryTimeStampMeal] CHECK CONSTRAINT [FK_MyWeight.DiaryTimeStampMeal_MyWeight.DiaryTimeStamp_DiaryTimeStampID]
GO
ALTER TABLE [MyWeight].[DiaryTimeStampMeal]  WITH CHECK ADD  CONSTRAINT [FK_MyWeight.DiaryTimeStampMeal_MyWeight.Meal_MealID] FOREIGN KEY([MealID])
REFERENCES [MyWeight].[Meal] ([MealID])
ON DELETE CASCADE
GO
ALTER TABLE [MyWeight].[DiaryTimeStampMeal] CHECK CONSTRAINT [FK_MyWeight.DiaryTimeStampMeal_MyWeight.Meal_MealID]
GO
ALTER TABLE [MyWeight].[Ingredient]  WITH CHECK ADD  CONSTRAINT [FK_MyWeight.Ingredient_MyWeight.NutritionFact_NutritionFactID] FOREIGN KEY([NutritionFactID])
REFERENCES [MyWeight].[NutritionFact] ([NutritionFactID])
ON DELETE CASCADE
GO
ALTER TABLE [MyWeight].[Ingredient] CHECK CONSTRAINT [FK_MyWeight.Ingredient_MyWeight.NutritionFact_NutritionFactID]
GO
ALTER TABLE [MyWeight].[MealIngredient]  WITH CHECK ADD  CONSTRAINT [FK_MyWeight.MealIngredient_MyWeight.Ingredient_IngredientID] FOREIGN KEY([IngredientID])
REFERENCES [MyWeight].[Ingredient] ([IngredientID])
ON DELETE CASCADE
GO
ALTER TABLE [MyWeight].[MealIngredient] CHECK CONSTRAINT [FK_MyWeight.MealIngredient_MyWeight.Ingredient_IngredientID]
GO
ALTER TABLE [MyWeight].[MealIngredient]  WITH CHECK ADD  CONSTRAINT [FK_MyWeight.MealIngredient_MyWeight.Meal_MealID] FOREIGN KEY([MealID])
REFERENCES [MyWeight].[Meal] ([MealID])
ON DELETE CASCADE
GO
ALTER TABLE [MyWeight].[MealIngredient] CHECK CONSTRAINT [FK_MyWeight.MealIngredient_MyWeight.Meal_MealID]
GO
ALTER TABLE [MyWeight].[MealRecipe]  WITH CHECK ADD  CONSTRAINT [FK_MyWeight.MealRecipe_MyWeight.Meal_MealID] FOREIGN KEY([MealID])
REFERENCES [MyWeight].[Meal] ([MealID])
ON DELETE CASCADE
GO
ALTER TABLE [MyWeight].[MealRecipe] CHECK CONSTRAINT [FK_MyWeight.MealRecipe_MyWeight.Meal_MealID]
GO
ALTER TABLE [MyWeight].[MealRecipe]  WITH CHECK ADD  CONSTRAINT [FK_MyWeight.MealRecipe_MyWeight.Recipe_RecipeID] FOREIGN KEY([RecipeID])
REFERENCES [MyWeight].[Recipe] ([RecipeID])
ON DELETE CASCADE
GO
ALTER TABLE [MyWeight].[MealRecipe] CHECK CONSTRAINT [FK_MyWeight.MealRecipe_MyWeight.Recipe_RecipeID]
GO
ALTER TABLE [MyWeight].[Recipe]  WITH CHECK ADD  CONSTRAINT [FK_MyWeight.Recipe_MyWeight.RecipeCategory_RecipeCategoryID] FOREIGN KEY([RecipeCategoryID])
REFERENCES [MyWeight].[RecipeCategory] ([RecipeCategoryID])
ON DELETE CASCADE
GO
ALTER TABLE [MyWeight].[Recipe] CHECK CONSTRAINT [FK_MyWeight.Recipe_MyWeight.RecipeCategory_RecipeCategoryID]
GO
ALTER TABLE [MyWeight].[RecipeDirections]  WITH CHECK ADD  CONSTRAINT [FK_MyWeight.RecipeDirections_MyWeight.Recipe_RecipeID] FOREIGN KEY([RecipeID])
REFERENCES [MyWeight].[Recipe] ([RecipeID])
ON DELETE CASCADE
GO
ALTER TABLE [MyWeight].[RecipeDirections] CHECK CONSTRAINT [FK_MyWeight.RecipeDirections_MyWeight.Recipe_RecipeID]
GO
ALTER TABLE [MyWeight].[RecipeIngredient]  WITH CHECK ADD  CONSTRAINT [FK_MyWeight.RecipeIngredient_MyWeight.Ingredient_IngredientID] FOREIGN KEY([IngredientID])
REFERENCES [MyWeight].[Ingredient] ([IngredientID])
ON DELETE CASCADE
GO
ALTER TABLE [MyWeight].[RecipeIngredient] CHECK CONSTRAINT [FK_MyWeight.RecipeIngredient_MyWeight.Ingredient_IngredientID]
GO
ALTER TABLE [MyWeight].[RecipeIngredient]  WITH CHECK ADD  CONSTRAINT [FK_MyWeight.RecipeIngredient_MyWeight.Recipe_RecipeID] FOREIGN KEY([RecipeID])
REFERENCES [MyWeight].[Recipe] ([RecipeID])
ON DELETE CASCADE
GO
ALTER TABLE [MyWeight].[RecipeIngredient] CHECK CONSTRAINT [FK_MyWeight.RecipeIngredient_MyWeight.Recipe_RecipeID]
GO
