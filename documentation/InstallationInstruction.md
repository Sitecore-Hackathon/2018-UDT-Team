# Installation Guide for Rating Feature

**Prerequisite to use this component**

1.	Install Sitecore 9 update 1 
2.	Install SXA 1.6
3.	SXA Rating Feature.zip file download link – [Packages](https://github.com/Sitecore-Hackathon/2018-UDT-Team/tree/master/Packages) 


**Installation Steps**
1.	Login to sitecore with your credential
2.	Open the sitecore desktop and then click the start icon and click the Installation wizard link
3.	It will open up the Installation wizard and then upload the SXA Rating Feature component.
4.	Click next to install the package.
5.	It will install the Rating Rendering and related files.
6.	Execute the App_Data/Rating.sql script in your sql, it will create the custom database to store ratings.
7.	Add the custom database connection string in connectionstring.config file of your website.
8.	To display the Rating Feature under tool box in experience editor, you can add rating rendering in any of the available rendering section. 


## Configuration

Once the module is installed, please update the below settings for Custom Database (used to store Ratings) and xConnect Endpoint as per your environment under [\App_Config\Include\Feature\Hackathon.Boilerplate.Feature.Rating.config]:

```xml
<?xml version="1.0"?>
<!--
  Purpose: Configuration settings for my hackathon module
-->
<configuration xmlns:patch="http://www.sitecore.net/xmlconfig/">
  <sitecore>
        <settings>
            <setting name="xconnectEndPoint" value="https://sc9_xconnect" />
            <setting name="CustomDataBase" value="custom" />
        </settings>
        <services>
            <configurator type="Hackathon.Boilerplate.Feature.Rating.Services.RatingServices,Hackathon.Boilerplate.Feature.Rating"/>
        </services>
    </sitecore>
</configuration>
```
