# Checkout Payment Gateway
_Author: Andy Davies._

#### Steps to use (pretty straightforward):
1. Clone Repo.
2. Run Checkout.PaymentGateway.Api
3. Use postman to test the endpoints.
4. I have added test postman script for POST and GET. See cko-gateway/CheckoutGatewayAPI.postman_collection.json.
5. First run POST, fetch the returned ID, and use this in the GET path to retrieve its details.

#### Random points of interest
* Pretty simple [n-tier](https://docs.microsoft.com/en-us/azure/architecture/guide/architecture-styles/n-tier) architecture pattern.
  * Controller => Service Layer => Data Access Layer.
  * No time to implement any fancing CQRS/event sourcing/proper DDD aggregate stuff.
  * Have focused on writing simple, clean easy to read code.
* Utilising custom model validators for currency code & expiry year.
  * Utilising "ISO.\_4217" nuget package as it looked sufficient to validate currency code
* Store Card & Payment information as seperate entities (if we want to retrieve card details independently)
* Generic repository pattern used for Card & Payment repositories, reduces code duplication for this simple use case.

#### How this would be hosted in real-world
* Hosting / system design was covered in my previous interview.
* Cloud hosting, either as
  * a deployed web app (e.g. Azure app service or AWS equivalent)
  * containerized app (docker etc) i.e. how Checkout actually deploys in the real world.
* As discussed in interview this could be deployed behind a load balancer and have multiple instances running.
  * i.e. could have more instances deployed to handle POST and fewer instances deployed to handle GET

#### Limitations of Code/Shortcuts taken. (Given time constraint):
* No auth.
* No logging.
* Low test coverage. I have written a few examples, so you can see how I test/frameworks used etc.
* Have created an in memory repository implementation for quick POC.
  * This is not thread-safe, but sufficient for demo purposes.
* Could definitely do with more validation etc in real world.
* No deduplication of cards when saving to repository.
* **Very** simple Mock Acquring bank implementation, if amount is > 100, return declined result, else return succeeded.
* I have "faked" async behaviour in some places, using Task.Delay etc to mimic these services in the real world.
* I am reusing DTOs between controller and service class, again just to save time. However I have created seperate entity models to store at repoitory layer.
