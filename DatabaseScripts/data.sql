SET IDENTITY_INSERT [dbo].[Movie] ON
INSERT INTO [dbo].[Movie] ([Id], [MovieName], [Genre], [Price]) VALUES (1, N'Fast and the Furious', N'Action/Thriller', CAST(150.00 AS Decimal(18, 2)))
INSERT INTO [dbo].[Movie] ([Id], [MovieName], [Genre], [Price]) VALUES (2, N'Captain America', N'Action', CAST(160.00 AS Decimal(18, 2)))
INSERT INTO [dbo].[Movie] ([Id], [MovieName], [Genre], [Price]) VALUES (4, N'Mission Impossible: Fallout', N'Action /Thriller', CAST(180.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[Movie] OFF

SET IDENTITY_INSERT [dbo].[Customer] ON
INSERT INTO [dbo].[Customer] ([Id], [CustomerName], [CutomerExternalId], [Email]) VALUES (1, N'John Smith', NULL, N'smith@gmail.com')
INSERT INTO [dbo].[Customer] ([Id], [CustomerName], [CutomerExternalId], [Email]) VALUES (2, N'Abe Houston ', NULL, N'abe@gmail.com')
INSERT INTO [dbo].[Customer] ([Id], [CustomerName], [CutomerExternalId], [Email]) VALUES (3, N'Harry Watson', NULL, N'harry@gmail.com')
SET IDENTITY_INSERT [dbo].[Customer] OFF

SET IDENTITY_INSERT [dbo].[Comment] ON
INSERT INTO [dbo].[Comment] ([Id], [CustomerId], [CommentText]) VALUES (1, 1, N'Great service!')
INSERT INTO [dbo].[Comment] ([Id], [CustomerId], [CommentText]) VALUES (2, 2, N'Good customer service !')

SET IDENTITY_INSERT [dbo].[Comment] OFF

SET IDENTITY_INSERT [dbo].[MovieTransaction] ON
INSERT INTO [dbo].[MovieTransaction] ([Id], [MovieId], [CustomerId]) VALUES (1, 1, 1)
INSERT INTO [dbo].[MovieTransaction] ([Id], [MovieId], [CustomerId]) VALUES (2, 1, 2)

SET IDENTITY_INSERT [dbo].[MovieTransaction] OFF