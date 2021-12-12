# API-Enhancement
![Alt text](https://github.com/steven5j/API-Enhancement/blob/master/titlejpg.jpg?raw=true)
## Description
面題題目，創建兩個Api以達到所需相對應結果
## 如何啟動?
1.將所有檔案下載回來.

2.將資料庫備份檔還原至資料庫(SQL SERVER).

3.將資料夾下面的appsettings.json內的CUR_MSSQL_Context的連線字串.

4.直接啟動，經由Swagger 填寫相關參數後直接執行，或是使用PostMan.

## API介紹
1.Api1(string id)

  Get lineItem/UnblendedCost grouping by product/productname

  - Parameter
  id=lineitem/usageaccountid


2.Api2(string id)

Get daily lineItem/UsageAmount grouping by product/productname

- Parameter
id=lineitem/usageaccountid

3.Api1Paginaton(string id, int onePageCount, int page)

(Optional) You can add more input arguments to your APIs to achieve paginaton strategy.

- Parameter
id=lineitem/usageaccountid
onePageCount=一頁顯示幾筆
page=第幾頁

4.Api2Paginaton(string id, int onePageCount, int page)

(Optional) You can add more input arguments to your APIs to achieve paginaton strategy.

- Parameter
id=lineitem/usageaccountid
onePageCount=一頁顯示幾筆
page=第幾頁
