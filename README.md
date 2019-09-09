# GeometryKit

## Version

Current version is 0.1.

That means that the library is in process of development and it may be changed a lot. Of course classes and strucures of geometry primitives will not be changed a lot but the structure of the

## License

The library is distributed under MIT license.

## What is it and why

GeometryKit is a library which contains geometry tools for .NET

This library was made because of a few reasons:
- to get geometry tools for my own .NET projects
- to make more mathematical geometry tools than existing libraries
- perhaps it will be used as a prototype for C++ geomery library

I see no reason to hide it and I share it with the community.

### "More mathematical"

Many geometry libraries have been designed for specific tasks like 3D or 2D graphics, thus:
- many of them have not some important mathematical entities and operations. For example, some of them have even no vector multiplication of 3D vectors :confused:
- many of them have excess entities which are useful for the specific tasks
- many geometry tool have specific naming policy and some entities are not obviously named

## Current state

All entities use double type for numbers and calculations. Almost all comparisons use Epsylon for comparison of float values except strict comparisons. But strict comparisons have specific names like **IsStrictlyEqualTo**

Let's look at some entities in the library.

### Angle

The structure describes angles. It has only one field: Radians - double float point number which contains amount of radians in the angle. This field is public and may be freely changed.
The structure has many methods which allow:

- to get angles in degrees and grads (gradians), converts radians, degrees and grads to each other (a grad (gradian) is 1/400 of a full round like a degree is a 1/360 of a full round).
- to normalize angles in ranges from 0 to 2xPi or from -Pi to Pi
- to use arithmetic operations with angles like ```2 * myAngle + 10``` and it will be an Angle too
- to compare two Angles
- to get values of trigonometric functions of an Angle
- to use it for turning of 2D vetrors and building turn matrixes

### Vector2 

This structure describes 2D vectors. There are two fields: x and y coordinates.
You can:

- calculate module of a vector
- get scalar multiplication of two vector
- get the angle between two vectors or an angle between a vector and a line
- normalize a vector
- check is a vector a zero vector
- check is a vector parallel or orthogonal to another vector or to some kind of line
- use arithmetic operations with vectors like ```a + b / 2 - 5 * c```

### Vector3

This structure describes 3D vectors. There are there fields: x, y and z coordinates.
You can do same things like you can do with 2D vectors but also you can:

- calculate vector multiplication of two vectors
- get the angle between a vectors a plane
- check is a vector parallel or orthogonal to a plane

## My plans

- Cover more code with unit test
- Add documentation
- Add project files for different platforms
- Add more functionality to the library

And perhaps it will be transformed into mathematical library which will consist for serveral .NET projects with minimum dependencies.
