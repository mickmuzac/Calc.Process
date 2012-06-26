#Calc.Process

##Introduction

Calc.Process is a very simple to use calculus calculator made to test the laws of mathematics. I do plan on adding visualization and expanding functionality to it over time.

A few bugs will be fixed, including a generic function bug. Updates to the InputParser class (to support generic functions) will also be included.

##Features

Because Calc.Process is in its very early stages, its feature set is currently very limited. It can integrate basic functions of any length (time taken depends on your processor's speed). It can also find the derivative of those functions. Generic function support is currently in progress and should be completed very soon.

* Unlimited generic functions: supports any function in System.Math that accepts and returns a single double value.
* Unlimited terms in any given function.
* Multithreaded support for superior performance.
* Calculates both the definite integral value and derivative value at any given x.
* More features coming soon!

##Major Changes
* 6/22/2012 - Major update including anti-aliasing, support to save png images, derivative line, bug fixes, and better color choices. Generic Math functions and trig functions are supported, but the parsing of those functions is still unsupported.

* 6/13/2012 - Added multithreading support resulting in a speed up of about 3-4x on average. Works very well with small dx or large function values.

* 6/11/2012 - Initial working addition of generic functions. Still needs to be parsed.

* 6/08/2012 - Migrated from C to C#. Derivative functionality added and is now working flawlessly. Work started on generic functions.

* 6/06/2012 - Initial commit. Project resurrected from the dead.
