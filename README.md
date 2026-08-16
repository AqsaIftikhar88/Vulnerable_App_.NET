# WebApplication1

## 📌 Project Description

This is a web application developed using ASP.NET WebForms. It includes features such as user registration, login functionality, user pages, and an admin panel.

The application was initially developed to fulfill the basic functional requirements. Security vulnerabilities were not the primary focus during the initial development phase.

After completing the basic application, I used my penetration testing knowledge to assess the application for common web application vulnerabilities. During the assessment, I identified several security issues and then implemented remediation measures to improve the security of the application.

---

## 🛠️ Technologies Used

* ASP.NET WebForms
* C#
* HTML
* CSS
* JavaScript
* SQL Server

## ⚙️ Requirements

* Visual Studio 2022
* .NET Framework 4.7.2
* SQL Server

---

## 🚀 How to Run the Project

1. Clone the repository:

```bash
git clone https://github.com/yourusername/WebApplication1.git
```

2. Open the project in Visual Studio 2022.

3. Restore NuGet packages if required.

4. Configure the database:

   * Import the provided `database.sql` file into SQL Server.
   * Update the connection string in `web.config` according to your local SQL Server configuration.

5. Run the application by pressing **F5** in Visual Studio.

---

## 🗄️ Database Setup

The application uses Microsoft SQL Server.

A database script is provided in the repository as:

```text
database.sql
```

Import the script into SQL Server and update the connection string in `web.config` according to your local environment.

---

# 🔐 Vulnerabilities Identified & Remediation

The following vulnerabilities were identified during the security assessment of the application.

The application was tested in a controlled local environment. For each vulnerability, the repository provides information about the issue, its impact, evidence, and the corresponding remediation.

> **Disclaimer:** This project is intended for educational purposes and to demonstrate secure web application development. The testing and reproduction steps are intended only for the included application running in a controlled environment. Do not test these techniques against applications or systems without proper authorization.

---

## 1. Broken Access Control

### Description

During the application assessment, I identified a Broken Access Control issue. The application contains different pages, including the home page, login page, user pages, and an admin page. Access to protected functionality is expected to require proper authentication and authorization. However, the administrative page could be accessed directly through its URL without first performing the required authorization checks.

### How to Reproduce

Run the application locally and access the home page:

```text
https://localhost:44325/home.aspx
```

Then directly access:

```text
https://localhost:44325/admin.aspx
```

The application allows the administrative page to be reached directly instead of properly enforcing authorization.

### POC

<img width="975" height="513" alt="image" src="https://github.com/user-attachments/assets/5546408b-5823-4964-8617-eca62c58a81c" />

### Remediation

<img width="975" height="424" alt="image" src="https://github.com/user-attachments/assets/dfa866ff-61f3-4a66-8a36-d24dcdf304af" />

---

## 2. Stored Cross-Site Scripting (XSS)

### Description

During the initial development of the application, security against XSS was not specifically considered. I tested whether user-controlled input was safely handled when creating a new account. A test XSS payload was entered as a username and stored by the application. When the stored username was later displayed, the input was interpreted as HTML/JavaScript instead of being safely encoded.

### How to Reproduce

1. Open the registration page in the local application.
2. Enter a test XSS payload in the username field.
3. Create the account.
4. Log in or navigate to a page where the username is displayed.
5. Observe how the stored input is rendered.

### POC

<img width="975" height="510" alt="image" src="https://github.com/user-attachments/assets/a5f3ebee-461a-43a7-b522-1c8f22706030" />
<img width="975" height="513" alt="image" src="https://github.com/user-attachments/assets/c286a515-e233-4f5b-a8bd-2a2f4ea76961" />

### Remediation

Implement strict input validation mechanisms to ensure that user-generated content is properly sanitized.

---

## 3. Boolean-Based SQL Injection

### Description

During the application security assessment, I identified a SQL Injection vulnerability in the login functionality. The issue was caused by improper handling of user input when constructing SQL queries. The application's authentication functionality was tested with SQL Injection inputs to determine whether user input could alter the intended SQL query logic.

### How to Reproduce

1. Open the application's login page.
2. Enter a test SQL Injection input into the appropriate input field.
3. Submit the login request.
4. Observe whether the application's authentication logic behaves differently from a normal login attempt.

### POC

<img width="975" height="505" alt="image" src="https://github.com/user-attachments/assets/5122050d-7f46-4867-b9cf-977d5f6ef363" />
<img width="975" height="512" alt="image" src="https://github.com/user-attachments/assets/103b9854-8cdc-43cf-824b-7137c8a6599a" />


### Remediation

<img width="975" height="426" alt="image" src="https://github.com/user-attachments/assets/0f4b21ee-5a9f-4e85-a6f5-4c16997d5691" />
The application should use **parameterized SQL queries** instead of directly concatenating user input into SQL statements.
Parameterized queries separate SQL commands from user-supplied data and significantly reduce the risk of SQL Injection.

---

## 4. Username Enumeration

### Description

During the authentication assessment, I identified a username enumeration issue. The application returned different error messages depending on whether the submitted username existed. For example, when a valid username was submitted with an incorrect password, the application returned a message indicating that the password was incorrect. However, when an invalid username was submitted, the application returned a different message indicating invalid credentials.
This difference in responses can help an attacker determine whether a username exists.

### How to Reproduce

1. Open the login page.
2. Enter a known/valid username with an incorrect password.
3. Observe the response Invalid credentials. 
5. Enter an invalid username with an incorrect password.
6. The responses is Invalid Password. 

If the responses are different, the application may disclose whether the username exists.

### POC

Username enumeration can help an attacker identify valid accounts and make subsequent password attacks more targeted.
<img width="975" height="468" alt="image" src="https://github.com/user-attachments/assets/5202efd2-db6d-4017-afb0-65e94a7f8ba5" />
<img width="975" height="483" alt="image" src="https://github.com/user-attachments/assets/80c6df8f-e54e-4813-afd5-4acf8c0fb935" />
<img width="975" height="476" alt="image" src="https://github.com/user-attachments/assets/a1f1ad3e-9ba0-4b7e-88a0-722f265fb19e" />
<img width="975" height="511" alt="image" src="https://github.com/user-attachments/assets/0e9bb0f4-3d88-4c28-a92d-ded527d1299e" />


### Remediation

The application should return a generic authentication error for both invalid usernames and incorrect passwords.


---

# 🛡️ Security Remediation

The purpose of this project was not only to identify vulnerabilities but also to understand how secure coding practices can be applied to remediate them.

The application therefore demonstrates the following approach:

```text
Initial Application
        ↓
Security Assessment
        ↓
Vulnerability Identification
        ↓
Evidence / Reproduction
        ↓
Impact Analysis
        ↓
Remediation
        ↓
Improved Application
```

The remediation changes are documented in the relevant application code and comments where applicable.

---

# 📚 What I Learned

This project helped me understand that developing an application according to functional requirements is not enough.

An application can work correctly from a functional perspective and still contain serious security weaknesses.

During this project, I learned the importance of considering security throughout the development lifecycle rather than treating security as a final step.

As I was learning penetration testing, testing my own application helped me understand vulnerabilities from both perspectives:

* **Developer perspective:** How an application is built.
* **Security perspective:** How the application's implementation can be tested for weaknesses.

This experience helped me understand the importance of secure coding practices and security testing when developing web applications.

---

## 👩‍💻 Developed by

**Engr. Aqsa Iftikhar**
