# TopMarket---Fresh-Organic-Food

1. First time setting - in Web.config:
  - Change Data Source in connectionString to your ServerName in SQL Server.
  - Edit VNPAY APPSETTING by change value of TmnCode and HashSecret with your value code and localhost port to yours.
    (get these configurations code by register test account at https://sandbox.vnpayment.vn/apis/docs/huong-dan-tich-hop/ and active the account in email then wait       for another email which included those code) 
2. Create database - using scripts databse or create new by open Package Manager Consol to input these command step by step:
  - PM> enable-migration
  - PM> add-migration CreateNewDatabase
  - PM> update-database
 
