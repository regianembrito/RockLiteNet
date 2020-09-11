USE [RockLikeDB]
GO

/****** Object:  Table [dbo].[Articles]    Script Date: 11/09/2020 10:05:29 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Articles](
	[IdArticle] [int] NOT NULL,
	[ArticleText] [text] NULL,
	[LikeCount] [int] NOT NULL,
 CONSTRAINT [PK_ARTICLES] PRIMARY KEY CLUSTERED 
(
	[IdArticle] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO


