use[Sportdb]
GO
--CREATE FULLTEXT CATALOG sportdb_fulltext_catalog as Default
--select * from sys.dm_fts_parser('FORMSOF(INFLECTIONAL, спортивний)', 1058, 0, 0);
GO
CREATE FULLTEXT INDEX ON Sections
( 
  [Description] Language 1058 
 ) 
 KEY INDEX PK_Sections ; 