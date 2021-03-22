# customer-order-api

## Tech Stack:
C#, ASP.Net Core Web Api, EF Core, Swagger, Flurl, nUnit, Moq

## How to run:

1) Fork and download the code

2) Open the solution in Visual Studio

3) Build & Run the solution

4) It should open Swagger UI, which can be used to send requests to the API


## Before moving to production, below should be looked into,

1) Add more validations

2) Add more unit tests

3) Add Authentication / Authorization

4) Move the DB connection string and Api Key away from the config file

5) Update log provider and set logging, monitoring & diagnostics

6) Add docker support

## Specification Improvements

1) Request parameters
  * Rename user to email 
  * Only one unique user id is sufficient 
  
2) Customer Details Api key should be posted with request header instead of query string

3) The first restriction, "Where the user's email address does not match the customer number, you should treat this as an invalid request", doesn't seem correct. The email    address and customer id are different types and store different data, so not possible to compare them. It should be updated to match either email addresses or customer ids instead.
