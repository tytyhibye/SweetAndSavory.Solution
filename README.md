![wc-title.jpg](https://i.ibb.co/TWVs26v/S-S-logo.jpg)

### _Created by Tyler Bates_

## _Description_

Pierre's Sweet and Savory is an application allowing the user to create, edit, delete, tag, organize and store the inventory of their bakery upon registration and login. All registered users have access to all inventory item details but only the author of the entries has access to the edit, delete and tag functionality of them. The user can search for an item by associated flavors and also by ingredient used in the recipe of the item for allergy reasons.


## _Setup/Installation Requirements_ 

1. Clone this projects repository into your local directory following [these](https://www.linode.com/docs/development/version-control/how-to-install-git-and-clone-a-github-repository/) instructions.

2. Open the now local project folder with [VSC](https://code.visualstudio.com/Download) or an equivalent

3. Download [.NET Core](https://docs.microsoft.com/en-us/dotnet/core/install/runtime?pivots=os-windows) then enter the following command in the terminal to confirm installation (2.2 or higher)
```sh
dotnet -- version
``` 
4. Still in the command line, enter
```sh
dotnet tool install -g 
dotnet-script
```
5. Download [ASP.NET Core](https://dotnet.microsoft.com/download) to enable live viewing on a local server

6. Open the repository, navigate to the containing folder of the project & Enter the following command to confirm build stability 

```sh
dotnet run build 
```

7. Within that same containing folder enter the following to open a live server w/auto updated viewing
```sh
dotnet watch run
``` 
8. Go to your browser and enter the following url:

```sh
http://localhost:5000
```
#### MySQL Installation & Configuration:
1. Download the MySQL Community Server DMG file [here](https://dev.mysql.com/downloads/file/?id=484914) with the "No thanks, just start my download" link.
2. On the configuration page of the installer select the following options:
* Use legacy password encryption
* Set your password
3. Open the terminal and enter the command:
*'export PATH="/usr/local/mysql/bin:$PATH"' >> ~/.bash_profile
4. Download the MySQL Workbench DMG file [here](https://dev.mysql.com/downloads/file/?id=484391)
5. Open Local Instance 3306 with the password you set.
6. Within the project directory, enter the following command:
```
dotnet ef migrations add Initial
```

7. Once this successfully employs, enter the following to update the data tables to correlate with the project models:
```
dotnet ef database update
```
8. You should now be able to navigate through the full functionality of the project.

## _Technology Used_

## <a href="https://en.wikipedia.org/wiki/C_Sharp_%28programming_language%29">C#</a>
## <a href="https://en.wikipedia.org/wiki/.NET_Core">.NET Core</a>
## <a href="https://en.wikipedia.org/wiki/Visual_Studio_Unit_Testing_Framework">MSTest</a>
## <a href="https://docs.microsoft.com/en-us/dotnet/framework/data/adonet/ef/language-reference/entity-sql-language">Entity</a>
## <a href="https://www.mysql.com/products/workbench/">MySQL Workbench</a>

## _Specs_

|Behavior|Input|Output|
|-----|-----|-----|
|Pierre is greeted and given option to register as new user or login as existing user|"home"|"localhost.5000/"|
|Pierre can view existing treats|"all treats"|"5000/treats/index"|
|Pierre can add treat via form submission |"input"|"5000/treats/{treatId}"|
|Pierre can edit extising treat information|"edit"|"5000/edit/{treatId}"|
|Pierre can add flavors to treat|"Add flavor"|"5000/flavor/new"|
|Pierre populates the order details and form submission adds input data|"input"|"5000/flavor/{flavorId}"|
|Pierre can delete existing flavors|"Delete Flavor"|"5000/flavor/delete"|
|Pierre is given additional option to delete existing treats|"Delete treat"|"5000/item/delete"|

## _Legal_

#### MIT License

### Copyright (c) 2020 Tyler Bates @ Epicodus

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.