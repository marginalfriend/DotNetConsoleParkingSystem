# Parking System Documentation

## Overview

The parking system is designed to manage parking slots for small cars and motorcycles using a console-based interface. Each vehicle is allocated one slot, and the system tracks vehicle details such as registration number, color, and type. The system supports various commands for parking, checking out, and generating reports.

## Commands and Usage

### Setup

Initialize the parking lot with a specified number of slots:

```
$ create_parking_lot <number_of_slots>
```
Example:
```
$ create_parking_lot 6
Created a parking lot with 6 slots
```

### Parking

Park a vehicle in the next available slot:

```
$ park <registration_number> <color> <vehicle_type>
```
Example:
```
$ park B-1234-XYZ White Car
Allocated slot number: 1
```

### Checking Out

Free up a slot upon vehicle checkout:

```
$ leave <slot_number>
```
Example:
```
$ leave 4
Slot number 4 is free
```

### Status Report

Display the current status of all parking slots:

```
$ status
```
Example:
```
$ status
Slot    No.         Type    Registration No Colour
1       B-1234-XYZ  Car     White
2       B-9999-XYZ  Bike    White
3       D-0001-HIJ  Car     Black
5       B-2701-XXX  Car     Blue
6       B-3141-ZZZ  Bike    Black
```

### Reports

Generate various reports based on specific criteria:

- Count of vehicles by type:
  ```
  $ type_of_vehicles <vehicle_type>
  ```
- List registration numbers based on odd/even criteria:
  ```
  $ registration_numbers_for_vehicles_with_ood_plate
  $ registration_numbers_for_vehicles_with_even_plate
  ```
- List registration numbers by color:
  ```
  $ registration_numbers_for_vehicles_with_colour <color>
  ```
- List slot numbers by color:
  ```
  $ slot_numbers_for_vehicles_with_colour <color>
  ```
- Find slot number by registration number:
  ```
  $ slot_number_for_registration_number <registration_number>
  ```

### Exiting the Program

Terminate the program execution:
```
$ exit
```

## Example Workflow

```
$ create_parking_lot 6
Created a parking lot with 6 slots

$ park B-1234-XYZ White Car
Allocated slot number: 1

$ park B-9999-XYZ White Bike
Allocated slot number: 2

$ status
Slot    No.         Type    Registration No Colour
1       B-1234-XYZ  Car     White
2       B-9999-XYZ  Bike    White

$ leave 1
Slot number 1 is free

$ park D-0001-HIJ Black Car
Allocated slot number: 1

$ type_of_vehicles Car
2

$ registration_numbers_for_vehicles_with_colour White
B-1234-XYZ, B-9999-XYZ

$ slot_number_for_registration_number B-9999-XYZ
2

$ exit
```