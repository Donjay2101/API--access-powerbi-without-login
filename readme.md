
# Access powerBI using API without interactive login.

this API can be used to connect with powerBI and get any information from it , without any interactive login. this can be useful if you do not want to share powerBI credentials with user and want to manage powerBI using own custom layer.

## Step 1: register appplication to azure.
1.	Open https://portal.azure.com.
![image](https://user-images.githubusercontent.com/20739249/125550035-7445f367-85be-4d81-9f64-e61347e36e8e.png)

2.	Click or search for Azure active directory in portal and open it.
![image](https://user-images.githubusercontent.com/20739249/125550258-e23d2621-b56d-465f-8110-8de790114fb8.png)
3. Click on app registrations and register application.
![image](https://user-images.githubusercontent.com/20739249/125550298-88c472f9-7104-409a-937a-504e6b98d1e6.png)
4. After registration click on “API permissions” and powerBI “delegated permissions”` to application.
![image](https://user-images.githubusercontent.com/20739249/125550342-452a2df0-aa92-401b-8401-d295fca119fe.png)

## Step 2: Add registered application to powerBI.
1.	Open “https://app.powerBI.com”.
![image](https://user-images.githubusercontent.com/20739249/125550545-a5a3e5b3-027e-4a71-abde-1527aa0ceab7.png)
2.	Click on settings logo on top right side corner and open settings and then click on “admin portal”.
![image](https://user-images.githubusercontent.com/20739249/125550578-7ac7dea9-3302-4d08-bc8f-71789e98b097.png)
3.	Enable developer settings for powerBI.
![image](https://user-images.githubusercontent.com/20739249/125550641-e358d54a-2554-4bf8-8e30-3d2d23912f21.png)
---
**NOTE**
you can enable, the entire organization or specific group. For security concern it is recommended to set security group.
---
4.	Click on workspaces and select the workspace you want to connect.
![image](https://user-images.githubusercontent.com/20739249/125550783-04a5780f-85c6-4ed3-9504-248ffa66d86e.png)
5.	Search for the name of application.
![image](https://user-images.githubusercontent.com/20739249/125550858-60682afc-50f9-44c1-9a4b-28925aea4589.png)
---
**Note**
search for the name of application, which you have given at the time of registration of application in azure.
---
6.	Add application to workspace with required access type.

once the above steps are done. you can clone or download the application. run the application and there is folder with "powerbi-client", which can be used for testing.




## License
[MIT](https://choosealicense.com/licenses/mit/)
