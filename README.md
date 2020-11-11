# CarRental

This is a rest API using **ASP.Net Core 3.1**.

## In a few words

This API simulates basic tasks of a car rental shop.

There are two basic tasks:

  * The delivery of the car 
  * The return of the car.

About the delivery of the car to the customer there are some details that must be recorded : 
* Id : This is the Id of the delivery and it works like, lets say, the reservation number of an airplane ticket. It identifies 
uniquely the delivery of the car.
* Registration Number : This is the registration number of the customer in the car rental shop.
* Customer's Social Security Number : It is needed for the rental of the car.
* Vehicle category : There are, currently, three types of cars(**Small Car, Hatchback, Truck**). 
* Date and time of delivery : The current date and time is mandatory to calculate the charges of the car rental.
* Current meter position on the car (km) at delivery time: It is also mandatory to calculate the charges for some types of cars.

About the return of the car to the car rental shop the details recorded are the following:
* Id : The Id is the same with the deliverys Id.
* Date and time of return : In combination with date and time of delivery, it is usefull to calculate charges.
* Current meter position on the car (km) at return time: As the date and time this is also usefull to calculate charges.

## Implementation
I modeled the 


## Example of usage


