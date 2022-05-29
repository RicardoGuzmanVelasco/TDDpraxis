### Basic API
- [ ]  Range is created from Factory Methods
  - [X]  Lower & Upper bounds
  - [ ]  Just lower bounds: `.GreaterThan(int)`, `.From(int)`
    - [ ]  Rename `.From(int, int)`???
  - [ ]  Just upper bounds: `.UpTo(int)`, `.To(int)`

- [X]  Distance
  - [X]  Rename to Length!
  
- [X]  Operators
  - [X]  Equality, inequality
    - [X]  Equals(object)
  - [X]  Order

- [ ]  Range-relative operations
  - [X]  Includes (also with a number)
  - [ ]  Overlaps
  - [ ]  Touches
    - Difference with Overlaps?
  - [ ]  Gap
  - [ ]  Abut
    - That is: a range does not overlaps an empty range
  - [https://martinfowler.com/eaaDev/Range.html](https://martinfowler.com/eaaDev/Range.html)

### Further API

- [ ]  Generic Range<T>?

- T is any type with order relation (<, >, <=, >=)
  - Not so obvious implementation, neither so generic chance.
- [ ]  Open/Closed edges? Like numeric intervals.

- Is the same Range type, or other Interval type?
- Edge emerges as a type??? Smart design!
  - [ ]  ToStrings are really graceful to implement this way
- [ ]  Continuous as opposed to discrete?
- [ ]  Whether or not implicit conversion from/to tuples?



### Control cases

- [X]  Min greater than max

### Special cases

- [X]  Empty range
- [X]  Zero range, which is empty

### Refactoring

### Documentation

- [ ]  Numeric intervals domain UML
- [ ]  Vocabulary choosing
