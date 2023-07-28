# About

Implementation of generic reservation domain.

## Problem

Imagine that you need a system that allows you to select and book a particular table in a restaurant, or a particular hairdresser in a hair salon, or perhaps a seat in a cinema.

Crushing domain with event storming:

![alt text](https://github.com/pszarzec/reservation-domain/blob/main/images/es_big_picture_1.jpg)

![alt text](https://github.com/pszarzec/reservation-domain/blob/main/images/es_big_picture_2.jpg)

![alt text](https://github.com/pszarzec/reservation-domain/blob/main/images/es_big_picture_3.jpg)

### Identified invariants:
- A resource cannot have multiple reservations at the same time.
- A customer can only have one reservation at the same time.
- The capacity of the resource cannot be exceeded - e.g. number of people on a reservation == table size.


### Ubiquitous language
|   Generic   | Resturants  |   Cinema    | Hairdresser |
|:-----------:|:-----------:|:-----------:|:-----------:|
|  Resource   |    Table    |    Seat     | Hairdresser |
| Reservation | Reservation | Reservation | Reservation |
|  Customer   |    Guest    |  Customer   |   Client    |

# Remarks

- I don't use full project naming type here: `ProjectName.Reservations...` or `PN.Reservations...` to keep it simple and maximise re-usability.

- Error handling is achieved by throwing domain exceptions(e.g. wrong reservation time, or too many people).

## What is missing from the solution at the moment:
- Domain events handling - in that case best option will be return them from each aggregate action.
- Application Services - there is only one case covered.
- Handling multi vendors(Restaurants) of Resources and multi-tenancy approach.
- Persistence layer. Domain use strongly-typed ID in order to use them in EF Core will be a need to implement custom ValueConverter and use them by fluent API in EF. 
- Interface where user can choose spots and make reservations.