CREATE TABLE ErrorLog(   

    [nId] Integer PRIMARY KEY autoincrement NOT NULL,   

    [dtDate] [datetime] NOT NULL,   

    [sThread] [varchar](100) NOT NULL,   

    [sLevel] [varchar](200) NOT NULL,   

    [sLogger] [varchar](500) NOT NULL,   

    [sMessage] [varchar](3000) NOT NULL,   

    [sException] [varchar](4000) NULL)