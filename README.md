# SxA Rating Feature

**Purpose**


SxA Rating feature/control provides end-users with an intuitive interface to rate content and services by allowing them to select item images ("stars" by default) that represent the user’s rating. The rating control has several great features that provide flexibility and customization. It stores rating associated with a Content in a database and additionally user information in xDB through xConnect. This way you can leverage the rating storage per Content type as well as contact list of known reviewers.

The most common way to use the rating control is to display an average rating while still allowing the user to enter their own rating value. In this scenario, the ratings control is initially set to reflect the average satisfaction rating of all users of a particular service or type of content (product, news, article etc.). It remains in this state until a user interacts with the control with the goal of individually rating an item. This interaction changes the state of the ratings control to reflect the user's personal satisfaction rating.

**Module Sitecore Hackathon Category:** SxA

## Pre-requisites

SxA Rating Feature Module relies on following Sitecore modules

- SxA (Sitecore Experience Accelerator)
- xConnect


## Installation Guide for Rating Feature

**Prerequisite to use this component**

1.	Installed Sitecore 9 update 1 
2.	Installed SXA 1.6
3.	SXA Rating Feature.zip file download link form – Github – link- 


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

## Usage

**Steps to add SxA Feature on any Page** 
1.	Login to Sitecore using the your credentials.
2.	Open Content Editor and select a page to which the component needs to be added. 
3.	Click on “Publish->Experience Editor”.
4.	On the Experience Editor, select the Rating component from the toolbox under "Hackathon" category.
![RenderingRating](images/RenderingRating.JPG)
5.	Drag and drop the component to the corresponding Placeholder e.g. Main 

**How the component Works**

1.	Rating component is displayed on the page as like below image,
![Webpage](images/Webpage.JPG)
2.	Average rating is by default highlighted on the star.
3.	User can give their rating by hover over the star.
4.	Average rating and total recordings is displayed under the rating symbol.
5.	Once User gives their rating, new section will open up, refer the below image
![ToolBox](images/ToolBox.JPG)
6.	In the section user can enter their user name and email id. This details has to be stored in XDB through xConnect API.
7.	When user comes back to the site, we can showcase some personalization content.


**Future Extensions**

1. We can Create another SxA Component such as Listing, which can extract the data from the Custom database based on Content Type [Template Id] and display the Top rated content [News/Articles/Products]
Listing Component can have the Rendering Parameters to Select the Type [Template] and the number of Content Items to be shown on the Listing.

2. Since our SxA Rating feature stores user data into xConnect, we can leverage Contact data further in Experience modules like EXM, Personalization etc. This way we can serve personalized content, send marketing emails and provide better user experience to our reviewers (users who rated content in your application).


## Video

Click on below Image to View the Video

[![Sitecore Hackathon 2018 SxA Rating Feature](images/UDT.png)](https://www.youtube.com/watch?v=uqQGOZbpoW4)