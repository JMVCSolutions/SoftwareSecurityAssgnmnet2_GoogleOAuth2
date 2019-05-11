How to Build For Deployment
1. Download the repository
2. Go to https://console.developers.google.com
3. Login with you google username and password
4. Create new project
5. Go to Credentials -> OAuth consent screen and set Application Name to show in Google login popup
6. Go to Credentials -> Credentials -> Create Credentials -> OAuth clien ID and select other. 
7. Retrive Client ID and Client secret from next popup
8. Open with Visual Studio (Developed with Visual Studio 2017)
9. Open Solution Explorer -> GoogleAuth.cs and set Client ID and Client secret for relevent variables
10. After, Right click on Project and select Rebuild

Deployment
11. Build file can be found in dist folder inside project directory (Project Folder/dist)
12. Copy all files to IIS folder inside hosting