# DatabaseSystem

 数据库大作业（功能不全），C#.net    window-Forms-app

##### 实现的功能

- 读者/管理员 登录

- 读者借阅图书

- 读者更改个人信息

- 管理员进行读者信息管理

- 管理员协助读者归还图书

###### 导出数据表

```
将下面内容粘贴到xxx.bat文件中，终端运行./xxx.bat,将数据表分成一个个表导出
```

```
@echo off

REM 设置保存路径
set SavePath=C:\dbs

REM MySQL连接信息
set DBUser=root
set DBPassword=你的密码
set DBName=你的数据库名

REM 获取所有表名
mysql -u %DBUser% -p%DBPassword% -N -B -e "SHOW TABLES" %DBName% > tables.txt

REM 读取 tables.txt 文件中的表名
for /F "usebackq" %%i in ("tables.txt") do (
  REM 导出每个表到单独的文件
  mysqldump -u %DBUser% -p%DBPassword% %DBName% %%i > "%SavePath%\%%i.sql"
)

REM 删除 tables.txt 文件
del tables.txt
```

```
或者一次性导出所有表到同一个sql文件中：
mysqldump -u root -p data > C:\Users\YourUsername\backup.sql
```

```
建议在cmd运行命令。
如果在powershell运行命令，导出的数据库sql文件可能会出现中文乱码
```

###### 导入数据库

```
mysql -u username -p database_name < file.sql
```
