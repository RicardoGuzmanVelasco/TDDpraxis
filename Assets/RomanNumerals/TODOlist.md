### Basic API
- [ ] Constructor by int
  - [ ] Implicit from int
- [x] Constructor by string
  - [x] Default I constructor
  - [x] Fails if not a valid symbol
- [x] ToString()
- [x] Implicit from string
- [x] Default is I
- [?] Relation with C# numbers
  - [x] implicit ToInt
  - [ ] implicit FromInt

### Implementations
- [ ] IComparable

### Test API
- [ ] 

### Control cases
- [x] Constructor with no roman symbols
- [ ] Lowers/Uppers letters
- [x] Not supporting [Additive notation](https://en.wikipedia.org/wiki/Roman_numerals#Variant_forms) 
  - [ ] Other additive cases, such as "VVVV"
    * It's implicitly controlled by default since any 4-matching-symbols chain is not supported.
  - [ ] Is MMMM valid?
- [?] Same character cannot appear in different numeral places. Example: XVX, CLC... 

### Common cases 
- [?] Factory Properties for I, V, X, L, C, M
- [x] Individual symbols to ints
- [x] Numeric relations
  - [x] Non substracting numerals to ints
  - [x] Just substracting numerals to ints
  - [x] Mixing numerals to ints

### Special cases
- [ ] [Irregular substractive notation](https://en.wikipedia.org/wiki/Roman_numerals#Irregular_subtractive_notation)

### Refactoring
- [x] Roman symbol as type

### Alternative implementations
- [ ]  
    
### Documentation
- [ ] 
