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
I implement the above tasks with one class with name : **CarRentalRegistration**.

This class has as member variables the following: 
* ```public Guid Id { get; set; }```

The unique identifier of the car rental. It holds for both the delivery of the car and the return. It is like a reservation
number for a round trip.
* ```public long RegistrNum { get; set; }```

This is the registration number of the customer.
* ```public long CustomerSocSecNum { get; set; }```

Customer's social security number.
* ```public VehicleCategory VehicleCat { get; set; }```

Category of vehicle i.e (**Small Car, Hatchback, Truck**) . Notice how the ```VehicleCategory``` is declared below : 
```public enum VehicleCategory
        {
            SmallCar = 1,
            HatchBack = 2,
            Truck = 3
        }
```

So it is very easy to add another category of vehicle in the future if you want. You have to add another enumeration 
and you have also to set the formula of the payment and the new category is ready.
* ```public DateTime DateOfDeli { get; set; } ```

The date and time of the delivery of the car to the customer.
* ```public long KmAtDelivery { get; set; }```

The meter position of the car at the delivery time of the car to the customer.
* ```public DateTime DateOfReturn { get; set; }```

The date and time of the return of the car to the car rental shop. 
* ```public long KmAtReturn { get; set; }```

The meter position of the car at the return time of the car to the car rental shop.
* ```public double Price { get; set; }```

The price paid by the customer το the car rental shop when returns the car.
* ```public bool IsReturned { get; set; } ```

This is an auxiliary variable. It is set as true when the car has returned by the customer, otherwise it is false.

About the ```CarRentalReturn``` class. It is an auxiliary class and it's member variables are a subset of the member variables of the class **CarRentalRegistration**.  It is used to model the json send with ```PUT``` request.

## Example of usage
* Scenario 1 : Customer goes to the car rental shop and asks for a car. The car rental owner asks the client for credentials,
i.e. the social security number and the registration number, and also about what type of car he/she wants. The car rental owner
goes to the car and note the current kilometer position of the car and gives it to the customer. The aforementioned scenario is
a ```POST``` request to the url ends with ```https://localhost:<port>/api/CarRentalRegistrations/``` with the following json example : 
``` 
{
        "registrNum": 435357435897,
        "customerSocSecNum": 192083209,
        "vehicleCat": 1,
        "kmAtDelivery": 151000        
}
```

The json answer to the above ```POST``` request is the following : 
```
{
    "id": "5bab39fd-14cf-4aa3-982b-70fc45cf7aa1",
    "registrNum": 435357435897,
    "customerSocSecNum": 192083209,
    "vehicleCat": 1,
    "dateOfDeli": "2020-11-12T09:45:25.8695752+02:00",
    "kmAtDelivery": 151000,
    "dateOfReturn": "2020-11-12T09:45:25.8695752+02:00",
    "kmAtReturn": 0,
    "price": 0,
    "isReturned": false
}
```
This json shows the ```id``` of the reservation produced, the ```dateOfDeli``` which is the time of the request sent, the ```dateOfReturn``` is
set the same as the ```dateOfDeli```, the ```kmAtReturn``` and ```price``` is set as zero and the ```isReturned``` is set as false.

* Scenario 1 : The owner wants to see all the car rental registrations, the car which are not yet returned and the car has been returned from the day one of the car rental shop. This is done with a ```GET``` request to the ```https://localhost:<port>/api/CarRentalRegistrations/```.

* Scenario 2 : The owner wants to see a specific car rental registration with a specific id. This is done with a ```GET``` request to the url ```https://localhost:<port>/api/CarRentalRegistrations/<id>```.

* Scenario 3 : The ownew wants to delete a car rental registration with a specific id. This is done with a ```DELETE``` request to the url ```https://localhost:<port>/api/CarRentalRegistrations/<id>```.

* Scenario 4 : Customer returns the car to the car rental shop. The owner checks the current meter position and asks the reservation number(id) and the customer pays.
This scenario is a ```PUT``` request with url ```https://localhost:<port>/api/CarRentalRegistrations/<id>``` and the following json example : 
```
{
    "id": "5bab39fd-14cf-4aa3-982b-70fc45cf7aa1",
    "dateOfReturn": "2020-11-13T09:45:25.8695752+02:00",
    "kmAtReturn": 151100
}
```
So the ```id``` is the one that the customer tell the owner, the ```dateOfReturn``` is the date of return and  ```kmAtReturn``` is the meter position of the car at the return. In order to know price you make a ```GET``` request to the url ```https://localhost:<port>/api/CarRentalRegistrations/<id>``` and you will see the following json: 
```
{
    "id": "5bab39fd-14cf-4aa3-982b-70fc45cf7aa1",
    "registrNum": 435357435897,
    "customerSocSecNum": 192083209,
    "vehicleCat": 1,
    "dateOfDeli": "2020-11-12T09:45:25.8695752+02:00",
    "kmAtDelivery": 151000,
    "dateOfReturn": "2020-11-13T09:45:25.8695752+02:00",
    "kmAtReturn": 151100,
    "price": 20,
    "isReturned": true
}
```
Where you can see the ```price``` of the transaction and that now the ```isReturned``` is ```true```.

 * Scenario 5 : If you want to cancel a car rental, you send a ```PUT``` request like the scenario 4 and set the ```dateOfReturn``` equals to the ```dateOfDeli``` and the ```kmAtDelivery``` equals to the ```kmAtReturn```. Then the price is zero and the whole car rental registration state is correct.

* Exceptional scenario 1 : When the customer return the car to the owner, the owner by mistake types another reservation number(id) that corresponds to a previously returned car. Then the ```PUT``` request of the scenario 4 will receive a ```BadRequest``` as a result with the messsage ```The car has been returned before!```.

* Exceptional scenario 2 : When the customer return the car to the owner, the owner by mistake types less kilometer position of the car and this position kilometer is smaller than the one had the car at the delivery time. Then the ```PUT``` request of the scenario 4 will receive ```BadRequest``` as a result with the messsage ```The kilometers at return can't be smaller than delivery time!```.

* Exceptional scenario 3 : When the customer return the car to the owner, the owner by mistake types previous date than the delivery date. Then the ```PUT``` request of the scenario 4 will receive ```BadRequest``` as a result with the messsage ```The date of the return can't be previous than the delivery date!```.

* Exceptional (technical) scenario 4 : When the ```id``` of the ```PUT``` request and the ```id``` inside the url ```https://localhost:<port>/api/CarRentalRegistrations/<id>``` are different then the scenario 4 will receive a ```BadRequest``` as a result with message ```The reservation number implicit given in url is different than the one in the json```
 
 
 ## Tests 
The tests are inside the ```CarRental.UnitTests```. The tests reproduce all the scenarios above and the check all the request, i.e ```GET``` with or with not id given in the url,```POST```,```PUT``` and ```DELETE```. The tests are testing also if the prices are correct for the different types of car and for different rental days and kilometers.

If you want to run the tests you can open a terminal go to the ```CarRental.UnitTests``` folder and type : 

```>>dotnet test```
