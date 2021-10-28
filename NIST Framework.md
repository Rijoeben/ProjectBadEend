<div align="center">
  <img src="https://fedvte.usalearning.gov/publiccourses/critical101/graphics/FedVTE_CriticalInfrastructure_p20.png">
  <br><br>
  <h1><b>🔐 NIST Cyber Security Framework 🔐</b></h1>
</div>

<h2><b><u>Abstract</u></b></h2>
<p>
This document serves as an explanation of the NIST Cybersecurity Framework in context with our project. It will explore all subjects of the 5 pillars of said Framework, namely: Identify, Protect, Detect, Respond, Recover. Explanations will be given and whether or not it will (and / or can) be implemented in our project.
</p>
<br>
<h2><b><u>Project Introduction</u></b></h2>
<p>
Project “Badeend” consists of a Twitter- esque platform where users can post text, images and other media on a once-a-day basis. Users can follow other users, like posts and other actions to improve connectivity. 

The NIST Cybersecurity Framework helps us as a ‘business’ better understand, manage, and reduce cybersecurity risks and protect our core business processes. This framework is not mandatory, but is simply a guide or suggestion any person or enterprise can follow, on their own volition. This framework gives us an outline of best practices to help us decide where to focus our time for cybersecurity protection.

Our project consists solely of a backend platform, so not all aspects of the framework can or will be implemented. 
</p>
<br>
<h2><b><u>The Framework</u></b></h2>
<h3><b>IDENTIFY</b></h3>

> **Asset Management**
* MongoDB (NoSQL)
* LiteDB (NoSQL → Relational Database)
* API's
* Hosting

There are no physical assets we need to manage, as every aspect of the project is software based. We will be using a third-party hosting platform to serve our project, as it is easier and cheaper than hosting it ourselves. Multiple databases are used to collect data needed for our functionality.

APIs are used to enable communication with our project without the need of a front- end.
<br><br>

> **Business environment**

We aim to develop a next-Gen Social media platform for users to connect with the world in a new and original way. 
<br><br>

> **Risk assessment**

* DDoS
* XSS
* NoSQL Injection
* Authentication Brute force
* Power outage
* Problems at hosting platform
<br><br>

> **Risk management strategy**

As we host our databases and API not by ourselves, we search for a host that can guarantee good uptime percentages and anti DDoS protection. As far as other vulnerabilities go, like XSS and NoSQL injection, we implement some sort of methods to validate the input of data that will be sent to the database to prevent these kinds of attacks. We also will be having a backup system that is running on the same patch at the same time somewhere else, so when the first server goes down, we can immediately switch to our backup server.
<br><br>

<h3><b>PROTECT</b></h3>

> **Access control**

As there is no front- end, no user accounts can be made. Therefore, we will manually insert some account details in the database. User passwords will be encrypted with the SHA256 algorithm, and salted. This is to ensure no data can be stolen, and if the case it is, not (easily) decipherable.

There is no physical access as we do not have any physical components for our project. 

We will be setting up multiple APIs to communicate with our services, and we will implement some basic permission system where users have to verify their identity when performing certain tasks or calls to the APIs.
<br><br>

> **Awareness and training**

As every employee of our fictional company is a student at Thomas More, and we all had a hand in developing the system ourselves, there is still a need to have a discussion about what the vulnerabilities are in our system. It is beneficial to the project to have a dialog even though we are students Information management & security.
<br><br>

> **Data security**

Every call to our APIs, and every response given is managed through HTTPS. We must ensure users can safely access their data within our platform. Everything is hosted on a third party provider, which gives us high availability. 

The development of new processes and features happen locally, and when completed will be transferred over to our hosting environment where it goes ‘live’.
<br><br>

> **Information protection processes and procedures**

Our project and team is not big enough to implement a real system development life cycle, but we do try to divide between data management and security. We have 3 students working on the data aspect of our project, and 2 on the securing of the newly added functionality of the data students.

Due to the fact that we use GitHub to store our project, backups are naturally made.

Our project is not a production app so disaster recovery strategies are not necessary and business continuity is not a focus. We however will try to make sure our application works as expected with the least amount of vulnerabilities and problems in the end product. 
<br><br>

> **Maintenance**

Maintenance is not needed as there are no organizational assets in need of maintenance.
<br><br>

> **Protective Technology**

We do not need asset protecting policies as our project is hosted on a third-party platform, in which case most of these policies are the responsibility of the third party.
<br><br>

<h3><b>DETECT</b></h3>

> **Security continuous monitoring**

Via access management, we can set permission on what a user can and cannot do with his or her account. When an admin or any other privileged user logs in, all their activities will be logged and monitored.

No personnel activity needs monitoring as there are no threat actors in our group (as far as I am aware).

Malicious code is less of a threat as there is little room for code to be injected into our system. The only path in and out of our system are the APIs, which will be monitored and verified for correct input and no malicious intent.
<br><br>

<h3><b>RESPOND</b></h3>

> **Response planning**

Our project is not suitable for production, so we do not really need a response plan in the case of an emergency, a threat or a breach.
<br><br>

<h3><b>RECOVER</b></h3>

> **Recovery Planning**

Running two similar instances of our project at two different servers, when the main server goes down, we can use the second while we try and fix the main server. Creating backups on a regular basis is also a good thing to do, this way we cannot lose any data, and we keep being compliant with GDPR.
<br><br>

> **Improvements**

We take a meeting together and think about new security features we can implement to prevent the same kind of events from happening in the future.
<br><br>

> **Communications**

No public relations (except with our teachers) need to be managed. There are no real external parties that require communication. 

Reputation is also not a concern.
<br><br>

- - - -
