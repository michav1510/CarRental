# CarRental

This is a rest API using **ASP.Net Core 3.1**.

This API simulates basic tasks of a car rental shop.

There are two basic tasks:

  * The delivery of the car 
  * The return of the car.

About the delivery of the car to the customer there are some details that must be recorded : 
* Id : This is the Id of the delivery and it works like, lets say, the reservation number of an airplane ticket.
* Registration Number : This is the registration number of the customer in the car rental shop.
* Customer's Social Security Number : It is needed for the rental of the car.
* Vehicle category : There are, currently, three types of cars(**Small Car, Hatchback, Truck**). 
* Date and time of delivery : The current date and time is mandatory to calculate the charges of the car rental.
* Current meter position on the car (km) : It is also mandatory to calculate the charges for some types of cars.


