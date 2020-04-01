CREATE LOGIN testuser WITH PASSWORD = 'test123';
use Przelicznik;
Create user testuser for login testuser;
use Przelicznik;
GO
Grant Control on TestTable to testuser;
