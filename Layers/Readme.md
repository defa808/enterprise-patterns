# Layers
## Task:
Write down which layers you find in this application: https: //github.com/agoncal/agoncal-application-petstore-ee6
<br/>
Tell us how many of them, what would you call them. And how would recommend to refactor the application

## Solution:
If we are talking about three principle layers we can divide the project into such parts as:
<br/>
- Presentation Layer:    

    - webapp

    - web

- Domain Layer 

    - domain

    - service

- Data Source Layer - communication with other systems.

    - rest

<br/>

If we are talking about in general, I can see such layers as:

- Presentation Layer

    - webapp

- Application/Controller Layer 

    - web

- Services Layer

    - services

- Domain Layer

    - domain

- Data Source/Integration/Persistence Layer

    - rest

- Resources Layer

    - resources

<br/>
<br/>
I would like to reorganize the applications by highlighting the layers more explicitly, for example by creating folders for each layer or renaming folders according to the layer. 
<br/>
Because on the one hand the web application is smeared into several layers that are at the same folder levels as other layers according to the three principle layers.
<br/>
On the other hand it would great rename 'web' folder with 'controller' or 'web-controller' to make it more explicitly according to other detailed layers.

<br/>
<br/>

Also I have noticed that domain layer consist of some logic in methods: 
<br/>
Customer : calculateAge()
<br/>
Customer : matchPassword()
<br/>
Order : getTotal() 
<br/>
and so on,
<br/>
but the system already has a service layer. So the architect should choose what to use a rich Domain Model or a simple Domain Model. I would like to implement a simple Domain Model because the system already has a service layer.
<br/>
It will be easier to move a couple of methods to separate services, for example: Customer calculateAge() to CustomerService, or moving matchPassword() to UserManager (Service).
<br/>
<br/>
As I noticed Integration layer(rest) uses a service layer, so it's totally fine. I like it.
<br/>
<br/>
I didn't understand which layer the folder 'util' should belong to. As I see, there are interceptor, logger and a lot of producers. So it should be Presentation/Application layer.
<br/>
<br/>
What about any mappers? Now it's not needed, but over time, when models for other systems appear in the application the need for such a layer will be needed.