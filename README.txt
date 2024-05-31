                     _        ______                               _____                            _   
     /\             (_)      |  ____|                             / ____|                          | |  
    /  \   __ _ _ __ _  ____ | |__   _ __   ___ _ __ __ _ _   _  | |     ___  _ __  _ __   ___  ___| |_ 
   / /\ \ / _` | '__| ||____||  __| | '_ \ / _ | '__/ _` | | | | | |    / _ \| '_ \| '_ \ / _ \/ __| __|
  / ____ | (_| | |  | |      | |____| | | |  __| | | (_| | |_| | | |___| (_) | | | | | | |  __| (__| |_ 
 /_/    \_\__, |_|  |_|      |______|_| |_|\___|_|  \__, |\__, |  \_____\___/|_| |_|_| |_|\___|\___|\__|
           __/ |                                     __/ | __/ |                                        
          |___/                                     |___/ |___/                                         
----------------------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------
Contents:
1. Visual Studio Setup And Program Execution
2. Login
3. Register
4. Reset Password
5. Home
6. Green Energy Marketplace
7. Educational Resources
8. Project Collaboration
9. Forums
10. Expanded Chat
11. Modify Farmers
12. Create Farmer
13. About Us
14. NavBar Functionality
15. Programming Logic
   15.1. Funcationality Of DBController
   15.2. Logged On Status
   15.3. Employee Status
   15.4. Database Queries
16. Demo Accounts
----------------------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------
How To Set Up Visual Studio And Run The Program
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
Step 1: Download and Install Visual Studio
Visit the official Visual Studio website: Visual Studio Downloads

Choose the version of Visual Studio you want to install (Community, Professional, or Enterprise) and 
click on the "Download" button.

Follow the on-screen instructions to complete the installation process. Make sure to select the 
components you want to install, including any additional tools or libraries.

Step 2: Open Visual Studio
Once Visual Studio is installed, launch the application from your desktop or start menu.

Step 3: Open the Project
Locate the .sln file for the project named ST10065470_RussellSchwedhelm_PROG7311_POE.sln. If you have the 
file on your computer, you can double-click it to open it directly in Visual Studio.

Step 4: Run the Project
Once the project is opened in Visual Studio, ensure that the correct startup project is selected. 
You can do this by right-clicking on the desired project in the Solution Explorer and selecting 
"Set as Startup Project" if it's not already set.

Next, click on the "Start" button (usually a green play button) in the toolbar, or press F5 on your keyboard 
to run the project.

Visual Studio will build the project and run it. Depending on the type of project, this might launch a 
window for a graphical application, start a web server, or execute some other action specified in 
the project settings.
----------------------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------
Login:
~~~~~~
Welcome to the login page of our application! This page allows you to securely access your account. 
Below, you'll find guidance on how to navigate the page and what information to provide:
---------------------------------------
Login Form:
---------------------------------------
Email: Enter your email address in this field.

Password: Enter your password in this field. For security reasons, the characters you type here will 
be masked.

Login Button: Click this button to submit your login credentials and access your account.

Register Button: If you don't have an account yet, you can click this button to navigate to the 
registration page.

Reset Password Button: Use this button if you've forgotten your password and need to reset it.
---------------------------------------
Instructions:
---------------------------------------
Email: Enter the email address associated with your account in the "Email" field. Make sure to 
enter the email correctly to avoid login issues.

Password: Type your account password in the "Password" field. Remember, passwords are case-sensitive.

Login: After entering your email and password, click the "Login" button to proceed. If the provided 
credentials are correct, you will be redirected to the home page of our application.

Registration: If you are new to our platform, click the "Register" button to create a new account. 
You will be directed to the registration page where you can provide your details and create a new account.

Password Reset: In case you forget your password, click the "Reset Password" button. You'll be taken 
to a page where you can reset your password by following the provided instructions.
---------------------------------------
Additional Information:
---------------------------------------
Email Validation: JavaScript is implemented on the page to ensure that a valid email address is entered 
before submission. If you enter an invalid email format, an alert will prompt you to correct it before proceeding.

Password Hashing: For security purposes, passwords are hashed using the SHA-256 algorithm before 
being stored or compared. This ensures that your password remains encrypted and secure within our system.
----------------------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------
Register
~~~~~~~~
Welcome to the registration page of our application! This page allows you to create a new account. Below, 
you'll find guidance on how to navigate the page and what information to provide:
---------------------------------------
Registration Form:
---------------------------------------
Name: Enter your first name and surname in the respective fields.

Address: Provide your street number, street, suburb, city, province, and country details.

Contact Info: Enter your email address and phone number.

Password Info: Choose a password and confirm it in the respective fields.

Employee: Check this box if you are an employee. An additional field for the employee code will appear if 
this box is checked.

Register Button: Click this button to submit your registration details and create your account.

Login Button: If you already have an account, you can click this button to navigate to the login page.
---------------------------------------
Instructions:
---------------------------------------
Name: Enter your first name and surname in the designated fields.

Address: Provide your residential address details including street number, street name, suburb, city, 
province, and country.

Contact Info: Enter your email address and phone number. Make sure the email address is valid as it will 
be used for account-related communications.

Password Info: Choose a strong password for your account and confirm it in the respective fields. Passwords 
must be at least 12 characters long and contain at least one number and one capital letter.

Employee: If you are an employee, check the box labeled "Employee". An additional field for the employee 
code will appear. Enter your employee code if applicable.

Register: After filling in all the required information, click the "Register" button to create your account. 
If successful, you will be redirected to the login page to access your new account.

Login: If you already have an account, you can click the "Login" button to navigate to the login page and 
sign in.
---------------------------------------
Additional Information:
---------------------------------------
Email Validation: JavaScript is implemented on the page to ensure that a valid email address is entered 
before submission. If you enter an invalid email format, an alert will prompt you to correct it before proceeding.

Password Strength: The password field is validated to ensure it meets the complexity requirements for 
security purposes.

Employee Verification: If you check the "Employee" box, an additional field for the employee code will 
appear. Make sure to enter a valid employee code if applicable. This will be provided to you by an employee
prior to registration. For the sake of this demo, the employee code is: 12HuustcDR33
----------------------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------
Reset Password
~~~~~~~~~~~~~~
Welcome to the reset password page of our application! This page allows you to reset your password if 
you've forgotten it. Below, you'll find guidance on how to navigate the page and what information to provide:
---------------------------------------
Reset Password Form:
---------------------------------------
Email: Enter the email address associated with your account in this field.

Old Password: Provide your old password (if applicable). This field is optional and only required if you 
wish to change your password.

New Password: Enter your new password in this field.

Confirm New Password: Re-enter your new password to confirm it.

Reset Password Button: Click this button to submit your reset password request.

Cancel Button: If you decide not to reset your password, you can click this button to cancel and return 
to the login page.
---------------------------------------
Instructions:
---------------------------------------
Email: Enter the email address associated with your account in the "Email" field. Make sure to enter 
the email correctly to ensure that the password reset request is sent to the correct address.

Old Password: If you remember your old password and wish to change it, you can enter it in the 
"Old Password" field. This field is optional.

New Password: Enter your new password in the "New Password" field. Passwords must be at least 12 
characters long and contain at least one number and one capital letter.

Confirm New Password: Re-enter your new password in the "Confirm New Password" field to ensure that 
it matches the one entered above.

Reset Password: After filling in all the required information, click the "Reset Password" button to 
submit your password reset request. If successful, you will receive a confirmation message, and your 
password will be updated.

Cancel: If you decide not to reset your password, you can click the "Cancel" button to return to the 
login page without making any changes.
---------------------------------------
Additional Information:
Input Validation: JavaScript is implemented on the page to ensure that all fields are filled correctly 
before submission. If any errors are detected, an alert will prompt you to correct them before proceeding.
----------------------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------
Home
~~~~
Welcome to the hOME page of Agri-Energy Connect, your hub for sustainable agriculture and green energy 
solutions! Below, you'll find guidance on how to navigate the page and what features are available:
---------------------------------------
Main Banner: The top section of the page features a captivating banner with the title "Welcome to Agri-Energy Connect" 
and a brief description of the platform's purpose. You'll also find a "Learn More" button directing you to the About Us page.
---------------------------------------
Features Section: Below the banner, you'll discover the key features of Agri-Energy Connect, 
each represented as clickable feature items. 

These features include:

- Interactive Forums For Farmers And Energy Experts

- Marketplace For Green Energy Solutions And Sales

- Educational Resources

- Project Collaboration And Funding Opportunities
---------------------------------------
Messages Section: 
Alongside the features, there's a message box displaying contact messages. Each message includes the 
sender's name and indicates whether it's read or unread.
---------------------------------------
Instructions:
---------------------------------------
Main Banner:
	Learn More Button: Click this button to delve deeper into the platform and explore its features.

Features Section:
	Interactive Forums: Click on "Interactive Forums For Farmers And Energy Experts" to participate in discussions and 
				exchange ideas with fellow members.

	Marketplace: Click on "Marketplace For Green Energy Solutions And Sales" to explore and trade green energy solutions.

	Educational Resources: Click on "Educational Resources" to access materials and resources aimed at enhancing your 
				knowledge of sustainable agriculture and green energy.

	Project Collaboration: Click on "Project Collaboration And Funding Opportunities" to discover opportunities for 
				collaboration and funding in green energy projects.

Messages Section:
	Review the list of contact messages. Unread messages are marked accordingly, allowing you to prioritize your responses.

Navigation:
	You can navigate to different sections of the platform by clicking on the respective feature items or using the 
	"Learn More" button.
---------------------------------------
Additional Information:
---------------------------------------
Authentication: 
To access the features and functionalities of Agri-Energy Connect, ensure that you are logged in. If not, you 
will be redirected to the login page.

Employee Access: 
If you are an employee, additional features or functionalities may be available to you, although none are 
specified in this version of the code.
----------------------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------
Green Energy Marketplace
~~~~~~~~~~~~~~~~~~~~~~~~
Welcome to the Green Energy Marketplace, where you can explore and acquire sustainable energy solutions 
for your agricultural needs. Below is a guide to navigating the page and utilizing its features effectively:
---------------------------------------
Marketplace Section:
---------------------------------------
Search Bar: 
	Use the search bar to search for suppliers or items based on specific criteria such as keywords, 
	date range, and category. You can refine your search by specifying the date range and selecting a category.

Supplier List: 
	Displays a list of suppliers. Clicking the "Select" button next to a supplier's name allows you 
	to view items associated with that supplier.

All Items: 
	Displays all available items in the marketplace, including product name, category, and production date.

My Store (Non-Employee Only): 
	If you're not an employee, this section displays items listed by you. You can also create new items 
	by clicking the "Create New Item" button.
---------------------------------------
Instructions:
---------------------------------------
Search Bar:
===========
Enter keywords related to the item or supplier you're looking for in the search textbox.

Use the date pickers to specify a date range for item production.

Select a category from the dropdown list to filter items by category.

Click the "Search" button to apply the filters and retrieve matching results.

Click the "Reset" button to clear all filters and display all items.

Supplier List:
==============
Browse the list of suppliers to find those offering the products or services you're interested in.

Click the "Select" button next to a supplier's name to view items associated with that supplier.

All Items:
==========
Explore the list of all available items in the marketplace.

Each item entry includes the product name, category, and production date.

My Store (Non-Employee Only):
=============================
If you're not an employee, this section displays items listed by you.

Click the "Create New Item" button to add a new item to your store.
---------------------------------------
Requirements and Limitations:
---------------------------------------
Authentication: To access the marketplace features, ensure that you are logged in. 
Non-logged-in users will be redirected to the login page.

Employee Access: Some features, such as the "My Store" section, are restricted to employees. 
If you're an employee, you won't see this section.
----------------------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------
Educational Resources
~~~~~~~~~~~~~~~~~~~~~
Welcome to the Educational Resources section, where you can access valuable information and learning 
materials on sustainable agriculture and green energy. Below is a guide to navigating the page and 
utilizing its features effectively:
---------------------------------------
NOTE
====
As this website is a demo, there are no accessable resources availible on the page and the search functionality
is not present.
---------------------------------------
Available Resources Section:
---------------------------------------
Search Bar: 
Use the search bar to search for specific resources by entering keywords related to your topic of interest.

List of Available Resources: Displays a list of available educational resources, including e-books, webinars, 
research papers, case studies, training modules, workshops, and events.
---------------------------------------
Instructions:
---------------------------------------
Search Bar:
Enter keywords related to the resource you're looking for in the search textbox.
Click the "Search" button to filter the list of available resources based on your search criteria.

List of Available Resources:
Browse the list of available educational resources.
Click on the resource title (e.g., "Sustainable Agriculture E-books") to access the respective resource.
---------------------------------------
Requirements and Limitations:
---------------------------------------
Authentication: Ensure that you are logged in to access the Educational Resources section. 
Non-logged-in users will be redirected to the login page.

Employee Access: There are no specific limitations set for employee access on this page. 
All logged-in users can access the available resources.
----------------------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------
Project Collaboration
~~~~~~~~~~~~~~~~~~~~~
Welcome to the Project Collaboration section, where you can collaborate on sustainable projects 
with other farmers, researchers, and experts.
---------------------------------------
NOTE
====
As this website is a demo, there are no accessable project collaborations availible on the page.
---------------------------------------
Potential Features:
---------------------------------------
Platform to Find and Join Collaborative Projects: 
Discover and join existing collaborative projects relevant to sustainable agriculture and green energy.

Project Management Tools and Resources: 
Access tools and resources to manage collaborative projects effectively.

Forums for Discussion and Idea Exchange: 
Engage in discussions and exchange ideas with other collaborators through forums.

Access to a Network of Experts and Collaborators: 
Connect with experts and fellow collaborators to expand your network and find potential collaborators for your projects.

Showcase of Successful Collaborative Projects: 
Explore successful collaborative projects as examples and inspiration for your own endeavors.
---------------------------------------
Resources:
---------------------------------------
All resouces when selected will redirect the user to the Educational Resources page.

Guide to Effective Collaboration: Access a guide to effective collaboration, providing insights 
and tips for successful project collaboration.

Project Management Tools: Explore tools and software solutions for project management tailored 
to collaborative projects.

Case Studies of Collaborative Projects: Learn from real-life case studies of successful 
collaborative projects in the field of sustainable agriculture and green energy.

Funding Opportunities for Joint Projects: Discover funding opportunities available for joint 
projects, including grants and sponsorships.

Networking Events and Workshops: Stay updated on networking events and workshops related to 
project collaboration in the sustainable agriculture and green energy sectors.
---------------------------------------
Instructions:
---------------------------------------
Features List:
Browse through the list of features to understand the capabilities offered by the Project 
Collaboration section.

Resources List:
Explore the available resources by clicking on the links provided. Each resource offers 
valuable information and tools to support your collaborative projects.
---------------------------------------
Requirements and Limitations:
---------------------------------------
Authentication: Ensure that you are logged in to access the Project Collaboration section. 
Non-logged-in users will be redirected to the login page.

Employee Access: There are no specific limitations set for employee access on this page. 
All logged-in users can access the features and resources available for project collaboration.
----------------------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------
Forums
~~~~~~
Welcome to the Forum page, where you can engage in discussions, seek advice, share experiences, 
and collaborate with others in the community.
---------------------------------------
NOTE
====
As this website is a demo, there are there is no functional chat feature. All chats are placeholders
to demonstrate the general style and funcationality of thye feature.
---------------------------------------
Chips: 
	Click on the chips to filter discussions based on different categories such as seeking advice, 
	sharing experiences, or collaboration.

New Chat Button: 
	Click the "New Chat" button to start a new discussion thread.

Forum Container:
	Chat Sections: Each chat section represents a discussion thread.

	Chat Header: Displays the title of the discussion thread.

	Chat Content: Provides a brief description of the discussion topic and an option to expand the chat.

	Expand Button: Click the "Expand" button to view the full discussion thread in an expanded view.
---------------------------------------
Instructions:
---------------------------------------
Chips Filtering:
Click on the chips to filter discussions based on your interests or the type of discussion you want to participate in.

New Chat Button:
Click the "New Chat" button to start a new discussion thread. Provide a title and description for the new discussion.

Chat Sections:
Browse through the existing chat sections to view ongoing discussions.
Click on the chat header to view the details of the discussion.
Use the "Expand" button to view the full discussion thread in an expanded view.
---------------------------------------
Requirements and Limitations:
---------------------------------------
Authentication: Ensure that you are logged in to participate in forum discussions. 
Non-logged-in users will be redirected to the login page.

Employee Access: There are no specific limitations set for employee access on this page. 
All logged-in users can access and participate in forum discussions.
----------------------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------
Expanded Chat
~~~~~~~~~~~~~
Welcome to the Expanded Chat page! This page allows you to view and participate in a specific chat discussion. 
---------------------------------------
NOTE
====
As this website is a demo, there are there is no functional chat feature. All chats are placeholders
to demonstrate the general style and funcationality of thye feature and the expanded chats are generic.
---------------------------------------
Page Information:
Chat Title: 
Displays the title of the chat discussion.

Chat Description: 
Provides an overview or context for the discussion.

Messages Section:
Individual Messages: 
Each message represents a contribution to the chat discussion.

User: 
Indicates the username or identity of the message sender.

Text: 
Displays the content of the message.

Reply Section:
Textarea: 
Enter your reply or message in the textarea provided.

Post Reply Button: 
Click the "Post Reply" button to submit your message to the chat discussion.
---------------------------------------
Instructions:
---------------------------------------
View Chat Title and Description:
Read the chat title and description to understand the context of the discussion.

View Messages:
Scroll through the messages to read the ongoing conversation.
Note the usernames of message senders to identify contributors.

Post a Reply:
Enter your message or reply in the textarea provided.

Click the "Post Reply" button to submit your message to the chat.
---------------------------------------
Requirements and Limitations:
---------------------------------------
Authentication: Ensure that you are logged in to participate in chat discussions. 
Non-logged-in users will be redirected to the login page.

Employee Access: There are no specific limitations set for employee access on this page. 
All logged-in users can view and participate in chat discussions.
----------------------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------
Modify Farmers
~~~~~~~~~~~~~~
Welcome to the Modify Farmers page! This page allows you to manage the list of farmers by 
modifying their details or deleting them from the system.
---------------------------------------
Page Structure
---------------------------------------
List of Farmers:
Displays a list of farmers currently stored in the system.
Each farmer entry includes their username and buttons for modifying or deleting their details.

Overlay and Popup for Delete Confirmation:
Displays a confirmation popup when attempting to delete a farmer.
Provides options to either confirm or cancel the deletion.

Overlay and Popup for Farmer Removal Confirmation:
Displays a confirmation popup after successfully removing a farmer from the database and a 
continue button that allows users to continue after the removal.
---------------------------------------
Instructions:
---------------------------------------
View Farmers List:
Scroll through the list of farmers to view their usernames.
Each farmer entry includes buttons for modifying or deleting their details.

Modify Farmer Details:
Click the "Modify" button next to a farmer to edit their details.
You will be redirected to the "CreateFarmer.aspx" page with the farmer's ID in the query string.

Delete Farmer:
Click the "Delete" button next to a farmer to initiate the deletion process.
A confirmation popup will appear, asking you to confirm the deletion.
Click "Continue" to proceed with the deletion or "Back" to cancel.

Create New Farmer:
Click the "Create New" button at the top of the page to create a new farmer.
You will be redirected to the "CreateFarmer.aspx" page to add details for the new farmer.
---------------------------------------
Requirements and Limitations:
---------------------------------------
Authentication:
Users must be logged in to access this page. 
Non-logged-in users will be redirected to the login page.

Only employees can access and modify farmer details. 
Non-employee users will be redirected to the home page.
----------------------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------
Create Farmers
~~~~~~~~~~~~~~
Welcome to the Create Farmer page! This page allows you to add or modify farmer details in the system. 
---------------------------------------
Page Structure
---------------------------------------
Form Sections:
Divided into sections such as Name, Address, and Contact Info.

Each section contains input fields for entering farmer details.

The "Submit" button allows you to save or update farmer information.
---------------------------------------
Instructions:
---------------------------------------
Input Farmer Details:
Fill out the required fields such as First Name, Surname, Email, Address, and Contact Information.
Ensure all required fields are filled out before submitting the form.

If a farmer is being modified, these fields will already be populated with stored information.

Submit Form:
Click the "Submit" button to save the farmer details.
If updating an existing farmer, the changes will be applied.

Validation:
The form includes client-side validation to ensure data integrity.
Error messages will be displayed if any fields are incorrectly filled out.

Success Message:
After successfully submitting the form, a popup message will appear confirming the action.
Click "Continue" to proceed.
---------------------------------------
Requirements and Limitations:
---------------------------------------
Authentication:
Users must be logged in to access this page. Non-logged-in users will be redirected to the login page.

Employee Status:
Only employees can access and modify farmer details. Non-employee users will be redirected.
---------------------------------------
Additional Notes:
---------------------------------------
Temporary Password:
If creating a new farmer, a temporary password will be generated and displayed in the success message.
In the release version of the website, an email will be sent to the farmer with their login information.
----------------------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------
About Us
~~~~~~~~
Welcome to the About Us page! This page provides an overview of Agri-Energy Connect, our vision, 
objectives, key features, and commitment to sustainable agriculture and renewable energy. 
---------------------------------------
Page Structure
---------------------------------------
Introduction: Provides background information on Agri-Energy Connect.
Vision: Describes our long-term goals and aspirations.
Objectives: Outlines specific aims and initiatives.
Key Features: Highlights the main functionalities and services offered.
Our Commitment: Affirms our dedication to sustainable agriculture.
Features: Lists additional features and offerings.
Resources: Provides links to relevant guides and resources.
---------------------------------------
Instructions:
---------------------------------------
Read Content:
Explore each section to gain a comprehensive understanding of Agri-Energy Connect, its goals, 
and offerings.

Learn About Vision and Objectives:
Understand our vision for the future of agriculture and the specific objectives we aim to achieve.

Discover Key Features:
Learn about the key functionalities and services offered by Agri-Energy Connect, such as the 
Sustainable Farming Hub and Green Energy Marketplace.

Understand Our Commitment:
Read about our commitment to driving sustainable agriculture and supporting the agricultural 
community.

Explore Additional Features and Resources:
Discover additional features, such as interactive forums and educational resources, as well 
as access links to useful guides and resources.
---------------------------------------
Authentication: Ensure that you are logged in to participate in chat discussions. 
Non-logged-in users will be redirected to the login page.

Employee Access: There are no specific limitations set for employee access on this page. 
All logged-in users can view Argi-Energy Connect's information
---------------------------------------
Additional Notes:
---------------------------------------
Interactive Elements:
Some sections may contain interactive elements, such as links to resources and forums for 
discussion.
----------------------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------
Navigation Bar Funcationality
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
The navigation bar (navbar) located at the top of the page provides easy access to various 
sections of the Agri-Energy Connect website
---------------------------------------
Navbar Sections:
---------------------------------------
Home: Directs users to the home page, where they can find general information about 
	Agri-Energy Connect and navigate to other sections.

Green Energy Marketplace: Takes users to the Green Energy Marketplace page, where 
	they can explore and compare green energy products and services tailored 
	to agricultural needs.

Educational Resources: Links users to the Educational Resources page, where they can 
	access online courses, workshops, and guides on integrating green energy 
	technologies into agriculture.

Project Collaboration: Navigates users to the Project Collaboration page, facilitating 
	collaboration among farmers, green energy experts, and enthusiasts on joint projects.

Forum: Redirects users to the Forum page, where they can engage in discussions, share 
	experiences, and collaborate on initiatives related to sustainable agriculture 
	and renewable energy.

Modify Farmers (Employee Access): Visible only to employees, this link leads to the 
	Modify Farmers page, where authorized personnel can update farmer details and 
	information.

About Us: Provides information about Agri-Energy Connect, its mission, vision, objectives, 
	and commitment to sustainable agriculture and renewable energy.

Log Out: Allows users to log out of their account and securely end their session.
---------------------------------------
Navbar Functionality:
---------------------------------------
Dynamic Display: The navbar dynamically adjusts its display based on the user's authentication 
	status and the current page being viewed. For example, the "Log Out" link is only 
	shown when the user is logged in, and certain links are hidden on specific pages 
	such as the login, register, or reset password pages.

Employee Access: Certain links, such as "Modify Farmers," are accessible only to employees 
	with appropriate permissions. These links are conditionally displayed based on the 
	user's employee status.
---------------------------------------
Usage Instructions:
---------------------------------------
Navigation:
Click on the respective navbar links to navigate to different sections of the website.

Employee Access:
If you are an employee, you can access additional functionalities such as modifying farmer 
details by clicking on the "Modify Farmers" link.

Logout:

To log out of your account, click on the "Log Out" link.
---------------------------------------
Requirements and Limitations:
Authentication:
Some pages and functionalities may require authentication. Users must log in to access certain features.

Employee Status:
Access to certain links and functionalities may be restricted based on the user's employee status.
----------------------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------
DBController
~~~~~~~~~~~~
The `DBController` class provides a comprehensive set of functionalities for interacting with a SQL 
database in a web application. It uses a connection string from the application's configuration file 
to establish a connection to the database. The class includes methods for logging in a user by verifying 
their email and hashed password, checking if a user is an employee, and retrieving all non-employee 
users (farmers). It allows the creation, updating, and deletion of user records, including the retrieval 
of detailed information about a specific farmer. The `DBController` also provides methods to check for 
the existence of an email or employee code, update a user's password, and compare provided credentials 
against stored ones. Additionally, it supports retrieving all items or suppliers associated with a user, 
filtering these items based on various criteria such as search terms, date range, and category, and 
fetching all categories for dropdown lists. Each method is designed to handle exceptions and ensure 
that connections to the database are properly opened and closed to maintain application stability and 
data integrity.
----------------------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------
Logged On Status
~~~~~~~~~~~~~~~~
In this program, the "logged on" status serves as a fundamental component of user authentication and session management. 

The SiteMaster class defines a property LoggedOn which determines whether the current user is an logged on or not. 
All pages except for Login, Register, and Reset Password, require the user to be logged on to access and use them.

User Authentication: 
When a user logs into the system, their "logged on" status is set to true. This status is stored in the 
user's session, indicating that they have successfully authenticated themselves.

Session Management: 
The "logged on" status helps manage user sessions. It ensures that users remain authenticated throughout 
their session duration. If the user navigates to other pages or performs actions within the system, 
their "logged on" status persists, indicating that they are still active within the session.

Access Control: 
The "logged on" status is checked on various pages. If a user attempts to access this page without 
being logged on (i.e., their "logged on" status is false), they are redirected to the login page 
(Login.aspx). This prevents unauthorized access to sensitive functionalities and ensures that only 
authenticated users can interact with the system.

Enhanced Security: 
By enforcing a "logged on" status, the program enhances security by restricting access to protected resources 
and functionalities. This helps mitigate potential security risks associated with unauthorized access to 
sensitive data or operations within the system.
----------------------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------
Employee Status
~~~~~~~~~~~~~~~
In this program, the employee role is utilized to control access and permissions within the system. 

The SiteMaster class defines a property Employee which determines whether the current user is an employee or not. 
Pages which are restricted from regular usershecks this property before granting access to certain functionalities.

Authorization: 
When the ModifyFarmers page loads, it checks if the user is logged in and if the user is an employee. 
If not logged in or not an employee, the user is redirected to the appropriate page (Login.aspx or Home.aspx).

Security: 
The program ensures that only authorized employees can perform critical actions like modifying or deleting 
farmer data. This helps maintain data integrity and security within the system.

For the sake of this demo, the employee in use is: 12HuustcDR33
----------------------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------
Database Queries
~~~~~~~~~~~~~~~~
CREATE TABLE [dbo].[Users] (
    [Id]        INT           IDENTITY (1, 1) NOT NULL,
    [FirstName] VARCHAR (50)  NOT NULL,
    [Surname]   VARCHAR (50)  NOT NULL,
    [Email]     VARCHAR (MAX) NOT NULL,
    [Password]  VARCHAR (MAX) NOT NULL,
    [Employee]  INT           NOT NULL,
    [StreetNumber] INT NULL, 
    [Street] VARCHAR(50) NULL, 
    [Suburb] VARCHAR(50) NULL, 
    [City] VARCHAR(50) NULL, 
    [Province] VARCHAR(50) NULL, 
    [Country] VARCHAR(50) NULL, 
    [Phone] VARCHAR(50) NULL, 
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


CREATE TABLE [dbo].[EmployeeCodes]
(
	[Codes] VARCHAR(12) NOT NULL PRIMARY KEY
)

CREATE TABLE [dbo].[Items] (
    [Id]          INT           IDENTITY (1, 1) NOT NULL,
    [UserId]      INT           NOT NULL,
    [ProductName] VARCHAR (50)  NOT NULL,
    [PDate]       DATE          NOT NULL,
    [CategoryId]  INT           NOT NULL,
    [Description] VARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([Id]),
    FOREIGN KEY ([CategoryId]) REFERENCES [dbo].[Categories] ([Id])
);

CREATE TABLE [dbo].[Categories] (
    [Id]       INT          IDENTITY (1, 1) NOT NULL,
    [Category] VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);
----------------------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------
Demo Accounts
~~~~~~~~~~~~~
Email: johndoe@gmail.com
Password: Examp1lePa55
Employee: YES

Email: amysmith@gmail.com
Password: 2eZtoL0gon!2
Employee: YES

Email: russellschwedhelm@gmail.com
Password: 12eAS6789ten
Employee: YES

Email: davidsimms@gmail.com
Password: Tw3lveD1gits
Employee: YES

Email: michaeldoe@gmail.com
Password: Passw0rdiSthis
Employee: NO

Email: jamieoliver@gmail.com
Password: 5Ingredients
Employee: NO

Email: danielzomm@gmail.com
Password: 0LdPassc4ntBnew
Employee: NO

Email: hellenpilla@gmail.com
Password: 4r0r4O4NTfnd
Employee: NO

Email: kencenton@gmail.com
Password: 1eMk3n0ugh4M3
Employee: NO

ALL DEMO DATA WAS ADDED THROUGH THE WEBSITE USING THE DEMO LOGINS