# Database project 2022 - Take away application 

> :warning: **React project containing the client is not finished so it is advised to use Postman instead to test the different endpoints**

#### Made by: ####

* Lukas Bang-Stoltz Andersen, cph-ls369@cphbusiness.dk
* Sebastian Godsk Hansen, cph-sh497@cphbusiness.dk 
* Phillip Thomas Isenborg Andersen, cph-pa124@cphbusiness.dk


### Setup

**Step 1: Run the script to start the application**

The file is located in the root called *StartApplication.sh* as shown below in the directory tree:

```
├── Application
├── Docker
├── React
├── README.md
├── StartApplication.sh
```


> :warning: Make sure that you have no instances of a postgres, mongo, redis og neo4j docker running and these ports should available and docker should be installed on your local machine:
> 
> * https://localhost:5001 for Api gateway
> * https://localhost:5002 for Mongo Api
> * https://localhost:5003 for Neo4J Api
> * https://localhost:5004 for Postgres Api
> * https://localhost:5005 for Identity server

 NOTE: it will approximately take 2 minutes

**Step 2: Run the test data endpoint if needed**

We have made a endpoint setting up test data for orders in mongoDB if needed which is located at the following URI:

*https://localhost:5001/Gateway/test-data*












