# Answers

## Please describe the differences between IAAS, PAAS and SAAS and give examples of each in a cloud platform of your choosing?

---

## 🔧 IaaS (Infrastructure as a Service)
- **Definition:** Provides virtualized infrastructure resources (compute, storage, networking).  
- **Use Case:** Ideal when you want control over the OS and applications but don’t want to buy physical hardware.  
- **Azure Example:**  
  - **Azure Virtual Machines** → lets you spin up Windows/Linux VMs on demand.  
  - **Azure Storage** → scalable cloud storage for files, blobs, and queues.  

---

## 🛠️ PaaS (Platform as a Service)
- **Definition:** Provides a managed platform for building, testing, and deploying applications.  
- **Use Case:** Best for developers who want to focus on coding without worrying about servers, patching, or scaling.  
- **Azure Example:**  
  - **Azure App Service** → host web apps and APIs with auto-scaling and built-in CI/CD.  
  - **Azure Functions** → serverless compute for event-driven apps.  

---

## 📦 SaaS (Software as a Service)
- **Definition:** Delivers complete applications over the internet.  
- **Use Case:** End-users simply log in and use the software; no installation or maintenance required.  
- **Azure/Microsoft Example:**  
  - **Microsoft 365** → Word, Excel, Outlook, Teams delivered as cloud apps.  
  - **Dynamics 365** → CRM and ERP applications for business management.  

---

## What are the considerations of a build or buy decision when planning and choosing software?
When deciding whether to build or buy software, organizations must weigh factors like cost, time-to-market, customization, scalability, vendor support, integration, and long-term maintenance. Building offers control and flexibility but requires more resources, while buying provides speed and proven reliability but may limit customization.

## What are the foundational elements and considerations when developing a serverless architecture? 
The foundational elements of serverless architecture include event-driven functions, stateless execution, managed infrastructure, and pay-per-use pricing. Key considerations are scalability, cold starts, vendor lock-in, monitoring, security, and integration with existing systems.

## Please describe the concept of composition over inheritance 
This is an object-oriented design principal that favors building classes by combining smaller, reusable components (composition) instead of relying on rigid class hierarchies (inheritance). It promotes flexibility, loose coupling, and easier maintenance.

## Describe a design pattern you’ve used in production code. What was the pattern? How did you use it? Given the same problem how would you modify your approach based on your experience?
I have used the Singleton design pattern to establish a connection to a database on startup. A sealed class that was thread safe and had a manager that would accept the connection string and determine if the instance was already created and return it otherwise it would open a lock, create a new connection and close the lock. This connection would then be used when code needed to interact with the database. I don't think I would change this approach because it provides a clean way to establish a database connection and had logic internally to reopen if the connection was not in an open state.

 



