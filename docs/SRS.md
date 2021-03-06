# NeCo - Software Requirements Specification

## 1. Introduction
### 1.1 Purpose
This SRS describes all specifications for "NeCo". It’s an Xamarin-App. "NeCo" allows
users to chat with people in their near environment. In this document the usage of the
"NeCo"-Xamarin-App will be explained. Furthermore reliability, reaction speed and other important
characteristics of this project will be specified. This includes design and architectural decisions regarding optimization of
these criteria as well.

### 1.2 Scope
This software specification applies to the whole "NeCo" application. The app allows users to chat with strangers in their near environment to meet new people, which are at the same spot as the user. It establishes user- and systemcreated chatrooms among users in close environments. 


### 1.3 Definitions, Acronyms and Abbreviations
In this section definitions and explanations of acronyms and abbreviations are listed to help the reader to understand these.

|			Abbreviation									|	Explanation		|
|---------------------------------------------------|---------------|
**Android**| This is a mobile operating system developed by Google which is primarily used on smartphones and tablets.|
**UC**| Use Case|
**UCD** |Use Case Diagram|
**OUCD** |Overall Use Case Diagram|
**SAD** |Software Architecture Document|
**RFC**| Request for Comments|


### 1.4 References
|			Title									|	Date		|
|---------------------------------------------------|---------------|
| [NeCo Blog](http:/necoproject.wordpress.com/) | 19.10.2017 |
| [Ouverall Use Case Diagramm (OUCD)](https://github.com/Haus4/NeCo/raw/develop/docs/img/UseCaseDiagramm_2nd.jpg)| 19.10.2017 |

### 1.5 Overview
The following chapters are about our vision and perspective, the software requirements, the demands we have, licensing and
the technical realization of this project.

## 2. Overall Description
### 2.1 Vision
Our idea is to develop a Xamarin App for chatting with strangers around you.
The basic idea behind NeCo is to use geolocalization technologies to create chatrooms with people around you, similar to the popular app “Jodel”.  The difference is that you chat with random people in your local area, to meet, to party, or just to have fun.
For security reasons we’ll use latest encryption technology like RSA & AES encryption. Ideas for future features could be a friend list to keep in contact.

People using our App can chat with strangers in their near environment. 

The following picture shows the overall use case diagram of our software:
![OUCD2]


## 3. Specific Requirements
### 3.1 Functionality - Android App
#### 3.1.1 Send message
The app provides the user with the possibility to send messages to another person nearby. This is provided through geolocalization within the functionality of the smartphone.

#### 3.1.2 Receive message
The app provides the user with the possibility to receive messages from another person nearby. This is provided through geolocalization within the functionality of the smartphone. 

#### 3.1.3 Create identiy
The server creates an identity for the user, by generating a private key for each user.

#### 3.1.4 Manage session
The server manages sessions and refers users according to their private key to a session. Users within the same session receive the same messages.

#### 3.1.5 Relay messages
The server receives messages of all users an relays them according to the session the user is in.

#### 3.1.6 Share files
The user is able to share files with the chatroom.

#### 3.1.7 Chat Geo-localized
The app provides the user with the possibility to receive a message from another in a certain distance around you.

#### 3.1.8 Chat encrypted
The app provides an encypted chat, where messages get encrypted and signed with ECDSA.


#### 3.1.9 Manage Lobby
he app provides the server with the possibility to manage lobbies.

#### 3.1.10 Visualize Lobby
The app provides the server with the possibility to visualisze lobbies.


### 3.2 Usability
#### 3.2.1 Smartphone user
The user should know how to use Android as a mobile operating system and how to install and use a mobile application on it. We will provide a installation guide.

### 3.3 Reliability
#### 3.3.1 Server availability
Our own server should ensure a 95% up-time.

Our server is co-hosted at the DHBW so we must rely on their service.

### 3.4 Performance
The sending of the messages and files from one user to another must not guarantee real-time data transfer, because the message and files will not be displayed and watched live. Nevertheless the transfer should not take longer than 5 seconds to ensure fast response times.

### 3.5 Supportability
#### 3.5.1 Language support
We will use the following languages, which will also be well supported in the future:

- C#
- XML

### 3.6 Design Constraints

#### 3.6.1 MVC architecture
Our Android application should implement the MVC pattern.

### 3.7 On-line User Documentation and Help System Requirements
The whole application will be built with an intuitive design, so there shouldn’t be a need for the user to ask us or the program for help. However, we will write our own blog on which users can find information and ask us questions.

### 3.8 Purchased Components
(n/a)

### 3.9 Interfaces
#### 3.9.1 User Interfaces
(tbd) 

Please consult the different use case descriptions for UI mockups (screenshots) and UI functionality descriptions:


- [UC1: Send Message][uc sendmessage]
- [UC2: Receive Message][uc receivemessage]
- [UC3: Create Identity][uc create identity]
- [UC4: Manage Session][uc manage session]
- [UC5: Relay Message][uc relay message]
- [UC6: Share Files][uc share files]
- [UC7: Chat Geo-Localized][uc geolocalize]
- [UC8: Chat Encrypted][uc encrypt]
- [UC9: Manage Lobbies][uc lobby]
- [UC10: Visualize Lobbies][uc lobbyviz]

<!--
- [UC6: Manage profile][uc manage profile]
- [UC7: Manage friendlist][uc manage friendlist]
- [UC8: Manage chatrooms][uc manage chatrooms]
- [UC9: Name moderator][uc name moderator]
- [UC10: Kick/Ban user][uc kick user]
- [UC11: Delete message][uc delete message]

-->

#### 3.9.2 Hardware Interfaces
(tbd)

#### 3.9.3 Software Interfaces
(tbd)

#### 3.9.4 Communications Interfaces
(tbd)

### 3.10 Licensing Requirement
(tbd)

### 3.11 Legal, Copyright and other Notices
(tbd)

### 3.12 Applicable Standards
(tbd)

## 4. Supporting Information
### 4.1 Appendices
You can find any internal linked sources in the chapter References (go to the top of this document). If you would like to know what the current status of this project is please visit the [NeCo Blog][blog].




[uc sendmessage]: https://github.com/Haus4/NeCo/blob/develop/docs/UC1_SendMessage.md "Use Case 1: Send a message"

[uc receivemessage]: https://github.com/Haus4/NeCo/blob/develop/docs/UC2_ReceiveMessage.md "Use Case 2: Receive a message"

[uc create identity]: https://github.com/Haus4/NeCo/blob/develop/docs/UC3_CreateIdentity.md "Use Case 3: Create a user identity"

[uc manage session]:https://github.com/Haus4/NeCo/blob/develop/docs/UC4_ManageSession.md "Use Case 4: Manage Session"

[uc relay message]:https://github.com/Haus4/NeCo/blob/develop/docs/UC5_RelayMessage.md "Use Case 5: Relay message"

[uc share files]: https://github.com/Haus4/NeCo/blob/develop/docs/sem_2/UC6_ShareFiles.md "Use Case 6: Share Files"
[uc geolocalize]: https://github.com/Haus4/NeCo/blob/develop/docs/sem_2/UC7_ChatGeoLocalized.md "Use Case 7: Chat geolocalized"
[uc encrypt]: https://github.com/Haus4/NeCo/blob/develop/docs/sem_2/UC8_ChatEncrypted.md "Use Case 8: Chat encrypted"
[uc lobby]: https://github.com/Haus4/NeCo/blob/develop/docs/sem_2/UC9_ManageLobby.md "Use Case 9: Manage Lobby"
[uc lobbyviz]: https://github.com/Haus4/NeCo/blob/develop/docs/sem_2/UC10_VisualizeLobby.md "Use Case 10: Visualize Lobby"

<!--
[uc share files]: <link einfügen> "Use Case 3: Share files with another User"
[uc manage profile]: <link einfügen> "Use Case 5: Manage profile informations"
[uc manage friendlist]: <link einfügen> "Use Case 6: Manage friends in friendlist"
[uc get points]: <link einfügen> "Use Case 7: Get Points for using the app"
[uc manage chatrooms]: <link einfügen> "Use Case 8: Manage chatrooms"
[uc name moderator]: <link einfügen> "Use Case 9: Name a moderator"
[uc kick user]: <link einfügen> "Use Case 10: Kick/Ban an user"
[uc delete message]: <link einfügen> "Use Case 11: Delete a message"

-->

[blog]: https://necoproject.wordpress.com/ "Neco Blog"
[github]: https://github.com/Haus4/NeCo "Sourcecode hosted at Github"

<!--

[presentation]: <link einfügen> "Final project presentation"
[installation guide]: <link einfügen> "Android App Installation Guide"

-->

<!-- Picture-Link definitions: -->
[OUCD]: https://raw.githubusercontent.com/Haus4/NeCo/develop/docs/img/UseCaseDiagramm.jpg "Overall Use Case Diagram"

[OUCD2]: https://raw.githubusercontent.com/Haus4/NeCo/develop/docs/img/UseCaseDiagramm_2nd.jpg "Overall Use Case Diagram"

<!--

[deployment diagram]: <link einfügen> "Deployment diagram, shows all modules and the relations between them"
[ci lifecycle]: <link einfügen> "Continuous Integration process"

-->

